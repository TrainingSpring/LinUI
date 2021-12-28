using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.JSInterop;


namespace LinUI.Tools
{
    public class Response
    {
        public int? Code { set; get; }
        public object? Data { set; get; } = null;
        public object? ResData { set; get; } = null;
        public string? Message { set; get; }
        public int? ResCode { set; get; }
        public string? ResMessage { set; get; }
        public string toString() => string.Format("ResCode:{0},ResData:{1},ResMessage:{2}",ResCode,ResData,ResMessage);
    }
    public class Request
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public string Host { set; get; } = "";
        public string Path { set; get; } = "";
        [Inject] IJSRuntime JS { set; get; }
        // public static string Host { set; get; } = "http://192.168.86.11:8002/";
        // public static string Path { set; get; } = "api/API/";
        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="api">api名</param>
        /// <param name="value">数据</param>
        /// <returns></returns>
        public async Task<Response> Post(string api,object value = null)
        {
            return await SendData(HttpMethod.Post, api, value);
        }
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="api">api</param>
        /// <param name="value">数据</param>
        /// <returns></returns>
        public async Task<Response> Get(string api,object value = null)
        {
            return await SendData(HttpMethod.Get, api, value);
        }
        /// <summary>
        /// 发送数据
        /// </summary>
        /// <param name="method">请求类型</param>
        /// <param name="api">api</param>
        /// <param name="value">value</param>
        /// <returns></returns>
        public async Task<Response> SendData(HttpMethod method,string api,object value,Dictionary<string,string> header = null)
        {
            
            var req = new HttpRequestMessage(method, Host+Path+api);
            if (header!=null)
            {
                foreach (var dic in header)
                {
                    req.Headers.Add(dic.Key,dic.Value);
                }
            }
            // req.Content.Headers.Add("content-type", "application/json");
            if (value != null)
            {
                if (method == HttpMethod.Get)
                {
                    var param = new List<string>();
                    string param_str;
                    var valProperties = value.GetType().GetProperties();
                    foreach (var propertyInfo in valProperties)
                    {
                        var key = propertyInfo.Name;
                        var val = propertyInfo.GetValue(value);
                        if (val != null)
                        {
                            string p = string.Format("{0}={1}", key, val);
                            param.Add(p);
                        }
                    }
                    param_str = string.Join("&",param);
                    var url = string.Format("{0}{1}{2}?{3}",Host,Path,api,param_str);
                    req =  new HttpRequestMessage(method, url);
                }
                else
                {
                    var content = JsonConvert.SerializeObject(value);
                    Console.WriteLine("SendContent: {0}",content);
                    req.Content = new StringContent(content, Encoding.UTF8, "application/json");  
                }
                
            }
            req.Headers.Add("Accept","*/*");
            req.Headers.Add("User-Agent", "HttpClientFactory-Sample");
            Console.WriteLine("Headers: {0}",req.Headers.ToString());
            var response = await _httpClient.SendAsync(req);
            Response result;
            if (response.IsSuccessStatusCode)
            {
                var str = await response.Content.ReadAsStringAsync();
                try
                {
                    result = JsonConvert.DeserializeObject<Response>(str.ToString(), new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                    
                }
                catch (Exception e)
                {
                    result = new Response{ ResCode = 0 ,ResMessage = e.Message, ResData = str};
                }
            }
            else
            {
                result = new Response{ ResCode = 0, ResData = new {}, ResMessage = "连接错误"};
            }
            
            Console.WriteLine("Response: {0}",result.toString());
            return result;
        }

    }
}
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace LinUI.Tools
{
    public struct ToastOptions
    {
        /// <summary>
        /// 延时时间
        /// </summary>
        public int Delay { set; get; } 
        /// <summary>
        /// 字体大小
        /// </summary>
        public string FontSize { set; get; }
    }

    public interface IToast
    {
        public Task InitToast(ToastOptions options);
        public Task Show(string title);
    }
    public class Toast:IToast
    {
        readonly IJSRuntime JS;
        public ToastOptions Options { set; get; } = new ToastOptions() { Delay = 3000, FontSize = "12px"};

        public Toast(IJSRuntime _js)
        {
            JS = _js;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="options"></param>
        public async Task InitToast(ToastOptions options)
        {
            await JS.InvokeVoidAsync("initToast",options);
        }
        /// <summary>
        /// 显示
        /// </summary>
        public async Task Show(string title)
        {
           await ExecuteCommand("show",title);
        }
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="command"></param>
        /// <param name="arg"></param>
        async Task ExecuteCommand(string command,string arg = null)
        {
            await JS.InvokeVoidAsync("handleComponents","Toast",command,arg);
        }
    }
}
using System;
using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace LinUI.Tools
{
    public struct LoadingOptions
    {
        /// <summary>
        /// 图标
        /// </summary>
        public string icon { get; set; }
        /// <summary>
        /// 提示文字
        /// </summary>
        public string tip { get; set; }
        /// <summary>
        /// 图标大小
        /// </summary>
        public int iconSize { get; set; }
        /// <summary>
        /// 背景颜色
        /// </summary>
        public string bgColor { get; set; }
        /// <summary>
        /// 文字颜色
        /// </summary>
        public string color { get; set; }
        /// <summary>
        /// 图标颜色
        /// </summary>
        public string iconColor { get; set; }
    }
    public interface ILoading
    {
        public Task InitLoading(LoadingOptions options);

        public Task Show();
        public Task Hide();
        public Task CorrectTip(string tip);
        public Task ExecuteCommand(string common,string arg = null);
    }
    public class Loading:ILoading
    { 
        readonly IJSRuntime JS;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_js"></param>
        public Loading(IJSRuntime _js)
        {
            JS = _js;
        }
        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task InitLoading(LoadingOptions options)
        {
            await JS.InvokeVoidAsync("initLoading",options);
        }
        /// <summary>
        /// 显示
        /// </summary>
        public async Task Show()
        {
            await ExecuteCommand("show");
        }

        /// <summary>
        /// 隐蔽
        /// </summary>
        public async Task Hide()
        {
            Console.WriteLine("hide");
            await ExecuteCommand("hide"); 
        }

        /// <summary>
        /// 修改提示文字
        /// </summary>
        /// <param name="tip"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task CorrectTip(string tip)
        {
            if (tip == null) throw new ArgumentNullException(nameof(tip));
            await ExecuteCommand("show",tip);
        }
        /// <summary>
        /// 执行命令
        /// </summary>
        /// <param name="command"></param>
        /// <param name="arg"></param>
        public async Task ExecuteCommand(string command,string arg = null)
        {
            await JS.InvokeVoidAsync("handleComponents",command,arg);
        }
    }
}
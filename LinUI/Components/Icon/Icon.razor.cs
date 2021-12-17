using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
namespace LinUI.Components
{
    public partial class Icon
    {
        /// <summary>
        /// 图标大小
        /// </summary>
        [Parameter]
        public int Size { get; set; } = 12;
        /// <summary>
        /// 图表名称
        /// </summary>
        [Parameter]
        public string Name { get; set; } = "";
        /// <summary>
        /// 图标颜色
        /// </summary>
        [Parameter]
        public string? Color { get; set; }
        /// <summary>
        /// 图标css样式
        /// </summary>
        [Parameter]
        public string? Style { get; set; }
        /// <summary>
        /// 图标的点击事件
        /// </summary>
        [Parameter]
        public EventCallback OnClick { get; set; }
    }
}
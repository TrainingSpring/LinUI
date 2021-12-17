using System.ComponentModel;

namespace LinUI.Data
{
    public enum LinShape
    {
        /// <summary>
        /// 圆形
        /// </summary>
        [Description("circle")]
        Circle,
        /// <summary>
        /// 圆角
        /// </summary>
        [Description("round")]
        Round,
        /// <summary>
        /// 默认方形
        /// </summary>
        [Description("default")]
        Default
    }
}
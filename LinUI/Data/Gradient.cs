using System.ComponentModel;

namespace LinUI.Data
{
    /// <summary>
    /// 渐变色
    /// </summary>
    public static class Gradient
    {
        [DisplayName("魅红")] public static string[] Red { get; } = new string[] { "#f43f3b","#ec008c" };
        [DisplayName("鎏金")] public static string[] Golden { get; } = new string[] { "#ff9700","#ed1c24" };
        [DisplayName("翠柳")] public static string[] Green { get;} = new string[] { "#39b54a","#8dc63f" };
        [DisplayName("靛青")] public static string[] Cyan { get;} = new string[] { "#0081ff","#1cbbb4" };
        [DisplayName("惑紫")] public static string[] Purple { get;} = new string[] { "#9000ff","#5e00ff" };
        [DisplayName("霞彩")] public static string[] Color { get;} = new string[] { "#ec008c","#6739b6" };
    }
}
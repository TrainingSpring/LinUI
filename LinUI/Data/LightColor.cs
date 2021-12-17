using System.ComponentModel;

namespace LinUI.Data
{
    /// <summary>
    /// 浅色
    /// </summary>
    public static class LightColor
    {
        [DisplayName("嫣红")] public static string Red { get;} = "#fadbd9";
        [DisplayName("桔橙")] public static string Orange { get;} = "#fde6d2";
        [DisplayName("明黄")] public static string Yellow { get;} = "rgba(254,242,206,.82)";
        [DisplayName("橄榄")] public static string Olive { get;} = "#e8f4d9";
        [DisplayName("森绿")] public static string Green { get;} = "#d7f0db";
        [DisplayName("天青")] public static string Cyan { get;} = "#d2f1f0";
        [DisplayName("海蓝")] public static string Blue { get;} = "#cce6ff";
        [DisplayName("姹紫")] public static string Purple { get;} = "#e1d7f0";
        [DisplayName("木槿")] public static string Mauve { get;} = "#ebd4ef";
        [DisplayName("桃粉")] public static string Pink { get;} = "#f9d7ea";
        [DisplayName("棕褐")] public static string Brown { get;} = "#ede1d9";
        [DisplayName("玄灰")] public static string Grey { get;} = "#e7ebed";
    }
}
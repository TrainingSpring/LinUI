namespace LinUI.Data
{
    /// <summary>
    /// 按钮类型
    /// </summary>
    public class ColorType
    {
        /// <summary>
        /// 数组中 , 第一个值为背景色
        /// 第二个值为前景色
        /// </summary>
        public static string[] Red { get; } = new string[] { DarkColor.Red,DarkColor.White };
        public static string[] Orange { get; } = new string[] { DarkColor.Orange,DarkColor.White };
        public static string[] Yellow { get; } = new string[] { DarkColor.Yellow,DarkColor.White };
        public static string[] Olive { get; } = new string[] { DarkColor.Olive,DarkColor.White };
        public static string[] Green { get; } = new string[] { DarkColor.Green,DarkColor.White };
        public static string[] Cyan { get; } = new string[] { DarkColor.Cyan,DarkColor.White };
        public static string[] Blue { get; } = new string[] { DarkColor.Blue,DarkColor.White };
        public static string[] Purple { get; } = new string[] { DarkColor.Purple,DarkColor.White };
        public static string[] Mauve { get; } = new string[] { DarkColor.Mauve,DarkColor.White };
        public static string[] Pink { get; } = new string[] { DarkColor.Pink,DarkColor.White };
        public static string[] Brown { get; } = new string[] { DarkColor.Brown,DarkColor.White };
        public static string[] Grey { get; } = new string[] { DarkColor.Grey,DarkColor.White };
        public static string[] Gray { get; } = new string[] { DarkColor.Gray,DarkColor.Black };
        public static string[] Black { get; } = new string[] { DarkColor.Black,DarkColor.White };
        public static string[] White { get; } = new string[] { DarkColor.White,DarkColor.Black };
    }
}
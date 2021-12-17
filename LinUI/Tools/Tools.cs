using System;
using System.ComponentModel;
using System.Reflection;
using LinUI.Data;
namespace LinUI.Tools
{
    public static class Tools
    {
        public static string GetDescriptionToString<TEnum>(this TEnum val) where TEnum : Enum =>
            typeof(TEnum).GetDescriptionToString(val.ToString());
        public static string GetDescriptionToString(this Type? type,string? val)
        {
            var res = string.Empty;
            if (type != null && !string.IsNullOrEmpty(val))
            {
                var t = Nullable.GetUnderlyingType(type) ?? type;
                var attr = t.GetField(val)?.GetCustomAttribute<DescriptionAttribute>(true);
                res = attr?.Description??val;
            }
            return res;
        }
    }
}
using System.ComponentModel;

namespace LinUI.Components
{
    public enum InputType
    {
        [Description("text")]
        Text,
        [Description("number")]
        Number,
        [Description("password")]
        Password,
    }
}
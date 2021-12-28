using System.ComponentModel;

namespace LinUI.Components
{
    public enum ButtonType
    {
        [Description("upload")]
        Upload,
        [Description("camera")]
        Camara,
        [Description("video")]
        Video,
        [Description("default")]
        Default
    }
}
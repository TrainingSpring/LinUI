namespace LinUI.Data
{
    public class CheckBoxConfig
    {
        public string Name { set; get; }
        public bool Value { set; get; } = false;
    }
    public class CheckBoxConfig<T>
    {
        public string Name { set; get; }
        public T? Other { set; get; }
        public bool Value { set; get; } = false;
    }
}
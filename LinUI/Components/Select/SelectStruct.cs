using System.Collections.Generic;

namespace LinUI.Components
{
    public class SelectData
    {
        public string id { set; get; }
        public string value { set; get; }
        public List<SelectData> childs { set; get; } = new List<SelectData>();
    }
    public class SelectData<T>
    {
        public string id { set; get; }
        public string value { set; get; }
        public T? other { set; get; }
        public List<SelectData<T>> childs { set; get; } = new List<SelectData<T>>();
    }
    public class SelectStruct<T>
    {
        public List<T> data;
    }
}
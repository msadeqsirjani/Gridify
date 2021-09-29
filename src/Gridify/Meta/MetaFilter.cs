namespace Gridify.Meta
{
    public class MetaFilter : IMeta
    {
        public string Operator { get; set; }

        public string DataType { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Assembly { get; set; }

        public string Fullname { get; set; }

        public string GetName() => "Filter";
    }
}

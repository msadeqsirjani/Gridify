namespace Gridify.Filter
{
    public class Filter
    {
        public FilterOperators Operator { get; set; }

        public DataType DataType { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Assembly { get; set; }

        public string Fullname { get; set; }
    }
}

namespace Gridify.Filter
{
    public class Filter
    {
        public Operators Operator { get; set; }

        public DataType DataType { get; set; }

        public string Key { get; set; }

        public string Value { get; set; }

        public string Assembly { get; set; }

        public string Fullname { get; set; }
    }
}

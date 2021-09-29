using Gridify.Filter;

namespace Gridify.Schema
{
    public class FilterResponse : IFilter
    {
        public FilterOperators Operator { get; set; }
        public FilterDataTypes DataType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Assembly { get; set; }
        public string Fullname { get; set; }
    }
}
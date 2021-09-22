using Fop.Filter;

namespace Fop.Meta
{
    public class MetaFilter : IFilter, IMeta
    {
        public FilterOperators Operator { get; set; }
        public FilterDataTypes DataType { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string Assembly { get; set; }
        public string Fullname { get; set; }
        public string GetName() => "Filter";
    }
}

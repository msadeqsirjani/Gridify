using Gridify.Filter;

namespace Gridify.Meta
{
    public class MetaDataType : IMeta
    {
        public DataType DataType { get; set; }

        public string GetName() => "DataType";
    }
}

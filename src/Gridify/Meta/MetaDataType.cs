namespace Gridify.Meta
{
    public class MetaDataType : IMeta
    {
        public string DataType { get; set; }

        public string GetName() => "DataType";
    }
}

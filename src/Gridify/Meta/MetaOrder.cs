namespace Gridify.Meta
{
    public class MetaOrder : IMeta
    {
        public string OrderBy { get; set; }
        public string Direction { get; set; }

        public string GetName() => "Orders";
    }
}

namespace Gridify.Meta
{
    public class MetaName : IMeta
    {
        public string Name { get; set; }

        public string GetName() => "Name";
    }
}

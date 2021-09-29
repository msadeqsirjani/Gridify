namespace Gridify.Meta
{
    public class MetaEditable : IMeta
    {
        public bool IsEditable { get; set; }

        public string GetName() => "IsEditable";
    }
}
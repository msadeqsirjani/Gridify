namespace Fop.Meta
{
    public class MetaSelectable : IMeta
    {
        public bool IsSelectable { get; set; }

        public string GetName() => "IsSelectable";
    }
}
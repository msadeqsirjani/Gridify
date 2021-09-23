namespace Fop.Meta
{
    public class MetaVisibleDefault : IMeta
    {
        public bool IsVisibleDefault { get; set; }

        public string GetName() => "IsVisibleDefault";
    }
}
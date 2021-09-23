namespace Fop.Meta
{
    public class MetaDetail : IMeta
    {
        public bool IsDetail { get; set; }

        public string GetName() => "IsDetail";
    }
}
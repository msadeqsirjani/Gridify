namespace Gridify.Meta
{
    public class MetaClickable : IMeta
    {
        public bool IsClickable { get; set; }

        public string GetName() => "IsClickable";
    }
}

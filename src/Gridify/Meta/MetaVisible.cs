namespace Gridify.Meta
{
    public class MetaVisible : IMeta
    {
        public bool IsVisible { get; set; }

        public string GetName() => "IsVisible";
    }
}
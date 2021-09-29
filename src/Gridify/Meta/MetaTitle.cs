namespace Gridify.Meta
{
    public class MetaTitle : IMeta
    {
        public string Title { get; set; }

        public string GetName() => "Title";
    }
}
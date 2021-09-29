namespace Gridify.Meta
{
    public class MetaSequence : IMeta
    {
        public int Sequence { get; set; }

        public string GetName() => "Sequence";
    }
}
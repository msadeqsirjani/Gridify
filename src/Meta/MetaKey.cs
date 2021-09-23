namespace Fop.Meta
{
    public class MetaKey : IMeta
    {
        public string GetName() => "IsKey";
    }

    public class MetaVisible : IMeta
    {
        public bool IsVisible { get; set; }

        public string GetName() => "IsVisible";
    }

    public class MetaVisibleDefault : IMeta
    {
        public bool IsVisibleDefault { get; set; }

        public string GetName() => "IsVisibleDefault";
    }

    public class MetaSelectable : IMeta
    {
        public bool IsSelectable { get; set; }

        public string GetName() => "IsSelectable";
    }

    public class MetaEditable : IMeta
    {
        public bool IsEditable { get; set; }

        public string GetName() => "IsEditable";
    }

    public class MetaOrder : IMeta
    {
        public int Order { get; set; }

        public string GetName() => "Order";
    }

    public class MetaDetail : IMeta
    {
        public bool IsDetail { get; set; }

        public string GetName() => "IsDetail";
    }
}

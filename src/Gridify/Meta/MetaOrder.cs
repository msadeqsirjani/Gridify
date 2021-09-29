namespace Gridify.Meta
{
    public class MetaOrder : Order.Order, IMeta
    {
        public string GetName() => "Order";
    }
}

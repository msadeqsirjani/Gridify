using Fop.Order;

namespace Fop.Meta
{
    public class MetaOrder : IOrderList, IMeta
    {
        public string OrderBy { get; }
        public OrderDirection Direction { get; }

        public string GetName() => "Order";
    }
}

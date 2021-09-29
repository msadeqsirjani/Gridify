using Gridify.Order;

namespace Gridify.Meta
{
    public class MetaOrder : IOrderList, IMeta
    {
        public string OrderBy { get; }
        public OrderDirection Direction { get; }

        public string GetName() => "Order";
    }
}

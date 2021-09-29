using Gridify.Order;

namespace Gridify.Meta
{
    public class MetaOrder : OrderList, IMeta
    {
        public string GetName() => "Order";
    }
}

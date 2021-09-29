using Gridify.Order;

namespace Gridify.Schema
{
    public class OrderResponse : IOrderList
    {
        public string OrderBy { get; set; }
        public OrderDirection Direction { get; set; }
    }
}
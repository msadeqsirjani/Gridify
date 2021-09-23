using Fop.Order;

namespace Fop.Schema
{
    public class OrderResponse : IOrderList
    {
        public string OrderBy { get; set; }
        public OrderDirection Direction { get; set; }
    }
}
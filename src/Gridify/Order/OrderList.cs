namespace Gridify.Order
{
    public class OrderList : IOrderList
    {
        public string OrderBy { get; set; }
        public OrderDirection Direction { get; set; }
    }
}

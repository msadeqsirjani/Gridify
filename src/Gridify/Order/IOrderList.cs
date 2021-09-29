namespace Gridify.Order
{
    public interface IOrderList
    {
        string OrderBy { get; }

        OrderDirection Direction { get; }
    }
}

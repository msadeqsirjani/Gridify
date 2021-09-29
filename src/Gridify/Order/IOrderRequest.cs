using System.Collections.Generic;

namespace Gridify.Order
{
    public interface IOrderRequest
    {
        IEnumerable<IOrderList> OrderList { get; set; }
    }
}

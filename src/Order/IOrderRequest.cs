using System.Collections.Generic;

namespace Fop.Order
{
    public interface IOrderRequest
    {
        IEnumerable<IOrderList> OrderList { get; set; }
    }
}

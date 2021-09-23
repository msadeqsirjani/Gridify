using Fop.Filter;
using Fop.Order;
using Fop.Page;
using Fop.Schema;

namespace Fop
{
    public interface IGridRequest : IFilterRequest, IOrderRequest, IPageRequest, ISchemaRequest
    {
    }

    public interface IGridRequest<T> : IGridRequest where T : new()
    {
    }
}

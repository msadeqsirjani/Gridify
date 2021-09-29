using Gridify.Filter;
using Gridify.Order;
using Gridify.Page;
using Gridify.Schema;

namespace Gridify
{
    public interface IGridRequest : IFilterRequest, IOrderRequest, IPageRequest, ISchemaRequest
    {
    }

    public interface IGridRequest<T> : IGridRequest where T : new()
    {
    }
}

using Fop.Filter;
using Fop.Order;
using Fop.Page;
using Fop.Schema;

namespace Fop
{
    public interface IFopRequest : IFilterRequest, IOrderRequest, IPageRequest, ISchemaRequest
    {
    }
}

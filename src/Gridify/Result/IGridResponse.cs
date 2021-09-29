using Gridify.Schema;

namespace Gridify.Result
{
    public interface IGridResponse
    {
        SchemaResponse Schema { get; }
    }
}
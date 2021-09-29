using Gridify.Schema;

namespace Gridify
{
    public interface IGridResponse
    {
        SchemaResponse Schema { get; }
    }
}
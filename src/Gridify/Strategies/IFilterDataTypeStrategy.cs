using Gridify.Filter;

namespace Gridify.Strategies
{
    public interface IFilterDataTypeStrategy
    {
        string ConvertFilterToText(IFilter filter);
    }
}

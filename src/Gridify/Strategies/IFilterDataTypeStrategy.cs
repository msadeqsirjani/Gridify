namespace Gridify.Strategies
{
    public interface IFilterDataTypeStrategy
    {
        string ConvertFilterToText(Filter.Filter filter);
    }
}

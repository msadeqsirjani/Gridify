using Gridify.Exceptions;
using Gridify.Filter;

namespace Gridify.Strategies
{
    public class GuidTypeStrategy : IFilterDataTypeStrategy
    {
        public string ConvertFilterToText(Filter.Filter filter)
        {
            switch (filter.Operator)
            {
                case Operators.Equal:
                    return filter.Key + " ==  new Guid(\"" + filter.Value + "\")";
                case Operators.NotEqual:
                    return filter.Key + " != new Guid(\"" + filter.Value + "\")";
                case Operators.Contains:
                case Operators.NotContains:
                case Operators.StartsWith:
                case Operators.NotStartsWith:
                case Operators.EndsWith:
                case Operators.NotEndsWith:
                case Operators.GreaterThan:
                case Operators.GreaterOrEqualThan:
                case Operators.LessThan:
                case Operators.LessOrEqualThan:
                default:
                    throw new GuidDataTypeNotSupportedException($"Guid filter does not support {filter.Operator}");
            }
        }
    }
}

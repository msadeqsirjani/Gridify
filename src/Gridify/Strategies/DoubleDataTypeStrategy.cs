using Gridify.Exceptions;
using Gridify.Filter;

namespace Gridify.Strategies
{
    public class DoubleDataTypeStrategy : IFilterDataTypeStrategy
    {
        public string ConvertFilterToText(Filter.Filter filter)
        {
            switch (filter.Operator)
            {
                case Operators.Equal:
                    return filter.Key + " == " + filter.Value;
                case Operators.NotEqual:
                    return filter.Key + " != " + filter.Value;
                case Operators.GreaterThan:
                    return filter.Key + " > " + filter.Value;
                case Operators.GreaterOrEqualThan:
                    return filter.Key + " >= " + filter.Value;
                case Operators.LessThan:
                    return filter.Key + " < " + filter.Value;
                case Operators.LessOrEqualThan:
                    return filter.Key + " <= " + filter.Value;
                case Operators.Contains:
                case Operators.NotContains:
                case Operators.StartsWith:
                case Operators.NotStartsWith:
                case Operators.EndsWith:
                case Operators.NotEndsWith:
                default:
                    throw new DoubleDataTypeNotSupportedException($"String filter does not support {filter.Operator}");
            }
        }
    }
}

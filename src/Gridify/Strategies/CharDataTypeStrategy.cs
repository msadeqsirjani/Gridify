using Gridify.Exceptions;
using Gridify.Filter;

namespace Gridify.Strategies
{
    public class CharDataTypeStrategy : IFilterDataTypeStrategy
    {
        public string ConvertFilterToText(Filter.Filter filter)
        {
            switch (filter.Operator)
            {
                case Operators.Equal:
                    return filter.Key + " == '" + filter.Value + "'";
                case Operators.NotEqual:
                    return filter.Key + " != '" + filter.Value + "'";
                case Operators.GreaterThan:
                case Operators.GreaterOrEqualThan:
                case Operators.LessThan:
                case Operators.LessOrEqualThan:
                case Operators.Contains:
                case Operators.NotContains:
                case Operators.StartsWith:
                case Operators.NotStartsWith:
                case Operators.EndsWith:
                case Operators.NotEndsWith:
                default:
                    throw new CharDataTypeNotSupportedException($"String filter does not support {filter.Operator}");
            }
        }
    }
}

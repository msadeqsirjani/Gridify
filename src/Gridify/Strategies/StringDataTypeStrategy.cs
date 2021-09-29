using Gridify.Exceptions;
using Gridify.Filter;

namespace Gridify.Strategies
{
    public class StringDataTypeStrategy : IFilterDataTypeStrategy
    {
        public string ConvertFilterToText(Filter.Filter filter)
        {
            switch (filter.Operator)
            {
                case Operators.Equal:
                    return filter.Key + " == \"" + filter.Value + "\"";
                case Operators.NotEqual:
                    return filter.Key + " != \"" + filter.Value + "\"";
                case Operators.Contains:
                    return filter.Key + ".Contains(\"" + filter.Value + "\")";
                case Operators.NotContains:
                    return "!" + filter.Key + ".Contains(\"" + filter.Value + "\")";
                case Operators.StartsWith:
                    return filter.Key + ".StartsWith(\"" + filter.Value + "\")";
                case Operators.NotStartsWith:
                    return "!" + filter.Key + ".StartsWith(\"" + filter.Value + "\")";
                case Operators.EndsWith:
                    return filter.Key + ".EndsWith(\"" + filter.Value + "\")";
                case Operators.NotEndsWith:
                    return "!" + filter.Key + ".EndsWith(\"" + filter.Value + "\")";
                case Operators.GreaterThan:
                case Operators.GreaterOrEqualThan:
                case Operators.LessThan:
                case Operators.LessOrEqualThan:
                default:
                    throw new StringDataTypeNotSupportedException($"String filter does not support {filter.Operator}");
            }
        }
    }
}

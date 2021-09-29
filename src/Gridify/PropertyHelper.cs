using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Gridify
{
    public static class PropertyHelper<T>
    {
        public static PropertyInfo GetProperty<TValue>(
            Expression<Func<T, TValue>> selector)
        {
            Expression body = selector;

            if (body is LambdaExpression lambdaExpression) body = lambdaExpression.Body;

            return body.NodeType switch
            {
                ExpressionType.MemberAccess => (PropertyInfo)((MemberExpression)body).Member,
                _ => throw new InvalidOperationException()
            };
        }
    }
}
using DynamicExpresso;
using Fop.Filter;
using Fop.Order;
using Fop.Page;
using Fop.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;

namespace Fop
{
    public static class Extensions
    {
        private static readonly Dictionary<FilterDataTypes, IFilterDataTypeStrategy> DataTypeStrategies = new();

        static Extensions()
        {
            DataTypeStrategies.Add(FilterDataTypes.Int, new IntDataTypeStrategy());
            DataTypeStrategies.Add(FilterDataTypes.Float, new FloatDataTypeStrategy());
            DataTypeStrategies.Add(FilterDataTypes.Double, new DoubleDataTypeStrategy());
            DataTypeStrategies.Add(FilterDataTypes.Long, new LongDataTypeStrategy());
            DataTypeStrategies.Add(FilterDataTypes.Decimal, new DecimalDataTypeStrategy());
            DataTypeStrategies.Add(FilterDataTypes.String, new StringDataTypeStrategy());
            DataTypeStrategies.Add(FilterDataTypes.Char, new CharDataTypeStrategy());
            DataTypeStrategies.Add(FilterDataTypes.DateTime, new DateTimeDataTypeStrategy());
            DataTypeStrategies.Add(FilterDataTypes.Boolean, new BooleanDataTypeStrategy());
            DataTypeStrategies.Add(FilterDataTypes.Enum, new EnumDataTypeStrategy());
            DataTypeStrategies.Add(FilterDataTypes.Guid, new GuidTypeStrategy());
        }

        public static IQueryable<T> ApplyGrid<T>(this IQueryable<T> queryable, IGridRequest request)
        {
            // Filter
            queryable = queryable.ApplyFiltering(request);

            // Order
            queryable = queryable.ApplyOrdering(request);

            // Paging
            queryable = queryable.ApplyPaging(request);

            return queryable;
        }

        public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> queryable, IPageRequest request)
        {
            if (request.Pagination == null)
                return queryable;

            var pagination = request.Pagination;

            if (pagination.PageNumber > 0 && pagination.PageSize > 0)
                queryable = queryable.Skip(pagination.PageSize * (pagination.PageNumber - 1)).Take(pagination.PageSize);

            return queryable;
        }

        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> queryable, IOrderRequest request)
        {
            if (request.OrderList == null || !request.OrderList.Any())
                return queryable;

            for (var i = 0; i < request.OrderList.Count(); i++)
            {
                var orderList = request.OrderList.ToArray()[i];

                if (!string.IsNullOrEmpty(orderList.OrderBy))
                {
                    queryable = queryable.OrderBy(orderList.OrderBy + " " + orderList.Direction);
                }
            }

            return queryable;
        }

        public static IQueryable<T> ApplyFiltering<T>(this IQueryable<T> queryable, IFilterRequest request)
        {
            if (request.FilterList == null || !request.FilterList.Any())
                return queryable;

            var whereExpression = string.Empty;
            var enumTypes = new List<KeyValuePair<string, string>>();

            for (var i = 0; i < request.FilterList.Count(); i++)
            {
                var filterList = request.FilterList.ToArray()[i];

                var (generatedWhereExpression, generatedEnumTypes) = GenerateDynamicWhereExpression(filterList);
                whereExpression += generatedWhereExpression;
                enumTypes.AddRange(generatedEnumTypes);

                if (i < request.FilterList.Count() - 1)
                {
                    whereExpression += ConvertLogicSyntax(FilterLogic.Or);
                }
            }

            var interpreter = new Interpreter().EnableAssignment(AssignmentOperators.None);
            foreach (var (key, value) in enumTypes)
            {
                var type = Type.GetType($"{key}, {value}");
                interpreter.Reference(type);
            }

            var expression = interpreter.ParseAsExpression<Func<T, bool>>(whereExpression, typeof(T).Name);
            queryable = queryable.Where(expression);

            return queryable;
        }

        #region [ Helpers ]

        private static (string, List<KeyValuePair<string, string>>) GenerateDynamicWhereExpression(IFilterList filterList)
        {
            var dynamicExpressBuilder = new StringBuilder();
            var kvp = new List<KeyValuePair<string, string>>();

            for (var i = 0; i < filterList.Filters.Count(); i++)
            {
                var filter = filterList.Filters.ToArray()[i];

                if (filter.DataType == FilterDataTypes.Enum)
                {
                    kvp.Add(new KeyValuePair<string, string>(filter.Fullname, filter.Assembly));
                }

                dynamicExpressBuilder.Append(ConvertFilterToText(filter));
                if (i < filterList.Filters.Count() - 1)
                {
                    dynamicExpressBuilder.Append(ConvertLogicSyntax(filterList.Logic));
                }
            }

            return ("(" + dynamicExpressBuilder + ")", kvp);
        }

        private static string ConvertLogicSyntax(FilterLogic filterListLogic)
        {
            return filterListLogic switch
            {
                FilterLogic.And => " && ",
                FilterLogic.Or => " || ",
                _ => throw new ArgumentOutOfRangeException(nameof(filterListLogic), filterListLogic, null)
            };
        }

        public static string ConvertFilterToText(IFilter filter)
        {
            return DataTypeStrategies[filter.DataType].ConvertFilterToText(filter);
        }

        #endregion
    }
}

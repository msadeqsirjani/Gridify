using Gridify.Schema;
using System.Collections;
using System.Collections.Generic;

namespace Gridify.Result
{
    public class ServiceResult
    {
        public ServiceResult()
        {

        }

        public ServiceResult(object value)
        {
            Value = value;
            if (value is IEnumerable enumerable)
            {
                Pagination = new PaginateResponse
                {
                    TotalRow = enumerable.Count()
                };
            }
        }

        public ServiceResult(object value, int count)
        {
            Value = value;

            Pagination = new PaginateResponse
            {
                TotalRow = count
            };
        }

        public ServiceResult InitSchema<TReturn>(GridRequest request) where TReturn : IGridResponse, new()
        {
            Schema = request.Schema;

            if (request.Pagination != null && Pagination != null && request.Pagination.Validate())
                Pagination.TotalPage = Pagination.TotalRow % request.Pagination.PageSize == 0
                    ? Pagination.TotalRow / request.Pagination.PageSize
                    : Pagination.TotalRow / request.Pagination.PageSize + 1;

            if (!Schema) return this;

            var schema = new TReturn().Schema;

            Fields = schema.Fields;
            Filters = schema.Filters;
            Orders = schema.Orders;

            return this;
        }

        public object Value { get; set; }
        public string Message { get; set; }
        public bool Schema { get; set; }

        public List<FieldResponse> Fields { get; set; }
        public List<FilterResponse> Filters { get; set; }
        public List<OrderResponse> Orders { get; set; }
        public PaginateResponse Pagination { get; set; }
    }

    public static class EnumerableExtensions
    {
        public static int Count(this IEnumerable source)
        {
            var count = 0;
            var enumerator = source.GetEnumerator();
            while (enumerator.MoveNext())
                count++;
            return count;
        }
    }
}

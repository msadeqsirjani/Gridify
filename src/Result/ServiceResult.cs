using Fop.Schema;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

namespace Fop.Result
{
    public class ServiceResult
    {
        public ServiceResult()
        {

        }

        public ServiceResult(object value)
        {
            Value = value;
            if (Value is IEnumerable enumerable)
            {
                Pagination = new PaginateResponse
                {
                    TotalRow = enumerable.Count()
                };
            }
        }

        public ServiceResult(object value, int total)
        {
            Value = value;
            Pagination = new PaginateResponse
            {
                TotalRow = total
            };
        }

        public ServiceResult(object value, int total, string message)
        {
            Value = value;
            Pagination = new PaginateResponse
            {
                TotalRow = total
            };
            Message = message;
        }

        public ServiceResult InitSchema(IGridRequest request)
        {
            Schema = request.Schema;

            return this;
        }

        public object Value { get; set; }
        public string Message { get; set; }
        public List<FieldResponse> Fields { get; set; }
        public List<FilterResponse> Filters { get; set; }
        public List<OrderResponse> Orders { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PaginateResponse Pagination { get; set; }
        public bool Schema { get; set; }
    }

    public class ServiceResult<T>
    {
        public ServiceResult()
        {

        }
        public ServiceResult(T value)
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

        public ServiceResult<T> InitSchema<TV>(IGridRequest<TV> request) where TV : new()
        {
            Schema = request.Schema;

            return this;
        }

        public T Value { get; set; }
        public string Message { get; set; }
        public List<FieldResponse> Fields { get; set; }
        public List<FilterResponse> Filters { get; set; }
        public List<OrderResponse> Orders { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public PaginateResponse Pagination { get; set; }
        public bool Schema { get; set; }
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

namespace Sample.Api.Models
{
    public class PagedResult<T>
    {

        public PagedResult(T data, int pageNumber, int pageSize)
        {
            Data = data;
            PageNumber = pageNumber;
            PageSize = pageSize;
        }


        public T Data { get; set; }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

    }
}

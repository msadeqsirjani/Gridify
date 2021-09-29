namespace Gridify.Page
{
    public interface IPagination
    {
        int PageNumber { get; set; }

        int PageSize { get; set; }
    }
}

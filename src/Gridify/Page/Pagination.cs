namespace Gridify.Page
{
    public class Pagination
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public bool Validate() => PageNumber > 0 && PageSize > 0;
    }
}

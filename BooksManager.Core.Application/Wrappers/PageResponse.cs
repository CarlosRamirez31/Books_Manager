namespace BooksManager.Core.Application.Wrappers
{
    public class PageResponse<T>
    {
        public int? TotalRecords { get; set; }
        public List<T>? Items { get; set; }
    }
}

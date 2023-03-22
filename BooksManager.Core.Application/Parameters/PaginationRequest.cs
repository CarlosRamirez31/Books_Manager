namespace BooksManager.Core.Application.Parameters
{
    public class PaginationRequest
    {
        public int NumPage { get; set; } = 1;
        private int NumRecordsPage { get; set; } = 10;
        public readonly int NumMaxRecordsPage = 30;
        public string Order { get; set; } = "asc";
        public string? Sort { get; set; } = null;

        public int Records
        {
            get => NumRecordsPage;
            set
            {
                NumRecordsPage = value > NumMaxRecordsPage ? NumMaxRecordsPage : value;
            }
        }
    }
}

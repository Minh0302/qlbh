namespace Test.Paging
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<T> data { get; set; } = new();

        public PagedList(int PageNumber, int TotalPages, List<T>items)
        {
            this.CurrentPage = PageNumber;
            this.TotalPages = TotalPages;
            this.data = items;
        }

    }
}

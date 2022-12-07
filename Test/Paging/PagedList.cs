namespace Test.Paging
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        //public int PageSize { get; set; }
        //public int TotalCount { get; set; }
        public List<T> data { get; set; } = new();
        //public bool HasPrevious => CurrentPage > 1;
        //public bool HasNext => CurrentPage < TotalPages;
        //public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        //{
        //    TotalCount = count;
        //    PageSize = pageSize;
        //    CurrentPage = pageNumber;
        //    TotalPages = (int)Math.Ceiling(count / (double)PageSize);
        //    AddRange(items); 

           
        //}

        public PagedList(int PageNumber, int TotalPages, List<T>items)
        {
            this.CurrentPage = PageNumber;
            this.TotalPages = TotalPages;
            this.data = items;
        }

        //public static PagedList<T> GetPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        //{
        //    var count = source.Count();
        //    var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        //    return new PagedList<T>(items, count, pageNumber, pageSize);
        //}
    }
}

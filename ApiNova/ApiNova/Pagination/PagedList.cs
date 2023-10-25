namespace ApiNova.Pagination
{
    public class PagedList<T> : List<T>
    {
        public int CurrentPage { get; private set; }
        public int TotalCount { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }

        public bool HasPrevious => CurrentPage > 1;
        public bool HaxNext => CurrentPage < TotalPages;

        public PagedList(List<T> items, int count, int pageNumber, int pageSize)
        {
            TotalCount = count;
            TotalPages = (int) Math.Ceiling(count / (double)pageSize);
            PageSize = pageSize;
            CurrentPage = pageNumber;

            AddRange(items);
        }

        public static PagedList<T> ToPagedList(IQueryable<T> source, int pageNumber, int pageSize)
        {
            var count = source.Count(); 
            var items = source.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            return new PagedList<T>(items, count, pageNumber, pageSize);
        }
    }
}

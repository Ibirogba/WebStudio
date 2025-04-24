namespace WebStudio.Application_core.Paging
{
    public class PageList<T>: List<T>
    {
        public MetaData metaData { get; set; }

        public PageList(List<T> items, int Count, int pageNumber, int pageSize)
        {
            this.metaData = new MetaData
            {
                TotalCount = Count,
                PageSize = pageSize,
                CurrentPage = pageNumber,
                TotalPage = (int)Math.Ceiling(Count / (double)pageSize)
            };

            AddRange(items);
        }

        public static PageList<T> ToPagedList(IEnumerable<T> source,int PageNumber, int PageSize)
        {
            var count = source.Count();
            var items = source.Skip((PageNumber - 1) * PageSize).Take(PageSize).ToList();
            return new PageList<T>(items, count, PageNumber, PageSize);
        }
            
    }
        
    
    
}

namespace EnglishTrainer.Infrastructure.SortOptions
{
    public class SortFilterPageOptions
    {
        public const int DefaultPageSize = 2; //default page size is 10

        private int _pageNum = 1;

        private int _pageSize = DefaultPageSize;

        public int ElementsCount { get;set; }
        
        public int PageNum
        {
            get { return _pageNum; }
            set { _pageNum = value; }
        }

        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value; }
        }

        public bool HasNextPage(int pagesCount)
        {
            return PageNum <  pagesCount;
        }

        public bool HasPrevPage()
        {
            return PageNum>1;
        }

    }
}
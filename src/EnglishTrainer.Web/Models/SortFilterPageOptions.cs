namespace EnglishTrainer.Web.Models
{
    public class SortFilterPageOptions
    {
        public const int DefaultPageSize = 10;
        private int _pageNum = 1;
        private int _pageSize = DefaultPageSize;
        public int[] PageSizes = new[] { 5, DefaultPageSize, 20, 50, 100 };
        //public BooksFilterBy FilterBy { get; set; }
        public string FilterValue { get; set; }

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

        /// <summary>
        ///     This is set to the number of pages available based on the number of entries in the query
        /// </summary>
        public int NumPages { get; private set; }

        /// <summary>
        ///     This holds the state of the key parts of the SortFilterPage parts
        /// </summary>
        public string PrevCheckState { get; set; }
        public void SetupRestOfDto<T>(IQueryable<T> query)
        {
            NumPages = (int)Math.Ceiling(
                (double)query.Count() / PageSize);
            PageNum = Math.Min(
                Math.Max(1, PageNum), NumPages);

            var newCheckState = GenerateCheckState();
            if (PrevCheckState != newCheckState)
                PageNum = 1;

            PrevCheckState = newCheckState;
        }

        private string GenerateCheckState()
        {
            return $"{FilterValue},{PageSize},{NumPages}";
        }
    }
}

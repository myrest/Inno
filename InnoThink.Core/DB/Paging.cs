namespace InnoThink.Core.DB
{
    public class Paging
    {
        public Paging()
        {
            this.Page = 1;
            this.PageSize = 10;
        }

        private int _page;
        private int _totalRecord;

        public int PageSize;
        public int MaxPage;

        public int? Page
        {
            get { return _page; }
            set
            {
                if ((value == null) || (value < 1))
                {
                    _page = 1;
                }
                else
                {
                    _page = (int)value;
                }
            }
        }

        public int totalRecord
        {
            get { return _totalRecord; }
            set
            {
                _totalRecord = value;
                if (_totalRecord == 0)
                {
                    MaxPage = 0;
                }
                else
                {
                    MaxPage = _totalRecord / PageSize;
                }
                if (PageSize * MaxPage < _totalRecord) MaxPage++;
                if (Page > MaxPage)
                {
                    Page = MaxPage;
                }
            }
        }

        public string LimitSql
        {
            get
            {
                if (PageSize == 0)
                {
                    PageSize = 10;
                }
                string limit = string.Format(" limit {0}, {1}", PageSize * (_page - 1), PageSize);
                return limit;
            }
        }
    }
}
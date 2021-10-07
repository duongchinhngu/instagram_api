
using System.Collections.Generic;

namespace Instagram.HttpMessages.Responses
{
    public class PagingResponse<T> where T : class
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public bool HasPrevious { get; set; }
        public bool HasNext { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}

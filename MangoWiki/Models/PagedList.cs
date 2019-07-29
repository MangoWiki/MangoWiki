using System.Collections.Generic;

namespace MangoWiki.Models
{
    public class PagedList<T> : PagerContext where T : class
    {
        public IEnumerable<T> List { get; set; }
    }
}

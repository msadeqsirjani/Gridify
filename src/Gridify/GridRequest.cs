using Gridify.Filter;
using Gridify.Page;
using System.Collections.Generic;

namespace Gridify
{
    public class GridRequest
    {
        public IEnumerable<FilterList> Filters { get; set; }

        public IEnumerable<Order.Order> Orders { get; set; }

        public Pagination Pagination { get; set; }

        public bool Schema { get; set; }
    }

    public class GridRequest<TSource> : GridRequest
    {
        public TSource Parameter { get; set; }
    }
}

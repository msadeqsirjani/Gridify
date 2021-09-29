using Gridify.Filter;
using Gridify.Order;
using Gridify.Page;
using System.Collections.Generic;

namespace Gridify
{
    public class GridRequest
    {
        public IEnumerable<FilterList> FilterList { get; set; }

        public IEnumerable<OrderList> OrderList { get; set; }

        public Pagination Pagination { get; set; }

        public bool Schema { get; set; }
    }

    public class GridRequest<T> where T : new()
    {
        public IEnumerable<FilterList> FilterList { get; set; }

        public IEnumerable<OrderList> OrderList { get; set; }

        public Pagination Pagination { get; set; }

        public bool Schema { get; set; }

        public T Parameter { get; set; }
    }
}

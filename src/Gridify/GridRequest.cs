using System.Collections.Generic;
using Gridify.Filter;
using Gridify.Order;
using Gridify.Page;

namespace Gridify
{
    public class GridRequest : IGridRequest
    {
        public IEnumerable<IFilterList> FilterList { get; set; }

        public IEnumerable<IOrderList> OrderList { get; set; }

        public IPagination Pagination { get; set; }

        public bool Schema { get; set; }
    }

    public class GridRequest<T> : IGridRequest<T> where T : new()
    {
        public IEnumerable<IFilterList> FilterList { get; set; }

        public IEnumerable<IOrderList> OrderList { get; set; }

        public IPagination Pagination { get; set; }

        public bool Schema { get; set; }

        public T Parameter { get; set; }
    }
}

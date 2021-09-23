using Fop.Filter;
using Fop.Order;
using Fop.Page;
using System.Collections.Generic;

namespace Fop
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

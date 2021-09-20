using Fop.Filter;
using Fop.Order;
using Fop.Page;
using System.Collections.Generic;

namespace Fop
{
    public class FopRequest : IFopRequest
    {
        public IEnumerable<IFilterList> FilterList { get; set; }

        public IEnumerable<IOrderList> OrderList { get; set; }

        public IPagination Pagination { get; set; }

        public bool Schema { get; set; }
    }
}

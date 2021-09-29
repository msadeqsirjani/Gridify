using System.Collections.Generic;

namespace Gridify.Filter
{
    public interface IFilterRequest
    {
        IEnumerable<IFilterList> FilterList { get; }
    }
}

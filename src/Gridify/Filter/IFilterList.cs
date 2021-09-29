using System.Collections.Generic;

namespace Gridify.Filter
{
    public interface IFilterList
    {
        FilterLogic Logic { get; set; }

        IEnumerable<IFilter> Filters { get; set; }
    }
}

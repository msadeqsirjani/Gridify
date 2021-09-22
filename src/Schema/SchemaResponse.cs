using Fop.Meta;
using System.Collections.Generic;
using System.Linq;

namespace Fop.Schema
{
    public class SchemaResponse
    {
        public IEnumerable<FieldResponse> Fields { get; set; }
        public IEnumerable<FilterResponse> Filters { get; set; }
        public IEnumerable<OrderResponse> Orders { get; set; }

        public SchemaResponse()
        {

        }

        public SchemaResponse(IReadOnlyCollection<KeyValuePair<string, IMeta>> pairs)
        {
            pairs?.GroupBy(x => x.Key)
                .ToList()
                .ForEach(g =>
                {
                    var fieldMetaKeys = pairs.Where(x => x.Key.Equals(g.Key))
                        .Select(x => x.Value)
                        .ToList();
                });
        }
    }
}

using Fop.Meta;
using System.Collections.Generic;
using System.Linq;

namespace Fop.Schema
{
    public class SchemaResponse
    {
        public List<FieldResponse> Fields { get; set; }
        public List<FilterResponse> Filters { get; set; }
        public List<OrderResponse> Orders { get; set; }

        public SchemaResponse()
        {
            Fields = new List<FieldResponse>();
            Filters = new List<FilterResponse>();
            Orders = new List<OrderResponse>();
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

                    Fields.Add(new FieldResponse().FillFieldResponse(fieldMetaKeys));

                    fieldMetaKeys.Where(m => m.GetType() == typeof(MetaFilter)).ToList().ForEach(meta =>
                    {
                        var metaFilter = (MetaFilter)meta;
                        Filters.Add(new FilterResponse
                        {
                            Key = metaFilter.Key,
                            Value = metaFilter.Value,
                            Assembly = metaFilter.Assembly,
                            DataType = metaFilter.DataType,
                            Operator = metaFilter.Operator,
                            Fullname = metaFilter.Fullname
                        });
                    });

                    fieldMetaKeys.Where(m => m.GetType() == typeof(MetaOrder)).ToList().ForEach(f =>
                    {
                        var metaFilter = (MetaOrder)f;
                        Orders.Add(new OrderResponse
                        {
                            OrderBy = metaFilter.OrderBy,
                            Direction = metaFilter.Direction
                        });
                    });
                });

            if (Fields.Any(f => f.Sequence > 0))
                return;

            var sequence = 0;
            Fields.ToList().ForEach(f =>
            {
                f.Sequence = sequence;
                sequence++;
            });
        }
    }
}

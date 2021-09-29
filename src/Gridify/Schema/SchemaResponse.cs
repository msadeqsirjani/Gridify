using Gridify.Meta;
using System.Collections.Generic;
using System.Linq;

namespace Gridify.Schema
{
    public class SchemaResponse
    {
        public List<FieldResponse> Fields { get; } = new();
        public List<FilterResponse> Filters { get; } = new();
        public List<OrderResponse> Orders { get; } = new();

        public SchemaResponse(IReadOnlyCollection<KeyValuePair<string, IMeta>> pairs)
        {
            pairs?.GroupBy(x => x.Key)
                .ToList()
                .ForEach(g =>
                {
                    var fieldMetaKeys = pairs.Where(x => x.Key.Equals(g.Key))
                        .Select(x => x.Value)
                        .ToList();

                    var fieldResponse = new FieldResponse().FillFieldResponse(fieldMetaKeys);

                    Fields.Add(fieldResponse);

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

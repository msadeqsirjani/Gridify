using Gridify.Filter;
using Gridify.Meta;
using Gridify.Schema;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Gridify.Result
{
    public abstract class GridResponse<TSource> : IGridResponse where TSource : new()
    {
        private readonly List<KeyValuePair<string, IMeta>> _metadata = new();

        public void Add(string key, IMeta meta)
        {
            _metadata.Add(new KeyValuePair<string, IMeta>(key, meta));
        }

        [JsonIgnore]
        public SchemaResponse Schema
        {
            get
            {
                if (!_metadata.Any())
                    InitSchema();
                return new SchemaResponse(_metadata);
            }
        }

        public MetaBuilder<TSource, TProperty> Meta<TProperty>(Expression<Func<TSource, TProperty>> expression)
        {
            var builder = new MetaBuilder<TSource, TProperty>(PropertyHelper<TSource>.GetProperty(expression), this);

            builder.AddMeta(builder.PropertyName, new MetaName { Name = builder.PropertyName });
            builder.AddMeta(builder.PropertyName, new MetaTitle { Title = builder.PropertyName });

            if (builder.PropertyInfo.PropertyType == typeof(string))
                builder.AddMeta(builder.PropertyName, new MetaDataType { DataType = DataType.String });

            if (builder.PropertyInfo.PropertyType == typeof(int) || builder.PropertyInfo.PropertyType == typeof(int?))
                builder.AddMeta(builder.PropertyName, new MetaDataType { DataType = DataType.Int });

            if (builder.PropertyInfo.PropertyType == typeof(float) || builder.PropertyInfo.PropertyType == typeof(float?))
                builder.AddMeta(builder.PropertyName, new MetaDataType { DataType = DataType.Float });

            if (builder.PropertyInfo.PropertyType == typeof(double) || builder.PropertyInfo.PropertyType == typeof(double?))
                builder.AddMeta(builder.PropertyName, new MetaDataType { DataType = DataType.Double });

            if (builder.PropertyInfo.PropertyType == typeof(long) || builder.PropertyInfo.PropertyType == typeof(long?))
                builder.AddMeta(builder.PropertyName, new MetaDataType { DataType = DataType.Double });

            if (builder.PropertyInfo.PropertyType == typeof(decimal) || builder.PropertyInfo.PropertyType == typeof(decimal?))
                builder.AddMeta(builder.PropertyName, new MetaDataType { DataType = DataType.Decimal });

            if (builder.PropertyInfo.PropertyType == typeof(char) || builder.PropertyInfo.PropertyType == typeof(char?))
                builder.AddMeta(builder.PropertyName, new MetaDataType { DataType = DataType.Char });

            if (builder.PropertyInfo.PropertyType == typeof(DateTime) || builder.PropertyInfo.PropertyType == typeof(DateTime?))
                builder.AddMeta(builder.PropertyName, new MetaDataType { DataType = DataType.DateTime });

            if (builder.PropertyInfo.PropertyType == typeof(bool) || builder.PropertyInfo.PropertyType == typeof(bool?))
                builder.AddMeta(builder.PropertyName, new MetaDataType { DataType = DataType.Boolean });

            if (builder.PropertyInfo.PropertyType == typeof(Enum))
                builder.AddMeta(builder.PropertyName, new MetaDataType { DataType = DataType.Enum });

            if (builder.PropertyInfo.PropertyType == typeof(Guid) || builder.PropertyInfo.PropertyType == typeof(Guid?))
                builder.AddMeta(builder.PropertyName, new MetaDataType { DataType = DataType.Guid });

            return builder;
        }

        public abstract void InitSchema();
    }
}

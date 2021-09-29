using Gridify.Filter;

namespace Gridify.Meta
{
    public static class MetaExpressions
    {
        public static MetaBuilder<TSource, TProperty> IsDetail<TSource, TProperty>(
            this MetaBuilder<TSource, TProperty> builder, bool isDetail = true) where TSource : new()
        {
            builder.AddMeta(builder.PropertyName, new MetaDetail
            {
                IsDetail = isDetail
            });

            return builder;
        }

        public static MetaBuilder<TSource, TProperty> IsEditable<TSource, TProperty>(
            this MetaBuilder<TSource, TProperty> builder, bool isEditable = true) where TSource : new()
        {
            builder.AddMeta(builder.PropertyName, new MetaEditable
            {
                IsEditable = isEditable
            });

            return builder;
        }

        public static MetaBuilder<TSource, TProperty> AddFilter<TSource, TProperty>(
            this MetaBuilder<TSource, TProperty> builder, Filter.Filter filter) where TSource : new()
        {
            builder.AddMeta(builder.PropertyName, new MetaFilter
            {
                Operator = filter.Operator.ToString(),
                DataType = filter.DataType.ToString(),
                Value = filter.Value,
                Fullname = filter.Fullname,
                Assembly = filter.Assembly,
                Key = filter.Key,
            });

            return builder;
        }

        public static MetaBuilder<TSource, TProperty> IsKey<TSource, TProperty>(
            this MetaBuilder<TSource, TProperty> builder) where TSource : new()
        {
            builder.AddMeta(builder.PropertyName, new MetaKey());

            return builder;
        }

        public static MetaBuilder<TSource, TProperty> AddName<TSource, TProperty>(
            this MetaBuilder<TSource, TProperty> builder, string name) where TSource : new()
        {
            builder.AddMeta(builder.PropertyName, new MetaName { Name = name });

            return builder;
        }

        public static MetaBuilder<TSource, TProperty> AddOrder<TSource, TProperty>(
            this MetaBuilder<TSource, TProperty> builder, Order.Order order) where TSource : new()
        {
            builder.AddMeta(builder.PropertyName, new MetaOrder
            {
                OrderBy = order.OrderBy,
                Direction = order.Direction.ToString()
            });

            return builder;
        }

        public static MetaBuilder<TSource, TProperty> IsSelectable<TSource, TProperty>(
            this MetaBuilder<TSource, TProperty> builder, bool isSelectable = true) where TSource : new()
        {
            builder.AddMeta(builder.PropertyName, new MetaSelectable
            {
                IsSelectable = isSelectable
            });

            return builder;
        }

        public static MetaBuilder<TSource, TProperty> AddSequence<TSource, TProperty>(
            this MetaBuilder<TSource, TProperty> builder, int sequence) where TSource : new()
        {
            builder.AddMeta(builder.PropertyName, new MetaSequence
            {
                Sequence = sequence
            });

            return builder;
        }

        public static MetaBuilder<TSource, TProperty> AddTitle<TSource, TProperty>(
            this MetaBuilder<TSource, TProperty> builder, string title) where TSource : new()
        {
            builder.AddMeta(builder.PropertyName, new MetaTitle
            {
                Title = title
            });

            return builder;
        }

        public static MetaBuilder<TSource, TProperty> AddDataType<TSource, TProperty>(
            this MetaBuilder<TSource, TProperty> builder, DataType dateType) where TSource : new()
        {
            builder.AddMeta(builder.PropertyName, new MetaDataType
            {
                DataType = dateType.ToString()
            });

            return builder;
        }

        public static MetaBuilder<TSource, TProperty> IsVisible<TSource, TProperty>(
            this MetaBuilder<TSource, TProperty> builder, bool isVisible = true) where TSource : new()
        {
            builder.AddMeta(builder.PropertyName, new MetaVisible
            {
                IsVisible = isVisible
            });

            return builder;
        }

        public static MetaBuilder<TSource, TProperty> IsVisibleDefault<TSource, TProperty>(
            this MetaBuilder<TSource, TProperty> builder, bool isVisibleDefault = true) where TSource : new()
        {
            builder.AddMeta(builder.PropertyName, new MetaVisibleDefault
            {
                IsVisibleDefault = isVisibleDefault
            });

            return builder;
        }

        public static MetaBuilder<TSource, TProperty> IsClickable<TSource, TProperty>(
            this MetaBuilder<TSource, TProperty> builder, bool isClickable = true) where TSource : new()
        {
            builder.AddMeta(builder.PropertyName, new MetaClickable()
            {
                IsClickable = isClickable
            });

            return builder;
        }
    }
}
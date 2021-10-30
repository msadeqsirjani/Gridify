using Gridify.Filter;
using System;
using System.Reflection;

namespace Gridify.Meta
{
    public class MetaBuilder<TSource, TProperty> where TSource : new()
    {
        public string PropertyName { get; }
        public PropertyInfo PropertyInfo { get; }
        public GridResponse<TSource> GridResponse { get; }

        public MetaBuilder(PropertyInfo propertyInfo, GridResponse<TSource> gridResponse)
        {
            PropertyName = propertyInfo.Name;
            PropertyInfo = propertyInfo;
            GridResponse = gridResponse;
        }

        public MetaBuilder(string propertyName, GridResponse<TSource> gridResponse)
        {
            PropertyName = propertyName;
            GridResponse = gridResponse;
            PropertyInfo = null;
        }

        public void AddMeta(string key, IMeta meta)
        {
            GridResponse.Add(key, meta);
        }

        public string GetDataType()
        {
            if (PropertyInfo.PropertyType == typeof(string))
                return DataType.String.ToString();

            if (PropertyInfo.PropertyType == typeof(int) || PropertyInfo.PropertyType == typeof(int?))
                return DataType.Int.ToString();

            if (PropertyInfo.PropertyType == typeof(float) || PropertyInfo.PropertyType == typeof(float?))
                return DataType.Float.ToString();

            if (PropertyInfo.PropertyType == typeof(double) || PropertyInfo.PropertyType == typeof(double?))
                return DataType.Double.ToString();

            if (PropertyInfo.PropertyType == typeof(long) || PropertyInfo.PropertyType == typeof(long?))
                return DataType.Double.ToString();

            if (PropertyInfo.PropertyType == typeof(decimal) || PropertyInfo.PropertyType == typeof(decimal?))
                return DataType.Decimal.ToString();

            if (PropertyInfo.PropertyType == typeof(char) || PropertyInfo.PropertyType == typeof(char?))
                return DataType.Char.ToString();

            if (PropertyInfo.PropertyType == typeof(DateTime) || PropertyInfo.PropertyType == typeof(DateTime?))
                return DataType.DateTime.ToString();

            if (PropertyInfo.PropertyType == typeof(bool) || PropertyInfo.PropertyType == typeof(bool?))
                return DataType.Boolean.ToString();

            if (PropertyInfo.PropertyType.IsEnum)
                return DataType.Enum.ToString();

            if (PropertyInfo.PropertyType == typeof(Guid) || PropertyInfo.PropertyType == typeof(Guid?))
                return DataType.Guid.ToString();

            throw new ArgumentException("No such data type");
        }
    }
}

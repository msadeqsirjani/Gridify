using Gridify.Result;
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
    }
}

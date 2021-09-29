using System.Collections.Generic;
using System.Reflection;

namespace Gridify.Meta
{
    public class MetaBuilder
    {
        public string PropertyName { get; }
        public PropertyInfo PropertyInfo { get; }
        public List<IMeta> MetaInformation { get; set; }

        public MetaBuilder(string propertyName, PropertyInfo propertyInfo)
        {
            PropertyName = propertyName;
            PropertyInfo = propertyInfo;
        }

        public MetaBuilder(string propertyName)
        {
            PropertyName = propertyName;
            PropertyInfo = null;
        }

        public void AddMeta(string key, IMeta meta)
        {
            MetaInformation.Add(meta);
        }
    }
}

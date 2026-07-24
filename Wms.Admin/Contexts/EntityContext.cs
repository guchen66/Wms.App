using Wms.Admin.Components;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Admin.Contexts
{
    /// <summary>
    /// 表的数据上下文
    /// </summary>
    public sealed class EntityContext
    {
        public EntityContext RootEntityContext { get; internal set; }
        public Type EntityType { get; internal set; }
        private Dictionary<string, object> Properties { get; set; } = new();


        public Dictionary<string, object> SetProperty<TComponent>(object value) where TComponent : class, IPrismComponent, new()
        {
            return SetProperty(typeof(TComponent), value);
        }

        /// <summary>
        /// 设置组件属性参数
        /// </summary>
        public Dictionary<string, object> SetProperty(Type componentType, object value)
        {
            return SetProperty(componentType.FullName, value);
        }

        public Dictionary<string, object> SetProperty(string key, object value)
        {
            if (string.IsNullOrWhiteSpace(key)) throw new ArgumentNullException(nameof(key));

            var properties = RootEntityContext == null ? Properties : RootEntityContext.Properties;

            if (!properties.ContainsKey(key))
            {
                properties.Add(key, value);
            }
            else properties[key] = value;

            return properties;
        }

    }
}

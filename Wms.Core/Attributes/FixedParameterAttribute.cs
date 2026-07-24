using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wms.Core.Attributes
{
    /// <summary>
    /// 要求参数必须固定开头和结尾
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false)]
    public class FixedParameterAttribute : Attribute
    {
        public string Start { get; set; }
        public string End ;//{ get; set; }

        public FixedParameterAttribute(string end)
        {
            End = end;
        }

        public void Validate(object value, ParameterInfo parameter)
        {
            if (!(value is string stringValue))
            {
                throw new ArgumentException($"The parameter {parameter.Name} must be a string.", parameter.Name);
            }

            if (!stringValue.EndsWith(End, StringComparison.OrdinalIgnoreCase))
            {
                throw new ArgumentException($"The parameter {parameter.Name} must end with '{End}'.", parameter.Name);
            }
        }
    }
}

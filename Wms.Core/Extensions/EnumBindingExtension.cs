using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Wms.Core.Extensions
{
    public class EnumBindingExtension : MarkupExtension
    {
        private Type _enumType;

        public EnumBindingExtension(Type enumType)
        {
            if (enumType == null || !enumType.IsEnum)
            {
                throw new ArgumentException("Enum type is required.");
            }

            _enumType = enumType;
        }
        public EnumBindingExtension()
        {

        }
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return Enum.GetValues(_enumType);
        }
    }
}

using Wms.Core.Attributes;
using Wms.Core.Consts;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Wms.Controls.Converters
{
    public class SelectetemRoleToIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is RoleEnum selectedRole)
            {
                // 获取选中角色的FieldInfo
                FieldInfo fieldInfo = typeof(RoleEnum).GetField(selectedRole.ToString());

                // 获取角色特性
                RoleRemarkAttribute attribute = fieldInfo.GetCustomAttribute<RoleRemarkAttribute>();

                // 返回特性中的等级值
                return attribute?.Remark;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

}

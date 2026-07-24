using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Wms.Controls.Converters
{
    public static class ElementExtensions
    {
        // 注册附加属性 propa
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.RegisterAttached(
                "IsSelected",
                typeof(bool),
                typeof(ElementExtensions),
                new PropertyMetadata(false, OnIsSelectedChanged));

        // 获取附加属性的值
        public static bool GetIsSelected(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsSelectedProperty);
        }

        // 设置附加属性的值
        public static void SetIsSelected(DependencyObject obj, bool value)
        {
            obj.SetValue(IsSelectedProperty, value);
        }

        // 当附加属性的值改变时调用的回调
        private static void OnIsSelectedChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as MyDateTimePicker;
            if (element != null)
            {
                var f = e.NewValue;
                var result = DateTime.Now;//.ToString("yyyy-MM-dd HH:mm:ss");
              //  element.SelectedDateTime= result;
                // 根据IsSelected的值改变元素的外观
             //   element.Foreground = (bool)e.NewValue ? Brushes.Red : Brushes.Black;
            }
        }
    }
}

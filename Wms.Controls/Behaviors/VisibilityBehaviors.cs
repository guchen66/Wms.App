using Microsoft.Xaml.Behaviors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Wms.Controls.Behaviors
{
    public class VisibilityBehaviors : Behavior<FrameworkElement>
    {
        public object SelectedItem
        {
            get { return (object)GetValue(SelectedItemProperty); }
            set { SetValue(SelectedItemProperty, value); }
        }

        public static readonly DependencyProperty SelectedItemProperty =
            DependencyProperty.Register("SelectedItem", typeof(object), typeof(VisibilityBehaviors), new PropertyMetadata(null, OnSelectedItemChanged));

        private static void OnSelectedItemChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var behavior = d as VisibilityBehaviors;
            if (behavior == null) return;
         //   sep.Background = System.Windows.Media.Brushes.Red;
            var associatedObject = behavior.AssociatedObject; // 获取行为关联的对象，这里应该是 StackPanel
        /*    if (associatedObject is StackPanel panel)
            {
                foreach (var child in panel.Children)
                {
                    if (child is Separator s)
                    {
                        
                        s.Background = System.Windows.Media.Brushes.Red;
                    }
                }
            }*/
        }

        public static System.Windows.Media.Brush ConvertToMediaBrush(System.Drawing.Brush drawingBrush)
        {
            // Convert System.Drawing.Color to System.Windows.Media.Color
            System.Drawing.Color color = ((System.Drawing.SolidBrush)drawingBrush).Color;
            System.Windows.Media.Color wpfColor = System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);

            // Create a SolidColorBrush using the converted color
            return new System.Windows.Media.SolidColorBrush(wpfColor);
        }
        protected override void OnAttached()
        {
            base.OnAttached();
         /*   AssociatedObject.Loaded += (_, _) =>
            {
                Children.First().Background= System.Windows.Media.Brushes.Red;
                foreach (var child in Children)
                {
                    child.Background = System.Windows.Media.Brushes.Red;
                }
            };*/

        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            // AssociatedObject.Loaded -= AssociatedObject_Loaded;
        }
        private void AssociatedObject_Loaded(object sender, RoutedEventArgs e)
        {
            if (sender is StackPanel panel)
            {

                //   btn.Content = "已点击";
            }

        }

        private IEnumerable<Separator> Children
        {
            get
            {
                if (AssociatedObject is Panel panel)
                    return panel.Children.OfType<Separator>();

                else if (AssociatedObject is ItemsControl control)
                    return control.Items.OfType<Separator>();

                return Enumerable.Empty<Separator>();
            }
        }
    }
}

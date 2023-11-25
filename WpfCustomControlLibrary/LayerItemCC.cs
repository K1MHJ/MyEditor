using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfCustomControlLibrary
{
    /// <summary>
    /// Follow steps 1a or 1b and then 2 to use this custom control in a XAML file.
    ///
    /// Step 1a) Using this custom control in a XAML file that exists in the current project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfCustomControlLibrary"
    ///
    ///
    /// Step 1b) Using this custom control in a XAML file that exists in a different project.
    /// Add this XmlNamespace attribute to the root element of the markup file where it is 
    /// to be used:
    ///
    ///     xmlns:MyNamespace="clr-namespace:WpfCustomControlLibrary;assembly=WpfCustomControlLibrary"
    ///
    /// You will also need to add a project reference from the project where the XAML file lives
    /// to this project and Rebuild to avoid compilation errors:
    ///
    ///     Right click on the target project in the Solution Explorer and
    ///     "Add Reference"->"Projects"->[Select this project]
    ///
    ///
    /// Step 2)
    /// Go ahead and use your control in the XAML file.
    ///
    ///     <MyNamespace:CustomControl1/>
    ///
    /// </summary>
    public class LayerItemCC : Control
    {
        static LayerItemCC()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LayerItemCC), new FrameworkPropertyMetadata(typeof(LayerItemCC)));
        }
        public Brush LayerBrush
        {
            get { return (Brush)GetValue(LayerBrushProperty); }
            set { SetValue(LayerBrushProperty, value); }
        }
        public static readonly DependencyProperty LayerBrushProperty = 
            DependencyProperty.Register("LayerBrush", typeof(Brush), typeof(LayerItemCC), new PropertyMetadata(Brushes.White));
        public Brush LayerEdgeBrush
        {
            get { return (Brush)GetValue(LayerEdgeBrushProperty); }
            set { SetValue(LayerEdgeBrushProperty, value); }
        }
        public static readonly DependencyProperty LayerEdgeBrushProperty = 
            DependencyProperty.Register("LayerEdgeBrush", typeof(Brush), typeof(LayerItemCC), new PropertyMetadata(Brushes.Black));
        public LayerVisibility VisibleOn
        {
            get { 
                return (LayerVisibility)GetValue(LayerVisibilityProperty);
            }
            set { 
                SetValue(LayerVisibilityProperty, value); 
            }
        }
        public static readonly DependencyProperty LayerVisibilityProperty = 
            DependencyProperty.Register("VisibleOn", typeof(LayerVisibility), typeof(LayerItemCC), new PropertyMetadata(LayerVisibility.Hidden));
    }
}

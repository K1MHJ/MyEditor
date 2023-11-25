using System;
using System.CodeDom;
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
    /// Interaction logic for LayerItemUC.xaml
    /// </summary>
    public partial class LayerItemUC : UserControl
    {
        public LayerItemUC()
        {
            InitializeComponent();
        }
        public LayerHatch HatchPattern
        {
            get { return (LayerHatch)GetValue(HatchPatternProperty); }
            set { SetValue(HatchPatternProperty, value); }
        }
        public static readonly DependencyProperty HatchPatternProperty = 
            DependencyProperty.Register("HatchPattern", typeof(LayerHatch), typeof(LayerItemUC),
                new FrameworkPropertyMetadata(LayerHatches.NoPattern, new PropertyChangedCallback(OnHatchPatternChanged)));

        private static void OnHatchPatternChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            LayerItemUC ctrl = d as LayerItemUC;
            if (ctrl != null)
            {
                ctrl.LayerBrush = ctrl.HatchPattern.GetVisualBrush(ctrl.LayerColor);
            }
        }

        public Color LayerColor
        {
            get { return (Color)GetValue(LayerColorProperty); }
            set { SetValue(LayerColorProperty, value); }
        }
        public static readonly DependencyProperty LayerColorProperty = 
            DependencyProperty.Register("LayerColor", typeof(Color), typeof(LayerItemUC), 
                new FrameworkPropertyMetadata(Colors.White, new PropertyChangedCallback(OnLayerColorChanged)));
        private static void OnLayerColorChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            LayerItemUC ctrl = d as LayerItemUC;
            if (ctrl != null)
            {
                ctrl.LayerBrush = ctrl.HatchPattern.GetVisualBrush(ctrl.LayerColor);
                ctrl.LayerEdgeBrush = new SolidColorBrush(ctrl.LayerColor);
            }
        }
        public Brush LayerBrush
        {
            get { return (Brush)GetValue(LayerBrushProperty); }
            set { SetValue(LayerBrushProperty, value); }
        }
        public static readonly DependencyProperty LayerBrushProperty = 
            DependencyProperty.Register("LayerBrush", typeof(Brush), typeof(LayerItemUC), new PropertyMetadata(Brushes.Black));
        public Brush LayerEdgeBrush
        {
            get { return (Brush)GetValue(LayerEdgeBrushProperty); }
            set { SetValue(LayerEdgeBrushProperty, value); }
        }
        public static readonly DependencyProperty LayerEdgeBrushProperty = 
            DependencyProperty.Register("LayerEdgeBrush", typeof(Brush), typeof(LayerItemUC), new PropertyMetadata(Brushes.Black));

        public LayerVisibility VisibleOn
        {
            get { return (LayerVisibility)GetValue(LayerVisibilityProperty); }
            set { SetValue(LayerVisibilityProperty, value); }
        }
        public static readonly DependencyProperty LayerVisibilityProperty = 
            DependencyProperty.Register("VisibleOn", typeof(LayerVisibility), typeof(LayerItemUC), new PropertyMetadata(LayerVisibility.Visible));
        public string Text 
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public static readonly DependencyProperty TextProperty = 
            DependencyProperty.Register("Text", typeof(string), typeof(LayerItemUC), new PropertyMetadata("00"));

        public event MouseButtonEventHandler LayerItemMouseDoubleClick;
        private void root_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if(icon.VisibleOn == LayerVisibility.Hidden)
            {
                icon.VisibleOn = LayerVisibility.Visible;
                text_block.TextDecorations = null;
            }
            else if(icon.VisibleOn == LayerVisibility.Visible)
            {
                icon.VisibleOn = LayerVisibility.Hidden;
                text_block.TextDecorations = TextDecorations.Strikethrough;
            }

            LayerItemUC item = sender as LayerItemUC;
            LayerItem layer = new LayerItem(item.Text, item.VisibleOn);
            LayerItemMouseDoubleClick?.Invoke(layer, e);
        }
    }
}

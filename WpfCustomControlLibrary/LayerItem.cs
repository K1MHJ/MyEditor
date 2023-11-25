using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WpfCustomControlLibrary
{
    public enum LayerVisibility : byte
    {
        Visible,
        Hidden,
        Collapsed
    }
    public sealed class LayerItem
    {
        public LayerItem(string name, LayerVisibility visibleOn)
        {
            Name = name;
            VisibleOn = visibleOn;
        }
        public string Name { get; private set; }
        public LayerVisibility VisibleOn { get; private set; }
    }
    public sealed class LayerResource
    {
        public static ResourceDictionary GetDictionary()
        {
            ResourceDictionary myResourceDictionary = new ResourceDictionary();
            myResourceDictionary.Source = new Uri(@"Themes/Generic.xaml", UriKind.RelativeOrAbsolute);
            return myResourceDictionary;
        }
    }
    public sealed class LayerHatches
    {
        public static LayerHatch NoPattern => LayerHatch.FromByte(1);
        public static LayerHatch Vertical => LayerHatch.FromByte(2);
        public static LayerHatch DotPattern => LayerHatch.FromByte(3);
        public static LayerHatch HLinePattern => LayerHatch.FromByte(4);
    }

    [Localizability(LocalizationCategory.None, Readability = Readability.Unreadable)]
    public struct LayerHatch : IFormattable, IEquatable<LayerHatch>
    {
        byte m_id;
        public override int GetHashCode()
        {
            return (int)m_id; 
        }

        public static bool Equals(LayerHatch color1, LayerHatch color2)
        {
            return color1 == color2;
        }

        public bool Equals(LayerHatch color)
        {
            return this == color;
        }
        public override bool Equals(object o)
        {
            if (o is LayerHatch)
            {
                LayerHatch color = (LayerHatch)o;
                return this == color;
            }

            return false;
        }
        string IFormattable.ToString(string format, IFormatProvider provider)
        {
            return ConvertToString(format, provider);
        }

        public static bool operator !=(LayerHatch hatch1, LayerHatch hatch2)
        {
            return !(hatch1 == hatch2);
        }
        public static bool operator ==(LayerHatch hatch1, LayerHatch hatch2)
        {
            if (hatch1.m_id == hatch2.m_id)
            {
                return true;
            }
            return false;
        }
        internal string ConvertToString(string format, IFormatProvider provider)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendFormat(provider, "#{0:X2}", new object[1] { m_id });
            return stringBuilder.ToString();
        }
        internal static LayerHatch FromByte(byte id)
        {
            LayerHatch result = default(LayerHatch);
            result.m_id = (byte)id;
            return result;
        }
        internal Brush GetVisualBrush(Color color)
        {
            VisualBrush vb = new VisualBrush();
            vb.TileMode = TileMode.Tile;
            vb.Viewport = new Rect(0, 0, 15, 15);
            vb.ViewportUnits = BrushMappingMode.Absolute;
            vb.Viewbox = new Rect(0, 0, 15, 15);
            vb.ViewboxUnits = BrushMappingMode.Absolute;
            Grid grid = new Grid();
            if(this == LayerHatches.NoPattern)
            {
                Path[] path = { new Path(), new Path() };
                path[1].Stroke = path[0].Stroke = new SolidColorBrush(color);
                path[0].Data = new LineGeometry(new Point(0, 15), new Point(15, 0));
                path[1].Data = new LineGeometry(new Point(0, 0), new Point(15, 15));
                grid.Children.Add(path[0]);
                grid.Children.Add(path[1]);
            }
            else if(this == LayerHatches.Vertical)
            {
                Path[] path = { new Path(), new Path() };
                path[1].Stroke = path[0].Stroke = new SolidColorBrush(color);
                path[0].Data = new LineGeometry(new Point(7, 0), new Point(7, 15));
                //path[1].Data = new LineGeometry(new Point(0, 0), new Point(15, 15));
                grid.Children.Add(path[0]);
                //grid.Children.Add(path[1]);
            }
            vb.Visual = grid;
            return vb;
        }
    }
}

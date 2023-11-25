using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using WpfCustomControlLibrary;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for LayerList.xaml
    /// </summary>
    public partial class LayerList : UserControl
    {
        public ObservableCollection<LayerListItem> Items 
        { get; private set; } = new ObservableCollection<LayerListItem>();
        public LayerList()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public void Add(LayerHatch hatch, Color color, string name, LayerVisibility visibleOn)
        {
            Items.Add(new LayerListItem(hatch, color, name, visibleOn));
        }
        public void Clear()
        {
            Items.Clear();
        }
        public event MouseButtonEventHandler LayerItemMouseDoubleClick;

        private void LayerItemUC_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LayerItemMouseDoubleClick?.Invoke(sender, e);
        }
    }
    public class LayerListItem
    {
        public LayerListItem(LayerHatch hatch, Color color, string name, LayerVisibility visibleOn)
        {
            this.hatch = hatch;
            this.color = color;
            this.name = name;
            this.visibleOn = visibleOn;
        }

        public LayerHatch hatch { get; private set; }
        public Color color { get; private set; }
        public string name { get; private set; }
        public LayerVisibility visibleOn { get; private set; }
    }
        
}

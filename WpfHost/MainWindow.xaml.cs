using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Security.RightsManagement;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MyViewModel();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            layerList.Add(LayerHatches.Vertical, Colors.Blue, "L00", LayerVisibility.Hidden);
            layerList.Add(LayerHatches.NoPattern, Colors.Gray, "L01", LayerVisibility.Visible);
        }
        private void LayerList_LayerItemMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            LayerItem layerItem = sender as LayerItem;
        }
    }
    public class MyItem
    {
        public string Name { get; set; }
    }
    public class MyViewModel
    {
        public ObservableCollection<MyItem> Items { get; set; }
        public MyViewModel() // Or in a constructor for your code-behind
        {
            Items = new ObservableCollection<MyItem>();
            // Populate the collection
            Items.Add(new MyItem() { Name = "Hello" });
        }
    }
}

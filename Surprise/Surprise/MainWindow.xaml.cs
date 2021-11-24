using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace Surprise
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<BooAPI> booboo = new List<BooAPI>();
        public MainWindow()
        {
            InitializeComponent();
            string jFile = File.ReadAllText("BooJSON.json");
            List<BooAPI> json = JsonConvert.DeserializeObject<List<BooAPI>>(jFile);

            foreach (var item in json)
            {
                booboo.Add(item);
            }

            PopulateComboBox();
        }

        private void PopulateComboBox()
        {
            combo.SelectedIndex = 0;
            foreach (var item in booboo)
            {
                combo.Items.Add(item);
            }
        }

        private void combo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BooAPI jam = (BooAPI)combo.SelectedItem;
            ListBox.Items.Clear();
            foreach (var item in jam.messageSelect)
            {
                ListBox.Items.Add(item);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BooMessage selected = (BooMessage)ListBox.SelectedItem;
            window win = new window();
            win.SetupWindow(selected);
            win.ShowDialog();
        }
    }
}

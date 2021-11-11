using HttpJsonGet;
using Mika_Music.Models;
using Newtonsoft.Json;
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

namespace Mika_Music
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void PackIconMicrons_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Environment.Exit(0);
        }

        private void PackIconCodicons_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState == WindowState.Maximized ? WindowState.Normal : WindowState.Maximized;
        }

        private void PackIconCodicons_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            
        }

        private void PackIconMaterial_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            string url = "https://soutwyy.vercel.app/user/detail?uid=32953014";

            string getJson = HttpUitls.Get(url);

            RootObject rt = JsonConvert.DeserializeObject<RootObject>(getJson);
            MessageBox.Show(rt.level.ToString());
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }
    }
}

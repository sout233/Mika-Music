using HttpJsonGet;
using Mika_Music.Models.Json;
using Mika_Music.Models.Json.Status;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Mika_Music.Views.Login
{
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            /*
            string url = "https://wyy01.sout.eu.org/login/status";
            string getJson = HttpUitls.Get(url);
            AccountData rt = JsonConvert.DeserializeObject<AccountData>(getJson);
            */
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (cfa.AppSettings.Settings["isSkipLogin"].Value == "true")
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                Close();
            }
            else
            {
                UserLogin userLogin = new UserLogin();
                userLogin.Show();
                Close();
            }
        }
    }
}

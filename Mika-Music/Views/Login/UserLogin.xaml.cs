using HttpJsonGet;
using Mika_Music.Models.Json.Login;
using Mika_Music.Views.Login;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Mika_Music.Views
{
    /// <summary>
    /// UserLogin.xaml 的交互逻辑
    /// </summary>
    public partial class UserLogin : Window
    {
        CellPhoneLogin CellPhoneLogin = new CellPhoneLogin();
        EmailLogin EmailLogin = new EmailLogin();
        private string LoginMode = "CellPhone";

        public UserLogin()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ContentControl.Content = CellPhoneLogin;
        }

        private void Tag_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(ContentControl.Content==CellPhoneLogin)
            {
                LoginMode = "Email";
                ContentControl.Content = EmailLogin;
                ChangeModeTag.Content = "使用手机账号登录";
            }
            else
            {
                LoginMode = "CellPhone";
                ContentControl.Content = CellPhoneLogin;
                ChangeModeTag.Content = "使用邮箱账号登录";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if(LoginMode=="CellPhone")
            {
                LoadingLine.Visibility = Visibility.Visible;

                string url = "https://soutwyy.vercel.app/login/cellphone?phone=" + CellPhoneLogin.PhoneNumber_TB.Text + "&password=" + CellPhoneLogin.PassWord_TB.Password;

                string getJson = HttpUitls.Get(url);

                RootObject rt = JsonConvert.DeserializeObject<RootObject>(getJson);
                Profile pf = JsonConvert.DeserializeObject<Profile>(getJson);

                //HandyControl.Controls.MessageBox.Show(rt.code);
                if (rt.code == "200")
                {
                    Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    cfa.AppSettings.Settings["userId"].Value = pf.userId.ToString();
                    cfa.AppSettings.Settings["nickName"].Value = pf.nickname;
                    cfa.Save();
                    //MessageBox.Show(pf.nickname);
                    MainWindow mainWindow = new MainWindow();
                    /*
                    HandyControl.Controls.MessageBox.Show("" +
                                  "问IDE" +
                        "一向码字为谁作，只当趣在键中说。" +
                        "浅浅Info窗中报，繁繁Error快如梭。" +
                        "线程怒爆协程弃，修以Bug可解脱？" +
                        "漫漫环视竟不屑，指下键响屏上落。"
                                         , "——sout",
                    MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                    */
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    LoadingLine.Visibility = Visibility.Hidden;
                    HandyControl.Controls.MessageBox.Show("账号或密码错误！", "登录失败", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                LoadingLine.Visibility = Visibility.Visible;

                string url = "https://soutwyy.vercel.app/login?email=" + EmailLogin.Email_TB.Text + "&password=" + EmailLogin.PassWord_TB.Password;

                string getJson = HttpUitls.Get(url);

                RootObject rt = JsonConvert.DeserializeObject<RootObject>(getJson);
                Profile pf = JsonConvert.DeserializeObject<Profile>(getJson);

                //HandyControl.Controls.MessageBox.Show(rt.code);
                if (rt.code == "200")
                {
                    Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    cfa.AppSettings.Settings["userId"].Value = pf.userId.ToString();
                    cfa.AppSettings.Settings["nickName"].Value = pf.nickname;
                    cfa.Save();

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    Close();
                }
                else
                {
                    LoadingLine.Visibility = Visibility.Hidden;
                    HandyControl.Controls.MessageBox.Show("账号或密码错误！", "登录失败", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}

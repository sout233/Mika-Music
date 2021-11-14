using HttpJsonGet;
using Mika_Music.Models;
using Mika_Music.Models.Json;
using Mika_Music.SongInfo;
using Mika_Music.SongList;
using Mika_Music.Song.Detail;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace Mika_Music
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private DispatcherTimer timer = new DispatcherTimer();
        private DispatcherTimer stimer = new DispatcherTimer();

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

            Models.RootObject rt = JsonConvert.DeserializeObject<Models.RootObject>(getJson);
            MessageBox.Show(rt.level.ToString());
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void SearchBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter && SearchBox.Text != "")
            {
                Thread thread = new Thread(new ThreadStart(SearchSongs));
                thread.Start();
            }
        }

        private void Test()
        {
            Dispatcher.BeginInvoke((Action)(() => LoadingLine.Visibility = Visibility.Visible));
            Thread.Sleep(3000);
            Dispatcher.BeginInvoke((Action)(() => LoadingLine.Visibility = Visibility.Hidden));
        }

        private void SearchSongs()
        {
            Dispatcher.Invoke(DispatcherPriority.Normal, (ThreadStart)delegate ()
            {
                listView.Items.Clear();
                LoadingLine.Visibility = Visibility.Visible;

                string url = "https://soutwyy.vercel.app/search?keywords=" + SearchBox.Text;
                string getJson = HttpUitls.Get(url);
                Models.Json.RootObject rt = JsonConvert.DeserializeObject<Models.Json.RootObject>(getJson);

                for (int i = 0; i < rt.result.songs.Count; i++)
                {
                    Thread.Sleep(200);
                    listView.Items.Add(new SongList.Emp { SongName = rt.result.songs[i].name, Artist = rt.result.songs[i].artists[0].name, SongID = rt.result.songs[i].id });
                }

                LoadingLine.Visibility = Visibility.Hidden;
            });
        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Emp emp = listView.SelectedItem as Emp;
            if (emp != null && emp is Emp)
            {
                try
                {
                    string url = "https://soutwyy.vercel.app/song/url?id=" + emp.SongID;
                    string getJson = HttpUitls.Get(url);
                    SongInfoRoot rt = JsonConvert.DeserializeObject<SongInfoRoot>(getJson);
                    SongName_T.Text = emp.SongName;
                    Artist_T.Text = emp.Artist;

                    if (rt.data[0].url != null)
                    {
                        Line_T.Text = "线路1";
                        MusicPlay(rt.data[0].url);
                    }
                    else
                    {
                        Line_T.Text = "线路2";
                        MusicPlay("https://music.163.com/song/media/outer/url?id=" + emp.SongID + ".mp3");
                        //HandyControl.Controls.MessageBox.Show("该资源可能已经下架", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                    string picurl = "https://soutwyy.vercel.app/song/detail?ids=" + emp.SongID;
                    string picGetJson = HttpUitls.Get(picurl);
                    SongDetailRoot picRT = JsonConvert.DeserializeObject<SongDetailRoot>(picGetJson);

                    SongPic.ImageSource = new BitmapImage(new Uri(picRT.songs[0].al.picUrl,UriKind.RelativeOrAbsolute));


                }
                catch (Exception ex)
                {
                    HandyControl.Controls.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void MusicPlay(string url)
        {
            PlayerController.Kind = MahApps.Metro.IconPacks.PackIconEntypoKind.ControllerPaus;
            try
            {
                mediaElement1.Source = new Uri(url, UriKind.Absolute);
                mediaElement1.Play();
            }
            catch (Exception ex)
            {
                HandyControl.Controls.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            NowTime.Text = MusicSlider.Value.ToString();
        }

        private void MusicSlider_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mediaElement1.Position = TimeSpan.FromSeconds(MusicSlider.Value);
            timer.Start();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(timer_Tick);
            timer.Start();

            stimer.Interval = TimeSpan.FromMilliseconds(500);
            stimer.Tick += new EventHandler(stimer_Tick);
        }

        private void stimer_Tick(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //使播放进度条跟随播放时间移动
            MusicSlider.ToolTip = mediaElement1.Position.ToString().Substring(0, 8);

            if (mediaElement1.NaturalDuration.HasTimeSpan)
            {
                MusicSlider.Maximum = (int)mediaElement1.NaturalDuration.TimeSpan.TotalSeconds;
                MusicSlider.Value = (int)mediaElement1.Position.TotalSeconds;
            }


            // txtTime.Text = mediaElement.Position.ToString().Substring(0, 8);

            NowTime.Text = string.Format(
                               "{0}{1:00}:{2:00}:{3:00}",
                               "播放进度：",
                               mediaElement1.Position.Hours,
                               mediaElement1.Position.Minutes,
                               mediaElement1.Position.Seconds);
        }

        private void MusicSlider_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //MessageBox.Show("1");
            timer.Stop();
        }

        private void MusicSlider_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            timer.Stop();
        }

        private void MusicSlider_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            mediaElement1.Position = TimeSpan.FromSeconds(MusicSlider.Value);
            timer.Start();
        }

        private void PackIconEntypo_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if(PlayerController.Kind.ToString()== "ControllerPlay")
            {
                mediaElement1.Play();
                PlayerController.Kind = MahApps.Metro.IconPacks.PackIconEntypoKind.ControllerPaus;
            }
            else
            {
                mediaElement1.Pause();
                PlayerController.Kind = MahApps.Metro.IconPacks.PackIconEntypoKind.ControllerPlay;
            }
        }

        private void PackIconMaterial_MouseLeftButtonUp_1(object sender, MouseButtonEventArgs e)
        {
            Downloader downloader = new Downloader();
            downloader.SongUrl = mediaElement1.Source.ToString();
            downloader.SongName = SongName_T.Text;
            downloader.SongArtist = Artist_T.Text;
            downloader.Show();
        }
    }
}

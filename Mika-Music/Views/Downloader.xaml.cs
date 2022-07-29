using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Threading;
using System.Windows;

namespace Mika_Music
{
    /// <summary>
    /// Downloader.xaml 的交互逻辑
    /// </summary>
    public partial class Downloader : Window
    {
        public string SongUrl;
        public string SongName;
        public string SongArtist;

        public Downloader()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog("请选择一个文件夹");
            dialog.IsFolderPicker = true; //选择文件还是文件夹（true:选择文件夹，false:选择文件）
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                PathBox.Text = dialog.FileName;
                Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                cfa.AppSettings.Settings["SetFilePath"].Value = PathBox.Text;
                cfa.Save();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (PathBox.Text != "" && Directory.Exists(PathBox.Text))
            {
                DownloadFileFromServer();
            }
            else if(PathBox.Text== Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Download"))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Download"));
                directoryInfo.Create();
                DownloadFileFromServer();
            }
            else
                HandyControl.Controls.MessageBox.Show("请确保储存位置正确", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void DownloadFileFromServer()
        {
            string serverFilePath = SongUrl;
            if (!Directory.Exists(PathBox.Text))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(PathBox.Text);
                directoryInfo.Create();
            }
            string targetPath = PathBox.Text + "\\" + SongName + " - " + SongArtist + ".mp3";
            DownloadFile(serverFilePath, targetPath);
        }

        public void DownloadFile(string serverFilePath, string targetPath)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(serverFilePath);
                WebResponse respone = request.GetResponse();
                Stream netStream = respone.GetResponseStream();
                using (Stream fileStream = new FileStream(targetPath, FileMode.Create))
                {
                    byte[] read = new byte[1024];
                    int realReadLen = netStream.Read(read, 0, read.Length);
                    long progressBarValue = 0;
                    while (realReadLen > 0)
                    {
                        Dispatcher.Invoke(new Action(() => fileStream.Write(read, 0, realReadLen)));
                        progressBarValue += realReadLen;
                        Dispatcher.Invoke(new Action(() => pbDown.Dispatcher.BeginInvoke(new ProgressBarSetter(SetProgressBar), progressBarValue)));
                        Dispatcher.Invoke(new Action(() => realReadLen = netStream.Read(read, 0, read.Length)));
                    }
                    netStream.Close();
                    fileStream.Close();
                }
            }
            catch(Exception ex)
            {
                HandyControl.Controls.MessageBox.Show("错误，但是已经将链接复制到剪贴板："+SongUrl, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Clipboard.SetDataObject(SongUrl);
                HandyControl.Controls.MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                //System.Diagnostics.Process.Start("explorer.exe", SongUrl);
            }
        }

        public delegate void ProgressBarSetter(double value);
        public void SetProgressBar(double value)
        {
            pbDown.Value = value;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Configuration cfa = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

            if (cfa.AppSettings.Settings["SetFilePath"].Value == "null")
            {
                PathBox.Text = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Download");
            }

            SongName_T.Text = SongName;
            ArtistName_T.Text = SongArtist;
        }
    }
}

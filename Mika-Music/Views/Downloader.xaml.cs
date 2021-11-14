using Microsoft.WindowsAPICodePack.Dialogs;
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
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (PathBox.Text != "" && System.IO.Directory.Exists(PathBox.Text))
            {
                WebRequest request = WebRequest.Create(SongUrl);
                WebResponse respone = request.GetResponse();
                pbDown.Maximum = respone.ContentLength;
                string path = PathBox.Text;
                ThreadPool.QueueUserWorkItem((obj) =>
                {
                    Stream netStream = respone.GetResponseStream();
                    Stream fileStream = new FileStream(path, FileMode.Create);
                    byte[] read = new byte[1024];
                    long progressBarValue = 0;
                    int realReadLen = netStream.Read(read, 0, read.Length);
                    while (realReadLen > 0)
                    {
                        fileStream.Write(read, 0, realReadLen);
                        progressBarValue += realReadLen;
                        pbDown.Dispatcher.BeginInvoke(new ProgressBarSetter(SetProgressBar), progressBarValue);
                        realReadLen = netStream.Read(read, 0, read.Length);
                    }
                    netStream.Close();
                    fileStream.Close();

                }, null);
            }
            else
                HandyControl.Controls.MessageBox.Show("请确保储存位置正确", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public delegate void ProgressBarSetter(double value);
        public void SetProgressBar(double value)
        {
            pbDown.Value = value;
        }
    }
}

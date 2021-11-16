using Mika_Music.Models.Json.LrcAna;
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

namespace Mika_Music.Views
{
    /// <summary>
    /// SongPlane.xaml 的交互逻辑
    /// </summary>
    public partial class SongPlane : UserControl
    {
        public SongPlane()
        {
            InitializeComponent();

            Lrc lrc = Lrc.InitLrc("C:\\Users\\sout\\Desktop\\111.lrc");
            Dictionary<double, string> openWith = lrc.LrcWord;
            LrcBox.IsReadOnly = true;
            

            foreach (string value in openWith.Values)
            {
                string myText = value;
                FlowDocument doc = LrcBox.Document;
                Run r = new Run(myText);
                Paragraph p = new Paragraph();
                p.Inlines.Add(r);
                doc.Blocks.Add(p);
                LrcBox.Document = doc;
                LrcBox.ScrollToEnd();
            }
        }
    }
}

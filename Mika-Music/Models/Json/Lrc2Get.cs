using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mika_Music.Models.Json
{
    public class TransUser
    {
        public string id { get; set; }
        public string status { get; set; }
        public string demand { get; set; }
        public string userid { get; set; }
        public string nickname { get; set; }
        public string uptime { get; set; }
    }

    public class Lrc
    {
        public string version { get; set; }
        public string lyric { get; set; }
    }

    public class Klyric
    {
        public string version { get; set; }
        public string lyric { get; set; }
    }

    public class Tlyric
    {
        public string version { get; set; }
        public string lyric { get; set; }
    }

    public class Lrc2Root
    {
        public string sgc { get; set; }
        public string sfy { get; set; }
        public string qfy { get; set; }
        public TransUser transUser { get; set; }
        public Lrc lrc { get; set; }
        public Klyric klyric { get; set; }
        public Tlyric tlyric { get; set; }
        public string code { get; set; }
    }
}

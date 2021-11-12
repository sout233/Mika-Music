using System;
using System.Collections.Generic;
using System.Text;

namespace Mika_Music.SongInfo
{
    public class FreeTrialInfo
    {
        public string start { get; set; }
        public string end { get; set; }
    }

    public class FreeTrialPrivilege
    {
        public string resConsumable { get; set; }
        public string userConsumable { get; set; }
    }

    public class FreeTimeTrialPrivilege
    {
        public string resConsumable { get; set; }
        public string userConsumable { get; set; }
        public string type { get; set; }
        public string remainTime { get; set; }
    }

    public class Data
    {
        public string id { get; set; }
        public string url { get; set; }
        public string br { get; set; }
        public string size { get; set; }
        public string md5 { get; set; }
        public string code { get; set; }
        public string expi { get; set; }
        public string type { get; set; }
        public string gain { get; set; }
        public string fee { get; set; }
        public string uf { get; set; }
        public string payed { get; set; }
        public string flag { get; set; }
        public string canExtend { get; set; }
        public FreeTrialInfo freeTrialInfo { get; set; }
        public string level { get; set; }
        public string encodeType { get; set; }
        public FreeTrialPrivilege freeTrialPrivilege { get; set; }
        public FreeTimeTrialPrivilege freeTimeTrialPrivilege { get; set; }
        public string urlSource { get; set; }
    }

    public class SongInfoRoot
    {
        public List<Data> data { get; set; }
        public string code { get; set; }
    }
}

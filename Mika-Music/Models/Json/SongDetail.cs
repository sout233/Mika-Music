using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mika_Music.Song.Detail
{
    public class Alias
    {
    }

    public class Ar
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Tns> tns { get; set; }
        public List<Alias> alias { get; set; }
    }


    public class Tns
    {
    }

    public class Al
    {
        public string id { get; set; }
        public string name { get; set; }
        public string picUrl { get; set; }
        public List<Tns> tns { get; set; }
        public string pic_str { get; set; }
        public string pic { get; set; }
    }

    public class H
    {
        public string br { get; set; }
        public string fid { get; set; }
        public string size { get; set; }
        public string vd { get; set; }
    }

    public class M
    {
        public string br { get; set; }
        public string fid { get; set; }
        public string size { get; set; }
        public string vd { get; set; }
    }

    public class L
    {
        public string br { get; set; }
        public string fid { get; set; }
        public string size { get; set; }
        public string vd { get; set; }
    }

    public class RtUrls
    {
    }

    public class Songs
    {
        public string name { get; set; }
        public string id { get; set; }
        public string pst { get; set; }
        public string t { get; set; }
        public List<Ar> ar { get; set; }
        public string pop { get; set; }
        public string st { get; set; }
        public string rt { get; set; }
        public string fee { get; set; }
        public string v { get; set; }
        public string crbt { get; set; }
        public string cf { get; set; }
        public Al al { get; set; }
        public string dt { get; set; }
        public H h { get; set; }
        public M m { get; set; }
        public L l { get; set; }
        public string a { get; set; }
        public string cd { get; set; }
        public string no { get; set; }
        public string rtUrl { get; set; }
        public string ftype { get; set; }
        public List<RtUrls> rtUrls { get; set; }
        public string djId { get; set; }
        public string copyright { get; set; }
        public string s_id { get; set; }
        public string mark { get; set; }
        public string originCoverType { get; set; }
        public string originSongSimpleData { get; set; }
        public string tagPicList { get; set; }
        public string resourceState { get; set; }
        public string version { get; set; }
        public string songJumpInfo { get; set; }
        public string single { get; set; }
        public string noCopyrightRcmd { get; set; }
        public string rtype { get; set; }
        public string rurl { get; set; }
        public string mst { get; set; }
        public string cp { get; set; }
        public string mv { get; set; }
        public string publishTime { get; set; }
    }

    public class FreeTrialPrivilege
    {
        public string resConsumable { get; set; }
        public string userConsumable { get; set; }
    }

    public class ChargeInfoList
    {
        public string rate { get; set; }
        public string chargeUrl { get; set; }
        public string chargeMessage { get; set; }
        public string chargeType { get; set; }
    }

    public class Privileges
    {
        public string id { get; set; }
        public string fee { get; set; }
        public string payed { get; set; }
        public string st { get; set; }
        public string pl { get; set; }
        public string dl { get; set; }
        public string sp { get; set; }
        public string cp { get; set; }
        public string subp { get; set; }
        public string cs { get; set; }
        public string maxbr { get; set; }
        public string fl { get; set; }
        public string toast { get; set; }
        public string flag { get; set; }
        public string preSell { get; set; }
        public string playMaxbr { get; set; }
        public string downloadMaxbr { get; set; }
        public string rscl { get; set; }
        public FreeTrialPrivilege freeTrialPrivilege { get; set; }
        public List<ChargeInfoList> chargeInfoList { get; set; }
    }

    public class SongDetailRoot
    {
        public List<Songs> songs { get; set; }
        public List<Privileges> privileges { get; set; }
        public string code { get; set; }
    }
}

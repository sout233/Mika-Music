using System;
using System.Collections.Generic;
using System.Text;

namespace Mika_Music.Models
{
    public class UserPoint
    {
        public string userId { get; set; }
        public string balance { get; set; }
        public string updateTime { get; set; }
        public string version { get; set; }
        public string status { get; set; }
        public string blockBalance { get; set; }
    }

    public class Experts
    {
    }

    public class ArtistIdentity
    {
    }

    public class Profile
    {
        public string avatarDetail { get; set; }
        public string userId { get; set; }
        public string avatarUrl { get; set; }
        public string nickname { get; set; }
        public string birthday { get; set; }
        public string avatarImgId { get; set; }
        public string vipType { get; set; }
        public string userType { get; set; }
        public string createTime { get; set; }
        public string gender { get; set; }
        public string mutual { get; set; }
        public string followed { get; set; }
        public string remarkName { get; set; }
        public string authStatus { get; set; }
        public string detailDescription { get; set; }
        public Experts experts { get; set; }
        public string expertTags { get; set; }
        public string djStatus { get; set; }
        public string accountStatus { get; set; }
        public string province { get; set; }
        public string city { get; set; }
        public string defaultAvatar { get; set; }
        public string backgroundImgId { get; set; }
        public string backgroundUrl { get; set; }
        public string description { get; set; }
        public string avatarImgIdStr { get; set; }
        public string backgroundImgIdStr { get; set; }
        public string signature { get; set; }
        public string authority { get; set; }
        public string followeds { get; set; }
        public string follows { get; set; }
        public string blacklist { get; set; }
        public string eventCount { get; set; }
        public string allSubscribedCount { get; set; }
        public string playlistBeSubscribedCount { get; set; }
        public string avatarImgId_str { get; set; }
        public string followTime { get; set; }
        public string followMe { get; set; }
        public List<ArtistIdentity> artistIdentity { get; set; }
        public string cCount { get; set; }
        public string sDJPCount { get; set; }
        public string playlistCount { get; set; }
        public string sCount { get; set; }
        public string newFollows { get; set; }
    }

    public class Bindings
    {
        public string userId { get; set; }
        public string expiresIn { get; set; }
        public string refreshTime { get; set; }
        public string bindingTime { get; set; }
        public string tokenJsonStr { get; set; }
        public string expired { get; set; }
        public string url { get; set; }
        public string id { get; set; }
        public string type { get; set; }
    }

    public class ProfileVillageInfo
    {
        public string title { get; set; }
        public string imageUrl { get; set; }
        public string targetUrl { get; set; }
    }

    public class RootObject
    {
        public string level { get; set; }
        public string listenSongs { get; set; }
        public UserPoint userPoint { get; set; }
        public string mobileSign { get; set; }
        public string pcSign { get; set; }
        public Profile profile { get; set; }
        public string peopleCanSeeMyPlayRecord { get; set; }
        public List<Bindings> bindings { get; set; }
        public string adValid { get; set; }
        public string code { get; set; }
        public string createTime { get; set; }
        public string createDays { get; set; }
        public ProfileVillageInfo profileVillageInfo { get; set; }
    }
}

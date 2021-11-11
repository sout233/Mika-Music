namespace Mika_Music.Models.Json.Status
{
    //如果好用，请收藏地址，帮忙分享。
    public class AccountData
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string account { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string profile { get; set; }
    }

    public class Root
    {
        /// <summary>
        /// 
        /// </summary>
        public AccountData data { get; set; }
    }

}

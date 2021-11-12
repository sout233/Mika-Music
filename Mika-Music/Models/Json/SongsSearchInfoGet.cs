using System;
using System.Collections.Generic;
using System.Text;

namespace Mika_Music.Models.Json
{
    public class Artists
    {
        public string id { get; set; }
        public string name { get; set; }
        public string picUrl { get; set; }
        public string albumSize { get; set; }
        public string picId { get; set; }
        public string img1v1Url { get; set; }
        public string img1v1 { get; set; }
        public string trans { get; set; }
    }


    public class Artist
    {
        public string id { get; set; }
        public string name { get; set; }
        public string picUrl { get; set; }
        public string albumSize { get; set; }
        public string picId { get; set; }
        public string img1v1Url { get; set; }
        public string img1v1 { get; set; }
        public string trans { get; set; }
    }

    public class Album
    {
        public string id { get; set; }
        public string name { get; set; }
        public Artist artist { get; set; }
        public string publishTime { get; set; }
        public string size { get; set; }
        public string copyrightId { get; set; }
        public string status { get; set; }
        public string picId { get; set; }
        public string mark { get; set; }
    }

    public class Songs
    {
        public string id { get; set; }
        public string name { get; set; }
        public List<Artists> artists { get; set; }
        public Album album { get; set; }
        public string duration { get; set; }
        public string copyrightId { get; set; }
        public string status { get; set; }
        public string rtype { get; set; }
        public string ftype { get; set; }
        public string mvid { get; set; }
        public string fee { get; set; }
        public string rUrl { get; set; }
        public string mark { get; set; }
    }

    public class Result
    {
        public List<Songs> songs { get; set; }
        public string hasMore { get; set; }
        public string songCount { get; set; }
    }

    public class RootObject
    {
        public Result result { get; set; }
        public string code { get; set; }
    }
}

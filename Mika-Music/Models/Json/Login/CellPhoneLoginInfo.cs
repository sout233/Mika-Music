using System;
using System.Collections.Generic;
using System.Text;

namespace Mika_Music.Models.Json.Login
{
    public class RootObject
    {
        public string msg { get; set; }
        public string code { get; set; }
        public string message { get; set; }
    }

    public class Profile
    {
        public int userId { get; set; }

        public string nickname { get; set; }
    }
}

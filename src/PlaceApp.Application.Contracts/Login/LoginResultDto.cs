using System;
using System.Collections.Generic;
using System.Text;

namespace PlaceApp.Login
{
    public class LoginResultDto
    {
        public int result { get; set; } = 2;
        public string description { get; set; }
        public string token { get; set; }
        public string tokenType { get; set; }
        public string expireIn { get; set; }
    }
}

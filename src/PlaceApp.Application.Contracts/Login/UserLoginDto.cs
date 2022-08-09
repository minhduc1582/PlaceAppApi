using System;
using System.Collections.Generic;
using System.Text;

namespace PlaceApp.Login
{
    public class UserLoginDto
    {
        public string userNameOrEmailAddress { get; set; }
        public string password { get; set; }
        public bool rememberMe { get; set; }
    }
}

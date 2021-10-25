using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class LoginVM
    {
        public string UserName { get; set; }

        public string Password { get; set; }
        
        public bool RememberMe { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? PersonnelCode { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public string Gender { get; set; }

    }
}

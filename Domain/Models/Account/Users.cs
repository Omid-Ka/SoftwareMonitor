using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;

namespace Domain.Models.Account
{
    public class Users : BaseEntity
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int? PersonnelCode { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public int GenderId { get; set; }
        public virtual Lookup Gender { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace Core.ViewModels
{
    public class LookupVM
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Information { get; set; }
        public int? ReferenceID { get; set; }
        public int Category { get; set; }
    }
}

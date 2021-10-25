using System;
using System.Collections.Generic;
using System.Text;

namespace Core.DTO
{
    public class BaseDTO
    {
        public int Id { get; set; }
        public int CreatorID { get; set; }
        public DateTime DateInserted { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? DateModified { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class TeamDetailVM
    {
        public int Id { get; set; }
        public int TeamId { get; set; }
        public int? UserId { get; set; }
        public string Member { get; set; }
        public string Position { get; set; }
    }
}

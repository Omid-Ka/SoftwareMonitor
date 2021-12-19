using System;
using System.Collections.Generic;
using System.Text;

namespace Core.ViewModels
{
    public class ShowNotification
    {
        public int Id { get; set; }
        public int EntityId { get; set; }
        public string EntityType { get; set; }
        public string Description { get; set; }
        public bool Seen { get; set; }
        public string  Time { get; set; }   

    }
}

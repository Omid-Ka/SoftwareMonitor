using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;

namespace Core.ViewModels
{
    public class ShowAccessVM
    {
        public int Id { get; set; }

        public string text { get; set; }

        public bool IsChecked { get; set; }

        public bool hasChildren { get; set; }

        public virtual List<ShowAccessVM> children { get; set; }
    }
}

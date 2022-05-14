using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;
using System.Text;

namespace Core.ViewModels
{
    public class AllReportInformationVM
    {
        public int HeaderId { get; set; }
        public int ProjectId { get; set; }
        public int VersionId { get; set; }

        public List<DocReviewVM> DocReviewList { get; set; }

        public CodeReviewVM CodeReview { get; set; }

        public CreateLoadOrStrssTest LoadOrStrssTestsList { get; set; }
    }
}

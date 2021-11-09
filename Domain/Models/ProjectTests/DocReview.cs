using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Enum;

namespace Domain.Models.ProjectTests
{
    public class DocReview:BaseEntity
    {
        public int TestHeaderId { get; set; }
        public virtual TestHeader TestHeader { get; set; }

        public DocReviewTitle DocReviewTitle { get; set; }

        public DocReviewAnswer DocReviewAnswer { get; set; }
        public string Discription { get; set; }

    }
}

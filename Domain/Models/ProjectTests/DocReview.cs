using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Models.Enum;

namespace Domain.Models.ProjectTests
{
    public class DocReview:BaseEntity
    {
        public int TestHeaderId { get; set; }
        public virtual TestHeader TestHeader { get; set; }
        public DocReviewTitle DocReviewTitle { get; set; }
        [Display(Name = "پاسخ")]
        public DocReviewAnswer DocReviewAnswer { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }

    }
}

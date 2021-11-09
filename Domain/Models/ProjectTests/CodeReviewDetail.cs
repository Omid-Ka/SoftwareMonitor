using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Enum;

namespace Domain.Models.ProjectTests
{
    public class CodeReviewDetail:BaseEntity
    {
        public int CodeReviewId { get; set; }
        public CodeReview CodeReview { get; set; }
        public CodeReviewDetailType DetailType { get; set; }
        public int? IndicatorId { get; set; }
        public virtual  Lookup Indicator { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }

    }
}

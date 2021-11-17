using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Models.Enum;
using Domain.Models.ProjectTests;

namespace Core.ViewModels
{
    public class CreateCodeReviewVM
    {
        public int HeaderId { get; set; }
        public int CodeId { get; set; }
        [Display(Name = "پروژه")]
        public int ProjectId { get; set; }
        [Display(Name = "تعداد کل خطوط")]
        public int AllCountRow { get; set; }
        [Display(Name = "گروه های تطابق")]
        public int MatchGroups { get; set; }
        [Display(Name = "تطابق دقیق")]
        public int AccurateMatch { get; set; }
        [Display(Name = "تطابق زیاد")]
        public int HighMatch { get; set; }
        [Display(Name = "تطابق معمولی")]
        public int NormalMatch { get; set; }
        [Display(Name = "تطابق ضعیف")]
        public int PoorMatch { get; set; }
        [Display(Name = "پیشنهادات")]
        public string Offers { get; set; }
        public List<CodeReviewDetailVM> CodeReviewDetailList { get; set; }
    }


    public class CodeReviewVM
    {
        public int HeaderId { get; set; }
        public int CodeId { get; set; }
        [Display(Name = "پروژه")]
        public int ProjectId { get; set; }
        [Display(Name = "تعداد کل خطوط")]
        public int AllCountRow { get; set; }
        [Display(Name = "گروه های تطابق")]
        public int MatchGroups { get; set; }
        [Display(Name = "تطابق دقیق")]
        public int AccurateMatch { get; set; }
        [Display(Name = "تطابق زیاد")]
        public int HighMatch { get; set; }
        [Display(Name = "تطابق معمولی")]
        public int NormalMatch { get; set; }
        [Display(Name = "تطابق ضعیف")]
        public int PoorMatch { get; set; }
        [Display(Name = "پیشنهادات")]
        public string Offers { get; set; }
    }


    public class CodeReviewDetailVM
    {
        public int CodeReviewId { get; set; }
        public CodeReviewDetailType DetailType { get; set; }
        public int? IndicatorId { get; set; }
        public string IndicatorDesc { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }
    }
}

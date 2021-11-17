using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Models.Enum;

namespace Core.ViewModels
{
    public class CreateTestVM
    {
        public int Id { get; set; }
        [Display(Name = "نوع آزمون")]
        public TestType TestType { get; set; }
        [Display(Name = "عنوان آزمون")]
        public int TitleId { get; set; }
        [Display(Name = "پروژه")]
        public int ProjectId { get; set; }
        public List<DocReviewVM> DocReviewList { get; set; }
    }

    public class GetTestHeaderVM
    {
        [Display(Name = "نوع آزمون")]
        public TestType TestType { get; set; }
        [Display(Name = "عنوان آزمون")]
        public int TitleId { get; set; }
        [Display(Name = "پروژه")]
        public int ProjectId { get; set; }
    }


    public class DocReviewVM
    {
        public int  Id { get; set; }
        public int  HeaderId { get; set; }
        public DocReviewTitle DocReviewTitle { get; set; }
        [Display(Name = "پاسخ")]
        public DocReviewAnswer DocReviewAnswer { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
    }

}

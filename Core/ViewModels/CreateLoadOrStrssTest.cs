using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.ViewModels
{
    public class CreateLoadOrStrssTest
    {
        [Display(Name = "نوع عنوان تست")]
        public int TitleId { get; set; }
        [Display(Name = "پروژه")]
        public int ProjectId { get; set; }
        [Display(Name = "کل درخواست ها")]
        public int TotalRequest { get; set; }
        [Display(Name = "درخواست های موفق")]
        public int SuccessRequest { get; set; }
        [Display(Name = "درخواست های خطا")]
        public int FailRequest { get; set; }
        [Display(Name = "زمان پاسخگویی")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal AveTime { get; set; }
        [Display(Name = "توانایی سرور")]
        public int Throughput { get; set; }
        [Display(Name = "انحراف")]
        public int Deviation { get; set; }

        public int HeaderId { get; set; }
        public int TestId { get; set; } 

    }
}

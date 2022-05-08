using Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Models.ProjectTests;

namespace Core.ViewModels
{
    public class TestHeaderVM
    {
        public int Id { get; set; }
        [Display(Name = "نوع آزمون")]
        public TestType TestType { get; set; }
        [Display(Name = "عنوان آزمون")]
        public int TitleId { get; set; }
        public string Title { get; set; }
        public int? EntityId { get; set; }
        public string EntityType { get; set; }
        [Display(Name = "پروژه")]
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime DateInserted { get; set; }
        public string StatusOfCharts { get; set; }
        public string Version { get; set; }
        public string MatchGroups { get; set; }
        public string AllCountRow { get; set; }

    }


}

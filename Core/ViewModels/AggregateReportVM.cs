using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Domain.Models.Enum;

namespace Core.ViewModels
{
    public class AggregateReportVM
    {
        public int ProjectId { get; set; }

        public string CodeReviewVersions { get; set; }  

        public List<CodeReviewVersions> CodeReviewVersionsList { get; set; }

        public List<DocReviewVersions> DocReviewVersionsList { get; set; }

        public string LoadOrStrssVersions { get; set; }

        public List<CreateLoadOrStrssTest> CreateLoadOrStrssTests { get; set; }



    }

    public class CodeReviewVersions
    {
        public string Version { get; set; }
        public int AllCountRow { get; set; }
        public int MatchGroups { get; set; }
        public int AccurateMatch { get; set; }
        public int HighMatch { get; set; }
        public int NormalMatch { get; set; }
        public int PoorMatch { get; set; }
        public decimal PercentAccurateMatch { get; set; }
        public decimal PercentHighMatch { get; set; }
        public decimal PercentNormalMatch { get; set; }
        public decimal PercentPoorMatch { get; set; }


        public int Readability { get; set; }
        public int ObjectOriented { get; set; }
        public int CodeSecurity { get; set; }
        public int UseOfResources { get; set; }
        public int Complexity { get; set; }
        public int Warning { get; set; }
        
    }

    public class DocReviewVersions
    {
        public string Version { get; set; }
        public DocReviewAnswer SequenceDiagram { get; set; }
        public DocReviewAnswer ActivityDiagram { get; set; }
        public DocReviewAnswer ApplicationDiagram { get; set; }
        public DocReviewAnswer ClassDiagram { get; set; }
        public DocReviewAnswer Modules { get; set; }
        public DocReviewAnswer ActivityDescription { get; set; }

    }

}

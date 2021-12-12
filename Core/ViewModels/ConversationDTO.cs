using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Enum;

namespace Core.ViewModels
{
    public class ConversationDTO
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public int versionId { get; set; }
        public string version { get; set; }

        public List<ConversationDetail> ConversationDetails { get; set; }   

    }

    public class ConversationDetail
    {
        public string Description { get; set; }
        public string SendedUser { get; set; }
        public string SendDate { get; set; }
        public bool IsMine { get; set; }
        public TypeOfCommand Type { get; set; }
    }
}

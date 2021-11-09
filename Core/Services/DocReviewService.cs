using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;

namespace Core.Services
{
    public class DocReviewService : IDocReviewService
    {
        private IUserLogRepository _userLogRepository;

        public DocReviewService(IUserLogRepository userLogRepository)
        {
            _userLogRepository = userLogRepository;
        }
        
    }
}

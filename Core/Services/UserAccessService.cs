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
using Domain.Models.Access;

namespace Core.Services
{
    public class UserAccessService : IUserAccessService
    {
        private IUserAccessRepository _userAccessRepository;

        public UserAccessService(IUserAccessRepository userAccessRepository)
        {
            _userAccessRepository = userAccessRepository;
        }

        public IEnumerable<UserAccess> GetAllByUserId(int userid)
        {
            return _userAccessRepository.GetAllAccessByUserId(userid);
        }
    }
}

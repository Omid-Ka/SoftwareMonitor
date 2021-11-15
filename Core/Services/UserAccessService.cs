using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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
        private IAccessRepository _accessRepository;

        public UserAccessService(IUserAccessRepository userAccessRepository, IAccessRepository accessRepository)
        {
            _userAccessRepository = userAccessRepository;
            _accessRepository = accessRepository;
        }

        public IEnumerable<UserAccess> GetAllByUserId(int userid)
        {
            return _userAccessRepository.GetAllAccessByUserId(userid);
        }

        public bool ChangeUserAccess(int[] intIds, int userid, ClaimsPrincipal user)
        {
            var UserAccess = _userAccessRepository.GetAllAccessByUserId(userid);
            var AllAccess = _accessRepository.GetAllAccess();

            var DeletedAccess = UserAccess.Where(x => !intIds.Contains(x.AccessId)).ToList();

            foreach (var item in DeletedAccess)
            {
                _userAccessRepository.DeleteAccess(item, user);
            }

            var UserAccessIds = UserAccess.Select(x => x.AccessId).ToArray();
            var NewAccess = AllAccess.Where(x => intIds.Contains(x.Id) && !UserAccessIds.Contains(x.Id)).ToList();

            foreach (var access in NewAccess)
            {
                _userAccessRepository.AddNewAccess(access.Id, userid, user);
            }

            return true;
        }

    }
}

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
    public class AccessGroupDetailService : IAccessGroupDetailService
    {
        private IAccessGroupDetailRepository _accessGroupDetailRepository;
        private IUserAccessRepository _userAccessRepository;

        public AccessGroupDetailService(IAccessGroupDetailRepository accessGroupDetailRepository, IUserAccessRepository userAccessRepository)
        {
            _accessGroupDetailRepository = accessGroupDetailRepository;
            _userAccessRepository = userAccessRepository;
        }

        public void AddGroupDetail(AccessGroupDetail accessGroupDetail, ClaimsPrincipal user)
        {
            _accessGroupDetailRepository.AddGroupDetail(accessGroupDetail, user);
        }

        public void DisableAllAccessByGroupId(int AccessGroupId, ClaimsPrincipal user)
        {
            _accessGroupDetailRepository.DeleteAllByGroupId(AccessGroupId, user);
        }

        public List<AccessGroupDetail> GetAllDetailByGroupId(int id)
        {
            return _accessGroupDetailRepository.GetAllUsedAccess().Where(x=>x.AccessGroupId == id).ToList();
        }

        public bool UserHasAccess(int id, int userId)
        {
            var data = _userAccessRepository.GetAllAccessByUserId(userId);



            return data.Any(x => x.AccessId == id);
        }
    }
}

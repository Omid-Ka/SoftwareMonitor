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

        public AccessGroupDetailService(IAccessGroupDetailRepository accessGroupDetailRepository)
        {
            _accessGroupDetailRepository = accessGroupDetailRepository;
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
    }
}

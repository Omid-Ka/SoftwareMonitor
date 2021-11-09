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
    public class AccessGroupService : IAccessGroupService
    {
        private IAccessGroupRepository _accessGroupRepository ;
        private IAccessGroupDetailRepository _accessGroupDetailRepository ;

        public AccessGroupService(IAccessGroupRepository accessGroupRepository, IAccessGroupDetailRepository accessGroupDetailRepository)
        {
            _accessGroupRepository = accessGroupRepository;
            _accessGroupDetailRepository = accessGroupDetailRepository;
        }

        public IEnumerable<AccessGroup> GetAllGroups()
        {
            return _accessGroupRepository.GetAllGroups();
        }

        public bool HasDuplicate(string groupName)
        {
            return _accessGroupRepository.HasDuplicate(groupName);
        }

        public void AddAccessGroup(AccessGroup entity, ClaimsPrincipal user)
        {
            _accessGroupRepository.AddAccessGroup(entity, user);
        }

        public void DeleteGroup(int id, ClaimsPrincipal user)
        {

            _accessGroupDetailRepository.DeleteAllByGroupId(id, user);
            _accessGroupRepository.DeleteGroup(id,user);
        }

        public AccessGroup GetById(int id)
        {
            return _accessGroupRepository.GetById(id);
        }

        public void UpdateAccessGroup(AccessGroup entity, ClaimsPrincipal user)
        {
            _accessGroupRepository.UpdateAccessGroup(entity, user);
        }
    }
}

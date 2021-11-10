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
    public class AccessService : IAccessService
    {
        private IAccessRepository _accessRepository;
        private IAccessGroupDetailRepository _accessGroupDetailRepository;

        public AccessService(IAccessRepository accessRepository, IAccessGroupDetailRepository accessGroupDetailRepository)
        {
            _accessRepository = accessRepository;
            _accessGroupDetailRepository = accessGroupDetailRepository;
        }
        public List<AccessVM> GetAllNotUsedAccess()
        {
            var UsedAcces = _accessGroupDetailRepository.GetAllUsedAccess().Select(x=>x.AccessId).ToArray();

            var AccessModel = _accessRepository.GetAllAccess().Where(x=>!UsedAcces.Contains(x.Id)).Select(x=>new AccessVM()
            {
                AccessId = x.Id,
                AccessName = x.Name,
                Selected = SelectedAccess(x.Id, UsedAcces)
            });
            return AccessModel.ToList();
        }

        private bool SelectedAccess(int id, int[] usedAcces)
        {
            var Has = usedAcces.Contains(id);
            return Has;
        }

        public List<AccessVM> GetAllCurrentAccessByGroupId(int id)
        {
            return _accessRepository.GetAllCurrentAccessByGroupId(id).Select(x => new AccessVM()
            {
                AccessId = x.Id,
                AccessName = x.Name,
                Selected = true
            }).ToList();
        }

        public List<AccessVM> GetAllByGroupId(int groupId)
        {
            var AccessModel = _accessGroupDetailRepository.GetAllUsedAccess().Where(x=>x.AccessGroupId == groupId).Select(x=>x.AccessId).ToArray();

            var Access = _accessRepository.GetAllAccess().Where(x => AccessModel.Contains(x.Id)).Select(x =>
                new AccessVM()
                {
                    AccessId = x.Id,
                    AccessName = x.Name,
                    Selected = false
                }).ToList();

            return Access;

        }

        public string[] GetAllByIds(int[] accessIds)
        {
            return _accessRepository.GetAllAccess().Where(x => accessIds.Contains(x.Id)).Select(x => x.Name).ToArray();
        }
    }
}

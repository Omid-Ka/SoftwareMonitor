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

namespace Core.Services
{
    public class ProjectUsersRelationService : IProjectUsersRelationService
    {
        private IProjectUsersRelationRepository _projectUsersRelationRepository;

        public ProjectUsersRelationService(IProjectUsersRelationRepository projectUsersRelationRepository)
        {
            _projectUsersRelationRepository = projectUsersRelationRepository;
        }

        public bool ChangeUserprojectRelations(int[] Ids, int userid, ClaimsPrincipal user)
        {

            var ProjectAccess = _projectUsersRelationRepository.GetAllProjectByUserId(userid);

            var RemovedAccess = ProjectAccess.Where(x => !Ids.Contains(x.ProjectId)).Select(x=>x.ProjectId).ToList();

            foreach (var ProjectId in RemovedAccess)
            {
                _projectUsersRelationRepository.RemoveAccess(ProjectId, userid, user);
            }

            //var AddedAccess = ProjectAccess.Where(x => Ids.Contains(x.ProjectId)).Select(x => x.ProjectId).ToList();

            foreach (var ProjectId in Ids)
            {
                _projectUsersRelationRepository.AddedAccess(ProjectId, userid, user);
            }

            return true;
        }
    }
}

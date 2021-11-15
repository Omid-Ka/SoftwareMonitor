using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.Projects;

namespace Domain.Interfaces
{
    public interface IProjectUsersRelationRepository
    {
        List<ProjectUsersRelation> GetAllProjectByUserId(int userId);
    }
}

using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Domain.Models.Teams;

namespace Core.Interfaces
{
    public interface ITeamService
    {
        IEnumerable<Team> GetAll();
    }
}

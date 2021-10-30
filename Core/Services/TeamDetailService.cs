using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class TeamDetailService : ITeamDetailService
    {
        private ITeamDetailRepository _teamDetailRepository;

        public TeamDetailService(ITeamDetailRepository teamDetailRepository)
        {
            _teamDetailRepository = teamDetailRepository;
        }

    }
}

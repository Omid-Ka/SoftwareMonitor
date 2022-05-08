using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Domain.Models.Enum;
using Domain.Models.Projects;

namespace Core.Services
{
    public class PartnersService : IPartnersService
    {
        private IPartnersRepository _partnersRepository;
        private IUsersRepository _usersRepository;
        private ITeamDetailRepository _teamDetailRepository;

        public PartnersService(IPartnersRepository partnersRepository, IUsersRepository usersRepository, ITeamDetailRepository teamDetailRepository)
        {
            _partnersRepository = partnersRepository;
            _usersRepository = usersRepository;
            _teamDetailRepository = teamDetailRepository;
        }

        public void AddPartner(Partners item, ClaimsPrincipal user)
        {
            _partnersRepository.AddPartner(item, user);
        }

        public List<PartnerVM> GetAllPartnerVMByProjectId(int projectId)
        {
            return _partnersRepository.GetAllPartnerVMByProjectId(projectId).Select(x => new PartnerVM()
            {
                UserId = x.UserId,
                TeamId = x.TeamId,
                Id = x.Id
                ,
                PartnerTeam = x.PartnerTeam,
                ProjectId = x.ProjectId
            }).ToList();
        }

        public List<ShowPartnersVM> GetAllPartnerInProjectByProjectId(int projectId)
        {
            var Teams = _partnersRepository.GetAllTeamsByProjectId(projectId);
            var Users = _partnersRepository.GetAllUsersByProjectId(projectId);

            var ShowPartners = new List<ShowPartnersVM>();

            foreach (PartnerTeam type in Enum.GetValues(typeof(PartnerTeam)))
            {
                var UserArray = Users.Where(x => x.IsActive && x.PartnerTeam == type && x.UserId.HasValue).Select(x => x.UserId.Value).ToArray();
                var TeamArray = Teams.Where(x => x.IsActive && x.PartnerTeam == type && x.TeamId.HasValue).Select(x => x.TeamId.Value).ToArray();
                var TeamUsers = _teamDetailRepository.GetUsersByTeamIds(TeamArray);


                if (UserArray.Count() > 0 && TeamUsers.Count() > 0)
                {
                    UserArray = (int[])UserArray.Union(TeamUsers);

                    ShowPartners.Add(new ShowPartnersVM()
                    {
                        PartnerTeam = type,
                        Users = _usersRepository.GetAllUsersByIds(UserArray).Select(x => new UserVM()
                        {
                            Id = x.Id,
                            FullName = x.Name + " " + x.Family
                        }).ToList(),
                        AllUserName = string.Join(',',
                            _usersRepository.GetAllUsersByIds(UserArray).Select(x => x.Name + " " + x.Family))
                    });
                }
                else if (TeamUsers.Count() > 0)
                {
                    ShowPartners.Add(new ShowPartnersVM()
                    {
                        PartnerTeam = type,
                        Users = _usersRepository.GetAllUsersByIds(TeamUsers).Select(x => new UserVM()
                        {
                            Id = x.Id,
                            FullName = x.Name + " " + x.Family
                        }).ToList(),
                        AllUserName = string.Join(',',
                        _usersRepository.GetAllUsersByIds(UserArray).Select(x => x.Name + " " + x.Family))
                    });
                }
                else if (UserArray.Count() > 0)
                {
                    ShowPartners.Add(new ShowPartnersVM()
                    {
                        PartnerTeam = type,
                        Users = _usersRepository.GetAllUsersByIds(UserArray).Select(x => new UserVM()
                        {
                            Id = x.Id,
                            FullName = x.Name + " " + x.Family
                        }).ToList(),
                        AllUserName = string.Join(',',
                        _usersRepository.GetAllUsersByIds(UserArray).Select(x => x.Name + " " + x.Family))
                    });
                }
                
            }

            return ShowPartners;
        }

        public void DeletePartnerByPK(int? id, ClaimsPrincipal user)
        {
            _partnersRepository.DeletePartnerByPK(id,user);
        }
    }
}

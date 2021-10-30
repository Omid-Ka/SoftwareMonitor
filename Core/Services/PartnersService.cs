using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class PartnersService : IPartnersService
    {
        private IPartnersRepository _partnersRepository;

        public PartnersService(IPartnersRepository partnersRepository)
        {
            _partnersRepository = partnersRepository;
        }

    }
}

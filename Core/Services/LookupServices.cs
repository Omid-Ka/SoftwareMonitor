using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public class LookupServices : ILookupService
    {
        private ILookupRepository _lookupRepository;

        public LookupServices(ILookupRepository lookupRepository)
        {
            this._lookupRepository = lookupRepository;
        }

        public LookupVM GetByPk(int id)
        {
            var Model = _lookupRepository.GetByPk(id);

            return new LookupVM()
            {
                Category = Model.Category,
                Description = Model.Description,
                Id = Model.Id,
                Information = Model.Information,
                ReferenceID = Model.ReferenceID
            };
        }
    }
}

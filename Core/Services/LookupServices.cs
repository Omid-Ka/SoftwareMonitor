using Core.DTO;
using Core.Interfaces;
using Core.ViewModels;
using Domain.Interfaces;
using Domain.Models.Account;
using Domain.Models.BaseInformation;
using Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public IEnumerable<LookupVM> GetAllByCategory(LookupCategory LookupCategory)
        {
            return _lookupRepository.GetAllByCategory(LookupCategory).Select(x=>new LookupVM()
            {
                Id = x.Id,
                Category = x.Category,
                Description = x.Description,
                Information = x.Information,
                ReferenceID = x.ReferenceID,
                DateInserted = x.DateInserted
            });
        }

        public IEnumerable<LookupVM> GetAll()
        {
            return _lookupRepository.GetAll().Select(x => new LookupVM()
            {
                Id = x.Id,
                Category = x.Category,
                Description = x.Description,
                Information = x.Information,
                ReferenceID = x.ReferenceID,
                DateInserted = x.DateInserted
            });
        }

        public bool HaslookupWithDescription(string description, LookupCategory category)
        {
            return _lookupRepository.HaslookupWithDescription(description, category);
        }

        public void AddLookup(Lookup model, ClaimsPrincipal user)
        {
            _lookupRepository.AddLookup(model, user);
        }

        public void DeleteLookup(int LookupId, ClaimsPrincipal user)
        {
            _lookupRepository.DeleteLookup(LookupId, user);
        }

        public void Editlookup(Lookup model, ClaimsPrincipal user)
        {
            _lookupRepository.Editlookup(model, user);
        }

        public Lookup GetByLookupId(int lookupId)
        {
           return  _lookupRepository.GetByLookupId(lookupId);
        }
    }
}

using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using System.Collections;
using System.Security.Claims;
using Domain.Models.BaseInformation;
using Domain.Models.Enum;
using Domain.Models.Account;

namespace Core.Interfaces
{
    public interface ILookupService
    {
        LookupVM GetByPk(int id);
        IEnumerable<LookupVM> GetAllByCategory(LookupCategory category);
        IEnumerable<LookupVM> GetAll();
        bool HaslookupWithDescription(string description, LookupCategory category);
        void AddLookup(Lookup model, ClaimsPrincipal user);
        void DeleteLookup(int LookupId, ClaimsPrincipal user);
        void Editlookup(Lookup model, ClaimsPrincipal user);
        Lookup GetByLookupId(int lookupId);
        IEnumerable<Lookup> GetAllByCategoryAndReference(CodeReviewDetailType type , LookupCategory indicator);
    }
}

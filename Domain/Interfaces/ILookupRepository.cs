using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.Account;

namespace Domain.Interfaces
{
    public interface ILookupRepository
    {
        Lookup GetByPk(int id);
        IEnumerable<Lookup> GetAllByCategory(LookupCategory category);
        IEnumerable<Lookup> GetAll();
        bool HaslookupWithDescription(string description, LookupCategory category);
        void AddLookup(Lookup model, ClaimsPrincipal user);
        void DeleteLookup(int LookupId, ClaimsPrincipal user);
        void Editlookup(Lookup model, ClaimsPrincipal user);
        Lookup GetByLookupId(int lookupId);
    }
}

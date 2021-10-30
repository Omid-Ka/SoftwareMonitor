using Domain.Interfaces;
using Domain.Models;
using Domain.Models.Account;
using Domain.Models.BaseInformation;
using Domain.Models.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Data.Repository
{
    public class LookupRepository : ILookupRepository
    {
        private SoftwareMonitoringDBContext _SMContext;
        public LookupRepository(SoftwareMonitoringDBContext SMContext)
        {
            this._SMContext = SMContext;
        }

        public IEnumerable<Lookup> GetAllByCategory(LookupCategory category)
        {
            return _SMContext.Lookups.Where(x=>x.IsActive && x.Category == category);
        }

        public Lookup GetByPk(int id)
        {
            return _SMContext.Lookups.Find(id);
        }

        public IEnumerable<Lookup> GetAll()
        {
            return _SMContext.Lookups.Where(x => x.IsActive);
        }

        public bool HaslookupWithDescription(string description, LookupCategory category)
        {
            return _SMContext.Lookups.Any(x => x.IsActive && x.Description == description && x.Category == category);
        }

        public void AddLookup(Lookup model, ClaimsPrincipal user)
        {
            model.IsActive = true;
            model.CreatorID = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateInserted = DateTime.Now;
            model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
                .FirstOrDefault();


            _SMContext.Add(model);
            _SMContext.SaveChanges();
        }

        public void DeleteLookup(int LookupId, ClaimsPrincipal user)
        {
            var model = _SMContext.Lookups.Find(LookupId);
            model.IsActive = false;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;
            //model.IpAddress = user.Claims.Where(x => x.Type == "IpAddress").Select(x => x.Value)
            //    .FirstOrDefault();


            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

        public void Editlookup(Lookup model, ClaimsPrincipal user)
        {
            model.IsActive = true;
            model.UpdatedUser = Convert.ToInt32(user.Claims.Where(x => x.Type == ClaimTypes.NameIdentifier).Select(x => x.Value)
                .FirstOrDefault());
            model.DateModified = DateTime.Now;

            _SMContext.Update(model);
            _SMContext.SaveChanges();
        }

        public Lookup GetByLookupId(int lookupId)
        {
            return _SMContext.Lookups.Find(lookupId);
        }
    }
}

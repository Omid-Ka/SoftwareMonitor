using Core.DTO;
using Core.Interfaces;
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

    }
}

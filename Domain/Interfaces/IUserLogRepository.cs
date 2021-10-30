using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Domain.Models.BaseInformation;
using Domain.Models.Log;

namespace Domain.Interfaces
{
    public interface IUserLogRepository
    {
        UserLog GetByPk(int id);
    }
}

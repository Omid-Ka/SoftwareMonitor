using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Domain.Models.Log;

namespace Core.Interfaces
{
    public interface IUserLogService
    {
        UserLog GetByPk(int id);
    }
}

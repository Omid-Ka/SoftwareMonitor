﻿using Core.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels;
using Domain.Models.Log;
using Domain.Models.Enum;
using System.Security.Claims;
using Domain.Models.ProjectTests;

namespace Core.Interfaces
{
    public interface ITestHeaderService
    {
        List<TestHeaderVM> GetTestHeaders(TestType TestType, int testId);   
    }
}

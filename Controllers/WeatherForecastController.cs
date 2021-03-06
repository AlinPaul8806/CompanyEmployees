﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CompanyEmployees.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly IRepositoryManager _repository;

        // constructor injection for the logger service:
        public WeatherForecastController( IRepositoryManager repository)
        {
            _repository = repository;
        }

        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    _logger.LogInfo("Here is info message from our values controller.");
        //    _logger.LogDebug("Here is debug message from our values controller.");
        //    _logger.LogWarn("Here is warn message from our values controller.");
        //    _logger.LogError("Here is an error message from our values controller.");

        //    return new string[] { "value1", "value2" };
        //}

        [HttpGet]
        public ActionResult<IEnumerable<string>> GetFromRepo()
        {
            //_repository.Company.AnyMethodFromComapnyRepositpory();
            // _repository.Employee.GetAllEmployees(false);

            return new string[] { "value1", "value2" };
        }

    }
}

using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Controllers
{
    [ApiController]
    [Route("api/employees")]
    public class EmployeesController : ControllerBase
    {
        //fields:
        private readonly IRepositoryManager _repository;

        private readonly ILoggerManager _logger;

        //constructor:
        public EmployeesController(ILoggerManager logger, IRepositoryManager repository)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetEmployees()
        {
            try
            {
                var employees = _repository.Employee.GetAllEmployees(trackChanges: false);

                return Ok(employees);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetEmployees)} action.");

                return StatusCode(500, "Internal server error.");
            }
        }
    }
}

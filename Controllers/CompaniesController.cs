/* While working with .NET Core Web API, the .NET Core Team strongly 
 * advises to use attribute routing instead of convetional routing */

using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyEmployees.Controllers
{
    [Route("api/[companies]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        //fields
        private readonly IRepositoryManager _repository;

        private readonly ILoggerManager _logger;

        // constructor
        public CompaniesController(IRepositoryManager repository, ILoggerManager logger)
        {
            _repository = repository;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult GetCompanies()
        {
            try
            {
                var companies = _repository.Company.GetAllCompanies(trackChanges: false);

                return Ok(companies);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong in the {nameof(GetCompanies)} action");

                return StatusCode(500, "Internal server error.");         
            }
        }
    }
}

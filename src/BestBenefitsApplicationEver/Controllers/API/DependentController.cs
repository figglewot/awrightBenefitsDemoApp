using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using BestBenefitsApplicationEver.Models;
using Microsoft.AspNet.Mvc;
using BestBenefitsApplicationEver.ViewModels;

namespace BestBenefitsApplicationEver.Controllers.API
{
    [Route("api/employees/{employeeId}/dependents")]
    public class DependentController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public DependentController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        [HttpGet("")]
        public JsonResult Get(int employeeId)
        {
            try
            {
                var results = _employeeRepository.GetEmployeesWithDependentsById(employeeId);

                return Json(results == null ? null : Mapper.Map<IEnumerable<DependentViewModel>>(results.Dependents));
            }
            catch (Exception)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json("Error occured finding employee");
            }
        }

        [HttpPost("")]
        public JsonResult Post(int employeeId, [FromBody]DependentViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newDependent = Mapper.Map<Dependent>(viewModel);

                    _employeeRepository.AddDependent(employeeId, newDependent);

                    if (_employeeRepository.SaveAll())
                    {
                        Response.StatusCode = (int) HttpStatusCode.Created;
                        return Json(Mapper.Map<DependentViewModel>(newDependent));
                    }
                }
            }
            catch (Exception)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json("Error occured adding dependent");
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Validation failed on new dependent");
        }
    }
}

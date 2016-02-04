using System;
using System.Collections.Generic;
using System.Net;
using AutoMapper;
using BestBenefitsApplicationEver.Models;
using BestBenefitsApplicationEver.ViewModels;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.Logging;

namespace BestBenefitsApplicationEver.Controllers.Api
{
    [Route("api/employees/{employeeId?}")]
    public class EmployeeController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [HttpGet("")]
        public JsonResult Get(int employeeId)
        {
            if (employeeId > 0)
            {
                var results = Mapper.Map<EmployeeViewModel>(_employeeRepository.GetEmployeesWithDependentsById(employeeId));
                return Json(results);
            }
            else
            {
                var results = Mapper.Map<IEnumerable<EmployeeViewModel>>(_employeeRepository.GetAllEmployeesWithDependents());
                return Json(results);
            }
        }

        [HttpPost("")]
        public JsonResult Post([FromBody]EmployeeViewModel viewModel, int employeeId)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var newEmployee = Mapper.Map<Employee>(viewModel);
                    var editEmployee = Mapper.Map<Employee>(viewModel);
                    if (employeeId > 0)
                    {
                        _employeeRepository.EditEmployee(editEmployee);
                    }
                    else
                    {
                        _employeeRepository.AddEmployee(newEmployee);
                    }
                    if (_employeeRepository.SaveAll())
                    {
                        Response.StatusCode = (int) HttpStatusCode.Created;
                        return Json(Mapper.Map<EmployeeViewModel>(newEmployee));
                    }
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int) HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message});
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Failed");
        }

        [HttpDelete("")]
        public JsonResult Delete(int employeeId)
        {
            try
            {
                _employeeRepository.DeleteEmployee(employeeId);
                if (_employeeRepository.SaveAll())
                {
                    Response.StatusCode = (int) HttpStatusCode.Accepted;
                    return Json("Success");
                }
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return Json(new { Message = ex.Message });
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Failed");
        }
    }
}
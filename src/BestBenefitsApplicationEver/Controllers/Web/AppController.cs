using System;
using System.Linq;
using BestBenefitsApplicationEver.Database;
using BestBenefitsApplicationEver.Models;
using Microsoft.AspNet.Mvc;

namespace BestBenefitsApplicationEver.Controllers.Web
{
    public class AppController : Controller
    {
        private IEmployeeRepository _employeeRepository;

        public AppController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IActionResult Index()
        {
            return View();
        }

        //public IActionResult AddEmployee()
        //{
        //    return View();
        //}
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Repo;

namespace WebApplication.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployeeRepo EmployeeRepo = new EmployeeRepo();

        // GET: Employee
        public ActionResult Index()
        {
            return View(EmployeeRepo.ListAllEmployee());
        }
    }
}
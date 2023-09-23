using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Repo;

namespace WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerRepo CustomerRepo = new CustomerRepo();

        // GET: Customer
        public ActionResult Index()
        {
            return View(CustomerRepo.ListAllCustomer());
        }
    }
}
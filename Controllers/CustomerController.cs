using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models;
using WebApplication.Models.Repo;

namespace WebApplication.Controllers
{
    public class CustomerController : Controller
    {
        ICustomerRepo CustomerRepo = new CustomerRepo();
        private Northwind2Entities1 db = new Northwind2Entities1();

        // GET: Customer
        public ActionResult Index()
        {
            return View(CustomerRepo.ListAllCustomer());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Include = "CustomerID,CompanyName")] Customer customer)
        {
            try
            {
                if (this.CheckInputErr(customer)) { return Json(new { ReturnStatus = "error", ReturnData = "請確認輸入訊息完整 !" }); }
                int maxId = db.Customers.DefaultIfEmpty().Max(p => p == null ? 0 : p.CustomerID);
                maxId += 1;
                customer.CustomerID = maxId;
                db.Customers.Add(customer);

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { ReturnStatus = "error", ReturnData = "請確認輸入訊息完整或資料重複 !" + ex });
            }
        }

        private bool CheckInputErr(Customer customer)
        {
            if (customer.CompanyName == null || customer.CompanyName == string.Empty) { return true; };

            return false;
        }

    }
}
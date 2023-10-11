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

        public ActionResult Edit(int id)
        {
            try
            {
                
                var model = db.Customers.Where(x => x.CustomerID == id).FirstOrDefault();

                return View(model);
            }
            catch (Exception ex)
            {
                return Json(new { ReturnStatus = "error", ReturnData = "Edit(), ex:" + ex });
            }
        }

        [HttpPost]
        public ActionResult Edit([Bind(Include = "CustomerID,CompanyName")] Customer customer)
        {
            try
            {
                var model = db.Customers.Where(x => x.CustomerID == customer.CustomerID).FirstOrDefault();
                model.CompanyName = customer.CompanyName;

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { ReturnStatus = "error", ReturnData = "請確認輸入訊息完整或資料重複 !" + ex });
            }
        }

        public ActionResult Delete()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            if (CustomerRepo.DeleteCustomer(id))
            {
                return RedirectToAction("Index");
            }
            return Json(new { ReturnStatus = "error", ReturnData = "刪除失敗 !" });
        }

        private bool CheckInputErr(Customer customer)
        {
            if (customer.CompanyName == null || customer.CompanyName == string.Empty) { return true; };

            return false;
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication.Models.Repo;

namespace WebApplication.Controllers
{
    public class ProductController : Controller
    {
        IProductRepo ProductRepo = new ProductRepo();

        // GET: Product
        public ActionResult Index()
        {
            return View(ProductRepo.ListAllProduct());
        }
    }
}
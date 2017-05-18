using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using shopping.Models;
namespace shopping.Controllers
{
    public class HomeController : System.Web.Mvc.Controller
    {
        public shopEntities shop = new shopEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryPartial()
        {
            var category=shop.Categories.ToList();
            return PartialView(category);
        }

       
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using shopping.Models;
using PagedList;
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
        public ActionResult login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult login(string username, string password)
        {
            string passwordMD5 = Common.encrypt(username + password);

            Account user = shop.Accounts.FirstOrDefault(x => x.accountName == username && x.password == passwordMD5 && x.active == 1);
            if (user != null)
            {
                Session.Add("Account", user);
                return RedirectToAction("Index");
            }
            ViewBag.error = "Đăng nhập sai hoặc bạn không có quyền truy cập";
            return View();
        }

        public ActionResult Logout()
        {
            Session["userid"] = null;
            Session["username"] = null;
            Session["fullname"] = null;
            return RedirectToAction("Login");
        }

    }
}
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
        public shopEntities db = new shopEntities();

        public ActionResult Index()
        {

            //var book = db.Books.OrderBy(x => x.book_Title);
            return View();
        }
        
    
        public ActionResult CategoryPartial()
        {
            var category = db.Categories.ToList();
            return PartialView(category);
        }
        public ActionResult PublisherPartial()
        {
            return PartialView(db.Publishers.ToList());
        }
       
        public ActionResult login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult login(string username, string password)
        {
            string passwordMD5 = Common.encrypt(username + password);

            Account user = db.Accounts.FirstOrDefault(x => x.accountName == username && x.password == passwordMD5);
            if (user != null)
            {
                Session.Add("Account", user);
                user.lastLogin = DateTime.Now;
                db.Accounts.Attach(user);
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.error = "Đăng nhập sai hoặc bạn không có quyền truy cập";
            return View();
        }

        public ActionResult Logout()
        {
            Session["Account"] = null;
            
            return RedirectToAction("Index","Home");
        }
    }
}
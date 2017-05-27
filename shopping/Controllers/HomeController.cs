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

        public ActionResult Index(string sortDisplay)
        {

            var book = db.Books.OrderBy(x => x.book_Title);
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
       
    }
}
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopping.Models;

namespace shopping.Controllers
{
    public class PublisherController : Controller
    {
        private shopEntities db = new shopEntities();

        // GET: /Publisher/
        public ActionResult Index()
        {
            return View(db.Publishers.ToList());
        }

        // GET: /Publisher/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(publisher);
        }

        // GET: /Publisher/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Publisher/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="publisher_Id,publisher_Name,publisher_Slug")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Publishers.Add(publisher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publisher);
        }

        // GET: /Publisher/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(publisher);
        }

        // POST: /Publisher/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="publisher_Id,publisher_Name,publisher_Slug")] Publisher publisher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publisher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publisher);
        }

        // GET: /Publisher/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Publisher publisher = db.Publishers.Find(id);
            if (publisher == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(publisher);
        }

        // POST: /Publisher/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Publisher publisher = db.Publishers.Find(id);
            db.Publishers.Remove(publisher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        public ActionResult FindPublisher(int? id,string slug)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var findpublisher = db.Publishers.Find(id);
            if (findpublisher == null)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.Title = findpublisher.publisher_Name.ToUpper();
            return View(findpublisher.Books.ToList());
        }
    }
}

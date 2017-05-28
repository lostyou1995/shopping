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
    public class AccountsController : Controller
    {
        private shopEntities db = new shopEntities();

        // GET: Accounts
        public ActionResult Index()
        {
            return View(db.Accounts.ToList());
        }

        // GET: Accounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return HttpNotFound();
            }
            return View(account);
        }

        // GET: Accounts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Accounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,accountName,password,fullName,imagePath,birthDay,phone,email,address,createDate,lastLogin,groupId,active")] Account account)
        {
            if (ModelState.IsValid)
            {
                
                var username = Request.Form["accountName"];
                var password = Request.Form["password"];
                string passwordMD5 = Common.encrypt(username + password);
                account.password = passwordMD5;
                account.createDate = DateTime.Now;
                account.groupId = 2;
                account.active = 1;
                db.Accounts.Add(account);
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }

            return View(account);
        }

        // GET: Accounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index","Home");
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(account);
        }

        // POST: Accounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,fullName,imagePath,birthDay,phone,email,address")] Account account)
        {
            if (ModelState.IsValid)
            {
                var a=db.Accounts.Find(account.id);
                
                a.fullName = account.fullName;
                //a.imagePath = account.imagePath;
                a.birthDay = account.birthDay;
                a.phone = account.phone;
                a.email = account.email;
                a.address = account.address;
                Session["Account"] =a;
                db.Entry(a).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Home");
            }
            return View(account);
        }

        // GET: Accounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Account account = db.Accounts.Find(id);
            if (account == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(account);
        }

        // POST: Accounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Account account = db.Accounts.Find(id);
            db.Accounts.Remove(account);
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
        public JsonResult CheckAccount(string accountName)
        {
            Account varCheck = db.Accounts.FirstOrDefault(x => x.accountName == accountName);
            if (varCheck == null)
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            return Json(false, JsonRequestBehavior.AllowGet);
        }
        public ActionResult LogOrder(int? id)
        {
            
            return View();
        }
    }
}

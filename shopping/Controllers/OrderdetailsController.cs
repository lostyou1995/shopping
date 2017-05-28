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
    public class OrderdetailsController : Controller
    {
        private shopEntities db = new shopEntities();

        // GET: Orderdetails
        public ActionResult Index()
        {

            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    var orderdetails = db.Orderdetails.Include(o => o.Book).Include(o => o.Order);
                    return View(orderdetails.ToList());
                }
                else
                {
                    var path = (from p in db.Paths
                                join groupPath in db.GroupPaths on p.id equals groupPath.pathId
                                join g in db.Groups on groupPath.groupId equals g.id
                                join accGroup in db.AccountGroups on g.id equals accGroup.groupId
                                join acc in db.Accounts on accGroup.accountId equals acc.id
                                where acc.id == account.id
                                select p).ToList();
                    for (int i = 0; i < path.Count; i++)
                    {
                        if (path[i].pathUrl.CompareTo("/Orderdetails/Details") == 0)
                        {
                            var orderdetails = db.Orderdetails.Include(o => o.Book).Include(o => o.Order);
                            return View(orderdetails.ToList());
                        }
                        else { continue; }
                    }
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            if (account == null) { return RedirectToAction("Index", "Home"); }
            return RedirectToAction("Index", "Home");
        }

        // GET: Orderdetails/Details/5
        public ActionResult Details(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    Orderdetail orderdetail = db.Orderdetails.Find(id);
                    if (orderdetail == null)
                    {
                        return HttpNotFound();
                    }
                    return View(orderdetail);

                }
                else
                {
                    var path = (from p in db.Paths
                                join groupPath in db.GroupPaths on p.id equals groupPath.pathId
                                join g in db.Groups on groupPath.groupId equals g.id
                                join accGroup in db.AccountGroups on g.id equals accGroup.groupId
                                join acc in db.Accounts on accGroup.accountId equals acc.id
                                where acc.id == account.id
                                select p).ToList();
                    for (int i = 0; i < path.Count; i++)
                    {
                        if (path[i].pathUrl.CompareTo("/Orderdetails/Details") == 0)
                        {
                            Orderdetail orderdetail = db.Orderdetails.Find(id);
                            if (orderdetail == null)
                            {
                                return HttpNotFound();
                            }
                            return View(orderdetail);
                        }
                        else { continue; }
                    }
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            if (account == null) { return RedirectToAction("Index", "Home"); }
            return RedirectToAction("Index", "Home");
        }

        // GET: Orderdetails/Create
        public ActionResult Create()
        {
            
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    ViewBag.orderdetail_book_Id = new SelectList(db.Books, "book_Id", "book_Title");
                    ViewBag.details_Id = new SelectList(db.Orders, "detail_Id", "detail_Id");
                    return View();

                }
                else
                {
                    var path = (from p in db.Paths
                                join groupPath in db.GroupPaths on p.id equals groupPath.pathId
                                join g in db.Groups on groupPath.groupId equals g.id
                                join accGroup in db.AccountGroups on g.id equals accGroup.groupId
                                join acc in db.Accounts on accGroup.accountId equals acc.id
                                where acc.id == account.id
                                select p).ToList();
                    for (int i = 0; i < path.Count; i++)
                    {
                        if (path[i].pathUrl.CompareTo("/Orderdetails/Create") == 0)
                        {
                            ViewBag.orderdetail_book_Id = new SelectList(db.Books, "book_Id", "book_Title");
                            ViewBag.details_Id = new SelectList(db.Orders, "detail_Id", "detail_Id");
                            return View();
                        }
                        else { continue; }
                    }
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            if (account == null) { return RedirectToAction("Index", "Home"); }
            return RedirectToAction("Index", "Home");
        }

        // POST: Orderdetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "orderdetail_Id,orderdetail_book_Id,orderdetail_Quantity,orderdetail_Price,orderdetail_Total,details_Id")] Orderdetail orderdetail)
        {

            if (ModelState.IsValid)
            {
                db.Orderdetails.Add(orderdetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.orderdetail_book_Id = new SelectList(db.Books, "book_Id", "book_Title", orderdetail.orderdetail_book_Id);
            ViewBag.details_Id = new SelectList(db.Orders, "detail_Id", "detail_Id", orderdetail.details_Id);
            return View(orderdetail);
        }

        // GET: Orderdetails/Edit/5
        public ActionResult Edit(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    Orderdetail orderdetail = db.Orderdetails.Find(id);
                    if (orderdetail == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.orderdetail_book_Id = new SelectList(db.Books, "book_Id", "book_Title", orderdetail.orderdetail_book_Id);
                    ViewBag.details_Id = new SelectList(db.Orders, "detail_Id", "detail_Id", orderdetail.details_Id);
                    return View(orderdetail);
                }
                else
                {
                    var path = (from p in db.Paths
                                join groupPath in db.GroupPaths on p.id equals groupPath.pathId
                                join g in db.Groups on groupPath.groupId equals g.id
                                join accGroup in db.AccountGroups on g.id equals accGroup.groupId
                                join acc in db.Accounts on accGroup.accountId equals acc.id
                                where acc.id == account.id
                                select p).ToList();
                    for (int i = 0; i < path.Count; i++)
                    {
                        if (path[i].pathUrl.CompareTo("/Orderdetails/Edit") == 0)
                        {
                            Orderdetail orderdetail = db.Orderdetails.Find(id);
                            if (orderdetail == null)
                            {
                                return HttpNotFound();
                            }
                            ViewBag.orderdetail_book_Id = new SelectList(db.Books, "book_Id", "book_Title", orderdetail.orderdetail_book_Id);
                            ViewBag.details_Id = new SelectList(db.Orders, "detail_Id", "detail_Id", orderdetail.details_Id);
                            return View(orderdetail);
                        }
                        else { continue; }
                    }
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            if (account == null) { return RedirectToAction("Index", "Home"); }
            return RedirectToAction("Index", "Home");
        }

        // POST: Orderdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "orderdetail_Id,orderdetail_book_Id,orderdetail_Quantity,orderdetail_Price,orderdetail_Total,details_Id")] Orderdetail orderdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(orderdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.orderdetail_book_Id = new SelectList(db.Books, "book_Id", "book_Title", orderdetail.orderdetail_book_Id);
            ViewBag.details_Id = new SelectList(db.Orders, "detail_Id", "detail_Id", orderdetail.details_Id);
            return View(orderdetail);
        }

        // GET: Orderdetails/Delete/5
        public ActionResult Delete(int? id)
        {

            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    Orderdetail orderdetail = db.Orderdetails.Find(id);
                    if (orderdetail == null)
                    {
                        return HttpNotFound();
                    }
                    return View(orderdetail);
                }
                else
                {
                    var path = (from p in db.Paths
                                join groupPath in db.GroupPaths on p.id equals groupPath.pathId
                                join g in db.Groups on groupPath.groupId equals g.id
                                join accGroup in db.AccountGroups on g.id equals accGroup.groupId
                                join acc in db.Accounts on accGroup.accountId equals acc.id
                                where acc.id == account.id
                                select p).ToList();
                    for (int i = 0; i < path.Count; i++)
                    {
                        if (path[i].pathUrl.CompareTo("/Orderdetails/Delete") == 0)
                        {
                            Orderdetail orderdetail = db.Orderdetails.Find(id);
                            if (orderdetail == null)
                            {
                                return HttpNotFound();
                            }
                            return View(orderdetail);
                        }
                        else { continue; }
                    }
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            if (account == null) { return RedirectToAction("Index", "Home"); }
            return RedirectToAction("Index", "Home");
        }

        // POST: Orderdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Orderdetail orderdetail = db.Orderdetails.Find(id);
            db.Orderdetails.Remove(orderdetail);
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
    }
}

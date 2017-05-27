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
    public class AuthorsController : Controller
    {
        private shopEntities db = new shopEntities();

        // GET: Authors
        public ActionResult Index()
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    return View(db.Authors.ToList());
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
                        if (path[i].pathUrl.CompareTo("/Authors/Index") == 0)
                        {
                            return View(db.Authors.ToList());
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

        // GET: Authors/Details/5
        public ActionResult Details(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    Author aut = db.Authors.Find(id);
                    if (aut == null)
                    {
                        return HttpNotFound();
                    }
                    return View(aut);
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
                        if (path[i].pathUrl.CompareTo("/Authors/Index") == 0)
                        {
                            Author aut = db.Authors.Find(id);
                            if (aut == null)
                            {
                                return HttpNotFound();
                            }
                            return View(aut);
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

        // GET: Authors/Create
        public ActionResult Create()
        {
            Account account = new Account();
            try
            {

                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
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
                        if (path[i].pathUrl.CompareTo("/Authors/Create") == 0)
                        {
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

        // POST: Authors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "author_Id,author_Name,author_Slug")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Authors.Add(author);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(author);
        }

        // GET: Authors/Edit/5
        public ActionResult Edit(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    Author aut = db.Authors.Find(id);
                    if (aut == null)
                    {
                        return HttpNotFound();
                    }
                    return View(aut);
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
                        if (path[i].pathUrl.CompareTo("/Authors/Edit") == 0)
                        {
                            Author aut = db.Authors.Find(id);
                            if (aut==null)
                            {
                                return HttpNotFound();
                            }
                            return View(aut);
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

        // POST: Authors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "author_Id,author_Name,author_Slug")] Author author)
        {
            if (ModelState.IsValid)
            {
                db.Entry(author).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(author);
        }

        // GET: Authors/Delete/5
        public ActionResult Delete(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {

                    Author author = db.Authors.Find(id);
                    if (author == null)
                    {
                        return HttpNotFound();
                    }
                    return View(author);
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
                        if (path[i].pathUrl.CompareTo("/Authors/Delete") == 0)
                        {
                            Author author = db.Authors.Find(id);
                            if (author == null)
                            {
                                return HttpNotFound();
                            }
                            return View(author);
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

        // POST: Authors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Author author = db.Authors.Find(id);
            db.Authors.Remove(author);
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

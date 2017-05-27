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
    public class PathsController : Controller
    {
        private shopEntities db = new shopEntities();

        // GET: Paths
        public ActionResult Index()
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    return View(db.Paths.ToList());

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
                        if (path[i].pathUrl.CompareTo("/Paths/Index") == 0)
                        {
                            return View(db.Paths.ToList());
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

        // GET: Paths/Details/5
        public ActionResult Details(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    Path path = db.Paths.Find(id);
                    if (path == null)
                    {
                        return HttpNotFound();
                    }
                    return View(path);
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
                        if (path[i].pathUrl.CompareTo("/Paths/Details") == 0)
                        {
                            Path path1 = db.Paths.Find(id);
                            if (path1 == null)
                            {
                                return HttpNotFound();
                            }
                            return View(path1);
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

        // GET: Paths/Create
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
                        if (path[i].pathUrl.CompareTo("/Paths/Create") == 0)
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

        // POST: Paths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,pathName,pathDescription,pathUrl,imageUrl,display,parentId,active")] Path path)
        {
            if (ModelState.IsValid)
            {
                db.Paths.Add(path);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(path);
        }

        // GET: Paths/Edit/5
        public ActionResult Edit(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId==1)
                {
                    Path path1 = db.Paths.Find(id);
                    if (path1 == null)
                    {
                        return HttpNotFound();
                    }
                    return View(path1);
                }
                var path = (from p in db.Paths
                            join groupPath in db.GroupPaths on p.id equals groupPath.pathId
                            join g in db.Groups on groupPath.groupId equals g.id
                            join accGroup in db.AccountGroups on g.id equals accGroup.groupId
                            join acc in db.Accounts on accGroup.accountId equals acc.id
                            where acc.id == account.id
                            select p).ToList();
                for (int i = 0; i < path.Count; i++)
                {
                    if (path[i].pathUrl.CompareTo("/Paths/Edit") == 0)
                    {
                        Path path1 = db.Paths.Find(id);
                        if (path1 == null)
                        {
                            return HttpNotFound();
                        }
                        return View(path1);
                    }
                    else { continue; }
                }
            }
            catch
            {
                return RedirectToAction("Index", "Home");
            }
            if (account == null) { return RedirectToAction("Index", "Home"); }
            return RedirectToAction("Index", "Home");
        }

        // POST: Paths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,pathName,pathDescription,pathUrl,imageUrl,display,parentId,active")] Path path)
        {
            if (ModelState.IsValid)
            {
                db.Entry(path).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(path);
        }

        // GET: Paths/Delete/5
        public ActionResult Delete(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    Path path = db.Paths.Find(id);
                    if (path == null)
                    {
                        return HttpNotFound();
                    }
                    return View(path);
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
                        if (path[i].pathUrl.CompareTo("/Paths/Delete") == 0)
                        {
                            Path path1 = db.Paths.Find(id);
                            if (path1 == null)
                            {
                                return HttpNotFound();
                            }
                            return View(path1);
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

        // POST: Paths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Path path = db.Paths.Find(id);
            db.Paths.Remove(path);
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

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
    public class GroupPathsController : Controller
    {
        private shopEntities db = new shopEntities();

        // GET: GroupPaths
        public ActionResult Index()
        {

            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    var groupPaths = db.GroupPaths.Include(g => g.Group).Include(g => g.Path);
                    return View(groupPaths.ToList());
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
                        if (path[i].pathUrl.CompareTo("/GroupPaths/Index") == 0)
                        {
                            var groupPaths = db.GroupPaths.Include(g => g.Group).Include(g => g.Path);
                            return View(groupPaths.ToList());
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

        // GET: GroupPaths/Details/5
        public ActionResult Details(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    var groupPaths = db.GroupPaths.Include(g => g.Group).Include(g => g.Path);
                    return View(groupPaths.ToList());
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
                        if (path[i].pathUrl.CompareTo("/GroupPaths/Details") == 0)
                        {
                            var groupPaths = db.GroupPaths.Include(g => g.Group).Include(g => g.Path);
                            return View(groupPaths.ToList());
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

        // GET: GroupPaths/Create
        public ActionResult Create()
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    ViewBag.groupId = new SelectList(db.Groups, "id", "groupName");
                    ViewBag.pathId = new SelectList(db.Paths, "id", "pathName");
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
                        if (path[i].pathUrl.CompareTo("/GroupPaths/Create") == 0)
                        {
                            ViewBag.groupId = new SelectList(db.Groups, "id", "groupName");
                            ViewBag.pathId = new SelectList(db.Paths, "id", "pathName");
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

        // POST: GroupPaths/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,groupId,pathId")] GroupPath groupPath)
        {
            if (ModelState.IsValid)
            {
                db.GroupPaths.Add(groupPath);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.groupId = new SelectList(db.Groups, "id", "groupName", groupPath.groupId);
            ViewBag.pathId = new SelectList(db.Paths, "id", "pathName", groupPath.pathId);
            return View(groupPath);
        }

        // GET: GroupPaths/Edit/5
        public ActionResult Edit(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    GroupPath groupPath = db.GroupPaths.Find(id);
                    if (groupPath == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.groupId = new SelectList(db.Groups, "id", "groupName", groupPath.groupId);
                    ViewBag.pathId = new SelectList(db.Paths, "id", "pathName", groupPath.pathId);
                    return View(groupPath);

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
                    if (path[i].pathUrl.CompareTo("/GroupPaths/Edit") == 0)
                    {
                        GroupPath groupPath = db.GroupPaths.Find(id);
                        if (groupPath == null)
                        {
                            return HttpNotFound();
                        }
                        ViewBag.groupId = new SelectList(db.Groups, "id", "groupName", groupPath.groupId);
                        ViewBag.pathId = new SelectList(db.Paths, "id", "pathName", groupPath.pathId);
                        return View(groupPath);
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

        // POST: GroupPaths/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,groupId,pathId")] GroupPath groupPath)
        {
            if (ModelState.IsValid)
            {
                db.Entry(groupPath).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.groupId = new SelectList(db.Groups, "id", "groupName", groupPath.groupId);
            ViewBag.pathId = new SelectList(db.Paths, "id", "pathName", groupPath.pathId);
            return View(groupPath);
        }

        // GET: GroupPaths/Delete/5
        public ActionResult Delete(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    GroupPath groupPath = db.GroupPaths.Find(id);
                    if (groupPath == null)
                    {
                        return HttpNotFound();
                    }
                    return View(groupPath);

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
                        if (path[i].pathUrl.CompareTo("/GroupPaths/Delete") == 0)
                        {
                            GroupPath groupPath = db.GroupPaths.Find(id);
                            if (groupPath == null)
                            {
                                return HttpNotFound();
                            }
                            return View(groupPath);
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

        // POST: GroupPaths/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GroupPath groupPath = db.GroupPaths.Find(id);
            db.GroupPaths.Remove(groupPath);
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

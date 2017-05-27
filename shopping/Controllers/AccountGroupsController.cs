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
    public class AccountGroupsController : Controller
    {
        private shopEntities db = new shopEntities();

        // GET: AccountGroups
        public ActionResult Index()
        {
            
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if(account.groupId==1)
                {
                    var accountGroups = db.AccountGroups.Include(a => a.Account).Include(a => a.Group);
                    return View(accountGroups.ToList());
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
                        if (path[i].pathUrl.CompareTo("/AccountGroups/Index") == 0)
                        {
                            var accountGroups = db.AccountGroups.Include(a => a.Account).Include(a => a.Group);
                            return View(accountGroups.ToList());
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

        // GET: AccountGroups/Details/5
        public ActionResult Details(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    AccountGroup accountGroup = db.AccountGroups.Find(id);
                    if (accountGroup == null)
                    {
                        return HttpNotFound();
                    }
                    return View(accountGroup);
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
                        if (path[i].pathUrl.CompareTo("/AccountGroups/Details") == 0)
                        {
                            AccountGroup accountGroup = db.AccountGroups.Find(id);
                            if (accountGroup == null)
                            {
                                return HttpNotFound();
                            }
                            return View(accountGroup);
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

        // GET: AccountGroups/Create
        public ActionResult Create()
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    ViewBag.accountId = new SelectList(db.Accounts, "id", "accountName");
                    ViewBag.groupId = new SelectList(db.Groups, "id", "groupName");
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
                        if (path[i].pathUrl.CompareTo("/AccountGroups/Create") == 0)
                        {
                            ViewBag.accountId = new SelectList(db.Accounts, "id", "accountName");
                            ViewBag.groupId = new SelectList(db.Groups, "id", "groupName");
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

        // POST: AccountGroups/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,groupId,accountId,active")] AccountGroup accountGroup)
        {
            if (ModelState.IsValid)
            {
                db.AccountGroups.Add(accountGroup);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accountId = new SelectList(db.Accounts, "id", "accountName", accountGroup.accountId);
            ViewBag.groupId = new SelectList(db.Groups, "id", "groupName", accountGroup.groupId);
            return View(accountGroup);
        }

        // GET: AccountGroups/Edit/5
        public ActionResult Edit(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    AccountGroup accountGroup = db.AccountGroups.Find(id);
                    if (accountGroup == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.accountId = new SelectList(db.Accounts, "id", "accountName", accountGroup.accountId);
                    ViewBag.groupId = new SelectList(db.Groups, "id", "groupName", accountGroup.groupId);
                    return View(accountGroup);
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
                        if (path[i].pathUrl.CompareTo("/AccountGroups/Edit") == 0)
                        {
                            AccountGroup accountGroup = db.AccountGroups.Find(id);
                            if (accountGroup == null)
                            {
                                return HttpNotFound();
                            }
                            ViewBag.accountId = new SelectList(db.Accounts, "id", "accountName", accountGroup.accountId);
                            ViewBag.groupId = new SelectList(db.Groups, "id", "groupName", accountGroup.groupId);
                            return View(accountGroup);
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

        // POST: AccountGroups/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,groupId,accountId,active")] AccountGroup accountGroup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accountGroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountId = new SelectList(db.Accounts, "id", "accountName", accountGroup.accountId);
            ViewBag.groupId = new SelectList(db.Groups, "id", "groupName", accountGroup.groupId);
            return View(accountGroup);
        }

        // GET: AccountGroups/Delete/5
        public ActionResult Delete(int? id)
        {

            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    AccountGroup accountGroup = db.AccountGroups.Find(id);
                    if (accountGroup == null)
                    {
                        return HttpNotFound();
                    }
                    return View(accountGroup);
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
                        if (path[i].pathUrl.CompareTo("/AccountGroups/Delete") == 0)
                        {
                            AccountGroup accountGroup = db.AccountGroups.Find(id);
                            if (accountGroup == null)
                            {
                                return HttpNotFound();
                            }
                            return View(accountGroup);
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

        // POST: AccountGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AccountGroup accountGroup = db.AccountGroups.Find(id);
            db.AccountGroups.Remove(accountGroup);
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

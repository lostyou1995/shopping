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
    public class Sub_CategoryController : Controller
    {
        private shopEntities db = new shopEntities();

        // GET: Sub_Category
        public ActionResult Index()
        {
            
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    var sub_Category = db.Sub_Category.Include(s => s.Category);
                    return View(sub_Category.ToList());
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
                        if (path[i].pathUrl.CompareTo("/Sub_Category/Details") == 0)
                        {
                            var sub_Category = db.Sub_Category.Include(s => s.Category);
                            return View(sub_Category.ToList());
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

        // GET: Sub_Category/Details/5
        public ActionResult Details(int? id)
        {

            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    Sub_Category sub_Category = db.Sub_Category.Find(id);
                    if (sub_Category == null)
                    {
                        return HttpNotFound();
                    }
                    return View(sub_Category);
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
                        if (path[i].pathUrl.CompareTo("/Sub_Category/Details") == 0)
                        {
                            Sub_Category sub_Category = db.Sub_Category.Find(id);
                            if (sub_Category == null)
                            {
                                return HttpNotFound();
                            }
                            return View(sub_Category);
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

        // GET: Sub_Category/Create
        public ActionResult Create()
        {
           
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    ViewBag.parent_CategoryId = new SelectList(db.Categories, "category_Id", "category_Name");
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
                        if (path[i].pathUrl.CompareTo("/Sub_Category/Create") == 0)
                        {
                            ViewBag.parent_CategoryId = new SelectList(db.Categories, "category_Id", "category_Name");
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

        // POST: Sub_Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "subcategory_Id,subcategory_Name,parent_CategoryId,subcategory_Slug")] Sub_Category sub_Category)
        {
            if (ModelState.IsValid)
            {
                db.Sub_Category.Add(sub_Category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.parent_CategoryId = new SelectList(db.Categories, "category_Id", "category_Name", sub_Category.parent_CategoryId);
            return View(sub_Category);
        }

        // GET: Sub_Category/Edit/5
        public ActionResult Edit(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (true)
                {
                    Sub_Category sub_Category = db.Sub_Category.Find(id);
                    if (sub_Category == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.parent_CategoryId = new SelectList(db.Categories, "category_Id", "category_Name", sub_Category.parent_CategoryId);
                    return View(sub_Category);
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
                        if (path[i].pathUrl.CompareTo("/Sub_Category/Edit") == 0)
                        {
                            Sub_Category sub_Category = db.Sub_Category.Find(id);
                            if (sub_Category == null)
                            {
                                return HttpNotFound();
                            }
                            ViewBag.parent_CategoryId = new SelectList(db.Categories, "category_Id", "category_Name", sub_Category.parent_CategoryId);
                            return View(sub_Category);
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

        // POST: Sub_Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "subcategory_Id,subcategory_Name,parent_CategoryId,subcategory_Slug")] Sub_Category sub_Category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sub_Category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.parent_CategoryId = new SelectList(db.Categories, "category_Id", "category_Name", sub_Category.parent_CategoryId);
            return View(sub_Category);
        }

        // GET: Sub_Category/Delete/5
        public ActionResult Delete(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    Sub_Category sub_Category = db.Sub_Category.Find(id);
                    if (sub_Category == null)
                    {
                        return HttpNotFound();
                    }
                    return View(sub_Category);
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
                        if (path[i].pathUrl.CompareTo("/Sub_Category/Delete") == 0)
                        {
                            Sub_Category sub_Category = db.Sub_Category.Find(id);
                            if (sub_Category == null)
                            {
                                return HttpNotFound();
                            }
                            return View(sub_Category);
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

        // POST: Sub_Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sub_Category sub_Category = db.Sub_Category.Find(id);
            db.Sub_Category.Remove(sub_Category);
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

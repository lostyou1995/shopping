using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using shopping.Models;
using PagedList;

namespace shopping.Controllers
{
    public class CategoryController : Controller
    {
        private shopEntities db = new shopEntities();

        // GET: /Category/
        public ActionResult Index()
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    return View(db.Categories.ToList());
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
                        if (path[i].pathUrl.CompareTo("/Category/Index") == 0)
                        {
                            return View(db.Categories.ToList());
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

        // GET: /Category/Details/5
        public ActionResult Details(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId==1)
                {
                    Category category = db.Categories.Find(id);
                    if (category == null)
                    {
                        return HttpNotFound();
                    }
                    return View(category);
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
                    if (path[i].pathUrl.CompareTo("/Category/Details") == 0)
                    {
                        Category category = db.Categories.Find(id);
                        if (category == null)
                        {
                            return HttpNotFound();
                        }
                        return View(category);
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

        // GET: /Category/Create
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
                        if (path[i].pathUrl.CompareTo("/Category/Create") == 0)
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

        // POST: /Category/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "category_Id,category_Name,category_Slug")] Category category)
        {
             if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);

        }

        // GET: /Category/Edit/5
        public ActionResult Edit(int? id)
        {

            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    Category category = db.Categories.Find(id);
                    if (category == null)
                    {
                        return HttpNotFound();
                    }
                    return View(category);
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
                        if (path[i].pathUrl.CompareTo("/Category/Edit") == 0)
                        {

                            Category category = db.Categories.Find(id);
                            if (category == null)
                            {
                                return HttpNotFound();
                            }
                            return View(category);
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


        // POST: /Category/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "category_Id,category_Name,category_Slug")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: /Category/Delete/5
        public ActionResult Delete(int? id)
        {
            Account account = new Account();
            try
            {
                return RedirectToAction("Index", "Home");
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    Category category = db.Categories.Find(id);
                    if (category == null)
                    {
                        return HttpNotFound();
                    }
                    return View(category);
                }
                else
                {
                    var path = (from p in db.Paths
                                join groupPath in db.GroupPaths on p.id equals groupPath.pathId
                                join g in db.Groups on groupPath.groupId equals g.id
                                join accountGrouop in db.AccountGroups on g.id equals accountGrouop.groupId
                                join acc in db.Accounts on accountGrouop.accountId equals acc.id
                                where acc.id == account.id
                                select p).ToList();

                    for (int i = 0; i < path.Count; i++)
                    {
                        if (path[i].pathUrl.CompareTo("/Category/Delete") == 0)
                        {
                            Category category = db.Categories.Find(id);
                            if (category == null)
                            {
                                return HttpNotFound();
                            }
                            return View(category);
                        }
                        else
                        { continue; }
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


        // POST: /Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
        public ActionResult RecommendCategory(int id)
        {
            var recommend = db.Sub_Category.Find(id);
            return View(recommend.Books.ToList());
        }
        public ActionResult FindCategory(int id, string slug)
        {
            var findCategory = db.Sub_Category.Find(id);
            ViewBag.Title = findCategory.subcategory_Name.ToUpper();
            return View(findCategory.Books.ToList());
        }
        public ActionResult FindCategoryParent(int? id,int? page,string slug)
        {
            Category cat=db.Categories.Find(id);
            if(id==null || cat==null)
            {
                return RedirectToAction("Index", "Home");
            }

            var findCategoryParent = (from book in db.Books
                                     join subcate in db.Sub_Category on book.subcategory_Id equals subcate.subcategory_Id
                                     join cate in db.Categories on subcate.parent_CategoryId equals cate.category_Id
                                     where cate.category_Id == id
                                     select book).ToList();
            int pageSize = 6;
            int pageNumber = (page ?? 1);
            ViewBag.Title = db.Categories.Where(x => x.category_Id == id).Select(x => x.category_Name).SingleOrDefault().ToUpper();
            return View(findCategoryParent.ToPagedList(pageNumber,pageSize));
        }
    }
}

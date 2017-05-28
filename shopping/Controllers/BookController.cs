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
    public class BookController : Controller
    {
        private shopEntities db = new shopEntities();

        // GET: /Book/
        public ActionResult Index()
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    var books = db.Books.Include(b => b.Publisher).Include(b => b.Sub_Category);
                    return View(books.ToList());
                   
                }
                else
                {
                    account = (Account)Session["Account"];
                    var path = (from p in db.Paths
                                join groupPath in db.GroupPaths on p.id equals groupPath.pathId
                                join g in db.Groups on groupPath.groupId equals g.id
                                join accGroup in db.AccountGroups on g.id equals accGroup.groupId
                                join acc in db.Accounts on accGroup.accountId equals acc.id
                                where acc.id == account.id
                                select p).ToList();
                    for (int i = 0; i < path.Count; i++)
                    {
                        if (path[i].pathUrl.CompareTo("/Book/Index") == 0)
                        {

                            var books = db.Books.Include(b => b.Publisher).Include(b => b.Sub_Category);
                            return View(books.ToList());
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

        // GET: /Book/Details/5
        public ActionResult Details(int? id, string slug)
        {
                        if (id == null)
            {
                return RedirectToAction("Index", "Home");
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View(book);
        }

        // GET: /Book/Create
        public ActionResult Create()
        {

            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    ViewBag.category_Id = new SelectList(db.Categories, "category_Id", "category_Name");
                    ViewBag.publisher_Id = new SelectList(db.Publishers, "publisher_Id", "publisher_Name");
                    return View();
                }
                else
                {
                    account = (Account)Session["Account"];
                    var path = (from p in db.Paths
                                join groupPath in db.GroupPaths on p.id equals groupPath.pathId
                                join g in db.Groups on groupPath.groupId equals g.id
                                join accGroup in db.AccountGroups on g.id equals accGroup.groupId
                                join acc in db.Accounts on accGroup.accountId equals acc.id
                                where acc.id == account.id
                                select p).ToList();
                    for (int i = 0; i < path.Count; i++)
                    {
                        if (path[i].pathUrl.CompareTo("/Book/Create") == 0)
                        {
                            ViewBag.category_Id = new SelectList(db.Categories, "category_Id", "category_Name");
                            ViewBag.publisher_Id = new SelectList(db.Publishers, "publisher_Id", "publisher_Name");
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

        // POST: /Book/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="book_Id,book_Title,book_Description,book_Price,book_Quantity,book_Image,book_Year,subcategory_Id,publisher_Id,book_Slug")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.publisher_Id = new SelectList(db.Publishers, "publisher_Id", "publisher_Name", book.publisher_Id);
            ViewBag.subcategory_Id = new SelectList(db.Sub_Category, "subcategory_Id", "subcategory_Name", book.subcategory_Id);
            return View(book);
        }

        // GET: /Book/Edit/5
        public ActionResult Edit(int? id,string slug)
        {

            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    Book book = db.Books.Find(id);
                    if (book == null)
                    {
                        return HttpNotFound();
                    }
                    ViewBag.category_Id = new SelectList(db.Categories, "category_Id", "category_Name", book.subcategory_Id);
                    ViewBag.publisher_Id = new SelectList(db.Publishers, "publisher_Id", "publisher_Name", book.publisher_Id);
                    return View(book);
                }
                else
                {
                    account = (Account)Session["Account"];
                    var path = (from p in db.Paths
                                join groupPath in db.GroupPaths on p.id equals groupPath.pathId
                                join g in db.Groups on groupPath.groupId equals g.id
                                join accGroup in db.AccountGroups on g.id equals accGroup.groupId
                                join acc in db.Accounts on accGroup.accountId equals acc.id
                                where acc.id == account.id
                                select p).ToList();
                    for (int i = 0; i < path.Count; i++)
                    {
                        if (path[i].pathUrl.CompareTo("/Book/Edit") == 0)
                        {
                            Book book = db.Books.Find(id);
                            if (book == null)
                            {
                                return HttpNotFound();
                            }
                            ViewBag.category_Id = new SelectList(db.Categories, "category_Id", "category_Name", book.subcategory_Id);
                            ViewBag.publisher_Id = new SelectList(db.Publishers, "publisher_Id", "publisher_Name", book.publisher_Id);
                            return View(book);
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

        // POST: /Book/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "book_Id,book_Title,book_Description,book_Price,book_Quantity,book_Image,book_Year,category_Id,publisher_Id,book_Slug")] Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.publisher_Id = new SelectList(db.Publishers, "publisher_Id", "publisher_Name", book.publisher_Id);
            ViewBag.subcategory_Id = new SelectList(db.Sub_Category, "subcategory_Id", "subcategory_Name", book.subcategory_Id);
            return View(book);
        }

        // GET: /Book/Delete/5
        public ActionResult Delete(int? id)
        {
            Account account = new Account();
            try
            {
                account = (Account)Session["Account"];
                if (account.groupId == 1)
                {
                    Book book = db.Books.Find(id);
                    if (book == null)
                    {
                        return HttpNotFound();
                    }
                    return View(book);
                }
                else
                {
                    account = (Account)Session["Account"];
                    var path = (from p in db.Paths
                                join groupPath in db.GroupPaths on p.id equals groupPath.pathId
                                join g in db.Groups on groupPath.groupId equals g.id
                                join accGroup in db.AccountGroups on g.id equals accGroup.groupId
                                join acc in db.Accounts on accGroup.accountId equals acc.id
                                where acc.id == account.id
                                select p).ToList();
                    for (int i = 0; i < path.Count; i++)
                    {
                        if (path[i].pathUrl.CompareTo("/Book/Delete") == 0)
                        {
                            Book book = db.Books.Find(id);
                            if (book == null)
                            {
                                return HttpNotFound();
                            }
                            return View(book);
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

        // POST: /Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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
        public ActionResult BookPartial(int? page)
        {
            var book = db.Books.ToList();
           
            //number product on page
            int pageSize = 6;
            //neu khong du 6sp/trang thi so trang mac dinh la 1;
            int pageNumber = (page ?? 1);
            return PartialView(book.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult SearchBook(FormCollection f)
        {
            if (f["txtSeaerch"] == "")
            {
                ViewBag.Message = "không tìm thấy kết quả phù hợp";
            }
            string stringSearch = f["txtSearch"].ToString();
           
            List<Book> list = db.Books.Where(x=>x.book_Title.Contains(stringSearch)).ToList();
            ViewBag.liscount = list.Count();
            return View(list);
        }
    }
}

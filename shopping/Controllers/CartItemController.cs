using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using shopping.Models;
namespace shopping.Controllers
{
    public class CartItemController : Controller
    {
        public shopEntities db = new shopEntities();
        // GET: CartItem
        public List<Cartitem> GetCartitem()
        {
            List<Cartitem> listCartitem = Session["Cartitems"] as List<Cartitem>;
            if(listCartitem==null)
            {
                listCartitem = new List<Cartitem>();
                Session["Cartitems"] = listCartitem;
            }
            return listCartitem;
        }
        //Add cart items
        public ActionResult AddCartitem(string url,int id)
        {
            Book b = db.Books.SingleOrDefault(x => x.book_Id == id);
            if(b==null)
            {
                return RedirectToAction("Index", "Home");

            }
            List<Cartitem> listCartitem = GetCartitem();
            //kiem tra book co ton tai trong session gio hang ko
            Cartitem product = listCartitem.Find(n => n.book_Id == id);
            if (product == null)
            {
                product = new Cartitem(id);
                listCartitem.Add(product);
                return Redirect(url);
            }else
            {
                product.book_Quantity++;
                return Redirect(url);
            }
        }
        //update cart item
        public ActionResult UpdateCartitem(int id,FormCollection q)
        {
            Book b = db.Books.SingleOrDefault(x => x.book_Id == id);
            if (b == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cartitem> listCartitem = GetCartitem();
            Cartitem product = listCartitem.SingleOrDefault(n => n.book_Id == id);
            if (product != null)
            {
                    product.book_Quantity = int.Parse(q["txtQuantity"].ToString());
            }
            return RedirectToAction("Cart");
        }
        //edit cart item
        public ActionResult EditCartitem()
        {
            if(Session["Cartitems"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cartitem> listCartitem = GetCartitem();
            return View(listCartitem);
        }
        //delete Cart item
        public ActionResult DeleteCartitem(int id,string slug)
        {
            Book b = db.Books.SingleOrDefault(x => x.book_Id == id);
            if (b == null)
            {
                return RedirectToAction("Index", "Home");

            }
            List<Cartitem> listCartitem = GetCartitem();
            Cartitem product = listCartitem.SingleOrDefault(n => n.book_Id == id);
            if (product != null)
            {
                listCartitem.RemoveAll(n => n.book_Id == id);
                
            }
            if (listCartitem.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Cart");
        }
        public ActionResult Cart()
        {
            if(Session["Cartitems"]==null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<Cartitem> listCartitem=GetCartitem();

            return View(listCartitem);
        }
        public int TotalQuantity()
        {
            int quantity = 0;
            List<Cartitem> listCartitem = Session["Cartitems"] as List<Cartitem>;
            if(listCartitem!=null)
            {
                quantity = listCartitem.Sum(n => n.book_Quantity);
            }
            return quantity;
        }
        public int TotalMoney()
        {
            int total = 0;
            List<Cartitem> listCartitem = Session["Cartitems"] as List<Cartitem>;
            if (listCartitem != null)
            {
                total = listCartitem.Sum(n => n.total_Money);
            }
            return total;
        }
        public ActionResult CartitemPartial()
        {
            if (TotalQuantity() == 0)
            {
                return PartialView();

            }
            ViewBag.TotalNumber = TotalQuantity();
            ViewBag.TotalMoney = TotalMoney();
            return PartialView();
        }
        [HttpPost]
        public ActionResult BuyCart()
        {
            //check
            if (Session["Cartitems"]==null)
            {
                RedirectToAction("Index", "Home");
            }
            //add order
            Order ord = new Order(); 
            Customer cus = new Customer();
            Account acc = new Account();
            if (Session["Account"] != null)
            {
                acc = (Account)Session["Account"];
                cus.customer_Fullname = acc.fullName;
                cus.customer_Address = acc.address;
                cus.customer_Phone = acc.phone;
                cus.customer_Email = acc.email;
                db.Customers.Add(cus);
                db.SaveChanges();
                ord.customer_Id = cus.customer_Id;
            }
            else
            {
                cus.customer_Fullname = Request.Form["customer_Fullname"];
                cus.customer_Address = Request.Form["customer_Address"];
                cus.customer_Phone = Request.Form["customer_Phone"];
                cus.customer_Email = Request.Form["customer_Email"];
                db.Customers.Add(cus);
                db.SaveChanges();
                ord.customer_Id = cus.customer_Id;
            }
                
                ord.account_Id = acc.id;
                //add order
                ord.order_Datetime = DateTime.Now;
                ord.order_Status = 0;
                db.Orders.Add(ord);
                db.SaveChanges();
                List<Cartitem> listcartitem = GetCartitem();
                foreach (var item in listcartitem)
                {
                    Orderdetail ordetails = new Orderdetail();
                    ordetails.details_Id = ord.detail_Id;
                    ordetails.orderdetail_book_Id = item.book_Id;
                    ordetails.orderdetail_Quantity = item.book_Quantity;
                    ordetails.orderdetail_Total = item.total_Money;
                    ordetails.orderdetail_Price = item.book_Price;
                    db.Orderdetails.Add(ordetails);
                }
            db.SaveChanges();
            return RedirectToAction("Index","Home");
        }
	}
}
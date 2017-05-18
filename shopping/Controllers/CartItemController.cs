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
        public ActionResult AddCartitem(int id,string url)
        {
            Book b = db.Books.SingleOrDefault(x => x.book_Id == id);
            if(b==null)
            {
                Response.SubStatusCode=404;
                return null;
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
                Response.StatusCode = 404;
                return null;
            }
            List<Cartitem> listCartitem = GetCartitem();
            Cartitem product = listCartitem.SingleOrDefault(n => n.book_Id == id);
            if (product != null)
            { 
                product.book_Quantity=int.Parse(q["txtQuantity"].ToString());
            }
            return View("Cart");
        }
        //delete Cart item
        public ActionResult DeleteCartitem(int id)
        {
            Book b = db.Books.SingleOrDefault(x => x.book_Id == id);
            if (b == null)
            {
                Response.StatusCode = 404;
                return null;
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
	}
}
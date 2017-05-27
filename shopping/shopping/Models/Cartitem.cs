using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace shopping.Models
{
    public class Cartitem
    {
        public shopEntities db = new shopEntities();
        public int book_Id { set; get; }
        public string book_Name { set; get; }
        public string book_Image { set; get; }
        public int book_Price { set; get; }
        public int book_Quantity { set; get; }
        public int total_Money
        {
            get { return book_Quantity * book_Price; }
        }
        public Cartitem(int id)
        {
            book_Id = id;
            Book b = db.Books.Single(x => x.book_Id == book_Id);
            book_Name = b.book_Title;
            book_Image = b.book_Image;
            book_Price = int.Parse(b.book_Price.ToString());
            book_Quantity = 1;
        }
    }
}
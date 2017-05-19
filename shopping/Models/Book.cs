//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace shopping.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Book
    {
        public Book()
        {
            this.Orderdetails = new HashSet<Orderdetail>();
            this.Authors = new HashSet<Author>();
        }
    
        public int book_Id { get; set; }
        public string book_Title { get; set; }
        public string book_Description { get; set; }
        public Nullable<int> book_Price { get; set; }
        public Nullable<int> book_Quantity { get; set; }
        public string book_Image { get; set; }
        public Nullable<int> book_Year { get; set; }
        public Nullable<int> subcategory_Id { get; set; }
        public Nullable<int> publisher_Id { get; set; }
        public string book_Slug { get; set; }
    
        public virtual Publisher Publisher { get; set; }
        public virtual Sub_Category Sub_Category { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}

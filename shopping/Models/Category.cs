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
    
    public partial class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
            this.Sub_Category = new HashSet<Sub_Category>();
        }
    
        public int category_Id { get; set; }
        public string category_Name { get; set; }
    
        public virtual ICollection<Book> Books { get; set; }
        public virtual ICollection<Sub_Category> Sub_Category { get; set; }
    }
}

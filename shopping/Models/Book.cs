﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace shopping.Models
{
    using System.ComponentModel.DataAnnotations;
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
        [Required]
        [Display(Name ="Tiêu Đề Sách")]
        public string book_Title { get; set; }
        [Required]
        [Display(Name = "Mô Tả Sách")]
        public string book_Description { get; set; }
        [Required]
        [Display(Name = "Giá Sách")]
        public Nullable<int> book_Price { get; set; }
        [Required]
        [Display(Name = "Số Lượng Sách")]
        public Nullable<int> book_Quantity { get; set; }
        [Required]
        [Display(Name = "Hình Sách")]
        public string book_Image { get; set; }
        [Required]
        [Display(Name = "Năm Xuất Bản")]
        public Nullable<int> book_Year { get; set; }
       
        public Nullable<int> subcategory_Id { get; set; }
        [Required]
        [Display(Name = "ID Nhà Xuất Bản")]
        public Nullable<int> publisher_Id { get; set; }
        [Required]
        [Display(Name = "Link Thân Thiện")]
        public string book_Slug { get; set; }
        [Required]
        [Display(Name = "Nhà Xuất Bản")]
        public virtual Publisher Publisher { get; set; }
        [Required]
        [Display(Name = "Danh Muc Con")]
        public virtual Sub_Category Sub_Category { get; set; }
        public virtual ICollection<Orderdetail> Orderdetails { get; set; }
        public virtual ICollection<Author> Authors { get; set; }
    }
}

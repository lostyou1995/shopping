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
    
    public partial class AccountGroup
    {
        public int id { get; set; }
        public Nullable<int> groupId { get; set; }
        public Nullable<int> accountId { get; set; }
        public Nullable<int> active { get; set; }
    
        public virtual Account Account { get; set; }
        public virtual Group Group { get; set; }
    }
}
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
    
    public partial class Group
    {
        public Group()
        {
            this.AccountGroups = new HashSet<AccountGroup>();
            this.GroupPaths = new HashSet<GroupPath>();
        }
    
        public int id { get; set; }
        public string groupName { get; set; }
        public Nullable<int> parentId { get; set; }
        public Nullable<int> active { get; set; }
    
        public virtual ICollection<AccountGroup> AccountGroups { get; set; }
        public virtual ICollection<GroupPath> GroupPaths { get; set; }
    }
}
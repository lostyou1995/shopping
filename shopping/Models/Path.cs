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
    
    public partial class Path
    {
        public Path()
        {
            this.GroupPaths = new HashSet<GroupPath>();
        }
    
        public int id { get; set; }
        public string pathName { get; set; }
        public string pathDescription { get; set; }
        public string pathUrl { get; set; }
        public string imageUrl { get; set; }
        public Nullable<int> display { get; set; }
        public Nullable<int> parentId { get; set; }
        public Nullable<int> active { get; set; }
    
        public virtual ICollection<GroupPath> GroupPaths { get; set; }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace managment.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class notice
    {
        public int n_id { get; set; }
        public string n_title { get; set; }
        public string n_date { get; set; }
        public Nullable<int> n_batch { get; set; }
        public string n_desc { get; set; }
    
        public virtual batch batch { get; set; }
    }
}

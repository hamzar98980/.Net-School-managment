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
    
    public partial class as_submit
    {
        public int su_id { get; set; }
        public Nullable<int> s_id { get; set; }
        public string su_submit { get; set; }
        public string su_desc { get; set; }
        public Nullable<int> as_id { get; set; }
    
        public virtual Assingment Assingment { get; set; }
        public virtual std_info std_info { get; set; }
    }
}
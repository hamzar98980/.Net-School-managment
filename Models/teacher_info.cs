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
    
    public partial class teacher_info
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public teacher_info()
        {
            this.teacher_batch = new HashSet<teacher_batch>();
        }
    
        public int t_id { get; set; }
        public string t_name { get; set; }
        public string t_email { get; set; }
        public Nullable<int> t_salary { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<teacher_batch> teacher_batch { get; set; }
    }
}

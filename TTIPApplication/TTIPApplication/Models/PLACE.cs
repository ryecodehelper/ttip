//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TTIPApplication.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PLACE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PLACE()
        {
            this.review_ = new HashSet<review_>();
        }
    
        public int ID { get; set; }
        public string STORE_NAME { get; set; }
        public string CITY { get; set; }
        public string category { get; set; }
        public string place_ex { get; set; }
    
        public virtual category category1 { get; set; }
        public virtual CITY CITY1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<review_> review_ { get; set; }
    }
}

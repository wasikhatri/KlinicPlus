//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KlinicPlusAPI
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_member
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_member()
        {
            this.tbl_inbox = new HashSet<tbl_inbox>();
        }
    
        public int member_id { get; set; }
        public Nullable<int> home_phone { get; set; }
        public Nullable<int> cell_phone { get; set; }
        public Nullable<int> cnic { get; set; }
        public string bloodgroup { get; set; }
        public string maritalstatus { get; set; }
        public string e_contactName { get; set; }
        public Nullable<int> e_contactNumber { get; set; }
        public string medicalHistory { get; set; }
        public string familyHistory { get; set; }
        public string allergies { get; set; }
        public string symptoms { get; set; }
        public string treatments { get; set; }
        public string habits { get; set; }
        public Nullable<int> user_id { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_inbox> tbl_inbox { get; set; }
        public virtual tbl_users tbl_users { get; set; }
    }
}

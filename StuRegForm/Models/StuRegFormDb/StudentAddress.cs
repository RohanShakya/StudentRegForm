//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StuRegForm.Models.StuRegFormDb
{
    using System;
    using System.Collections.Generic;
    
    public partial class StudentAddress
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StudentAddress()
        {
            this.Students = new HashSet<Students>();
            this.Students1 = new HashSet<Students>();
        }
    
        public int Id { get; set; }
        public int ZoneId { get; set; }
        public int DistrictId { get; set; }
        public int WardNo { get; set; }
        public string StreetName { get; set; }
    
        public virtual Districts Districts { get; set; }
        public virtual Zones Zones { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Students> Students { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Students> Students1 { get; set; }
    }
}

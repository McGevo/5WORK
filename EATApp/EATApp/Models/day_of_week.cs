//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EATApp.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class day_of_week
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public day_of_week()
        {
            this.crn_session_timetable = new HashSet<crn_session_timetable>();
        }
    
        public int DayCode { get; set; }
        public string DayShortName { get; set; }
        public string DayLongName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<crn_session_timetable> crn_session_timetable { get; set; }
    }
}

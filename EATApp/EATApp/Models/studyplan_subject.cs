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
    
    public partial class studyplan_subject
    {
        public string StudyPlanCode { get; set; }
        public string SubjectCode { get; set; }
        public int TimingSemester { get; set; }
        public int TimingSemesterTerm { get; set; }
    
        public virtual studyplan_qualification studyplan_qualification { get; set; }
        public virtual subject subject { get; set; }
    }
}

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
    
    public partial class StudentSchool
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public int PassedYear { get; set; }
        public int LevelId { get; set; }
        public int GradeId { get; set; }
        public Nullable<double> Percentage { get; set; }
        public int BoardId { get; set; }
    
        public virtual Board Board { get; set; }
        public virtual Grades Grades { get; set; }
        public virtual Level Level { get; set; }
        public virtual Students Students { get; set; }
    }
}
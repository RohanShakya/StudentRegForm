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
    
    public partial class vwStuAllInfo
    {
        public int StudentId { get; set  ; }
        public int VoucherNo { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public long Mobile { get; set; }
        public string Email { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public string ParentName { get; set; }
        public long ParentMobile { get; set; }
        public System.DateTime RegistrationDate { get; set; }
        public string pZone { get; set; }
        public string pDistrict { get; set; }
        public int pWardNo { get; set; }
        public string pStreetName { get; set; }
        public string tZone { get; set; }
        public string tDistrict { get; set; }
        public int tWardNo { get; set; }
        public string tStreetName { get; set; }
        public string SchoolName { get; set; }
        public string SchoolAddress { get; set; }
        public int PassedYear { get; set; }
        public Nullable<double> Percentage { get; set; }
        public string BoardName { get; set; }
        public string LevelName { get; set; }
        public double GPA { get; set; }
        public string CourseName { get; set; }
        public string PhotoAttPath { get; set; }
        public string PhotoAttName { get; set; }
        public string MarksheetAttPath { get; set; }
        public string MarksheetAttName { get; set; }
    }
}
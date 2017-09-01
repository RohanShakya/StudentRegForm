using StuRegForm.Models.StuRegFormDb;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StuRegForm.ViewModel
{
    public class StudentsViewModel
    {
        [Display(Name = "Form Number")]
        public int StudentId { get; set; }

        [Display(Name = "Voucher Number")]
        [Required]
        public int VoucherNo { get; set; }

        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Middle Name")]
        public string MiddleName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "Gender")]
        [Required]
        public int GenderId { get; set; }

        [Display(Name = "Mobile Number")]
        [Required]
        public long Mobile { get; set; }

        [Display(Name = "Email")]
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        [Required]
        public System.DateTime DateOfBirth { get; set; }

        [Display(Name = "Parent's Name")]
        [Required]
        public string ParentName { get; set; }

        [Display(Name = "Parent's Contact Number")]
        [Required]
        public long ParentMobile { get; set; }

        //[Display(Name = "Permanent Address")]
        //[Required]
        //public int PerAddressId { get; set; }

        //[Display(Name = "Temporary Address")]
        //[Required]
        //public Nullable<int> TempAddressId { get; set; }

        //public System.DateTime RegistrationDate { get; set; }

        //public IList<SelectListItem> ZoneNames { get; set; }

        //public IList<SelectListItem> DistrictNames { get; set; }


        public int TempZoneId { get; set; }

        public int TempDistrictId { get; set; }

        public int TempWardNo { get; set; }

        public string TempStreet { get; set; }

        [Required]
        public int PerZoneId { get; set; }

        [Required]
        public int PerDistrictId { get; set; }

        [Required]
        public int PerWardNo { get; set; }

        [Required]
        public string PerStreet { get; set; }

        [Required]
        public string SchoolName { get; set; }

        [Required]
        public string SchoolAddress { get; set; }

        [Required]
        public int PassedYear { get; set; }

        [Required]
        public int LevelId { get; set; }

        [Required]
        public int GradeId { get; set; }

        public Nullable<double> Percentage { get; set; }

        [Required]
        public int BoardId { get; set; }

        [Display(Name = "Choose the Course you would like to apply for.")]
        [Required]
        public int CourseId { get; set; }
        
        [Required]
        public HttpPostedFileBase photoFile { get; set; }

        [Required]
        public HttpPostedFileBase marksheetFile { get; set; }
        
        public string PhotoAttPath { get; set; }
        
        public string PhotoAttName { get; set; }

        public string MarksheetAttPath { get; set; }

        public string MarksheetAttName { get; set; }

        
        //public virtual Genders Genders { get; set; }
        //public virtual StudentAddress StudentAddress { get; set; }
        //public virtual StudentAddress StudentAddress1 { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<StudentSchool> StudentSchool { get; set; }
        //public virtual Courses Courses { get; set; }
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<StudentAttachments> StudentAttachments { get; set; }

    }
}
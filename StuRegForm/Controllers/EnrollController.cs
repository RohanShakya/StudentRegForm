using StuRegForm.Models.StuRegFormDb;
using StuRegForm.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StuRegForm.Controllers
{
    public class EnrollController : Controller
    {
        private StuRegFormEntities db = new StuRegFormEntities();
        
        // GET: Enroll
        public ActionResult Index()
        {
            ViewBag.Address = "kathmandu nepal";
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Gender");

            ViewBag.TempZoneId = new SelectList(db.Zones, "Id", "Zone");
            ViewBag.TempDistrictId = new SelectList(db.Districts, "Id", "District");

            //ViewBag.PerZoneId = ViewBag.TempZoneId;
            //ViewBag.PerDistrictId = ViewBag.TempDistrictId;

            ViewBag.LevelId = new SelectList(db.Level, "Id", "LevelName");
            ViewBag.BoardId = new SelectList(db.Board, "Id", "BoardName");
            ViewBag.GradeId = new SelectList(db.Grades, "Id", "GPA");
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName");

            List<Zones> ZonesList = db.Zones.ToList();
            ViewBag.ZonesList = new SelectList(ZonesList, "Id", "Zone");

            return View();
        }

        
        [HttpPost]
        public ActionResult Index(StudentsViewModel svm, HttpPostedFileBase photoFile, HttpPostedFileBase marksheetFile)
        {
            var voucher = db.Students.FirstOrDefault(x => x.VoucherNo==svm.VoucherNo);
            if(voucher!=null)
            {
                ModelState.AddModelError("VoucherNo", "Voucher already exists");
            }

            if (ModelState.IsValid)
            {

                // insert permanannt and temp addrerss in student address table

                StudentAddress perStudentAdd = new StudentAddress { ZoneId = svm.PerZoneId, DistrictId = svm.PerDistrictId, WardNo = svm.PerWardNo, StreetName = svm.PerStreet };

                StudentAddress tempStudentAdd = new StudentAddress { ZoneId = svm.TempZoneId, DistrictId = svm.TempDistrictId, WardNo = svm.TempWardNo, StreetName = svm.TempStreet };

                db.StudentAddress.Add(perStudentAdd);
                db.StudentAddress.Add(tempStudentAdd);
                db.SaveChanges();
                
                var stuId = db.Students.Max(x => x.StudentId) + 1;
                svm.StudentId = stuId;

                Students s = new Students();
                s.StudentId = svm.StudentId;
                s.VoucherNo = svm.VoucherNo;
                s.FirstName = svm.FirstName;
                s.MiddleName = svm.MiddleName;
                s.LastName = svm.LastName;
                s.GenderId = svm.GenderId;
                s.Mobile = svm.Mobile;
                s.Email = svm.Email;
                s.DateOfBirth = svm.DateOfBirth;
                s.ParentName = svm.ParentName;
                s.ParentMobile = svm.ParentMobile;
                s.PerAddressId = perStudentAdd.Id;
                s.TempAddressId = tempStudentAdd.Id;
                s.RegistrationDate = DateTime.Now;
                
                db.Students.Add(s);
                db.SaveChanges();
                
                StudentSchool stuSchool = new StudentSchool { StudentId = stuId, SchoolName = svm.SchoolName, SchoolAddress = svm.SchoolAddress, PassedYear = svm.PassedYear, LevelId = svm.LevelId, GradeId = svm.GradeId, Percentage = svm.Percentage, BoardId = svm.BoardId };
                db.StudentSchool.Add(stuSchool);
                db.SaveChanges();

                StudentCourse stuCourse = new StudentCourse { StudentId = stuId, CourseId = svm.CourseId };
                db.StudentCourse.Add(stuCourse);
                db.SaveChanges();

                if (photoFile != null)
                {
                    var photoPath = Path.Combine(Server.MapPath("~/Content/Uploads/Photos"), photoFile.FileName);
                    photoFile.SaveAs(photoPath);

                    svm.PhotoAttName = photoFile.FileName;
                    svm.PhotoAttPath = photoPath;
                }

                if (marksheetFile != null)
                {
                    var marksheetPath = Path.Combine(Server.MapPath("~/Content/Uploads/marksheet"), marksheetFile.FileName);
                    marksheetFile.SaveAs(marksheetPath);

                    svm.MarksheetAttName = marksheetFile.FileName;
                    svm.MarksheetAttPath = marksheetPath;
                }

                StudentAttachments stuAttachments = new StudentAttachments { StudentId = stuId, PhotoAttName = svm.PhotoAttName, PhotoAttPath = svm.PhotoAttPath, MarksheetAttName = svm.MarksheetAttName, MarksheetAttPath = svm.MarksheetAttPath };
                db.StudentAttachments.Add(stuAttachments);

                db.SaveChanges();

                return RedirectToAction("Index", "Success");
            }
            ViewBag.GenderId = new SelectList(db.Genders, "Id", "Gender");
            ViewBag.TempZoneId = new SelectList(db.Zones, "Id", "Zone");
            ViewBag.TempDistrictId = new SelectList(db.Districts, "Id", "District");

            ViewBag.PerZoneId = ViewBag.TempZoneId;
            //ViewBag.PerDistrictId = ViewBag.TempDistrictId;
            ViewBag.LevelId = new SelectList(db.Level, "Id", "LevelName");
            ViewBag.BoardId = new SelectList(db.Board, "Id", "BoardName");
            ViewBag.GradeId = new SelectList(db.Grades, "Id", "GPA");
            ViewBag.CourseId = new SelectList(db.Courses, "Id", "CourseName");
            return View();
        }
        
        public JsonResult GetDistrictsList(int perZoneId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            List<Districts> DistrictsList = db.Districts.Where(x => x.ZoneId == perZoneId).ToList();
            return Json(DistrictsList, JsonRequestBehavior.AllowGet);
        }
        
    }
}


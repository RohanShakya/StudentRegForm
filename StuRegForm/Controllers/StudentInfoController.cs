using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StuRegForm.Models.StuRegFormDb;

namespace StuRegForm.Controllers
{
    public class StudentInfoController : Controller
    {
        private StuRegFormEntities db = new StuRegFormEntities();

        // GET: StudentInfo
        public ActionResult Index()
        {
            return View(db.vwStuAllInfo.ToList());
        }

        // GET: StudentInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwStuAllInfo vwStuAllInfo = db.vwStuAllInfo.Find(id);
            if (vwStuAllInfo == null)
            {
                return HttpNotFound();
            }
            return View(vwStuAllInfo);
        }

        // GET: StudentInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StudentInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,VoucherNo,FirstName,MiddleName,LastName,Gender,Mobile,Email,DateOfBirth,ParentName,ParentMobile,RegistrationDate,pZone,pDistrict,pWardNo,pStreetName,tZone,tDistrict,tWardNo,tStreetName,SchoolName,SchoolAddress,PassedYear,Percentage,BoardName,LevelName,GPA,CourseName,PhotoAttPath,PhotoAttName,MarksheetAttPath,MarksheetAttName")] vwStuAllInfo vwStuAllInfo)
        {
            if (ModelState.IsValid)
            {
                db.vwStuAllInfo.Add(vwStuAllInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vwStuAllInfo);
        }

        // GET: StudentInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwStuAllInfo vwStuAllInfo = db.vwStuAllInfo.Find(id);
            if (vwStuAllInfo == null)
            {
                return HttpNotFound();
            }
            return View(vwStuAllInfo);
        }

        // POST: StudentInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,VoucherNo,FirstName,MiddleName,LastName,Gender,Mobile,Email,DateOfBirth,ParentName,ParentMobile,RegistrationDate,pZone,pDistrict,pWardNo,pStreetName,tZone,tDistrict,tWardNo,tStreetName,SchoolName,SchoolAddress,PassedYear,Percentage,BoardName,LevelName,GPA,CourseName,PhotoAttPath,PhotoAttName,MarksheetAttPath,MarksheetAttName")] vwStuAllInfo vwStuAllInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vwStuAllInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vwStuAllInfo);
        }

        // GET: StudentInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwStuAllInfo vwStuAllInfo = db.vwStuAllInfo.Find(id);
            if (vwStuAllInfo == null)
            {
                return HttpNotFound();
            }
            return View(vwStuAllInfo);
        }

        // POST: StudentInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vwStuAllInfo vwStuAllInfo = db.vwStuAllInfo.Find(id);
            db.vwStuAllInfo.Remove(vwStuAllInfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

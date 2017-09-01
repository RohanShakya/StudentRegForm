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
    public class StudentsController : Controller
    {
        private StuRegFormEntities db = new StuRegFormEntities();

        // GET: Students
        public ActionResult Index()
        {
            return View(db.vwStudentAddress.ToList());
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwStudentAddress vwStudentAddress = db.vwStudentAddress.FirstOrDefault(x => x.StudentId == id);
            if (vwStudentAddress == null)
            {
                return HttpNotFound();
            }
            return View(vwStudentAddress);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StudentId,VoucherNo,FirstName,MiddleName,LastName,GenderId,Mobile,Email,DateOfBirth,ParentName,ParentMobile,PerAddressId,TempAddressId,RegistrationDate,PZone,PDistrict,wardNo,StreetName,tWard,tStreet,TZone,TDistrict")] vwStudentAddress vwStudentAddress)
        {
            if (ModelState.IsValid)
            {
                db.vwStudentAddress.Add(vwStudentAddress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vwStudentAddress);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwStudentAddress vwStudentAddress = db.vwStudentAddress.Find(id);
            if (vwStudentAddress == null)
            {
                return HttpNotFound();
            }
            return View(vwStudentAddress);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StudentId,VoucherNo,FirstName,MiddleName,LastName,GenderId,Mobile,Email,DateOfBirth,ParentName,ParentMobile,PerAddressId,TempAddressId,RegistrationDate,PZone,PDistrict,wardNo,StreetName,tWard,tStreet,TZone,TDistrict")] vwStudentAddress vwStudentAddress)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vwStudentAddress).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vwStudentAddress);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vwStudentAddress vwStudentAddress = db.vwStudentAddress.Find(id);
            if (vwStudentAddress == null)
            {
                return HttpNotFound();
            }
            return View(vwStudentAddress);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            vwStudentAddress vwStudentAddress = db.vwStudentAddress.Find(id);
            db.vwStudentAddress.Remove(vwStudentAddress);
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

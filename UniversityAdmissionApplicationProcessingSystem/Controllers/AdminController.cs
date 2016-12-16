using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using UniversityAdmissionApplicationProcessingSystem.Core.BLL;
using UniversityAdmissionApplicationProcessingSystem.Models;

namespace UniversityAdmissionApplicationProcessingSystem.Controllers
{
    public class AdminController : Controller
    {
        private UASDBEntities db = new UASDBEntities();

        private ApplicantManager applicantManager = new ApplicantManager();
        public ActionResult LogIn()
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            ModelState.Clear();
            return View();
        }

        [HttpPost]
        public ActionResult LogIn(Admin admin)
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            var user = db.Admins.Where(m => m.UserName == admin.UserName && m.Password == admin.Password).SingleOrDefault();
            Session["User"] = user;
            if (Session["User"] != null)
            {
                return RedirectToAction("AdminHome", "Admin");
            }
            ViewBag.PostBack = true;

            return View();
        }

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("LogIn");
        }

        public ActionResult AdminHome()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("LogIn", "Admin");
            }
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            return View();
        }
        public ActionResult Index()
        {
            if (Session["User"] == null)
            {
                return RedirectToAction("LogIn", "Admin");
            }
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            return View(db.Admins.ToList());
        }

        public ActionResult Create()
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            return View();
        }

        [HttpPost]
     
        public ActionResult Create([Bind(Include="Id,UserName,Password")] Admin admin)
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            if (ModelState.IsValid)
            {
                db.Admins.Add(admin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(admin);
        }

        public ActionResult Edit(int? id)
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Admin admin = db.Admins.Find(id);
            if (admin == null)
            {
                return HttpNotFound();
            }
            return View(admin);
        }

        [HttpPost]
        
        public ActionResult Edit([Bind(Include="Id,UserName,Password")] Admin admin)
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            if (ModelState.IsValid)
            {
                db.Entry(admin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(admin);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityAdmissionApplicationProcessingSystem.Core.BLL;
using UniversityAdmissionApplicationProcessingSystem.Models;

namespace UniversityAdmissionApplicationProcessingSystem.Controllers
{
    public class UnitWiseAdminController : Controller
    {
        UnitWiseApplicantManager unitWiseApplicantManager=new UnitWiseApplicantManager();
        private ApplicantManager applicantManager = new ApplicantManager();

        public List<SelectListItem> GetUnit()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "--Select Unit--", Selected = true},
                new SelectListItem() {Value = "A", Text = "A", Selected = false},
                new SelectListItem() {Value = "B", Text = "B", Selected = false},


            };
            return items;
        }

       public ActionResult ShowAllApplicant()
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            ViewBag.Unit = GetUnit();
            ViewBag.PostBack = false;
           
            return View();
        }
      


        [HttpPost]
    public ActionResult ShowAllApplicant(Applicant applicant)
    {
        ViewBag.Unit = GetUnit();
        var exam = applicantManager.GetExamInfo();
        ViewBag.Exam = exam;

        var unitWiseApplicantList = unitWiseApplicantManager.GetAllApplicantsByUnit(applicant);
        ViewBag.UnitWiseApplicantList = unitWiseApplicantList;
        ViewBag.TotalApplicant= unitWiseApplicantList.Count();
        ViewBag.UnitName = applicant.Unit;
        ViewBag.PostBack = true;
       
        return View();
    }

        public ActionResult AllocateRoom()
        {
            ViewBag.PostBack = false;
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            var roomList=unitWiseApplicantManager.GetAllRoom();
            ViewBag.RoomList = roomList;
            ViewBag.Unit = GetUnit();
            return View();

        }

        [HttpPost]
        public ActionResult AllocateRoom(Applicant applicant)
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            ViewBag.AllocateRoom = unitWiseApplicantManager.AllocateRoom(applicant);
            ViewBag.RoomList = unitWiseApplicantManager.GetAllRoom();
            ViewBag.Unit = GetUnit();
            ViewBag.PostBack = true;

            return View();

        }


        public ActionResult GetAllocateRoomByRollNo()
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            ViewBag.Unit = GetUnit();
            ViewBag.PostBack = false;

            return View();
        }



        [HttpPost]
        public ActionResult GetAllocateRoomByRollNo(Applicant applicant)
        {
            ViewBag.Unit = GetUnit();
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;

            var allocateRoomInfo = unitWiseApplicantManager.GeApplicantsByRollNo(applicant);
            ViewBag.AllocateRoomInfo = allocateRoomInfo;
            ViewBag.PostBack = true;

            return View();
        }


       
	}
        
	}

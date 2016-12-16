using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa;
using UniversityAdmissionApplicationProcessingSystem.Core.BLL;
using UniversityAdmissionApplicationProcessingSystem.Models;

namespace UniversityAdmissionApplicationProcessingSystem.Controllers
{
    public class ApplicantController : Controller
    {

        private ApplicantManager applicantManager = new ApplicantManager();

        private AUnitManager aUnitManager = new AUnitManager();
        private BUnitManager bUnitManager = new BUnitManager();

        public List<SelectListItem> GetBoard()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select Board Name...", Selected = true},
                 new SelectListItem() {Value = "DHAKA", Text = "DHAKA", Selected = false},
                new SelectListItem() {Value = "BARISHAL", Text = "BARISHAL", Selected = false},
                new SelectListItem() {Value = "COMILLA", Text = "COMILLA", Selected = false},
                new SelectListItem() {Value = "CHITTAGONG", Text = "CHITTAGONG", Selected = false},
                new SelectListItem() {Value = "DINAJPUR", Text = "DINAJPUR", Selected = false},
                new SelectListItem() {Value = "JESSORE", Text = "JESSORE", Selected = false},
                new SelectListItem() {Value = "MADRASAH", Text = "MADRASAH", Selected = false},
                new SelectListItem() {Value = "RAJSHAHI", Text = "RAJSHAHI", Selected = false},
                new SelectListItem() {Value = "SYLHET", Text = "SYLHET", Selected = false},
                new SelectListItem() {Value = "TECHNICAL", Text = "TECHNICAL", Selected = false},

            };
            return items;
        }

        public List<SelectListItem> GetUnit()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select Unit...", Selected = true},
                new SelectListItem() {Value = "A", Text = "A", Selected = false},
                new SelectListItem() {Value = "B", Text = "B", Selected = false},


            };
            return items;
        }

        public List<SelectListItem> GetSSCPassYear()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select Passing Year...", Selected = true},
                new SelectListItem() {Value = "2015", Text = "2015", Selected = false},
                new SelectListItem() {Value = "2014", Text = "2014", Selected = false},
                new SelectListItem() {Value = "2013", Text = "2013", Selected = false},

            };
            return items;
        }

        public List<SelectListItem> GetHSCPassYear()
        {
            List<SelectListItem> items = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "Select Passing Year...", Selected = true},
                new SelectListItem() {Value = "2016", Text = "2016", Selected = false},
                new SelectListItem() {Value = "2015", Text = "2015", Selected = false},

            };
            return items;
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult LogIn()
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            ViewBag.Board = GetBoard();
            ViewBag.SSCPassYear = GetSSCPassYear();
            ViewBag.HSCPassYear = GetHSCPassYear();
            return View();
        }

        [HttpPost]
        public ActionResult ApplicantDetailInfo(Applicant applicant)
        {
            var applicant1 = applicantManager.GetApplicantInfo(applicant);
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            ViewBag.Applicant = applicant1;
            ViewBag.Board = GetBoard();
            ViewBag.SSCPassYear = GetSSCPassYear();
            ViewBag.HSCPassYear = GetHSCPassYear();
            ViewBag.AUnit = aUnitManager.AUnit(applicant);


            if (aUnitManager.CSE(applicant) == true)
            {
                ViewBag.CSE = "CSE";
            }
            else
            {
                ViewBag.CSE = "";
            }

            if (aUnitManager.Math(applicant) == true)
            {
                ViewBag.Math = "Math";
            }
            else
            {
                ViewBag.Math = "";
            }
            if (aUnitManager.Physics(applicant) == true)
            {
                ViewBag.Physics = "Physics";
            }
            else
            {
                ViewBag.Physics = "";
            }
            if (aUnitManager.Environment(applicant) == true)
            {
                ViewBag.Environment = "Environment";
            }
            else
            {
                ViewBag.Environment = "";
            }


            if (aUnitManager.Statistics(applicant) == true)
            {
                ViewBag.Statistics = "Statistics";
            }
            else
            {
                ViewBag.Statistics = null;
            }
            if (aUnitManager.Geology(applicant) == true)
            {
                ViewBag.Geology = "Geology";
            }
            else
            {
                ViewBag.Geology = null;
            }
            if (aUnitManager.Chemistry(applicant) == true)
            {
                ViewBag.Chemistry = "Chemistry";
            }
            else
            {
                ViewBag.Chemistry = null;
            }


            ViewBag.BUnit = bUnitManager.BUnit(applicant);

            if (bUnitManager.Economics(applicant) == true)
            {
                ViewBag.Economics = "Economics";
            }
            else
            {
                ViewBag.Economics = null;
            }

            if (bUnitManager.GeologyAndEnvironment(applicant) == true)
            {
                ViewBag.GeologyAndEnvironment = "Geology & Environment";
            }
            else
            {
                ViewBag.GeologyAndEnvironment = null;
            }
            if (bUnitManager.GovernmentAndPolitics(applicant) == true)
            {
                ViewBag.GovernmentAndPolitics = "Government & Politics";
            }
            else
            {
                ViewBag.GovernmentAndPolitics = null;
            }

            

            //if (bUnitManager.BUnit(applicant) == "ELIGIBLE For B Unit")
            //{
            //    ViewBag.BUnitSubject = "Subject B";
            //}
            //else
            //{
            //    ViewBag.BUnitSubject = null;
            //}



            return View(applicant1);
        }

        [HttpPost]

        public ActionResult SaveApplicantInfo(Applicant applicant)
        {

            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            var applicants = applicantManager.GetApplicantInfo(applicant);
            ViewBag.Applicant = applicants;

            if (applicant.Unit == "A")
            {

                var fileNamePhoto = Path.GetFileName(applicant.Unit+applicant.HSC_Roll + applicant.HSC_Board + applicant.HSC_PassYear + "Photo" + applicant.Photo.FileName);
                var pathFolderPhoto = Path.Combine(Server.MapPath("/AUnit_Photos/"), fileNamePhoto);
                var pathDbPhoto = "~/AUnit_Photos/" + fileNamePhoto;

                applicant.PhotoLocation = pathDbPhoto;

                var fileNameSign = Path.GetFileName(applicant.Unit+applicant.HSC_Roll + applicant.HSC_Board + applicant.HSC_PassYear + "Sign" + applicant.Signature.FileName);
                var pathFolderSign = Path.Combine(Server.MapPath("/AUnit_Signs/"), fileNameSign);
                var pathDbSign = "~/AUnit_Signs/" + fileNameSign;

                applicant.SignatureLocation = pathDbSign;

                ViewBag.Message = applicantManager.SaveApplicant(applicant);
                if (ViewBag.Message == "Save Successfully")
                {
                    applicant.Photo.SaveAs(pathFolderPhoto);
                    applicant.Signature.SaveAs(pathFolderSign);
                }

            }

            else if (applicant.Unit == "B")
            {


                var fileNamePhoto = Path.GetFileName(applicant.Unit+applicant.HSC_Roll + applicant.HSC_Board + applicant.HSC_PassYear + "Photo" + applicant.Photo.FileName);
                var pathFolderPhoto = Path.Combine(Server.MapPath("/BUnit_Photos/"), fileNamePhoto);
                var pathDbPhoto = "~/BUnit_Photos/" + fileNamePhoto;

                applicant.PhotoLocation = pathDbPhoto;

                var fileNameSign = Path.GetFileName(applicant.Unit+applicant.HSC_Roll + applicant.HSC_Board + applicant.HSC_PassYear+ "Sign" + applicant.Signature.FileName);
                var pathFolderSign = Path.Combine(Server.MapPath("/BUnit_Signs/"), fileNameSign);
                var pathDbSign = "~/BUnit_Signs/" + fileNameSign;

                applicant.SignatureLocation = pathDbSign;

                ViewBag.Message = applicantManager.SaveApplicant(applicant);
                if (ViewBag.Message == "Save Successfully")
                {
                    applicant.Photo.SaveAs(pathFolderPhoto);
                    applicant.Signature.SaveAs(pathFolderSign);
                }

            }

            var applicantAdmit = applicantManager.GetApplicant(applicant);
            ViewBag.Admit = applicantAdmit;

            return View(applicant);


        }

        [HttpPost]
        public ActionResult GetAdmitCard(Applicant applicant)
        {

            var applicantAdmit = applicantManager.GetApplicant(applicant);
            ViewBag.Admit = applicantAdmit;
            var admitCardFileName = applicantAdmit.RollNo + "_" + applicantAdmit.Name + "_" + applicantAdmit.Unit + "_" + ".pdf";


            return new ActionAsPdf("DownloadAdmitCard", applicantAdmit) { FileName = admitCardFileName };

        }


        public ActionResult DownloadAdmitCard(Applicant applicant)
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            var applicantAdmit = applicantManager.GetApplicant(applicant);
            ViewBag.Admit = applicantAdmit;
            return View();
        }
        public ActionResult RecoveryAdmit()
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;

            ViewBag.Board = GetBoard();
            ViewBag.SSCPassYear = GetSSCPassYear();
            ViewBag.HSCPassYear = GetHSCPassYear();
            ViewBag.Unit = GetUnit();
            return View();
        }
        [HttpPost]
        public ActionResult RecoveryAdmitCardView(Applicant applicant)
        {

            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            var applicantAdmit = applicantManager.GetApplicant(applicant);
            ViewBag.Admit = applicantAdmit;

            return View();
        }

        public ActionResult RecoveryTransctionId()
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            ViewBag.PostBack = false;
            return View();
        }
        [HttpPost]
        public ActionResult RecoveryTransctionId(Applicant applicant)
        {
            var exam = applicantManager.GetExamInfo();
            ViewBag.Exam = exam;
            var transction = applicantManager.GetTransctionId(applicant);
            ViewBag.Transction = transction;
            ViewBag.PostBack = true;
            return View();
        }

        public ActionResult Payment()
        {
            return View();
        }

        public ActionResult Notice()
        {
            return View();

        }

        public ActionResult HelpLine()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

    }
}
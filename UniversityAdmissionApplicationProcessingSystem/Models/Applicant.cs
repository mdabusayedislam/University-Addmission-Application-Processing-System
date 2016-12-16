using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityAdmissionApplicationProcessingSystem.Models
{
    public class Applicant
    {
    
        public int Id { get; set; }
        [Required(ErrorMessage = "এসএসসি রোল ইনপুট দিন")]
        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only  numbers of SSC Roll  Number")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "SSC Roll Number must be 6(Six) charecters long")]
        [DisplayName("রোল নং")]
        public string SSC_Roll { get; set; }
        [Required(ErrorMessage = "এসএসসি রেজিঃ ইনপুট দিন")]
        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only  numbers of SSC Registration Number ")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "SSC Registration Number must be 6(Six) charecters long")]
        [DisplayName("রেজিঃ নং")]
        public string SSC_Reg { get; set; }
        [Required(ErrorMessage = " এসএসসি  বোর্ড সিলেক্ট করুন")]
        [DisplayName("বোর্ড")]
        public string SSC_Board { get; set; }
        [Required(ErrorMessage = "এসএসসি পাসের সন সিলেক্ট করুন")]
        [DisplayName("পাসের  সন")]
        public string SSC_PassYear { get; set; }
        [Required(ErrorMessage ="এইচএসসি রোল ইনপুট দিন")]
        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only  numbers of HSC Roll  Number")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "HSC Roll Number must be 6(Six) charecters long")]
        [DisplayName("রোল নং")]
        public string HSC_Roll { get; set; }
        [Required(ErrorMessage = "এইচএসসি রেজিঃ ইনপুট দিন")]
        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only  numbers of HSC Registration Number ")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "HSC Registration Number must be 6(Six) charecters long")]
        [DisplayName("রেজিঃ নং")]
        public string HSC_Reg { get; set; }
        [Required(ErrorMessage = "এইচএসসি  বোর্ড সিলেক্ট করুন")]
        [DisplayName("বোর্ডের নাম")]
        public string HSC_Board { get; set; }
        
        public int HSC_BoardId { get; set; }
        [Required(ErrorMessage = " এইচএসসি  পাসের সন সিলেক্ট করুন")]
        [DisplayName("পাশের সন")]
        public string HSC_PassYear { get; set; }

        public int HSC_PassYearId { get; set; }

        public string Name { get; set; }
        public string FatherName { get; set; }
        public string MotherName { get; set; }
        public string Sex { get; set; }
        public double SSC_GPA { get; set; }
        public double SSC_GPAEXC4TH { get; set; }

       

        public string SSC_SubjectWiseGrade { get; set; }


        public string SSC_SubjectCode1 { get; set; }
        public string SSC_SubjectName1 { get; set; }
        public string SSC_SubjectGrade1 { get; set; }
        public double SSC_SubjectPoint1 { get; set; }
        public string SSC_SubjectCode2 { get; set; }
        public string SSC_SubjectName2 { get; set; }
        public string SSC_SubjectGrade2 { get; set; }
        public double SSC_SubjectPoint2 { get; set; }
        public string SSC_SubjectCode3 { get; set; }
        public string SSC_SubjectName3 { get; set; }
        public string SSC_SubjectGrade3 { get; set; }
        public double SSC_SubjectPoint3 { get; set; }
        public string SSC_SubjectCode4 { get; set; }
        public string SSC_SubjectName4 { get; set; }
        public string SSC_SubjectGrade4 { get; set; }
        public double SSC_SubjectPoint4 { get; set; }
        public string SSC_SubjectCode5 { get; set; }
        public string SSC_SubjectName5 { get; set; }
        public string SSC_SubjectGrade5 { get; set; }
        public double SSC_SubjectPoint5 { get; set; }
        public string SSC_SubjectCode6 { get; set; }
        public string SSC_SubjectName6 { get; set; }
        public string SSC_SubjectGrade6 { get; set; }
        public double SSC_SubjectPoint6 { get; set; }
        public string SSC_SubjectCode7 { get; set; }
        public string SSC_SubjectName7 { get; set; }
        public string SSC_SubjectGrade7 { get; set; }
        public double SSC_SubjectPoint7 { get; set; }
        public string SSC_SubjectCode8 { get; set; }
        public string SSC_SubjectName8 { get; set; }
        public string SSC_SubjectGrade8 { get; set; }
        public double SSC_SubjectPoint8 { get; set; }
        public string SSC_SubjectCode9 { get; set; }
        public string SSC_SubjectName9 { get; set; }
        public string SSC_SubjectGrade9 { get; set; }
        public double SSC_SubjectPoint9 { get; set; }



        public string SSC_4thSubject { get; set; }



        public string SSC_4thSubjectCode { get; set; }
        public string SSC_4thSubjectName { get; set; }
        public string SSC_4thSubjectGrade { get; set; }
        public double SSC_4thSubjectPoint { get; set; }



        public string HSC_Group { get; set; }

        public double HSC_GPA { get; set; }
        public double HSC_GPAEXC4TH { get; set; }



        public string HSC_SubjectWiseGrade { get; set; }


        public string HSC_SubjectCode1 { get; set; }
        public string HSC_SubjectName1 { get; set; }
        public string HSC_SubjectGrade1 { get; set; }
        public double HSC_SubjectPoint1 { get; set; }
        public string HSC_SubjectCode2 { get; set; }
        public string HSC_SubjectName2 { get; set; }
        public string HSC_SubjectGrade2 { get; set; }
        public double HSC_SubjectPoint2 { get; set; }
        public string HSC_SubjectCode3 { get; set; }
        public string HSC_SubjectName3 { get; set; }
        public string HSC_SubjectGrade3 { get; set; }
        public double HSC_SubjectPoint3 { get; set; }
        public string HSC_SubjectCode4 { get; set; }
        public string HSC_SubjectName4 { get; set; }
        public string HSC_SubjectGrade4 { get; set; }
        public double HSC_SubjectPoint4 { get; set; }
        public string HSC_SubjectCode5 { get; set; }
        public string HSC_SubjectName5 { get; set; }
        public string HSC_SubjectGrade5 { get; set; }
        public double HSC_SubjectPoint5 { get; set; }
        public string HSC_SubjectCode6 { get; set; }
        public string HSC_SubjectName6 { get; set; }
        public string HSC_SubjectGrade6 { get; set; }
        public double HSC_SubjectPoint6 { get; set; }



        public string HSC_4thSubject { get; set; }



        public string HSC_4thSubjectCode { get; set; }
        public string HSC_4thSubjectName { get; set; }
        public string HSC_4thSubjectGrade { get; set; }
        public double HSC_4thSubjectPoint { get; set; }



        public double Total_GPA { get; set; }
        public double Total_GPAEXC4TH { get; set; }


        

        public string University { get; set; }
        public string ExamName { get; set; }
        [Required(ErrorMessage = "মোবাইল নম্বর ইনপুট দিন")]
        [RegularExpression("([0-9 .&'-]+)", ErrorMessage = "Enter only  numbers of Mobile  Number")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Mobile Number must be 11(Eleven) charecters long")]
        [DisplayName("মোবাইল নং")]
        public string Mobile { get; set; }
        //[Required(ErrorMessage = "ইমেইল আইডি  ইনপুট দিন")]
        //[RegularExpression("(^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$)", ErrorMessage = "Enter only correct format  of Email ID")]
       // [DisplayName("ইমেইল নং")]
        public string TransctionId { get; set; }



        public HttpPostedFileBase Photo { get; set; }
        public string PhotoLocation { get; set; }
        public HttpPostedFileBase Signature { get; set; }
        public string SignatureLocation { get; set; }
        [Required(ErrorMessage = " রোল নং সিলেক্ট করুন")]
        public int RollNo { get; set; }

        [Required(ErrorMessage = "ইউনিট সিলেক্ট করুন")]
        [DisplayName("ইউনিট")]
        public string Unit { get; set; }
        public int UnitId { get; set; }

        public string BillerId { get; set; }
        public string BillNumber { get; set; }
        public int Amount { get;set; }

        [Required(ErrorMessage = "রুম সিলেক্ট করুন")]
        public string AllocateRoom { get; set; }
         [Required(ErrorMessage = "আসন সংখ্যা  সিলেক্ট করুন")]
        public int CapacityofRoom { get; set; }


       
       


        

        
    }
}
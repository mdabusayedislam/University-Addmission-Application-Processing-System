using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityAdmissionApplicationProcessingSystem.Core.DAL;
using UniversityAdmissionApplicationProcessingSystem.Models;

namespace UniversityAdmissionApplicationProcessingSystem.Core.BLL
{
    public class ApplicantManager
    {
        private ApplicantGateway applicantGateway = new ApplicantGateway();

        public Applicant GetApplicantInfo(Applicant applicant)
        {
            return applicantGateway.GetApplicantInfo(applicant);
        }

        public Applicant GetApplicant(Applicant applicant)
        {
            return applicantGateway.GetApplicant(applicant);
        }


        public Applicant GetExamInfo()
        {
            return applicantGateway.GetExamInfo();
        }

        public string SaveApplicant(Applicant applicant)
        {
            if (applicant.Mobile.Length == 11)
            {
                if (applicantGateway.IsPaymentCompleted(applicant))
                {
                    if ((applicant.Unit == "A" && !applicantGateway.IsApplicantExistsAUnit(applicant)) || (applicant.Unit == "B" && !applicantGateway.IsApplicantExistsBUnit(applicant)))
                    {
                        if (applicantGateway.SaveApplicant(applicant) > 0)
                        {
                            return "Save Successfully";
                        }

                        else
                        {
                            return "Insertion Fail";
                        }
                    }
                    else
                    {
                        return "Information Already Exist";
                    }
                }
                else
                {
                    return "Payment Incomplete";
                }

            }
            else
            {
                return "Mobile number must be 11 Character long";
            }

        }


        public List<Applicant> GetTransctionId(Applicant applicant)
        {
            return applicantGateway.GetTransctionId(applicant);
        }
    }


}
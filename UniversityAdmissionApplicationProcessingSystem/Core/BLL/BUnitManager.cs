using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityAdmissionApplicationProcessingSystem.Core.DAL;
using UniversityAdmissionApplicationProcessingSystem.Models;

namespace UniversityAdmissionApplicationProcessingSystem.Core.BLL
{
    public class BUnitManager
    {
        private ApplicantGateway applicantGateway = new ApplicantGateway();

        public string BUnit(Applicant applicant)
        {
            if (!applicantGateway.IsApplicantExistsBUnit(applicant))
            {
                if (((applicantGateway.GetApplicantInfo(applicant).HSC_GPA >= 3.25)
                     && (applicantGateway.GetApplicantInfo(applicant).SSC_GPA >= 3.25)))
                {
                    if (((Economics(applicant) == true) || (GovernmentAndPolitics(applicant)) ||
                        (GeologyAndEnvironment(applicant)) == true))

                    {
                        return "ELIGIBLE For B Unit";
                    }

                    else
                    {
                        return "Not ELIGIBLE For B Unit";
                    }
                }
                else
                {
                    return "Not ELIGIBLE For B Unit";
                }
            }
            else
            {

                return "B Unit - Already Applied";
            }
        }
    

    public bool Economics(Applicant applicant)
        {
            if (applicantGateway.GetApplicantInfo(applicant).Total_GPA >= 8.00)
            {                 
             return true;
            }
                else
                {
                    return false;
                }

            }
        public bool GeologyAndEnvironment(Applicant applicant)
        {
            if (applicantGateway.GetApplicantInfo(applicant).Total_GPA >= 7.50)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool GovernmentAndPolitics(Applicant applicant)
        {
            if (applicantGateway.GetApplicantInfo(applicant).Total_GPA >= 7.50)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }


}
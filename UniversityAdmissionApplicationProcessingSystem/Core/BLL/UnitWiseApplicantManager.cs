using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityAdmissionApplicationProcessingSystem.Core.DAL;
using UniversityAdmissionApplicationProcessingSystem.Models;

namespace UniversityAdmissionApplicationProcessingSystem.Core.BLL
{
    public class UnitWiseApplicantManager
    {

          UnitWiseApplicantGateway unitWiseApplicantGateway=new UnitWiseApplicantGateway();

        public List<Applicant> GetAllApplicantsByUnit(Applicant applicant)
        {
            return unitWiseApplicantGateway.GetAllApplicantsByUnit(applicant);
        }

        public string AllocateRoom(Applicant applicant)
        {
            if (unitWiseApplicantGateway.AllocateRoom(applicant) > 0)
            {
                return "Allocate Room Successfully";

            }
            else
            {
                return "Allocate Room Failure";
            }
        }

        public List<Applicant> GetAllRoom()
        {
            return unitWiseApplicantGateway.GetAllRoom();
        }


        public List<Applicant> GeApplicantsByRollNo(Applicant applicant)
        {
            return unitWiseApplicantGateway.GeApplicantsByRollNo(applicant);
        }

    }
}
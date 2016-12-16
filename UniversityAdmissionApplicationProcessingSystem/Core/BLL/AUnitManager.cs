using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityAdmissionApplicationProcessingSystem.Core.DAL;
using UniversityAdmissionApplicationProcessingSystem.Models;

namespace UniversityAdmissionApplicationProcessingSystem.Core.BLL
{
    public class AUnitManager
    {
        ApplicantGateway applicantGateway = new ApplicantGateway();
        public string AUnit(Applicant applicant)
        {
            if (!applicantGateway.IsApplicantExistsAUnit(applicant))
            {
                {
                    if ((applicantGateway.GetApplicantInfo(applicant).HSC_Group == "SCIENCE")
                 && ((applicantGateway.GetApplicantInfo(applicant).HSC_GPA >= 3.50)
                     && (applicantGateway.GetApplicantInfo(applicant).SSC_GPA >= 3.50)))
                    {
                        if (CSE(applicant) || Math(applicant) || Physics(applicant) || Environment(applicant) || Statistics(applicant) || Geology(applicant) || Chemistry(applicant))
                        {
                            return "ELIGIBLE For A Unit";
                        }
                        else
                        {
                            return "Not ELIGIBLE For A Unit";
                        }
                    }
                    else
                    {
                        return "Not ELIGIBLE For A Unit";
                    }

                }

            }
            else
            {
                return "A Unit - Already Applied";
            }



        }

        public bool CSE(Applicant applicant)
        {
            if (applicantGateway.GetApplicantInfo(applicant).Total_GPA >= 8.50)
            {
                if (((applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName1 == "PHYSICS"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint1 >= 4)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName2 == "PHYSICS"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint2 >= 4)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName3 == "PHYSICS"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint3 >= 4)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName4 == "PHYSICS"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint4 >= 4)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName5 == "PHYSICS"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint5 >= 4)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName6 == "PHYSICS"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint6 >= 4)))
                {
                    if ((
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName1 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint1 >= 4)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName2 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint2 >= 4)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName3 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint3 >= 4)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName4 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint4 >= 4)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName5 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint5 >= 4)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName6 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint6 >= 4)


                    ))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }


        public bool Math(Applicant applicant)
        {
            if (applicantGateway.GetApplicantInfo(applicant).Total_GPA >= 7.5)
            {
                if (
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName1 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint1 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName2 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint2 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName3 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint3 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName4 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint4 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName5 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint5 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName6 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint6 >= 3)


                    )
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }



        }

        public bool Physics(Applicant applicant)
        {
            if (applicantGateway.GetApplicantInfo(applicant).Total_GPA >= 8)
            {
                if (((applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName1 == "PHYSICS"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint1 >= 3.50)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName2 == "PHYSICS"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint2 >= 3.50)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName3 == "PHYSICS"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint3 >= 3.50)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName4 == "PHYSICS"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint4 >= 3.50)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName5 == "PHYSICS"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint5 >= 3.50)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName6 == "PHYSICS"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint6 >= 3.50)))
                {
                    if ((
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName1 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint1 >= 3.50)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName2 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint2 >= 3.50)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName3 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint3 >= 3.50)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName4 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint4 >= 3.50)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName5 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint5 >= 3.50)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName6 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint6 >= 3.50)


                    ))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }

        public bool Environment(Applicant applicant)
        {
            if (applicantGateway.GetApplicantInfo(applicant).Total_GPA >= 8.5)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Statistics(Applicant applicant)
        {
            if (applicantGateway.GetApplicantInfo(applicant).Total_GPA >= 7.50)
            {
                if (
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName1 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint1 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName2 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint2 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName3 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint3 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName4 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint4 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName5 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint5 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName6 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint6 >= 3))
                {
                    return true;
                }
                else if ((applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName1 == "STATISTICS"
                          && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint1 >= 3)
                         ||
                         (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName2 == "STATISTICS"
                          && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint2 >= 3)
                         ||
                         (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName3 == "STATISTICS"
                          && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint3 >= 3)
                         ||
                         (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName4 == "STATISTICS"
                          && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint4 >= 3)
                         ||
                         (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName5 == "STATISTICS"
                          && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint5 >= 3)
                         ||
                         (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName6 == "STATISTICS"
                          && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint6 >= 3))
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }

            else
            {
                return false;
            }
        }

        public bool Geology(Applicant applicant)
        {
            if (applicantGateway.GetApplicantInfo(applicant).Total_GPA >= 8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Chemistry(Applicant applicant)
        {
            if (applicantGateway.GetApplicantInfo(applicant).Total_GPA >= 8)
            {
                if (((applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName1 == "CHEMISTRY"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint1 >= 4)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName2 == "CHEMISTRY"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint2 >= 4)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName3 == "CHEMISTRY"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint3 >= 4)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName4 == "CHEMISTRY"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint4 >= 4)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName5 == "CHEMISTRY"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint5 >= 4)
                 ||
                 (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName6 == "CHEMISTRY"
                  && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint6 >= 4)))
                {
                    if ((
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName1 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint1 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName2 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint2 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName3 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint3 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName4 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint4 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName5 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint5 >= 3)
                    ||
                    (applicantGateway.GetApplicantInfo(applicant).HSC_SubjectName6 == "MATHEMATICS"
                     && applicantGateway.GetApplicantInfo(applicant).HSC_SubjectPoint6 >= 3)


                    ))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                else
                {
                    return false;
                }

            }
            else
            {
                return false;
            }
        }




    }
}
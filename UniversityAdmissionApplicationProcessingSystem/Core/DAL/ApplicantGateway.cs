using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityAdmissionApplicationProcessingSystem.Models;

namespace UniversityAdmissionApplicationProcessingSystem.Core.DAL
{
    public class ApplicantGateway
    {

        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityAdmissionSystemDBConnection"].ConnectionString;

        SqlConnection connection = new SqlConnection();

        public Applicant GetApplicantInfo(Applicant applicant)
        {
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand("spApplicant", connection);
            command.CommandType = CommandType.StoredProcedure;


            command.Parameters.Add("SSC_Roll", SqlDbType.NVarChar);
            command.Parameters["SSC_Roll"].Value = applicant.SSC_Roll;
            command.Parameters.Add("SSC_Reg", SqlDbType.NVarChar);
            command.Parameters["SSC_Reg"].Value = applicant.SSC_Reg;
            command.Parameters.Add("SSC_Board", SqlDbType.NVarChar);
            command.Parameters["SSC_Board"].Value = applicant.SSC_Board;
            command.Parameters.Add("SSC_PassYear", SqlDbType.NVarChar);
            command.Parameters["SSC_PassYear"].Value = applicant.SSC_PassYear;
            command.Parameters.Add("HSC_Roll", SqlDbType.NVarChar);
            command.Parameters["HSC_Roll"].Value = applicant.HSC_Roll;
            command.Parameters.Add("HSC_Reg", SqlDbType.NVarChar);
            command.Parameters["HSC_Reg"].Value = applicant.HSC_Reg;
            command.Parameters.Add("HSC_Board", SqlDbType.NVarChar);
            command.Parameters["HSC_Board"].Value = applicant.HSC_Board;
            command.Parameters.Add("HSC_PassYear", SqlDbType.NVarChar);
            command.Parameters["HSC_PassYear"].Value = applicant.HSC_PassYear;


            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Applicant applicantinfo = new Applicant();
            while (reader.Read())
            {

                applicantinfo.Name = reader["Name"].ToString();
                applicantinfo.FatherName = reader["FatherName"].ToString();
                applicantinfo.MotherName = reader["MotherName"].ToString();
                applicantinfo.Sex = reader["Sex"].ToString();

                applicantinfo.SSC_Roll = reader["SSC_Roll"].ToString();
                applicantinfo.SSC_Reg = reader["SSC_Reg"].ToString();
                applicantinfo.SSC_Board = reader["SSC_Board"].ToString();
                applicantinfo.SSC_PassYear = reader["SSC_PassYear"].ToString();


                applicantinfo.HSC_Roll = reader["HSC_Roll"].ToString();
                applicantinfo.HSC_Reg = reader["HSC_Reg"].ToString();
                applicantinfo.HSC_Board = reader["HSC_Board"].ToString();
                applicantinfo.HSC_BoardId = Convert.ToInt32(reader["HSC_BoardId"]); 

                applicantinfo.HSC_PassYear = reader["HSC_PassYear"].ToString();
                applicantinfo.HSC_PassYearId =Convert.ToInt32(reader["HSC_PassYearId"]);

                applicantinfo.SSC_SubjectWiseGrade = reader["SSC_SubjectWiseGrade"].ToString();
                applicantinfo.SSC_4thSubject = reader["SSC_4thSubject"].ToString();
                applicantinfo.HSC_SubjectWiseGrade = reader["HSC_SubjectWiseGrade"].ToString();
                applicantinfo.HSC_4thSubject = reader["HSC_4thSubject"].ToString();
                applicantinfo.HSC_Group = reader["HSC_Group"].ToString();

                if (applicantinfo.Sex == "0")
                {
                    applicantinfo.Sex = "Male";
                }

                else
                {
                    applicantinfo.Sex = "Female";
                }

                if (!reader["SSC_GPA"].Equals(System.DBNull.Value))
                {
                    applicantinfo.SSC_GPA = Convert.ToDouble(reader["SSC_GPA"]);
                }
                else
                {
                    applicantinfo.SSC_GPA = 0;
                }
                if (!reader["SSC_GPAEXC4TH"].Equals(System.DBNull.Value))
                {
                    applicantinfo.SSC_GPAEXC4TH = Convert.ToDouble(reader["SSC_GPAEXC4TH"]);
                }
                else
                {
                    applicantinfo.SSC_GPAEXC4TH = 0;
                }

                if (!reader["HSC_GPA"].Equals(System.DBNull.Value))
                {
                    applicantinfo.HSC_GPA = Convert.ToDouble(reader["HSC_GPA"]);
                }
                else
                {
                    applicantinfo.HSC_GPA = 0;
                }

                if (!reader["HSC_GPAEXC4TH"].Equals(System.DBNull.Value))
                {
                    applicantinfo.HSC_GPAEXC4TH = Convert.ToDouble(reader["HSC_GPAEXC4TH"]);
                }
                else
                {
                    applicantinfo.HSC_GPAEXC4TH = 0;
                }

                if (!reader["Total_GPA"].Equals(System.DBNull.Value))
                {
                    applicantinfo.Total_GPA = Convert.ToDouble(reader["Total_GPA"]);
                }
                else
                {
                    applicantinfo.Total_GPA = 0;
                }
                if (!reader["Total_GPAEXC4TH"].Equals(System.DBNull.Value))
                {
                    applicantinfo.Total_GPAEXC4TH = Convert.ToDouble(reader["Total_GPAEXC4TH"]);
                }
                else
                {
                    applicantinfo.Total_GPAEXC4TH = 0;
                }



                applicantinfo.HSC_SubjectCode1 = reader["HSC_SubjectCode1"].ToString();
                applicantinfo.HSC_SubjectName1 = reader["HSC_SubjectName1"].ToString();
                applicantinfo.HSC_SubjectGrade1 = reader["HSC_SubjectGrade1"].ToString();
                applicantinfo.HSC_SubjectPoint1 = Convert.ToDouble(reader["HSC_SubjectPoint1"].ToString());

                applicantinfo.HSC_SubjectCode2 = reader["HSC_SubjectCode2"].ToString();
                applicantinfo.HSC_SubjectName2 = reader["HSC_SubjectName2"].ToString();
                applicantinfo.HSC_SubjectGrade2 = reader["HSC_SubjectGrade2"].ToString();
                applicantinfo.HSC_SubjectPoint2 = Convert.ToDouble(reader["HSC_SubjectPoint2"].ToString());

                applicantinfo.HSC_SubjectCode3 = reader["HSC_SubjectCode3"].ToString();
                applicantinfo.HSC_SubjectName3 = reader["HSC_SubjectName3"].ToString();
                applicantinfo.HSC_SubjectGrade3 = reader["HSC_SubjectGrade3"].ToString();
                applicantinfo.HSC_SubjectPoint3 = Convert.ToDouble(reader["HSC_SubjectPoint3"].ToString());

                applicantinfo.HSC_SubjectCode4 = reader["HSC_SubjectCode4"].ToString();
                applicantinfo.HSC_SubjectName4 = reader["HSC_SubjectName4"].ToString();
                applicantinfo.HSC_SubjectGrade4 = reader["HSC_SubjectGrade4"].ToString();
                applicantinfo.HSC_SubjectPoint4 = Convert.ToDouble(reader["HSC_SubjectPoint4"].ToString());


                applicantinfo.HSC_SubjectCode5 = reader["HSC_SubjectCode5"].ToString();
                applicantinfo.HSC_SubjectName5 = reader["HSC_SubjectName5"].ToString();
                applicantinfo.HSC_SubjectGrade5 = reader["HSC_SubjectGrade5"].ToString();
                applicantinfo.HSC_SubjectPoint5 = Convert.ToDouble(reader["HSC_SubjectPoint5"].ToString());

                applicantinfo.HSC_SubjectCode6 = reader["HSC_SubjectCode6"].ToString();
                applicantinfo.HSC_SubjectName6 = reader["HSC_SubjectName6"].ToString();
                applicantinfo.HSC_SubjectGrade6 = reader["HSC_SubjectGrade6"].ToString();
                applicantinfo.HSC_SubjectPoint6 = Convert.ToDouble(reader["HSC_SubjectPoint6"].ToString());


                applicantinfo.SSC_SubjectCode1 = reader["SSC_SubjectCode1"].ToString();
                applicantinfo.SSC_SubjectName1 = reader["SSC_SubjectName1"].ToString();
                applicantinfo.SSC_SubjectGrade1 = reader["SSC_SubjectGrade1"].ToString();
                applicantinfo.SSC_SubjectPoint1 = Convert.ToDouble(reader["SSC_SubjectPoint1"].ToString());

                applicantinfo.SSC_SubjectCode2 = reader["SSC_SubjectCode2"].ToString();
                applicantinfo.SSC_SubjectName2 = reader["SSC_SubjectName2"].ToString();
                applicantinfo.SSC_SubjectGrade2 = reader["SSC_SubjectGrade2"].ToString();
                applicantinfo.SSC_SubjectPoint2 = Convert.ToDouble(reader["SSC_SubjectPoint2"].ToString());

                applicantinfo.SSC_SubjectCode3 = reader["SSC_SubjectCode3"].ToString();
                applicantinfo.SSC_SubjectName3 = reader["SSC_SubjectName3"].ToString();
                applicantinfo.SSC_SubjectGrade3 = reader["SSC_SubjectGrade3"].ToString();
                applicantinfo.SSC_SubjectPoint3 = Convert.ToDouble(reader["SSC_SubjectPoint3"].ToString());

                applicantinfo.SSC_SubjectCode4 = reader["SSC_SubjectCode4"].ToString();
                applicantinfo.SSC_SubjectName4 = reader["SSC_SubjectName4"].ToString();
                applicantinfo.SSC_SubjectGrade4 = reader["SSC_SubjectGrade4"].ToString();
                applicantinfo.SSC_SubjectPoint4 = Convert.ToDouble(reader["SSC_SubjectPoint4"].ToString());


                applicantinfo.SSC_SubjectCode5 = reader["SSC_SubjectCode5"].ToString();
                applicantinfo.SSC_SubjectName5 = reader["SSC_SubjectName5"].ToString();
                applicantinfo.SSC_SubjectGrade5 = reader["SSC_SubjectGrade5"].ToString();
                applicantinfo.SSC_SubjectPoint5 = Convert.ToDouble(reader["SSC_SubjectPoint5"].ToString());

                applicantinfo.SSC_SubjectCode6 = reader["SSC_SubjectCode6"].ToString();
                applicantinfo.SSC_SubjectName6 = reader["SSC_SubjectName6"].ToString();
                applicantinfo.SSC_SubjectGrade6 = reader["SSC_SubjectGrade6"].ToString();
                applicantinfo.SSC_SubjectPoint6 = Convert.ToDouble(reader["SSC_SubjectPoint6"].ToString());

                applicantinfo.SSC_SubjectCode7 = reader["SSC_SubjectCode7"].ToString();
                applicantinfo.SSC_SubjectName7 = reader["SSC_SubjectName7"].ToString();
                applicantinfo.SSC_SubjectGrade7 = reader["SSC_SubjectGrade7"].ToString();
                applicantinfo.SSC_SubjectPoint7 = Convert.ToDouble(reader["SSC_SubjectPoint7"].ToString());

                applicantinfo.SSC_SubjectCode8 = reader["SSC_SubjectCode8"].ToString();
                applicantinfo.SSC_SubjectName8 = reader["SSC_SubjectName8"].ToString();
                applicantinfo.SSC_SubjectGrade8 = reader["SSC_SubjectGrade8"].ToString();
                applicantinfo.SSC_SubjectPoint8 = Convert.ToDouble(reader["SSC_SubjectPoint8"].ToString());

                applicantinfo.SSC_SubjectCode9 = reader["SSC_SubjectCode9"].ToString();
                applicantinfo.SSC_SubjectName9 = reader["SSC_SubjectName9"].ToString();
                applicantinfo.SSC_SubjectGrade9 = reader["SSC_SubjectGrade9"].ToString();
                applicantinfo.SSC_SubjectPoint9 = Convert.ToDouble(reader["SSC_SubjectPoint9"].ToString());

            }
            reader.Close();
            connection.Close();
            return applicantinfo;
        }




        public Applicant GetExamInfo()
        {
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand("spExam", connection);
            command.CommandType = CommandType.StoredProcedure;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Applicant applicant = new Applicant();

            while (reader.Read())
            {
                applicant.University = reader["University"].ToString();
                applicant.ExamName = reader["ExamName"].ToString();

            }
            reader.Close();
            connection.Close();
            return applicant;
        }


        public int SaveApplicant(Applicant applicant)
        {
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand("spAdmit", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();


            command.Parameters.Add("Name", SqlDbType.VarChar);
            command.Parameters["Name"].Value = applicant.Name;
            command.Parameters.Add("FatherName", SqlDbType.VarChar);
            command.Parameters["FatherName"].Value = applicant.FatherName;
            command.Parameters.Add("MotherName", SqlDbType.VarChar);
            command.Parameters["MotherName"].Value = applicant.MotherName;
            command.Parameters.Add("Sex", SqlDbType.VarChar);
            command.Parameters["Sex"].Value = applicant.Sex;
            command.Parameters.Add("SSC_Roll", SqlDbType.NVarChar);
            command.Parameters["SSC_Roll"].Value = applicant.SSC_Roll;
            command.Parameters.Add("SSC_Reg", SqlDbType.NVarChar);
            command.Parameters["SSC_Reg"].Value = applicant.SSC_Reg;
            command.Parameters.Add("SSC_Board", SqlDbType.NVarChar);
            command.Parameters["SSC_Board"].Value = applicant.SSC_Board;
            command.Parameters.Add("SSC_PassYear", SqlDbType.NVarChar);
            command.Parameters["SSC_PassYear"].Value = applicant.SSC_PassYear;
            command.Parameters.Add("HSC_Roll", SqlDbType.NVarChar);
            command.Parameters["HSC_Roll"].Value = applicant.HSC_Roll;
            command.Parameters.Add("HSC_Reg", SqlDbType.NVarChar);
            command.Parameters["HSC_Reg"].Value = applicant.HSC_Reg;
            command.Parameters.Add("HSC_Board", SqlDbType.NVarChar);
            command.Parameters["HSC_Board"].Value = applicant.HSC_Board;
            command.Parameters.Add("HSC_PassYear", SqlDbType.NVarChar);
            command.Parameters["HSC_PassYear"].Value = applicant.HSC_PassYear;
            command.Parameters.Add("Total_GPA", SqlDbType.Float);
            command.Parameters["Total_GPA"].Value = applicant.Total_GPA;
            command.Parameters.Add("Mobile", SqlDbType.VarChar);
            command.Parameters["Mobile"].Value = applicant.Mobile;
            command.Parameters.Add("TransctionId", SqlDbType.VarChar);
            command.Parameters["TransctionId"].Value = applicant.TransctionId;
            command.Parameters.Add("BillerId", SqlDbType.VarChar);
            command.Parameters["BillerId"].Value = applicant.BillerId;
            command.Parameters.Add("BillNumber", SqlDbType.VarChar);
            command.Parameters["BillNumber"].Value = applicant.BillNumber;
            command.Parameters.Add("Amount", SqlDbType.Int);
            command.Parameters["Amount"].Value = applicant.Amount;
            command.Parameters.Add("PhotoLocation", SqlDbType.VarChar);
            command.Parameters["PhotoLocation"].Value = applicant.PhotoLocation;
            command.Parameters.Add("SignatureLocation", SqlDbType.VarChar);
            command.Parameters["SignatureLocation"].Value = applicant.SignatureLocation;
            command.Parameters.Add("Unit", SqlDbType.VarChar);
            command.Parameters["Unit"].Value = applicant.Unit;


            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }





        public bool IsApplicantExistsAUnit(Applicant applicant)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM A_Admit WHERE SSC_Roll=@SSC_Roll and SSC_Reg=@SSC_Reg and SSC_Board=@SSC_Board and SSC_PassYear=@SSC_PassYear and HSC_Roll=@HSC_Roll and HSC_Reg=@HSC_Reg and HSC_Board=@HSC_Board and HSC_PassYear=@HSC_PassYear";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();

            command.Parameters.Add("SSC_Roll", SqlDbType.NVarChar);
            command.Parameters["SSC_Roll"].Value = applicant.SSC_Roll;
            command.Parameters.Add("SSC_Reg", SqlDbType.NVarChar);
            command.Parameters["SSC_Reg"].Value = applicant.SSC_Reg;
            command.Parameters.Add("SSC_Board", SqlDbType.NVarChar);
            command.Parameters["SSC_Board"].Value = applicant.SSC_Board;
            command.Parameters.Add("SSC_PassYear", SqlDbType.NVarChar);
            command.Parameters["SSC_PassYear"].Value = applicant.SSC_PassYear;
            command.Parameters.Add("HSC_Roll", SqlDbType.NVarChar);
            command.Parameters["HSC_Roll"].Value = applicant.HSC_Roll;
            command.Parameters.Add("HSC_Reg", SqlDbType.NVarChar);
            command.Parameters["HSC_Reg"].Value = applicant.HSC_Reg;
            command.Parameters.Add("HSC_Board", SqlDbType.NVarChar);
            command.Parameters["HSC_Board"].Value = applicant.HSC_Board;
            command.Parameters.Add("HSC_PassYear", SqlDbType.NVarChar);
            command.Parameters["HSC_PassYear"].Value = applicant.HSC_PassYear;


            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        public bool IsApplicantExistsBUnit(Applicant applicant)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM B_Admit WHERE SSC_Roll=@SSC_Roll and SSC_Reg=@SSC_Reg and SSC_Board=@SSC_Board and SSC_PassYear=@SSC_PassYear and HSC_Roll=@HSC_Roll and HSC_Reg=@HSC_Reg and HSC_Board=@HSC_Board and HSC_PassYear=@HSC_PassYear";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();

            command.Parameters.Add("SSC_Roll", SqlDbType.NVarChar);
            command.Parameters["SSC_Roll"].Value = applicant.SSC_Roll;
            command.Parameters.Add("SSC_Reg", SqlDbType.NVarChar);
            command.Parameters["SSC_Reg"].Value = applicant.SSC_Reg;
            command.Parameters.Add("SSC_Board", SqlDbType.NVarChar);
            command.Parameters["SSC_Board"].Value = applicant.SSC_Board;
            command.Parameters.Add("SSC_PassYear", SqlDbType.NVarChar);
            command.Parameters["SSC_PassYear"].Value = applicant.SSC_PassYear;
            command.Parameters.Add("HSC_Roll", SqlDbType.NVarChar);
            command.Parameters["HSC_Roll"].Value = applicant.HSC_Roll;
            command.Parameters.Add("HSC_Reg", SqlDbType.NVarChar);
            command.Parameters["HSC_Reg"].Value = applicant.HSC_Reg;
            command.Parameters.Add("HSC_Board", SqlDbType.NVarChar);
            command.Parameters["HSC_Board"].Value = applicant.HSC_Board;
            command.Parameters.Add("HSC_PassYear", SqlDbType.NVarChar);
            command.Parameters["HSC_PassYear"].Value = applicant.HSC_PassYear;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }





        public bool IsPaymentCompleted(Applicant applicant)
        {
            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Payment WHERE TransctionId=@TransctionId and BillerId=@BillerId and BillNumber=@BillNumber and Amount=@Amount";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();

            command.Parameters.Add("BillerId", SqlDbType.NVarChar);
            command.Parameters["BillerId"].Value = applicant.BillerId;
            command.Parameters.Add("TransctionId", SqlDbType.NVarChar);
            command.Parameters["TransctionId"].Value = applicant.TransctionId;
            command.Parameters.Add("BillNumber", SqlDbType.VarChar);
            command.Parameters["BillNumber"].Value = applicant.BillNumber;
            command.Parameters.Add("Amount", SqlDbType.Int);
            command.Parameters["Amount"].Value = applicant.Amount;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }
        public Applicant GetApplicant(Applicant applicant)
        {
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand("spAdmitCard", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();


            command.Parameters.Add("SSC_Roll", SqlDbType.NVarChar);
            command.Parameters["SSC_Roll"].Value = applicant.SSC_Roll;
            command.Parameters.Add("SSC_Reg", SqlDbType.NVarChar);
            command.Parameters["SSC_Reg"].Value = applicant.SSC_Reg;
            command.Parameters.Add("SSC_Board", SqlDbType.NVarChar);
            command.Parameters["SSC_Board"].Value = applicant.SSC_Board;
            command.Parameters.Add("SSC_PassYear", SqlDbType.NVarChar);
            command.Parameters["SSC_PassYear"].Value = applicant.SSC_PassYear;
            command.Parameters.Add("HSC_Roll", SqlDbType.NVarChar);
            command.Parameters["HSC_Roll"].Value = applicant.HSC_Roll;
            command.Parameters.Add("HSC_Reg", SqlDbType.NVarChar);
            command.Parameters["HSC_Reg"].Value = applicant.HSC_Reg;
            command.Parameters.Add("HSC_Board", SqlDbType.NVarChar);
            command.Parameters["HSC_Board"].Value = applicant.HSC_Board;
            command.Parameters.Add("HSC_PassYear", SqlDbType.NVarChar);
            command.Parameters["HSC_PassYear"].Value = applicant.HSC_PassYear;
            command.Parameters.Add("Unit", SqlDbType.NVarChar);
            command.Parameters["Unit"].Value = applicant.Unit;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            Applicant applicantinfo = new Applicant();
            while (reader.Read())
            {
                applicantinfo.Name = reader["Name"].ToString();
                applicantinfo.FatherName = reader["FatherName"].ToString();
                applicantinfo.MotherName = reader["MotherName"].ToString();
                applicantinfo.Sex = reader["Sex"].ToString();
                applicantinfo.SSC_Roll = reader["SSC_Roll"].ToString();
                applicantinfo.SSC_Reg = reader["SSC_Reg"].ToString();
                applicantinfo.SSC_Board = reader["SSC_Board"].ToString();
                applicantinfo.SSC_PassYear = reader["SSC_PassYear"].ToString();
                applicantinfo.HSC_Roll = reader["HSC_Roll"].ToString();
                applicantinfo.HSC_Reg = reader["HSC_Reg"].ToString();
                applicantinfo.HSC_Board = reader["HSC_Board"].ToString();
                applicantinfo.HSC_PassYear = reader["HSC_PassYear"].ToString();
                applicantinfo.Total_GPA = Convert.ToDouble(reader["Total_GPA"].ToString());
                applicantinfo.RollNo = Convert.ToInt32(reader["RollNo"]);
                applicantinfo.Unit = reader["Unit"].ToString();
                applicantinfo.PhotoLocation = reader["PhotoLocation"].ToString();
                applicantinfo.SignatureLocation = reader["SignatureLocation"].ToString();

            }

            reader.Close();
            connection.Close();
            return applicantinfo;


        }

        public List<Applicant> GetTransctionId(Applicant applicant)
        {

            connection.ConnectionString = connectionString;
            string query = "SELECT * FROM Payment WHERE  BillNumber=@BillNumber";
            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.Clear();
            command.Parameters.Add("BillNumber", SqlDbType.NVarChar);
            command.Parameters["BillNumber"].Value = applicant.BillNumber;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Applicant> applicantList = new List<Applicant>();

            while (reader.Read())
            {
                Applicant applicant1 = new Applicant();

                applicant1.TransctionId = reader["TransctionId"].ToString();
                applicant1.BillNumber = reader["BillNumber"].ToString(); 
                applicantList.Add(applicant1);
            }

            reader.Close();
            connection.Close();
            return applicantList;
        }
        
    }
}
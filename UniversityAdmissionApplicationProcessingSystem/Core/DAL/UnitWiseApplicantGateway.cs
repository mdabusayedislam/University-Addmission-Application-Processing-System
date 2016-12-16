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
    public class UnitWiseApplicantGateway
    {
        private string connectionString = WebConfigurationManager.ConnectionStrings["UniversityAdmissionSystemDBConnection"].ConnectionString;

        private SqlConnection connection = new SqlConnection();

        public List<Applicant> GetAllApplicantsByUnit(Applicant applicant)
        {

            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand("spUnitWiseApplicant", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();

            command.Parameters.Add("Unit", SqlDbType.NVarChar);
            command.Parameters["Unit"].Value = applicant.Unit;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Applicant> applicantList = new List<Applicant>();

            while (reader.Read())
            {
                Applicant applicant1 = new Applicant();
                applicant1.Name = reader["Name"].ToString();
                applicant1.FatherName = reader["FatherName"].ToString();
                applicant1.MotherName = reader["MotherName"].ToString();
                applicant1.Sex = reader["Sex"].ToString();
                applicant1.Unit = reader["Unit"].ToString();
                applicant1.RollNo = Convert.ToInt32(reader["RollNo"].ToString());
                applicant1.PhotoLocation = reader["PhotoLocation"].ToString();
                applicant1.SignatureLocation = reader["SignatureLocation"].ToString();
               // applicant1.AllocateRoom = reader["AllocateRoom"].ToString();
                if (applicant.AllocateRoom == string.Empty)
                {
                    applicant1.AllocateRoom = "Not Assign Yet";
                }
                else
                {
                    applicant1.AllocateRoom = reader["AllocateRoom"].ToString();
                }


                applicantList.Add(applicant1);
            }

            reader.Close();
            connection.Close();
            return applicantList;
        }

        public int AllocateRoom(Applicant applicant)
        {
            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand("spUnitWiseRoomAllocation", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();



            //string query = "Update A_Admit SET AllocateRoom=@AllocateRoom  WHERE (RollNo Between @RollNo And (@RollNo+@CapacityofRoom-1))";
            //SqlCommand command = new SqlCommand(query, connection);
            //command.Parameters.Clear();
            command.Parameters.Add("Unit", SqlDbType.NVarChar);
            command.Parameters["Unit"].Value = applicant.Unit;
            command.Parameters.Add("AllocateRoom", SqlDbType.NVarChar);
            command.Parameters["AllocateRoom"].Value = applicant.AllocateRoom;
            command.Parameters.Add("RollNo", SqlDbType.BigInt);
            command.Parameters["RollNo"].Value = applicant.RollNo;
            command.Parameters.Add("CapacityofRoom", SqlDbType.Int);
            command.Parameters["CapacityofRoom"].Value = applicant.CapacityofRoom;
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();

            return rowAffected;
        }


        public List<Applicant> GetAllRoom()
        {
            connection.ConnectionString = connectionString;

            string query = "SELECT * FROM Rooms";
            SqlCommand command = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Applicant> roomList = new List<Applicant>();
            while (reader.Read())
            {
                Applicant room = new Applicant();
                room.Id = Convert.ToInt32(reader["Id"].ToString());
                room.AllocateRoom = reader["AllocateRoom"].ToString();
                room.CapacityofRoom = Convert.ToInt32(reader["CapacityofRoom"].ToString());
                roomList.Add(room);
            }

            reader.Close();
            connection.Close();
            return roomList;
        }


        public List<Applicant> GeApplicantsByRollNo(Applicant applicant)
        {

            connection.ConnectionString = connectionString;
            SqlCommand command = new SqlCommand("spApplicantByRollNo", connection);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();

            command.Parameters.Add("Unit", SqlDbType.NVarChar);
            command.Parameters["Unit"].Value = applicant.Unit;
            command.Parameters.Add("RollNo", SqlDbType.BigInt);
            command.Parameters["RollNo"].Value = applicant.RollNo;

            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            List<Applicant> applicantList = new List<Applicant>();

            while (reader.Read())
            {
                Applicant applicant1 = new Applicant();
                applicant1.Name = reader["Name"].ToString();
                applicant1.FatherName = reader["FatherName"].ToString();
                applicant1.MotherName = reader["MotherName"].ToString();
                applicant1.Sex = reader["Sex"].ToString();
                applicant1.Unit = reader["Unit"].ToString();
                applicant1.RollNo = Convert.ToInt32(reader["RollNo"].ToString());
                applicant1.PhotoLocation = reader["PhotoLocation"].ToString();
                applicant1.SignatureLocation = reader["SignatureLocation"].ToString();
                // applicant1.AllocateRoom = reader["AllocateRoom"].ToString();
                if (applicant.AllocateRoom == string.Empty)
                {
                    applicant1.AllocateRoom = "Not Assign Yet";
                }
                else
                {
                    applicant1.AllocateRoom = reader["AllocateRoom"].ToString();
                }


                applicantList.Add(applicant1);
            }

            reader.Close();
            connection.Close();
            return applicantList;
        }

       
    }
}


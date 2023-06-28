﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Lifetime;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
//using static Layout_2.2.DBConnection;

namespace SetOffs1
{

    //Database Connection And Operation
    public class DBConnection
    {
        private SqlConnection con;
        private DataTable profile ;
        public DBConnection()
        {
            this.con = new SqlConnection(connectionString: ConfigurationManager.ConnectionStrings["Setoffs"].ConnectionString);
        }
        //String cs = "Data Source=DESKTOP-OVIGJK3;Initial Catalog=Setoffs;Integrated Security=True ";
        //    SqlConnection Con = new SqlConnection(cs);
        public List<EmployeeLeave> GetEmployeeLeave(DateTime date)
        {
            Employee emp = new Employee();
            List<EmployeeLeave> users = new List<EmployeeLeave>();
            using (SqlCommand command = new SqlCommand("SELECT e.FirstName, l.LeaveType FROM Employee e INNER JOIN Leave l ON e.id = l.EMPID WHERE  '" + date.ToString("yyyy-MM-dd") + "'between l.StartDate AND l.EndDate;", con))
            {
                con.Open();



                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        EmployeeLeave e = new EmployeeLeave();
                        e.FirstName = reader.GetString(0);
                        e.LeaveType = reader.GetString(reader.GetOrdinal("LeaveType"));
                      
                        users.Add(e);
                    }
                }
            }
            con.Close();

            return users;
        }

        public void AddEmployee(Employee employee)
        {

            using (SqlCommand command = new SqlCommand("INSERT INTO Employee (Id ,FristName,LastName,Designation, Email,Password) VALUES (@Id,@FristName,@LastName,@Designation, @Email,@Password)", con))
            {
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@fristName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Designation", employee.Designation);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Password", employee.Password);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }
        
        public Employee GetEmployee(string email)
        {
            Employee emp = new Employee();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Employee where Email='" +email + "'", con))
            {
                con.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Access column values using reader


                        emp.Id = reader.GetInt32(0);
                        emp.FirstName = reader.GetString(1);
                        emp.LastName = reader.GetString(2);
                        emp.Email = reader.GetString(4);
                        emp.Designation = reader.GetString(3);
                        emp.Password = reader.GetString(5); //reader.GetString(reader.GetOrdinal("Password"));


                    }
                }
                con.Close();
            }

            return emp;
        }

        public void AddLeave(Leave leave)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO Leave (EmpId, LeaveType, StartDate, EndDate, Comments,Days) VALUES (@EmpId,@LeaveType,@StartDate, @EndDate,@Comments, @Days)", con))
            {
                command.Parameters.AddWithValue("@EmpId", leave.EmpId);
                command.Parameters.AddWithValue("@LeaveType", leave.LeaveType);
                command.Parameters.AddWithValue("@StartDate", leave.StartDate);
                command.Parameters.AddWithValue("@EndDate", leave.EndDate);
                command.Parameters.AddWithValue("@Comments", leave.Comments);
                command.Parameters.AddWithValue("@Days", leave.Days);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();

            }

        }

        public Leave GetLeave(int id)
        {
            Leave leave = new Leave();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Leave where EmpId=" + id + "", con))
            {
                con.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Access column values using reader

                        leave.EmpId = reader.GetInt32(reader.GetOrdinal("EmpId"));
                        leave.LeaveType = reader.GetString(reader.GetOrdinal("LeaveType"));
                        leave.StartDate = reader.GetDateTime(2);
                        leave.EndDate = reader.GetDateTime(3);
                        leave.Comments = reader.GetString(reader.GetOrdinal("Designation"));
                        leave.Days = reader.GetInt32(reader.GetOrdinal("Days"));

                    }
                }
                con.Close();
            }
            return leave;
        }

        public List<Employee> GetCalendarDetails()
        {
            List<Employee> values = new List<Employee>();


            return values;
        }
        
        public DataTable GetProfileDataTable(String s)
        {
            // Replace with your data retrieval logic
            DataTable dt = new DataTable();
            dt.Columns.Add("Profile"); // Replace "ColumnName" with the actual column name

            DBConnection d = new DBConnection();
            Employee emp = new Employee();
            emp = d.GetEmployee(s);
            DataRow row1 = dt.NewRow();
            row1["Profile"] = emp.FirstName + " " + emp.LastName;
            dt.Rows.Add(row1);

            DataRow row2 = dt.NewRow();
            row2["Profile"] = emp.Id.ToString();
            dt.Rows.Add(row2);

            DataRow row3 = dt.NewRow();
            row3["Profile"] = emp.Email;
            dt.Rows.Add(row3);

            // ...

            return dt;
        }
    }

    public class EmployeeLeave
    {
        
        public string FirstName { get; set; } = "NotSpecified";
        
        public string LeaveType { get; set; } = "Leave";
       
    }
    public class Employee
    {
        public int Id { get; set; } = 0;

        public string FirstName { get; set; } = "NotSpecified";
        public string LastName { get; set; } = "NotSpecified";
        public string Email { get; set; } = "NotSpecified";
        public string Designation { get; set; } = "NotSpecified";
        public string Password { get; set; } = "pass";
    }

    public class Leave
    {
        public int EmpId { get; set; } = 0;
        public string LeaveType { get; set; } = "Leave";
        public DateTime StartDate { get; set; } = DateTime.Now;

        public DateTime EndDate { get; set; } = DateTime.Now.AddDays(1);
        public string Comments { get; set; } = "NoComments";
        public int Days { get; set; } = 0;
    }
    
    

}
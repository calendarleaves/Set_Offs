﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Lifetime;
using System.Security.Cryptography;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
//using static Layout_2.2.DBConnection;

namespace SetOffs1
{

    //Database Connection And Operation
    public class DBConnection
    {
        private SqlConnection con;
        private DataTable profile;

        public DBConnection()
        {
            this.con = new SqlConnection(connectionString: ConfigurationManager.ConnectionStrings["Setoffs"].ConnectionString);
        }

        public List<EmployeeLeave> GetEmployeeLeave(DateTime date)
        {
            Employee emp = new Employee();
            List<EmployeeLeave> users = new List<EmployeeLeave>();
            using (SqlCommand command = new SqlCommand("SELECT e.FirstName, l.LeaveType FROM Employee e INNER JOIN Leave l ON e.id = l.EMPID WHERE  '" + date.ToString("yyyy-MM-dd") + "'between l.StartDate AND l.EndDate ;", con))
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
        public List<string> GetAllEmployeeName()
        {
            List<string> users = new List<string>();
            using (SqlCommand command = new SqlCommand("SELECT FirstName, LastName FROM Employee", con))
            {
                con.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string value1 = reader["FirstName"].ToString();
                        string value2 = reader["LastName"].ToString();


                        users.Add(value1 + " " + value2);
                    }
                }
            }
            con.Close();

            return users;
        }

        public void AddEmployee(Employee employee)
        {

            using (SqlCommand command = new SqlCommand("INSERT INTO Employee (Id ,FristName,LastName,Designation, Email,Password,Flx_Id) VALUES (@Id,@FristName,@LastName,@Designation, @Email,@Password,@Flx_Id)", con))
            {
                command.Parameters.AddWithValue("@Id", employee.Id);
                command.Parameters.AddWithValue("@fristName", employee.FirstName);
                command.Parameters.AddWithValue("@LastName", employee.LastName);
                command.Parameters.AddWithValue("@Designation", employee.Designation);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@Password", employee.Password);
                command.Parameters.AddWithValue("@Flx_Id", employee.Flx_Id);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();
            }
        }

        public Employee GetEmployee(string email)
        {
            Employee emp = new Employee();
            using (SqlCommand command = new SqlCommand("SELECT * FROM Employee where Email='" + email + "'", con))
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
                        emp.Flx_Id = reader.GetString(6);

                    }
                }
                con.Close();
            }

            return emp;
        }

        public List<HolidayList> GetUpcomingHolidays(DateTime currentDate)
        {
            List<HolidayList> upcomingHolidays = new List<HolidayList>();

            using (SqlCommand command = new SqlCommand("SELECT * FROM HolidayList WHERE Date >= @CurrentDate", con))
            {
                command.Parameters.AddWithValue("@CurrentDate", currentDate.Date);
                con.Open();

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HolidayList holiday = new HolidayList();
                        DateTime dateTimeValue = reader.GetDateTime(0);
                        // holiday.Date = dateTimeValue.Date.ToString("yyyy-MM-dd") ;
                        holiday.Date = dateTimeValue.Date.ToString("dd-MMM-yyyy");
                        holiday.Holiday = reader.GetString(1);
                        upcomingHolidays.Add(holiday);
                    }
                }
                con.Close();
            }

            return upcomingHolidays;
        }

        public void AddLeave(Leave leave)
        {
            using (SqlCommand command = new SqlCommand("INSERT INTO Leave (EmpId, LeaveType, StartDate, EndDate, Comments,Days,Created_On,CreatedBy) VALUES (@EmpId,@LeaveType,@StartDate, @EndDate,@Comments, @Days,@Created_On,@CreatedBy)", con))
            {
                command.Parameters.AddWithValue("@EmpId", leave.EmpId);
                command.Parameters.AddWithValue("@LeaveType", leave.LeaveType);
                command.Parameters.AddWithValue("@StartDate", leave.StartDate);
                command.Parameters.AddWithValue("@EndDate", leave.EndDate);
                command.Parameters.AddWithValue("@Comments", leave.Comments);
                command.Parameters.AddWithValue("@Days", leave.Days);
                command.Parameters.AddWithValue("@Created_On", leave.Created_On);
                command.Parameters.AddWithValue("@CreatedBy", leave.CreatedBy);

                con.Open();
                command.ExecuteNonQuery();
                con.Close();

            }

        }

        public void Addleave(string firstname, string lastname, Leave l)
        {


            string query = "SELECT id FROM Employee WHERE FirstName = @firstName AND LastName = @lastName";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@firstName", firstname);
                command.Parameters.AddWithValue("@lastName", lastname);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        l.EmpId = reader.GetInt32(0);
                    }
                }
                con.Close();
                AddLeave(l);
            }
        }
        // GetAll Leave from data base for search 

        public int getEmployeeId(String s)
        {
            string firstName = "";
            string lastName = "";
            int i = 0;
            string[] nameParts = s.Split(' ');
            if (nameParts.Length > 0)
                firstName = nameParts[0];
            if (nameParts.Length > 1)
                lastName = nameParts[1];
            else
            {

            }

            string query = "SELECT id FROM Employee WHERE FirstName =@firstName and LastName = @lastName";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        i = reader.GetInt32(0);
                    }
                }


            }
            con.Close();
            return i;
        }

        public DataTable GetAllEmployeesLeave()
        {
            DataTable dt = new DataTable();

            con.Open();

            SqlCommand command = new SqlCommand("SELECT e.Id     ,e.FirstName     ,e.LastName  ,l.LeaveType     ,l.StartDate  ,l.EndDate      ,l.Days  FROM Employee e join Leave l on e.Id = l.EmpId order by e.FirstName ", con);


            SqlDataAdapter reader = new SqlDataAdapter(command);
            reader.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetAllEmployeesLeavebyName(String s)
        {
            int i = getEmployeeId(s);
            DataTable dt = new DataTable();

            string query = "SELECT e.Id     ,e.FirstName     ,e.LastName  ,l.LeaveType     ,l.StartDate  ,l.EndDate      ,l.Days  FROM Employee e join Leave l on e.Id = l.EmpId where l.EmpId=@EmpId order by e.FirstName ";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@EmpId", i);
                SqlDataAdapter reader = new SqlDataAdapter(command);


                reader.Fill(dt);
            }
            con.Close();
            return dt;
        }

        public DataTable GetAllLeaveRecords()
        {
            DataTable dt = new DataTable();

            int currentYear = DateTime.Now.Year;

            SqlCommand command = new SqlCommand(@"
        SELECT 
            CONCAT(e.FirstName, ' ', e.LastName) AS Name,
            CONVERT(varchar, l.StartDate, 106) AS StartDate,
            CONVERT(varchar, l.EndDate, 106) AS EndDate,
            l.Comments
        FROM 
            Employee e
        JOIN 
            Leave l ON e.Id = l.EmpId
        WHERE 
            l.StartDate >= @StartDate AND l.StartDate <= @EndDate
        ORDER BY 
            l.StartDate, e.FirstName", con);

            // Construct date ranges for 1st July to 31st July of the current year
            DateTime startDate = new DateTime(currentYear, 1, 1);
            DateTime endDate = new DateTime(currentYear, 12, 31);

            command.Parameters.AddWithValue("@StartDate", startDate);
            command.Parameters.AddWithValue("@EndDate", endDate);

            SqlDataAdapter reader = new SqlDataAdapter(command);


            reader.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetUserLeaveRecords(string email)
        {
            DataTable dt = new DataTable();

            int currentYear = DateTime.Now.Year;

            SqlCommand command = new SqlCommand(@"
        SELECT 
            CONCAT(e.FirstName, ' ', e.LastName) AS Name,
            CONVERT(varchar, l.StartDate, 106) AS StartDate,
            CONVERT(varchar, l.EndDate, 106) AS EndDate,
            l.Comments
        FROM 
            Employee e
        JOIN 
            Leave l ON e.Id = l.EmpId
        WHERE 
            e.Email = @EmployeeId
            AND l.StartDate >= @StartDate AND l.StartDate <= @EndDate
        ORDER BY 
            l.StartDate", con);

            // Construct date ranges for 1st July to 31st July of the current year
            DateTime startDate = new DateTime(currentYear, 1, 1);
            DateTime endDate = new DateTime(currentYear, 12, 31);

            command.Parameters.AddWithValue("@EmployeeId", email);
            command.Parameters.AddWithValue("@StartDate", startDate);
            command.Parameters.AddWithValue("@EndDate", endDate);

            SqlDataAdapter reader = new SqlDataAdapter(command);


            reader.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetAllHolidayDates()
        {
            DataTable dt = new DataTable();

            con.Open();

            SqlCommand command = new SqlCommand("SELECT Date FROM HolidayList", con);


            SqlDataAdapter reader = new SqlDataAdapter(command);
            reader.Fill(dt);
            con.Close();
            return dt;
        }

        public DataTable GetAllEmployeesLeaveLikeName(String s)
        {
            string firstName = "";
            string lastName = "";
            int i = 0;
            string[] nameParts = s.Split(' ');
            if (nameParts.Length > 0)
                firstName = nameParts[0];
            if (nameParts.Length > 1)
                lastName = nameParts[1];
            else
            {

            }
            DataTable dt = new DataTable();

            string query = "SELECT e.Id     ,e.FirstName     ,e.LastName  ,l.LeaveType     ,l.StartDate  ,l.EndDate      ,l.Days , l.Comments FROM Employee e join Leave l on e.Id = l.EmpId where e.FirstName LIKE @firstName + '%' AND e.LastName LIKE @lastName + '%' order by e.FirstName ";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);
                SqlDataAdapter reader = new SqlDataAdapter(command);


                reader.Fill(dt);
            }
            con.Close();
            return dt;
        }


        public DataTable GetAllEmployeesLeave(String s, DateTime startDate)
        {
            int i = getEmployeeId(s);
            DataTable dt = new DataTable();

            string query = "SELECT e.Id     ,e.FirstName     ,e.LastName  ,l.LeaveType     ,l.StartDate  ,l.EndDate      ,l.Days  FROM Employee e join Leave l on e.Id = l.EmpId where l.EmpId=@EmpId AND StartDate = @StartDate order by e.FirstName ";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@EmpId", i);
                command.Parameters.AddWithValue("@StartDate", startDate);
                SqlDataAdapter reader = new SqlDataAdapter(command);

                reader.Fill(dt);
            }
            con.Close();
            return dt;
        }

        public DataTable GetAllEmployeesLeave(String s, DateTime startDate, DateTime endDate)
        {
            int i = getEmployeeId(s);
            DataTable dt = new DataTable();

            string query = "SELECT e.Id     ,e.FirstName     ,e.LastName  ,l.LeaveType     ,l.StartDate  ,l.EndDate      ,l.Days  FROM Employee e join Leave l on e.Id = l.EmpId where l.EmpId=@EmpId AND (l.StartDate = @StartDate OR l.EndDate = @EndDate) order by e.FirstName ";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@EmpId", i);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);


                SqlDataAdapter reader = new SqlDataAdapter(command);


                reader.Fill(dt);
            }
            con.Close();
            return dt;
        }




        public int CountLeave(string s)
        {

            int id = getEmployeeId(s);
            int count;

            string query = "SELECT COUNT(*)  FROM Employee e join Leave l on e.Id = l.EmpId  WHERE l.EmpId =@EmpId ";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@EmpId", id);

                count = (int)command.ExecuteScalar();

            }
            con.Close();
            return count;
        }

        public int CountLeave(string s, DateTime startDate)
        {
            int id = getEmployeeId(s);
            int count;

            string query = "SELECT COUNT(*)  FROM Employee e join Leave l on e.Id = l.EmpId  WHERE l.EmpId =@EmpId AND l.StartDate= @startDate";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@EmpId", id);
                command.Parameters.AddWithValue("@startDate", startDate);


                count = (int)command.ExecuteScalar();

            }
            con.Close();
            return count;
        }

        public void DeleteLeave(string s)
        {
            int id = getEmployeeId(s);

            string query = "DELETE FROM  Leave WHERE EmpID = @EmpId";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@EmpId", id);

                command.ExecuteReader();
            }
            con.Close();

        }

        public void DeleteLeave(string s, DateTime startDate)
        {
            int id = getEmployeeId(s);

            string query = "DELETE FROM  Leave WHERE EmpID = @EmpId  AND StartDate = @StartDate ";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@EmpId", id);
                command.Parameters.AddWithValue("@StartDate", startDate);

                command.ExecuteReader();
            }
            con.Close();
        }
        public void DeleteLeave(string s, DateTime startDate, DateTime endDate)
        {
            int id = getEmployeeId(s);

            string query = "DELETE FROM  Leave WHERE EmpID = @EmpId  AND (StartDate = @StartDate and EndDate = @EndDate) ";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@EmpId", id);
                command.Parameters.AddWithValue("@StartDate", startDate);
                command.Parameters.AddWithValue("@EndDate", endDate);


                command.ExecuteReader();
            }
            con.Close();
        }
        //public void DeleteLeave(DateTime startDate, DateTime endDate)
        //{


        //    string query = "DELETE FROM  Leave WHERE   (StartDate = @StartDate OR EndDate = @EndDate) ";
        //    con.Open();
        //    using (SqlCommand command = new SqlCommand(query, con))
        //    {

        //        command.Parameters.AddWithValue("@StartDate", startDate);
        //        command.Parameters.AddWithValue("@EndDate", endDate);


        //        command.ExecuteReader();
        //    }
        //    con.Close();
        //}




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
                        leave.Days = reader.GetOrdinal("Days");

                    }
                }
                con.Close();
            }
            return leave;
        }

        public DataTable GetLeaveBalance(string usId)
        {
            DataTable dt = new DataTable();

            // int currentYear = DateTime.Now.Year;


            SqlCommand command = new SqlCommand(@"
        SELECT 
            CONCAT(e.FirstName, ' ', e.LastName) AS Name,
			LeaveBalance
        FROM 
            Employee e 
			WHERE
			e.Email = @UserID", con);

            command.Parameters.AddWithValue("@UserID", usId);
            SqlDataAdapter reader = new SqlDataAdapter(command);


            reader.Fill(dt);
            con.Close();
            return dt;
        }

        public void UpdateLeaveAfterDelete(string s, string l)
        {
            int id = getEmployeeId(s);


            try
            {
                con.Open();
                double leaveBalanceIncrement = double.Parse(l);



                string updateQuery = "UPDATE Employee SET LeaveBalance = LeaveBalance + @LeaveBalanceIncrement WHERE Id = @EmpId";



                using (SqlCommand updateCommand = new SqlCommand(updateQuery, con))
                {

                    updateCommand.Parameters.AddWithValue("@LeaveBalanceIncrement", leaveBalanceIncrement);
                    updateCommand.Parameters.AddWithValue("@EmpId", id);

                    updateCommand.ExecuteReader();

                }

                con.Close();
            }
            catch (Exception ex) { }

        }

        public void UpdateLeaveAfterAdd(string s, double l)
        {
            int id = getEmployeeId(s);


            try
            {
                con.Open();
                // double leaveBalanceIncrement = double.Parse(l);
                double leaveBalanceIncrement = l;


                string updateQuery = "UPDATE Employee SET LeaveBalance = LeaveBalance - @LeaveBalanceIncrement WHERE Id = @EmpId";



                using (SqlCommand updateCommand = new SqlCommand(updateQuery, con))
                {

                    updateCommand.Parameters.AddWithValue("@LeaveBalanceIncrement", leaveBalanceIncrement);
                    updateCommand.Parameters.AddWithValue("@EmpId", id);

                    updateCommand.ExecuteReader();

                }

                con.Close();
            }
            catch (Exception ex) { }

        }
        public void UpdateLeaveAfterAdd2(int id, double l)
        {
            //int id = getEmployeeId(s);


            try
            {
                con.Open();
                // double leaveBalanceIncrement = double.Parse(l);
                double leaveBalanceIncrement = l;


                string updateQuery = "UPDATE Employee SET LeaveBalance = LeaveBalance - @LeaveBalanceIncrement WHERE Id = @EmpId";



                using (SqlCommand updateCommand = new SqlCommand(updateQuery, con))
                {

                    updateCommand.Parameters.AddWithValue("@LeaveBalanceIncrement", leaveBalanceIncrement);
                    updateCommand.Parameters.AddWithValue("@EmpId", id);

                    updateCommand.ExecuteReader();

                }

                con.Close();
            }
            catch (Exception ex) { }

        }

        public DataTable GetLeaveBalance()
        {
            DataTable dt = new DataTable();

            // int currentYear = DateTime.Now.Year;


            SqlCommand command = new SqlCommand(@"
        SELECT 
            CONCAT(e.FirstName, ' ', e.LastName) AS Name,
			LeaveBalance
        FROM 
            Employee e", con);

            // command.Parameters.AddWithValue("@UserID", usId);
            SqlDataAdapter reader = new SqlDataAdapter(command);


            reader.Fill(dt);
            con.Close();
            return dt;
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
            row2["Profile"] = emp.Flx_Id;
            dt.Rows.Add(row2);

            DataRow row3 = dt.NewRow();
            row3["Profile"] = emp.Email;
            dt.Rows.Add(row3);

            // ...

            return dt;
        }

        public DataTable GetUpcomingLeaves(DateTime curentDate, DateTime nextFriday)
        {
            DataTable dt = new DataTable();

            string query = "SELECT e.Id, e.FirstName, e.LastName,l.LeaveType,  FORMAT(l.StartDate, 'dd MMM') as StartDate , FORMAT(l.EndDate, 'dd MMM') as EndDate FROM Employee e JOIN Leave l ON e.Id = l.EmpId WHERE (l.StartDate >= @Variable1 AND l.StartDate <= @Variable2)   OR    (l.EndDate >= @Variable1 AND l.EndDate <= @Variable2)   OR  (l.StartDate <= @Variable1 AND l.EndDate >= @Variable2) ORDER BY l.StartDate";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@Variable1", curentDate);
                command.Parameters.AddWithValue("@Variable2", nextFriday);


                SqlDataAdapter reader = new SqlDataAdapter(command);


                reader.Fill(dt);
            }
            con.Close();

            return dt;
        }

        public DataTable allEmployees()
        {
            DataTable dt = new DataTable();

            string query = "SELECT * FROM Employee ";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                SqlDataAdapter reader = new SqlDataAdapter(command);


                reader.Fill(dt);
            }
            con.Close();
            return dt;
        }
        public void UpdatePassword()
        {
            DBConnection d = new DBConnection();
            DataTable dt = d.allEmployees();


            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];
                var id = row["Id"];
                var Password = DBConnection.HashPassword(row["Password"].ToString());
                using (SqlCommand command = new SqlCommand("update Employee set Password='" + Password + "' where Id=" + id + "", con))
                {
                    con.Open();
                    command.ExecuteReader();
                    con.Close();
                }
            }


        }
        public void UpdatePassword(string s, string password)
        {
            DBConnection d = new DBConnection();
            Employee emp = d.GetEmployee(s);
            var id = emp.Id;
            var Password = DBConnection.HashPassword(password);
            using (SqlCommand command = new SqlCommand("update Employee set Password='" + Password + "' where Id=" + id + "", con))
            {
                con.Open();
                command.ExecuteReader();
                con.Close();
            }


        }

        public static string HashPassword(string password)
        {
            // Generate a random salt with a work factor of 12
            string salt = BCrypt.Net.BCrypt.GenerateSalt(12);

            // Hash the password with the salt
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password, salt);

            return hashedPassword;
        }

        public static bool VerifyPassword(string password, string hashedPassword)
        {
            // Verify the password by comparing it with the stored hashed password
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public int test()
        {
            string s = "Bhimashankar Patil";
            int i = 0;
            string[] nameParts = s.Split(' ');

            string firstName = nameParts[0];
            string lastName = nameParts[1];
            string query = "SELECT id FROM Employee WHERE FirstName = @firstName AND LastName = @lastName";
            con.Open();
            using (SqlCommand command = new SqlCommand(query, con))
            {
                command.Parameters.AddWithValue("@firstName", firstName);
                command.Parameters.AddWithValue("@lastName", lastName);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    i = int.Parse(reader.GetString(0));
                }
            }
            return i;

        }
        public DataTable LeaveApproval()
        {
            con.Open();

            DataTable dt = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM Leave ", con);
            
               
                //                using (SqlDataReader reader = command.ExecuteReader())
                //                {

                //                    SqlDataAdapter reader = new SqlDataAdapter(command);
                //                    reader.Fill(dt);
                //}
                //                con.Close();
                //            }
                //            return dt;

                SqlDataAdapter reader = new SqlDataAdapter(command);


                reader.Fill(dt);
                con.Close();
                return dt;
            }


        public void UpdateRowInDatabase2( string LeaveType, string ApprovalStatus)
        {
            con.Open();
            //string updateQuery = "UPDATE Leave SET LeaveType = @LeaveType WHERE ApprovalStatus = @ApprovalStatus";

            //using (SqlCommand command = new SqlCommand(updateQuery, con))
            //{
            //    command.Parameters.AddWithValue("@LeaveType", leaveType);
            //    command.Parameters.AddWithValue("@ApprovalStatus", approvalStatus);


            //    command.ExecuteReader();
            //}


            string updateQuery2 = "UPDATE Leave SET ApprovalStatus = @value1 WHERE LeaveType = @value2";
      using (SqlCommand cmd = new SqlCommand(updateQuery2, con))
                {

                    cmd.Parameters.AddWithValue("@value1", ApprovalStatus);
                    cmd.Parameters.AddWithValue("@value2", LeaveType);


                   
                    int rowsAffected = cmd.ExecuteNonQuery();

                
            }

            con.Close();
        }





    }

    public class HolidayList
    {
        public string Date { get; set; }
        public string Holiday { get; set; }
    }
    public class EmployeeLeave
    {
        public string FirstName { get; set; } = "NotSpecified";

        public string LeaveType { get; set; } = "Leave";

    }
    public class Upcomingleaves
    {
        public string FirstName { get; set; } = "NotSpecified";
        public string LastName { get; set; } = "NotSpecified";
        public DateTime StartDate { get; set; } = DateTime.Now;
        public DateTime EndDate { get; set; } = DateTime.Now;

    }
    public class Employee
    {
        public int Id { get; set; } = 0;
        public string Flx_Id { get; set; } = "FLX";
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
        public float Days { get; set; } = 0;

        public DateTime Created_On { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; } = "NoUser";
    }

}
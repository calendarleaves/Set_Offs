using System;
using Layout_2._1;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SetOffs1;
using System.Web.Configuration;

namespace WebApplication1
{
    public partial class WebForm11 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!Page.IsPostBack)
                {
                    if (Session["ID"] == null)
                    {
                        Response.Write("<script> alert('Your session has been expired...'); window.location.href = 'Login.aspx'</script>");
                    }
                }
                if (Session["ID"] == null)
                {
                    Response.Write("<script> alert('please Login...'); window.location.href = 'Login.aspx'</script>");
                }
                if (!IsPostBack)
                {
                    try
                    {
                        LoadTodayRecords();
                    }catch (Exception ex)
                    {
                        Custom.ErrorHandle(ex, Response);
                    }
                }
                //ProfileImage.Attributes.Add("onclick", "ToggleDropdownMenu()");

                if (Session["ID"] != null || Session["ID"] as String != "")
                {

                    //Added Dropdown Profile details 
                    DBConnection d = new DBConnection();
                    DataTable dt = d.GetProfileDataTable(Session["Id"] as string);

                    GridView3.DataSource = dt;
                    GridView3.DataBind();

                    //Added Profile side name name to 
                    Employee emp = new Employee();
                    emp = d.GetEmployee(Session["Id"] as string);
                    EmpName_profile.Text = emp.FirstName;
                    //EmpId_profile.Text = emp.Id.ToString();
                }
                LoadHolidays();
            }
            catch(Exception ex) 
            {
                Custom.ErrorHandle(ex, Response);
            }
        }



            protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                DateTime selectedDate = Calendar1.SelectedDate.Date;
                //if selected date is greater than today's date
                if (selectedDate > DateTime.Today)
                {
                    List<EmployeeLeave> sLeaves = GetEmployeeLeavesByDate(selectedDate); // fetching data from database


                    if (sLeaves.Count == 0) // if no records is there then show below message.
                    {
                        GridView1.DataSource = null;
                        GridView1.DataBind();

                        lblMessage.Text = "NO RECORDS YET !!";
                    }
                    else
                    {
                        GridView1.DataSource = sLeaves; // if record is there then show that records only.
                        GridView1.DataBind();

                        lblMessage.Text = string.Empty;
                    }
                }
                else if (selectedDate < DateTime.Today) // //if selected date is less than today's date
                {
                    List<EmployeeLeave> sLeaves = GetEmployeeLeavesByDate(selectedDate);//fetching data from database
                    if (sLeaves.Count == 0)
                    {
                        GridView1.DataSource = null; // if no records is there then show below message.
                        GridView1.DataBind();

                        lblMessage.Text = "ALL WERE PRESENT !!";
                    }
                    else
                    {
                        GridView1.DataSource = sLeaves; //if record is there then show that records only.
                        GridView1.DataBind();

                        lblMessage.Text = string.Empty;
                    }
                }
                else if (selectedDate == DateTime.Today)
                {
                    LoadTodayRecords();
                }
                else
                {

                    lblMessage.Text = "INVALID DATE";  // default condition.
                }
            }
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response);
            }
        }

        private List<EmployeeLeave> GetEmployeeLeavesByDate(DateTime date) // method to get employee list who are on leave by date
        {   

            DBConnection d = new DBConnection();
            return d.GetEmployeeLeave(date);
        }

        private void LoadTodayRecords() // this will load Today's records
        {
            try
            {
                DateTime today = DateTime.Today;

                List<EmployeeLeave> todayLeaves = GetEmployeeLeavesByDate(today);

                if (todayLeaves.Count == 0)
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();

                    lblMessage.Text = "ALL ARE PRESENT !!";
                }
                else
                {
                    GridView1.DataSource = todayLeaves;
                    GridView1.DataBind();

                    lblMessage.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response);
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsWeekend)
            {
                e.Day.IsSelectable = false;
                e.Cell.ToolTip = "Chhuti hai bhai..";

            }
            if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            try
            {
                lblMessage.Text = string.Empty;
                //This ccondition is to check if after month chages user is returning to current month then it'll show today's records.
                if (Calendar1.VisibleDate.Month == DateTime.Today.Month && Calendar1.VisibleDate.Year == DateTime.Today.Year)
                {
                    LoadTodayRecords();
                }
                else
                {
                    GridView1.DataSource = null; //  else Clear the data source
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("Create_Abs.aspx");
            }
            catch(Exception ex) { Custom.ErrorHandle(ex, Response); }
        }

        protected void logout(object sender, EventArgs e)
        {
            Session["ID"] = null;
            try
            {
                Response.Redirect("Login.aspx");
            }
            catch(Exception ex) {
                //Response.Redirect("Create_Abs.aspx");
            };
        }
        //private DataTable GetDataTable()
        //{
        //    // Replace with your data retrieval logic
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("Profile"); // Replace "ColumnName" with the actual column name

        //    DBConnection d = new DBConnection();
        //    Employee emp = new Employee();
        //    emp = d.GetEmployee(Session["Id"] as string);
        //    DataRow row1 = dt.NewRow();
        //    row1["Profile"] = emp.FirstName + " " + emp.LastName;
        //    dt.Rows.Add(row1);

        //    DataRow row2 = dt.NewRow();
        //    row2["Profile"] = emp.Id.ToString();
        //    dt.Rows.Add(row2);

        //    DataRow row3 = dt.NewRow();
        //    row3["Profile"] = emp.Email;
        //    dt.Rows.Add(row3);

        //    // ...

        //    return dt;
        //}

        private void LoadHolidays() // this will load next Holidays
        {
            try
            {
                DateTime today = DateTime.Today;
                DBConnection d = new DBConnection();
                List<HolidayList> nextHolidays = d.GetUpcomingHolidays(today);


                GridView2.DataSource = nextHolidays;
                GridView2.DataBind();



            }
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response);
            }
        }
    }
}



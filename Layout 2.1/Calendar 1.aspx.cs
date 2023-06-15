using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using SetOffs1;

namespace WebApplication1
{
    public partial class WebForm11 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
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
                LoadTodayRecords();
            }
            ProfileImage.Attributes.Add("onclick", "ToggleDropdownMenu()");
        }

      

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
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

        private List<EmployeeLeave> GetEmployeeLeavesByDate(DateTime date) // method to get employee list who are on leave by date
        {
            DBConnection d = new DBConnection();
            return d.GetEmployeeLeave(date);
        }

        private void LoadTodayRecords() // this will load Today's records
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create_Abs.aspx");
        }

        protected void logout(object sender, EventArgs e)
        {
            Session["ID"] = null;
            try
            {
                Response.Redirect("Login.aspx");
            }
            catch(Exception ex) { };
        }
    }
}



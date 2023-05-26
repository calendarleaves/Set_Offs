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
        //SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2VT3DAG;Initial Catalog=db1;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadTodayRecords();
            }
          
           
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Create_Abs.aspx");
        }


        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            //string selectDate = Calendar1.SelectedDate.ToString("yyyy-MM-dd");
            //string todayDate = Calendar1.TodaysDate.ToString("yyyy-MM-dd");

            //Response.Write(selectDate);
            // Response.Write(todayDate);
            /*
             List<EmployeeLeave> l = new List<EmployeeLeave>();
             DBConnection d = new DBConnection();
             l = d.GetEmployeeLeave(Calendar1.SelectedDate);

                 GridView1.DataSource = l;
                 GridView1.DataBind();   */
            LoadSelectedDateRecords();
        }    
        /*
        private void today()
        {
            List<EmployeeLeave> l = new List<EmployeeLeave>();
            DBConnection d = new DBConnection();
            l = d.GetEmployeeLeave(Calendar1.TodaysDate);
            GridView1.DataSource = l;
            GridView1.DataBind();

        }*/

        private List<EmployeeLeave> GetEmployeeLeavesByDate(DateTime date)
        {
            DBConnection d = new DBConnection();
            return d.GetEmployeeLeave(date);
        }

        private void LoadTodayRecords()
        {
            DateTime today = DateTime.Today;

            List<EmployeeLeave> todayLeaves = GetEmployeeLeavesByDate(today);

            GridView1.DataSource = todayLeaves;
            GridView1.DataBind();
        }

        private void LoadSelectedDateRecords()
        {
            DateTime selectedDate = Calendar1.SelectedDate;
            if (selectedDate != DateTime.MinValue)
            {
                List<EmployeeLeave> selectedDateLeaves = GetEmployeeLeavesByDate(selectedDate);

                GridView1.DataSource = selectedDateLeaves;
                GridView1.DataBind();
            }
               
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if ( e.Day.IsWeekend)
            {
                e.Day.IsSelectable = false;
                e.Cell.ToolTip = "Chhuti hai bhai..";
                
            }
            if(e.Day.IsOtherMonth )
            {
                e.Day.IsSelectable = false;
            }

            

        }

        protected void Calendar1_VisibleMonthChanged(object sender, MonthChangedEventArgs e)
        {
            Response.Write("Month Changed");

            if (Calendar1.SelectedDate == DateTime.MinValue)
            {
                GridView1.DataSource = new List<EmployeeLeave>(); // Clear the data source
                GridView1.DataBind();
            }
        }

        /*

         protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
         {
             if(e.Row.RowType == DataControlRowType.EmptyDataRow)
             {
                 // e.Row.Cells[0].Text = "NO RECORDS FOUND !!";

                 List<EmployeeLeave> selectedDateLeaves = GetEmployeeLeavesByDate(Calendar1.SelectedDate);

                 if (selectedDateLeaves.Count == 0)
                 {
                     if (Calendar1.SelectedDate < DateTime.Today)
                     {
                         e.Row.Cells[0].Text = "ALL WERE PRESENT !!";
                     }
                     else if (Calendar1.SelectedDate > DateTime.Today)
                     {
                         e.Row.Cells[0].Text = "NO RECORDS YET !!";
                     }
                     else if (Calendar1.SelectedDate.Date == DateTime.Today.Date)
                     {
                         e.Row.Cells[0].Text = "ALL ARE PRESENT !!";
                     }
                 }
                 else
                 {
                     e.Row.Cells[0].Text = "NO RECORDS FOUND !!";
                 }*/


    }
        }
    
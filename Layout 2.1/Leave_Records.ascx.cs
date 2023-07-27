using SetOffs1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Layout_2._1
{
    public partial class Leave_Records : System.Web.UI.UserControl
    {
        string usId = HttpContext.Current.Session["ID"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            List<HolidayList> nextHolidays = LoadHolidays2();
            try
            {
                GridView4.DataSource = nextHolidays;
                GridView4.DataBind();
            }
            catch (Exception ex)
            {

            }


            DBConnection d = new DBConnection();
            DataTable dt = new DataTable();
            if (usId == "admin@flexur.com")
            {
                 dt = d.GetAllLeaveRecords();
                GridView4.DataSource = dt;
                GridView4.DataBind();
                
            }
            else {
                 dt = d.GetUserLeaveRecords(usId);
                GridView4.DataSource = dt;
                GridView4.DataBind();
                GridView4.Columns[0].Visible = false;
            }

            
           
        }
        private List<HolidayList> LoadHolidays2() // this will load next Holidays
        {
            try
            {
                DateTime today = DateTime.Today;
                DBConnection d = new DBConnection();
                List<HolidayList> nextHolidays = d.GetUpcomingHolidays(today);

                return nextHolidays;

            }
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response);
                return new List<HolidayList>();
            }
        }
    }
}
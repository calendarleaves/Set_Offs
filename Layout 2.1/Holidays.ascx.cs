using SetOffs1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Layout_2._1
{
    public partial class Holidays : System.Web.UI.UserControl
    {
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
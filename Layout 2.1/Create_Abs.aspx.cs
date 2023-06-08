using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Reflection.Emit;
using SetOffs1;
//using Microsoft.AspNet.FriendlyUrls;

namespace WebApplication1
{

    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-2VT3DAG;Initial Catalog=db1;Integrated Security=True");


        DateTime currentDate;

        static string b = "1";
        int a = Int16.Parse(b);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;
            }

            if (from.Text == null)
            {
                Calendar2.Enabled = false;
            }


        }
        public string totalDays()
        {
            if (from.Text != "" && To.Text != "")
            {
                int weekoff = 0;

                DateTime startDate = Calendar1.SelectedDate;
                DateTime endDate = Calendar2.SelectedDate;
                {

                    currentDate = startDate;

                    while (currentDate <= endDate)
                    {
                        if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            weekoff++;
                        }
                        currentDate = currentDate.AddDays(1);
                    }


                }

                TimeSpan difference = endDate - startDate;
                string m = difference.ToString("dd");

                int n = Int16.Parse(m) + 1 - weekoff;
                Total_Days.Text = n.ToString();
            }
            return Total_Days.Text;
        }

        protected void Calendar1_Click(object sender, ImageClickEventArgs e)
        {
            Calendar1.SelectedDate = currentDate;
            calendar1lable.Text = "";
            from.Text = "";

            Total_Days.Text = "";

            Calendar2.Visible = false;
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;

            }
            else
            {
                Calendar1.Visible = true;
            }

            Calendar1.Attributes.Add("style", "position:absolute");

        }

        protected void Calendar2_Click(object sender, ImageClickEventArgs e)
        {
            Calendar2.SelectedDate = currentDate;
            Calendar2Label.Text = "";
            To.Text = "";
            if (from.Text != "")
            {
                Calendar2.Enabled = true;
            }
            Calendar1.Visible = false;
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;
            }
            else
            {
                Calendar2.Visible = true;
            }
            Calendar2.Attributes.Add("style", "position:absolute");

        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

            from.Text = Calendar1.SelectedDate.ToString("dd/MM/yy");
            Calendar1.Visible = false;
            totalDays();
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {

            To.Text = Calendar2.SelectedDate.ToString("dd/MM/yy");
            Calendar2.Visible = false;
            totalDays();

        }


        protected void Submit_click(object sender, EventArgs e)
        {
            try
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;
                DateTime start1 = Calendar1.SelectedDate;
                DateTime end1 = Calendar2.SelectedDate;
                if (Drop.SelectedValue == "")
                {
                    LeaveLable.Text = "* Please select leave";

                }
                else if (from.Text == "")
                {
                    calendar1lable.Text = "* Please select Startdate";
                }
                else if (To.Text == "")
                {
                    Calendar2Label.Text = "* Please select Enddate";
                }
                else
                {

                    conn.Open();
                    SqlCommand cmd = new SqlCommand("insert into [Leave]  values('" + a + "','" + Drop.SelectedValue + "', '" + Calendar1.SelectedDate.ToString("yyyy-MM-dd") + "','" + Calendar2.SelectedDate.ToString("yyyy-MM-dd") + "','" + TextBox1.Text + "','" + Total_Days.Text + "') ", conn);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                    Response.Redirect("WebForm1.aspx");
                }
            }
            catch (Exception ex)
            {

                Response.Write("genreral exception");

            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.Date) // Replace DateTime.Now with your selected value
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray; // Change the color to gray to indicate the disabled day
            }

            if (To.Text != "")
            {
                if (e.Day.Date > Calendar2.SelectedDate) // Replace DateTime.Now with your selected value
                {
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Gray; // Change the color to gray to indicate the disabled day
                }
            }
        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < Calendar1.SelectedDate) // Replace DateTime.Now with your selected value
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray; // Change the color to gray to indicate the disabled day
            }

        }

        protected void Drop_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = Drop.SelectedValue;

            if (selectedValue != "")
            {
                LeaveLable.Text = "";
            }
        }


    }
}
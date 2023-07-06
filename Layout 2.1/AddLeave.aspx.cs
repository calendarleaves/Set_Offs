using SetOffs1;
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
using System.Diagnostics.Eventing.Reader;
using Layout_2._1;

namespace Layout_2._1
{
    public partial class AddLeave : System.Web.UI.Page
    {
        string selectedValue;
        int id;
        string value1;
        string value2;

        string item;
        DateTime currentDate;

        protected void Page_Load(object sender, EventArgs e)
        {


            if (from.Text == null)
            {
                Calendar2.Enabled = false;

            }

            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;

                DBConnection s = new DBConnection();

                List<string> data = new List<string>();
                data = s.GetAllEmployeeLeave();

                DropDownList1.DataSource = data;
                DropDownList1.DataBind();

            }


        }
        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        protected void Submit_click(object sender, EventArgs e)
        {
             try
            {

                string fullName = DropDownList1.SelectedItem.Value;


                string[] nameParts = fullName.Split(' ');

                string firstName = nameParts[0];
                string lastName = nameParts[1];


                Calendar1.Visible = false;
                Calendar2.Visible = false;
                DateTime start1 = Calendar1.SelectedDate;
                DateTime end1 = Calendar2.SelectedDate;


                if (Drop.SelectedValue == "")

                {
                    LeaveLable.Text = "* Please Select Leave";
                    Drop.Focus();


                }
                else if (from.Text == "")
                {
                    calendar1lable.Text = "* Please Select Start Date";
                    from.Focus();

                }
                else if (To.Text == "")
                {
                    Calendar3Label.Text = "* Please Select End Date";
                    To.Focus();

                }
                else
                {
                    Leave l = new Leave();
                    l.LeaveType = Drop.SelectedValue;
                    l.StartDate = Calendar1.SelectedDate;
                    l.EndDate = Calendar2.SelectedDate;
                    l.Days = Int16.Parse(Total_Days.Text);
                    l.Comments = CommentBox.Text;

                    DBConnection s = new DBConnection();

                    s.Addleave(firstName, lastName, l);

                    Server.Transfer("Calendar 1.aspx");
                }

            }
            catch (Exception ex)
            {

                Custom.ErrorHandle(ex, Response);


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
            Calendar3Label.Text = "";
            To.Text = "";
            Total_Days.Text = "";
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


        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            Calendar1.BackColor = Color.White;
            Calendar1.TitleFormat = TitleFormat.Month;

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
            if (e.Day.Date.DayOfWeek == DayOfWeek.Saturday || e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Red;

            }

        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Now.Date) // Replace DateTime.Now with your selected value
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray; // Change the color to gray to indicate the disabled day
            }
            if (e.Day.Date < Calendar1.SelectedDate) // Replace DateTime.Now with your selected value
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray; // Change the color to gray to indicate the disabled day
            }
            if (e.Day.Date.DayOfWeek == DayOfWeek.Saturday || e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Red;

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

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("Calendar 1.aspx");
        }
    }
}

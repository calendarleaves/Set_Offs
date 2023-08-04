using SetOffs1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Layout_2._1
{
    public partial class Add_Leave : System.Web.UI.UserControl
    {
        string selectedValue;
        int id;
        string value1;
        string value2;

        string item;
        DateTime currentDate;


        SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HDH00MK;Initial Catalog=PCCOE;Integrated Security=True");

        private List<DateTime> holidays = new List<DateTime>();

        protected void Page_Load(object sender, EventArgs e)
        {


            holidays.Add(new DateTime(2023, 8, 15));
            holidays.Add(new DateTime(2023, 9, 19));
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


                data = s.GetAllEmployeeName();
                data.Insert(0, "--Select Employee--");
                DropDownList1.DataSource = data;
                DropDownList1.DataBind();

                /*      DropDownList1.DataSource = data;
                      DropDownList1.DataBind(); */


            }


        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (DropDownList1.SelectedValue != "--Select Employee--")
            {
                DropdownlistError.Text = "";

            }
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);

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


                if (DropDownList1.SelectedValue == "--Select Employee--")

                {
                    DropdownlistError.Text = "* Please select Employee";
                    DropDownList1.Focus();

                }
                else if (Drop.SelectedValue == "--Select Leave--")

                {
                    LeaveLable.Text = "* Please select leave";
                    Drop.Focus();

                }
                else if (from.Text == "")
                {
                    calendar1lable.Text = "* Please select start date";
                    from.Focus();



                }
                else if (To.Text == "")
                {
                    Calendar3Label.Text = "* Please select end ate";
                    To.Focus();


                }
                else if (comment.Text == "")
                {
                    commentError.Text = " * Please mention leave reason";
                    comment.Focus();



                }
                else
                {


                    Leave l = new Leave();
                    l.LeaveType = Drop.SelectedValue;
                    l.StartDate = Calendar1.SelectedDate;
                    l.EndDate = Calendar2.SelectedDate;
                    l.Days = float.Parse(Total_Days.Text);
                    l.Comments = comment.Text;

                    DBConnection s = new DBConnection();

                    s.Addleave(firstName, lastName, l);

                    Server.Transfer("Calendar 1.aspx");



                }

            }
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response);

            }

            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);

        }



        public string totalDays()
        {
            if (from.Text != "" && To.Text != "")
            {
                int weekoff = 0;
                int holidaysCount = 0;
                DateTime startDate;
                DateTime endDate;
                if (Drop.SelectedValue == "First Half " || Drop.SelectedValue == "Second Half")
                {
                    startDate = Calendar1.SelectedDate;
                    endDate = Calendar1.SelectedDate;
                }
                else
                {


                    startDate = Calendar1.SelectedDate;
                    endDate = Calendar2.SelectedDate;
                }

                {

                    currentDate = startDate;


                    while (currentDate <= endDate)
                    {
                        if (currentDate.DayOfWeek == DayOfWeek.Saturday || currentDate.DayOfWeek == DayOfWeek.Sunday)
                        {
                            weekoff++;
                        }
                        if (holidays.Contains(currentDate))
                        {
                            holidaysCount++;
                        }

                        currentDate = currentDate.AddDays(1);
                    }


                }

                TimeSpan difference = endDate - startDate;
                string m = difference.ToString("dd");

                if (Drop.SelectedValue == "First Half " || Drop.SelectedValue == "Second Half")

                {
                    Total_Days.Text = "0.5";

                    
                }
                else
                {
                    int n = Int16.Parse(m) + 1 - weekoff - holidaysCount;
                    Total_Days.Text = n.ToString();
                }



            }
            return Total_Days.Text;
        }

        protected void Calendar1_Click(object sender, ImageClickEventArgs e)
        {

            Calendar1.SelectedDate = currentDate;
            calendar1lable.Text = "";
            from.Text = "";

            Total_Days.Text = "";

            if (Drop.SelectedValue == "First Half " || Drop.SelectedValue == "Second Half")
            {
                To.Text = "";
            }

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
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);


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
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);


        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            from.Text = Calendar1.SelectedDate.ToString("dd/MM/yy");

            if (Drop.SelectedValue == "First Half " || Drop.SelectedValue == "Second Half")
            {
                To.Text = from.Text;
            }

            Calendar1.Visible = false;
            totalDays();
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);

        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {

            To.Text = Calendar2.SelectedDate.ToString("dd/MM/yy");
            Calendar2.Visible = false;
            totalDays();
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);


        }




        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {

            Calendar1.BackColor = Color.White;
            Calendar1.TitleFormat = TitleFormat.Month;

            DateTime startDate1 = new DateTime(2023, 4, 1);
            DateTime endDate1 = new DateTime(2024, 3, 31);

            if (e.Day.Date < startDate1 || e.Day.Date > endDate1) // Disable dates outside the specified range
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray; // Change the color to gray to indicate the disabled day
            }

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
            if (holidays.Contains(e.Day.Date))
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Red; // Optionally, change the color of the holiday dates
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);


        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {

            DateTime startDate1 = new DateTime(2023, 4, 1);
            DateTime endDate1 = new DateTime(2024, 3, 31);

            if (e.Day.Date < startDate1 || e.Day.Date > endDate1) // Disable dates outside the specified range
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Gray; // Change the color to gray to indicate the disabled day
            }
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
            if (holidays.Contains(e.Day.Date))
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.Red; // Optionally, change the color of the holiday dates
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);


        }

        protected void Drop_SelectedIndexChanged(object sender, EventArgs e)
        {
            Total_Days.Text = "";
            from.Text = "";
            To.Text = "";

            string selectedValue = Drop.SelectedValue;

            if (!string.IsNullOrEmpty(selectedValue) && selectedValue != "--Select Leave--")
            {
                LeaveLable.Text = "";

                if (Drop.SelectedValue == "First Half " || Drop.SelectedValue == "Second Half")
                {
                    Cal1.Enabled = false;
                    Cal1.BackColor = System.Drawing.Color.Gray;
                    Cal1.Visible = false;
                }
                else
                {
                    Cal1.Enabled = true;
                    Cal1.BackColor = System.Drawing.Color.White;
                    Cal1.Visible = true;
                }

            }
            if (Calendar1.Visible)
            {
                Calendar1.Visible = false;

            }
            if (Calendar2.Visible)
            {
                Calendar2.Visible = false;

            }
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);


        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            DropDownList1.ClearSelection();
            from.Text = "";
            To.Text = "";
            Drop.ClearSelection();
            comment.Text = "";
            Total_Days.Text = "";

            Calendar1.Visible = false;
            Calendar2.Visible = false;
        }


    }
}
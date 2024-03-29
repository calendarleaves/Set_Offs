﻿using SetOffs1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Layout_2._1
{
    public partial class Add_Leave : System.Web.UI.UserControl
    {
        string selectedValue; DateTime currentDate, targetDate;
        
        List<DateTime> holidays = new List<DateTime>();
        //private List<DateTime> holidays = new List<DateTime>();

        protected void Page_Load(object sender, EventArgs e)
        {

            try{ 
         
            DBConnection db = new DBConnection();
            DataTable dt = db.GetAllHolidayDates();
            DefaultValues();
            CultureInfo culture = new CultureInfo("en-GB");
            foreach (DataRow row in dt.Rows)
            {
              
                DateTime targetDate = Convert.ToDateTime(row["Date"],culture);
                holidays.Add(targetDate);
            }

            if (!IsPostBack)
            {

                Calendar1.Visible = false;
                Calendar2.Visible = false;

                SelectEmployee.Items.Clear();
                SelectEmployee.Items.Add(new ListItem("--Select Employee--", "null"));
                SelectEmployee.Items[0].Attributes["disabled"] = "disabled"; // Disable the item

                DBConnection s = new DBConnection();
                List<string> data = s.GetAllEmployeeName();

                foreach (string employeeName in data)
                {
                    SelectEmployee.Items.Add(new ListItem(employeeName, employeeName));
                }

                }

            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }
        }

        protected void DefaultValues()
        {
            try
            {

                To.BackColor = System.Drawing.Color.LightGray;
                from.BackColor = System.Drawing.Color.LightGray;
                Total_Days.BackColor = System.Drawing.Color.LightGray;
                To.Enabled = false;
                from.Enabled = false;
                Total_Days.Enabled = false;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
            }

        }

        protected void SelectEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try { 
            DropdownlistError.Text = "";

            if (SelectEmployee.SelectedValue != "null")

            {
                DropdownlistError.Text = "";


            }
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);
        }
         catch (Exception ex)
            {
                Logger.LogException(ex);
            }

}

        protected void Submit_click(object sender, EventArgs e)
        {

            try
            {
                string fullName = SelectEmployee.SelectedItem.Value;

             
                Calendar1.Visible = false;
                Calendar2.Visible = false;
                DateTime start1 = Calendar1.SelectedDate;
                DateTime end1 = Calendar2.SelectedDate;

                    string[] nameParts = fullName.Split(' ');

                    string firstName = nameParts[0];
                    string lastName = nameParts[1];
                    Leave l = new Leave();
                    l.LeaveType = drop.SelectedValue;
                    l.StartDate = Calendar1.SelectedDate;

                    if (drop.SelectedValue == "First Half " || drop.SelectedValue == "Second Half")

                    {
                        l.EndDate = Calendar1.SelectedDate;


                    }
                    else
                    {
                        l.EndDate = Calendar2.SelectedDate;
                    }
                    l.Days = float.Parse(Total_Days.Text);


                    l.Comments = comment.Text;

                    l.CreatedOn = DateTime.Now;
                    l.CreatedBy = "admin@flexur.com";

                    double l1;
                    if (l.LeaveType == "Work From  Home")
                    {
                        l1 = 0;
                    }
                    else
                    {
                        l1 = double.Parse(Total_Days.Text);
                    }

                    DBConnection s = new DBConnection();
                if (s.Addleave(firstName, lastName, l))
                {
                    s.UpdateLeaveAfterAdd(fullName, l1);
                    Response.Redirect("Calendar.aspx");
                }
                else
                {
                    commentError.Text = "Record already exists.Please fill different dates.";

                }

            }
            catch (System.Threading.ThreadAbortException ex)
            { }


            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);

            }

            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);

        }

        public string totalDays()
        {
            try
            {
                if (from.Text != "" && To.Text != "")
                {
                    int weekoff = 0;
                    int holidaysCount = 0;
                    DateTime startDate;
                    DateTime endDate;
                    if (drop.SelectedValue == "First Half " || drop.SelectedValue == "Second Half")
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

                    if (drop.SelectedValue == "First Half " || drop.SelectedValue == "Second Half")

                    {
                        Total_Days.Text = "0.5";


                    }
                    else
                    {
                        int n = Int16.Parse(m) + 1 - weekoff - holidaysCount;
                        Total_Days.Text = n.ToString();
                    }

                }
                
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);

            }
            return Total_Days.Text;
        }

        protected void Calendar1_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Calendar1.SelectedDate = currentDate;
                calendar1lable.Text = "";
                from.Text = "";

                Total_Days.Text = "";

                if (drop.SelectedValue == "First Half " || drop.SelectedValue == "Second Half")
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
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);

            }


        }

        protected void Calendar2_Click(object sender, ImageClickEventArgs e)
        {
            try { 
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
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);

            }


        }

        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                from.Text = Calendar1.SelectedDate.ToString("dd/MM/yy", CultureInfo.InvariantCulture);

                if (drop.SelectedValue == "First Half " || drop.SelectedValue == "Second Half")
                {
                    To.Text = from.Text;
                }

                Calendar1.Visible = false;
                totalDays();
                ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);

            }
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                To.Text = Calendar2.SelectedDate.ToString("dd/MM/yy", CultureInfo.InvariantCulture);
                Calendar2.Visible = false;
                totalDays();
                ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);
            }

            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);

            }

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {

                Calendar1.BackColor = Color.White;
                Calendar1.TitleFormat = TitleFormat.Month;

                DateTime startDate1 = new DateTime(2023, 4, 1);
                DateTime endDate1 = new DateTime(2024, 3, 31);

                if (e.Day.Date < startDate1 || e.Day.Date > endDate1)
                {
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Gray;
                }

                //if (e.Day.Date < DateTime.Now.Date) // Replace DateTime.Now with your selected value
                //{
                //    e.Day.IsSelectable = false;
                //    e.Cell.ForeColor = System.Drawing.Color.Gray; // Change the color to gray to indicate the disabled day
                //}

                if (To.Text != "")
                {
                    if (e.Day.Date > Calendar2.SelectedDate)
                    {
                        e.Day.IsSelectable = false;
                        e.Cell.ForeColor = System.Drawing.Color.Gray;
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
                    e.Cell.ForeColor = System.Drawing.Color.Red;
                }

                ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);

            }

        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {
                DateTime startDate1 = new DateTime(2023, 4, 1);
                DateTime endDate1 = new DateTime(2024, 3, 31);

                if (e.Day.Date < startDate1 || e.Day.Date > endDate1)
                {
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Gray;
                }
                //if (e.Day.Date < DateTime.Now.Date) 
                //{
                //    e.Day.IsSelectable = false;
                //    e.Cell.ForeColor = System.Drawing.Color.Gray; 
                if (e.Day.Date < Calendar1.SelectedDate)
                {
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Gray;
                }
                if (e.Day.Date.DayOfWeek == DayOfWeek.Saturday || e.Day.Date.DayOfWeek == DayOfWeek.Sunday)
                {
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Red;

                }

                if (holidays.Contains(e.Day.Date))
                {
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Red;
                }
                ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal3').modal('show');", true);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);

            }
        }

        protected void Drop_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LeaveLable.Text = "";
                Total_Days.Text = "";
                from.Text = "";
                To.Text = "";

                string selectedValue = drop.SelectedValue;

                if (!string.IsNullOrEmpty(selectedValue) && selectedValue != "--Select Leave--")
                {


                    if (drop.SelectedValue == "First Half " || drop.SelectedValue == "Second Half")
                    {
                        Cal1.Enabled = false;
                        Cal1.BackColor = System.Drawing.Color.LightGray;

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
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);

            }

        }

        protected void Cancel_Click(object sender, EventArgs e)
        {
            try
            {
                Server.Transfer("Calendar.aspx");
            }
            catch (System.Threading.ThreadAbortException ex)
            {

            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);

            }

        }
        protected void close_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Server.Transfer("Calendar.aspx");
            }
            catch (System.Threading.ThreadAbortException ex)
            {

            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);

            }
        }

        protected void comment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                commentError.Text = "";
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
            }
        }
    }
}
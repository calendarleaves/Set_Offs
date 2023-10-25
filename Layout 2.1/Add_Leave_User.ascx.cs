using SetOffs1;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography.X509Certificates;
using System.Security.Policy;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//SendMail() in this methode line 215 and 217
    //specify the email address of mail receivers

namespace Layout_2._1
{

    public partial class Add_Leave_User : System.Web.UI.UserControl
    {
        
        string selectedValue, value1, value2, item;
        int id;
        DateTime currentDate, targetDate;
        private List<DateTime> holidays = new List<DateTime>();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                DefaultSetting();
                DBConnection db = new DBConnection();
                DataTable dt = db.GetAllHolidayDates();


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
                    }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
            }

        }

        public void DefaultSetting()
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
                Custom.ErrorHandle(ex, Response);
            }

        }
        public string totalDays()
        {
            try
            {
                int weekoff = 0, holidaysCount = 0; DateTime startDate, endDate; string m;
                if (from.Text != "" && To.Text != "")
                {
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


                    TimeSpan difference = endDate - startDate;
                    m = difference.ToString("dd");

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
                // calendar1lable.Text = "";
                from.Text = "";

                Total_Days.Text = "";

                Calendar2.Visible = false;

                if (Drop.SelectedValue == "First Half " || Drop.SelectedValue == "Second Half")
                {
                    To.Text = "";
                }

                if (Calendar1.Visible)
                {
                    Calendar1.Visible = false;

                }
                else
                {
                    Calendar1.Visible = true;
                }

                Calendar1.Attributes.Add("style", "position:absolute");
                ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal7').modal('show');", true);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);

            }
        }

        protected void Calendar2_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Calendar2.SelectedDate = currentDate; To.Text = ""; Total_Days.Text = ""; Calendar1.Visible = false;

                if (Calendar2.Visible)
                {
                    Calendar2.Visible = false;
                }
                else
                {
                    Calendar2.Visible = true;
                }
                Calendar2.Attributes.Add("style", "position:absolute");
                ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal7').modal('show');", true);
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

                if (Drop.SelectedValue == "First Half " || Drop.SelectedValue == "Second Half")
                {
                    To.Text = from.Text;
                }

                Calendar1.Visible = false;
                totalDays();
                ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal7').modal('show');", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal7').modal('show');", true);
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);

            }
        }

        protected void SendMail()
        {

            try
            {
                DBConnection cmd = new DBConnection();
            Employee emp = new Employee();
            emp = cmd.GetEmployee(Session["ID"] as string);

            string FirstName = emp.FirstName;
            string lastName = emp.LastName;

            Leave leave = new Leave();

                MailMessage Email = new MailMessage();
                MailAddress Sender = new MailAddress("flexur.messenger@flexur.com");
                Email.From = Sender;
                string format;

                Email.To.Add("swapnil.suradkar@flexur.com");
        

                 string[] ccEmails = { "bhimashankar.patil@flexur.com", Session["ID"] as string };

                foreach (string ccEmail in ccEmails)
                {
                    Email.CC.Add(ccEmail);
                }
                if (Drop.SelectedValue == "Work From  Home")
                {
                    Email.Subject = "LeavePortal-{ " + FirstName + " " + lastName + " }-{ " + Drop.SelectedValue + " }";
                    //Email.Subject = FirstName + " " + lastName + " On " + Drop.SelectedValue;
                    format = "Hello,\n"
                                + FirstName + " " + lastName + " has requested for " + Drop.SelectedValue + " on date " + from.Text + " to " + To.Text + " for " + Total_Days.Text + " days \n" +
                                "Reason for leave - " + comment.Text + " \n\n" +

                                "Thank you \n" +
                                "Regards \n" +
                                 FirstName + " " + lastName;
                }
                else
                {
                    //Email.Subject = FirstName + " " + lastName + " On " + Drop.SelectedValue + " Leave ";
                    Email.Subject = "LeavePortal-{ " + FirstName + " " + lastName + " }-{ " + Drop.SelectedValue + " Leave}";
                    format = "Hello,\n"
                                + FirstName + " " + lastName + " has requested for " + Drop.SelectedValue + " leave on date " + from.Text + " to " + To.Text + " for " + Total_Days.Text + " days \n" +
                                "Reason for leave - " + comment.Text + " \n\n" +

                                "Thank you \n" +
                                "Regards \n" +
                                 FirstName + " " + lastName;
                }

                Email.Body = format;
                //string ServerName = "flxdev";
                //string Port = "25";

                string ServerName = ConfigurationManager.AppSettings["SmtpServerName"];
                string Port = ConfigurationManager.AppSettings["SmtpPort"];

                //if (string.IsNullOrEmpty(Port))
                  //  Port = "25";

                SmtpClient MailClient = new SmtpClient(ServerName, int.Parse(Port));
                MailClient.Send(Email)

;
                Email.Dispose();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
            }

        }


        protected void Submit_click(object sender, EventArgs e)
        {
            try
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;
                DateTime start1 = Calendar1.SelectedDate;
                DateTime end1 = Calendar2.SelectedDate;

                DBConnection cmd = new DBConnection();
                Employee emp = new Employee();
                emp = cmd.GetEmployee(Session["ID"] as string);

                Leave l = new Leave();
                l.EmpId = emp.Id;
                l.LeaveType = Drop.SelectedValue;
                l.StartDate = Calendar1.SelectedDate;

                l.CreatedOn = DateTime.Now;
                l.CreatedBy = emp.Email;

                if (Drop.SelectedValue == "First Half " || Drop.SelectedValue == "Second Half")

                {
                    l.EndDate = Calendar1.SelectedDate;


                }
                else
                {
                    l.EndDate = Calendar2.SelectedDate;
                }
                l.Days = float.Parse(Total_Days.Text);
                l.Comments = comment.Text;


                double l1;
                if (l.LeaveType == "Work From  Home")
                {
                    l1 = 0;
                }
                else
                {
                    l1 = double.Parse(Total_Days.Text);
                }

                int id1 = emp.Id;

                if (cmd.AddLeave(l))
                {
                    cmd.UpdateLeaveAfterAdd2(id1, l1);
                    SendMail();
                    Response.Redirect("Calendar.aspx");
                }
                else
                {
                    Logger.Log("Duplicate Leave addition attempt...");
                    commentError.Text = "Leave already exists.Please fill different dates.";

                }

                ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal7').modal('show');", true);

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

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            try
            {
                Calendar1.BackColor = Color.White;
                Calendar1.TitleFormat = TitleFormat.Month;

                if (e.Day.Date < DateTime.Now.Date)
                {
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Gray;
                }

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
                ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal7').modal('show');", true);


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
                if (e.Day.Date < DateTime.Now.Date)
                {
                    e.Day.IsSelectable = false;
                    e.Cell.ForeColor = System.Drawing.Color.Gray;
                }
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
                ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal7').modal('show');", true);
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
                Total_Days.Text = "";
                from.Text = "";
                To.Text = "";

                string selectedValue = Drop.SelectedValue;

                if (!string.IsNullOrEmpty(selectedValue) && selectedValue != "--Select Leave--")
                {
                    if (Drop.SelectedValue == "First Half " || Drop.SelectedValue == "Second Half")
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
                ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal7').modal('show');", true);
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
           // commentError.Text = "";
        }
    }
}
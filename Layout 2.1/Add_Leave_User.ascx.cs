using SetOffs1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Layout_2._1
{

    public partial class Add_Leave_User : System.Web.UI.UserControl
    {
        string selectedValue;
        int id;
        string value1;
        string value2;
        string item;
        DateTime currentDate;
        DateTime targetDate;
        private List<DateTime> holidays = new List<DateTime>();
        protected void Page_Load(object sender, EventArgs e)
        {

            DBConnection db = new DBConnection();
            DataTable dt = db.GetAllHolidayDates();

            To.BackColor = System.Drawing.Color.LightGray;
            from.BackColor = System.Drawing.Color.LightGray;
            Total_Days.BackColor = System.Drawing.Color.LightGray;

            To.Enabled = false;
            from.Enabled = false;

            Total_Days.Enabled = false;

            foreach (DataRow row in dt.Rows)
            {
                DateTime targetDate = Convert.ToDateTime(row["Date"]);
                holidays.Add(targetDate);
            }

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

        protected void Calendar2_Click(object sender, ImageClickEventArgs e)
        {
            Calendar2.SelectedDate = currentDate;
           // Calendar3Label.Text = "";
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
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal7').modal('show');", true);

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
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal7').modal('show');", true);

        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {

            To.Text = Calendar2.SelectedDate.ToString("dd/MM/yy");
            Calendar2.Visible = false;
            totalDays();
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal7').modal('show');", true);


        }

        protected void SendMail()
        {
            DBConnection cmd = new DBConnection();
            Employee emp = new Employee();
            emp = cmd.GetEmployee(Session["ID"] as string);

            Leave leave = new Leave();


            try
            {
                MailMessage Email = new MailMessage();
                MailAddress Sender = new MailAddress("flexur.messanger@flexur.com");
                Email.From = Sender;
                //      Console.WriteLine("Enter receiver email address:");

                // Email.To.Add("suraj.patil@flexur.com");

                Email.To.Add(Session["ID"] as string);



                Email.Subject = "Leave Application";


                string format = @"Hello sir,
                                          I will be unavailable in office from" + from.Text + "To" + To.Text + "\n           reason: " + comment.Text;


                // Set the email body to the comments
                Email.Body = format;



                //        Console.WriteLine("Enter SMTP server name :");
                string ServerName = "flxdev";
                //        Console.WriteLine("Enter Port (default 25) :");
                string Port = "25";
                if (string.IsNullOrEmpty(Port))
                    Port = "25";



                SmtpClient MailClient = new SmtpClient(ServerName, int.Parse(Port));
                MailClient.Send(Email)
;
                Email.Dispose();
                //   Console.WriteLine("Message sent succesfully. Check receiver inbox or smtp delivery queue.");
            }
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response);
            }
        }


        protected void Submit_click(object sender, EventArgs e)
        {
            SendMail();
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

                    cmd.AddLeave(l);
                    cmd.UpdateLeaveAfterAdd2(id1, l1);
                    Response.Redirect("Calendar.aspx");
                
            }
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal7').modal('show');", true);

        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
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

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
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

        protected void Drop_SelectedIndexChanged(object sender, EventArgs e)
        {

            ;


           // LeaveLable.Text = "";
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


                    //   Cal1.Visible = false;

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

        protected void Cancel_Click(object sender, EventArgs e)
        {
            Server.Transfer("Calendar.aspx");
        }

        protected void close_Click(object sender, ImageClickEventArgs e)
        {
            Server.Transfer("Calendar.aspx");
        }

        protected void comment_TextChanged(object sender, EventArgs e)
        {
           // commentError.Text = "";
        }
    }
}
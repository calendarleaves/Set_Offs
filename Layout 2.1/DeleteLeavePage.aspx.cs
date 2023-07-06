using System;
using SetOffs1;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Layout_2._1
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Calendar1.Visible = false;
                Calendar2.Visible = false;
                BindGridView();
            }        
        }

        protected void StartDateCalendar_Click(object sender, ImageClickEventArgs e)
        {

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

        protected void EndDateCalendar_Click(object sender, ImageClickEventArgs e)
        {
            if (StartDateSearch.Text != "")
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
            StartDateSearch.Text = Calendar1.SelectedDate.ToString("dd/MM/yyyy");
            Calendar1.Visible = false;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            EndDateSearch.Text = Calendar2.SelectedDate.ToString("dd/MM/yyyy");
            Calendar2.Visible = false;
        }



        private void BindGridView()
        {
            DataTable dt = new DataTable();
            DBConnection con = new DBConnection();

            dt = con.GetAllEmployeesLeave();

            DeleteLeaveGridView.DataSource = dt;
            DeleteLeaveGridView.DataBind();

        }
        

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            DBConnection con = new DBConnection();

            if (string.IsNullOrEmpty(txtSearch.Text) && string.IsNullOrEmpty(StartDateSearch.Text) && string.IsNullOrEmpty(EndDateSearch.Text))
            {

                //string script = "alert('Please enter a value in at least one textbox.');";
                //ClientScript.RegisterStartupScript(this.GetType(), "EmptyTextBoxPrompt", script, true);
                MainLabel.Text = "* Please enter atleast one input.";
                EmpNameLabel.Visible = false;
                StartDateLabel.Visible = false;
                EndDateLabel.Visible = false;
                txtSearch.Focus();
            }
            else if(string.IsNullOrEmpty(txtSearch.Text) && string.IsNullOrEmpty(StartDateSearch.Text))
            {
                MainLabel.Visible = false;
                EmpNameLabel.Text = "* Please enter employee full name.";
                StartDateLabel.Visible = false;
                EndDateLabel.Visible = false;
                txtSearch.Focus();
            }
            else if(string.IsNullOrEmpty(txtSearch.Text) && string.IsNullOrEmpty(EndDateSearch.Text))
                {
                MainLabel.Visible = false;
                EmpNameLabel.Text = "* Please enter employee full name.";
                StartDateLabel.Visible = false;
                EndDateLabel.Visible = false;
                txtSearch.Focus();
            }

            else if (string.IsNullOrEmpty(StartDateSearch.Text) && string.IsNullOrEmpty(EndDateSearch.Text))
            {


                int recordCount = con.CountLeave(txtSearch.Text); // to check if record count ==1;pooja devare

                if (recordCount == 1)
                {
                    con.DeleteLeave(txtSearch.Text);
                    BindGridView();
                }
                else
                {
                    //string script = "alert('Please enter start date.');";
                    //ClientScript.RegisterStartupScript(this.GetType(), "EmptyTextBoxPrompt", script, true);
                    MainLabel.Visible = false;
                    EmpNameLabel.Visible = false;
                    StartDateLabel.Text = "* Please enter start date.";
                    EndDateLabel.Visible = false;
                    StartDateSearch.Focus();
                }
            }
            else if (string.IsNullOrEmpty(EndDateSearch.Text))
            {

                int recordCount = con.CountLeave(txtSearch.Text, DateTime.Parse(StartDateSearch.Text)); // to check if record count ==1;
                if (recordCount == 1)
                {
                    con.DeleteLeave(txtSearch.Text, DateTime.Parse(StartDateSearch.Text));
                    BindGridView();
                }
                else
                {
                    //string script = "alert('Please enter end date.');";
                    //ClientScript.RegisterStartupScript(this.GetType(), "EmptyTextBoxPrompt", script, true);
                    MainLabel.Visible = false;
                    EmpNameLabel.Visible = false;
                    StartDateLabel.Visible = false;
                    EndDateLabel.Text = "* Please enter end date.";
                    EndDateSearch.Focus();
                }
            }
            else
            {
                con.DeleteLeave(txtSearch.Text, DateTime.Parse(StartDateSearch.Text), DateTime.Parse(EndDateSearch.Text));
                BindGridView();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            DBConnection con = new DBConnection();

            if (string.IsNullOrEmpty(txtSearch.Text) && string.IsNullOrEmpty(StartDateSearch.Text) && string.IsNullOrEmpty(EndDateSearch.Text))
            {
                MainLabel.Text = "* Please enter atleast one input.";
                EmpNameLabel.Visible = false;
                StartDateLabel.Visible = false;
                EndDateLabel.Visible = false;
                txtSearch.Focus();
            }
            else if (string.IsNullOrEmpty(txtSearch.Text) && string.IsNullOrEmpty(StartDateSearch.Text))
            {
                MainLabel.Visible = false;
                EmpNameLabel.Text = "* Please enter employee full name.";
                StartDateLabel.Visible = false;
                EndDateLabel.Visible = false;
                txtSearch.Focus();
            }
            else if (string.IsNullOrEmpty(txtSearch.Text) && string.IsNullOrEmpty(EndDateSearch.Text))
            {
                MainLabel.Visible = false;
                EmpNameLabel.Text = "* Please enter employee full name.";
                StartDateLabel.Visible = false;
                EndDateLabel.Visible = false;
                txtSearch.Focus();
            }
            

            else if (string.IsNullOrEmpty(StartDateSearch.Text) && string.IsNullOrEmpty(EndDateSearch.Text))
            {
                DataTable dt = new DataTable();
                dt = con.GetAllEmployeesLeave(txtSearch.Text);
                if (dt.Rows.Count == 0)
                {
                    DeleteLeaveGridView.DataSource = null;
                    DeleteLeaveGridView.DataBind();
                    lblmessage.Text = "No Records!";
                }
                else
                {
                    DeleteLeaveGridView.DataSource = dt;
                    DeleteLeaveGridView.DataBind();
                    lblmessage.Text = string.Empty; 
                    lblmessage.Visible = false;
                }
            }

            else if (string.IsNullOrEmpty(EndDateSearch.Text))
            {
                DataTable dt = new DataTable();

                dt = con.GetAllEmployeesLeave(txtSearch.Text, DateTime.Parse(StartDateSearch.Text));

                if (dt.Rows.Count == 0)
                {
                    DeleteLeaveGridView.DataSource = null;
                    DeleteLeaveGridView.DataBind();
                    lblmessage.Text = "No Records!";
                }
                else
                {
                    DeleteLeaveGridView.DataSource = dt;
                    DeleteLeaveGridView.DataBind();
                    lblmessage.Text = string.Empty;
                    lblmessage.Visible = false;
                }
            }
            else
            {
                DataTable dt = new DataTable();
                dt = con.GetAllEmployeesLeave(txtSearch.Text, DateTime.Parse(StartDateSearch.Text), DateTime.Parse(EndDateSearch.Text));
                if (dt.Rows.Count == 0)
                {
                    DeleteLeaveGridView.DataSource = null;
                    DeleteLeaveGridView.DataBind();
                    lblmessage.Text = "No Records!";
                }
                else
                {
                    DeleteLeaveGridView.DataSource = dt;
                    DeleteLeaveGridView.DataBind();
                    lblmessage.Text = string.Empty;
                    lblmessage.Visible = false;
                }
            }
        }

        protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsWeekend)
            {
                e.Day.IsSelectable = false;              
            }
            else if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
            }
        }

        protected void Calendar2_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.IsWeekend)
            {
                e.Day.IsSelectable = false;             
            }
            else if (e.Day.IsOtherMonth)
            {
                e.Day.IsSelectable = false;
            }
        }

        private void IsValid()
        {
            if (string.IsNullOrEmpty(txtSearch.Text) && string.IsNullOrEmpty(StartDateSearch.Text) && string.IsNullOrEmpty(EndDateSearch.Text))
            {

                MainLabel.Text = "* Please enter atleast one input.";
                EmpNameLabel.Visible = false;
                StartDateLabel.Visible = false;
                EndDateLabel.Visible = false;
                txtSearch.Focus();
            }
            else if(string.IsNullOrEmpty(StartDateSearch.Text) && string.IsNullOrEmpty(EndDateSearch.Text))
            {
                MainLabel.Text = "* Please enter atleast one input.";
                EmpNameLabel.Visible = false;
                StartDateLabel.Visible = false;
                EndDateLabel.Visible = false;
                txtSearch.Focus();
            }
        }
    }
 }

using System;
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
            }
            BindGridView();
        }

        DataTable dt = new DataTable();
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
            StartDateSearch.Text = Calendar1.SelectedDate.ToString("dd/MM/yy");
            Calendar1.Visible = false;
        }

        protected void Calendar2_SelectionChanged(object sender, EventArgs e)
        {
            EndDateSearch.Text = Calendar2.SelectedDate.ToString("dd/MM/yy");
            Calendar2.Visible = false;
        }

 
        private void BindGridView()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM DeleteLeave", con);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                DeleteLeaveGridView.DataSource = dt;
                DeleteLeaveGridView.DataBind();

            }
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (string.IsNullOrEmpty(txtSearch.Text) && string.IsNullOrEmpty(StartDateSearch.Text) && string.IsNullOrEmpty(EndDateSearch.Text))
                {

                    string script = "alert('Please enter a value in at least one textbox.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "EmptyTextBoxPrompt", script, true);
                }

                else if (string.IsNullOrEmpty(StartDateSearch.Text) && string.IsNullOrEmpty(EndDateSearch.Text))
                {

                    string countQuery = "SELECT COUNT(*) FROM DeleteLeave WHERE EmployeeName = @EmployeeName  ";
                    SqlCommand countCmd = new SqlCommand(countQuery, con);
                    countCmd.Parameters.AddWithValue("@EmployeeName", txtSearch.Text);

                    con.Open();
                    int recordCount = (int)countCmd.ExecuteScalar(); // to check if record count ==1;
                    con.Close();

                    if (recordCount == 1)
                    {
                        // Only one record matches the criteria
                        // Proceed with the deletion
                        string deleteQuery = "DELETE FROM DeleteLeave WHERE EmployeeName = @EmployeeName  ";
                        SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);
                        deleteCmd.Parameters.AddWithValue("@EmployeeName", txtSearch.Text);


                        con.Open();
                        deleteCmd.ExecuteNonQuery();
                        con.Close();

                        BindGridView();


                    }
                    else
                    {
                        string script = "alert('Please enter start date.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "EmptyTextBoxPrompt", script, true);

                    }

                }
                else if (string.IsNullOrEmpty(EndDateSearch.Text))
                {
                    string countQuery = "SELECT COUNT(*) FROM DeleteLeave WHERE EmployeeName = @EmployeeName AND StartDate = @StartDate ";
                    SqlCommand countCmd = new SqlCommand(countQuery, con);
                    countCmd.Parameters.AddWithValue("@EmployeeName", txtSearch.Text);
                    countCmd.Parameters.AddWithValue("@StartDate", DateTime.Parse(StartDateSearch.Text));

                    con.Open();
                    int recordCount = (int)countCmd.ExecuteScalar(); // to check if record count ==1;
                    con.Close();

                    if (recordCount == 1)
                    {
                        // Only one record matches the criteria
                        // Proceed with the deletion
                        string deleteQuery = "DELETE FROM DeleteLeave WHERE EmployeeName = @EmployeeName AND StartDate = @StartDate ";
                        SqlCommand deleteCmd = new SqlCommand(deleteQuery, con);
                        deleteCmd.Parameters.AddWithValue("@EmployeeName", txtSearch.Text);
                        deleteCmd.Parameters.AddWithValue("@StartDate", DateTime.Parse(StartDateSearch.Text));


                        con.Open();
                        deleteCmd.ExecuteNonQuery();
                        con.Close();

                        BindGridView();


                    }
                    else
                    {
                        string script = "alert('Please enter end date.');";
                        ClientScript.RegisterStartupScript(this.GetType(), "EmptyTextBoxPrompt", script, true);

                    }
                }
                else
                {
                    string query = "Delete from DeleteLeave  where EmployeeName= @EmployeeName AND (StartDate = @StartDate OR EndDate = @EndDate)";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Employeename", txtSearch.Text);
                    cmd.Parameters.AddWithValue("@StartDate", DateTime.Parse(StartDateSearch.Text));
                    cmd.Parameters.AddWithValue("@EndDate", DateTime.Parse(EndDateSearch.Text));


                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    BindGridView();

                }
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            //string employeeName = txtSearch.Text.Trim();
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                if (string.IsNullOrEmpty(txtSearch.Text) && string.IsNullOrEmpty(StartDateSearch.Text) && string.IsNullOrEmpty(EndDateSearch.Text))
                {

                    string script = "alert('Please enter a value in at least one textbox.');";
                    ClientScript.RegisterStartupScript(this.GetType(), "EmptyTextBoxPrompt", script, true);
                }

                else if (string.IsNullOrEmpty(StartDateSearch.Text) && string.IsNullOrEmpty(EndDateSearch.Text))
                {
                    string query = "Select * from DeleteLeave where EmployeeName= @EmployeeName";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@EmployeeName", txtSearch.Text.Trim());

                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DeleteLeaveGridView.DataSource = dt;
                        DeleteLeaveGridView.DataBind();
                    }
                }

                else if (string.IsNullOrEmpty(EndDateSearch.Text))
                {
                    string query = "Select * from DeleteLeave where EmployeeName= @EmployeeName AND StartDate = @StartDate ";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@EmployeeName", txtSearch.Text.Trim());
                    sda.SelectCommand.Parameters.AddWithValue("@StartDate", DateTime.Parse(StartDateSearch.Text));

                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DeleteLeaveGridView.DataSource = dt;
                        DeleteLeaveGridView.DataBind();
                    }
                }
                else
                {

                    string query = "Select * from DeleteLeave where EmployeeName= @EmployeeName AND (StartDate = @StartDate OR EndDate = @EndDate)";
                    SqlDataAdapter sda = new SqlDataAdapter(query, con);
                    sda.SelectCommand.Parameters.AddWithValue("@EmployeeName", txtSearch.Text.Trim());
                    sda.SelectCommand.Parameters.AddWithValue("@StartDate", DateTime.Parse(StartDateSearch.Text));
                    sda.SelectCommand.Parameters.AddWithValue("@EndDate", DateTime.Parse(EndDateSearch.Text));
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        DeleteLeaveGridView.DataSource = dt;
                        DeleteLeaveGridView.DataBind();
                    }
                }




            }
        }


    }
}
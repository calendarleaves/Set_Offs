using System;
using System.Collections.Generic;
using System.Configuration;
using SetOffs1;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

namespace Layout_2._1
{
    public partial class WebForm2 : System.Web.UI.Page
    {


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();
            }

        }

        private void BindGridView()
        {
            try
            {
                DataTable dt = new DataTable();
                DBConnection con = new DBConnection();

                dt = con.GetAllEmployeesLeave();
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
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response);
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                DBConnection con = new DBConnection();

                string searchText = txtSearch.Text.Trim();
                Regex regex = new Regex("^[A-Za-z\\s]+$");

                if (string.IsNullOrEmpty(txtSearch.Text))
                {
                    lblErrorMessage.Text = "Enter Employee Name..";
                    txtSearch.Focus();
                }
                else if (!regex.IsMatch(searchText))
                {
                    lblErrorMessage.Visible = true;
                    lblErrorMessage.Text = "Wrong input! Only letters  are allowed.";
                    lblmessage.Visible = false;
                    return;
                }
                else
                {
                    dt = con.GetAllEmployeesLeaveLikeName(searchText);

                    if (dt.Rows.Count == 0)
                    {
                        DeleteLeaveGridView.DataSource = null;
                        DeleteLeaveGridView.DataBind();
                        lblmessage.Visible = true;
                        lblmessage.Text = "No Records!";
                        lblErrorMessage.Text = string.Empty;
                        lblErrorMessage.Visible = false;
                    }
                    else
                    {
                        DeleteLeaveGridView.DataSource = dt;
                        DeleteLeaveGridView.DataBind();
                        lblmessage.Text = string.Empty;
                        lblmessage.Visible = false;
                        lblErrorMessage.Text = string.Empty;
                        lblmessage.Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response);
            }
        }

        protected void DeleteLeaveGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            try
            {
                string fullName = DeleteLeaveGridView.Rows[e.RowIndex].Cells[1].Text + " " + DeleteLeaveGridView.Rows[e.RowIndex].Cells[2].Text;
                string startDate = DeleteLeaveGridView.Rows[e.RowIndex].Cells[4].Text;
                string endDate = DeleteLeaveGridView.Rows[e.RowIndex].Cells[5].Text;

                DBConnection con = new DBConnection();
                con.DeleteLeave(fullName, DateTime.Parse(startDate), DateTime.Parse(endDate));

                BindGridView();

            }
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response);
            }

        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            try
            {
                lblmessage.Text = string.Empty;
                lblmessage.Visible = false;
                lblErrorMessage.Text = string.Empty;
                lblmessage.Visible = false;
                txtSearch.Text = "";
                txtSearch.Focus();
                BindGridView();
            }
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response);
            }

        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
               Response.Redirect("Calendar 1.aspx");
            }
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response);
            }
        }
    }
}
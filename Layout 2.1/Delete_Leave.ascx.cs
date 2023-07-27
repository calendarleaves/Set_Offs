using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SetOffs1;

namespace Layout_2._1
{
    public partial class Delete_Leave : System.Web.UI.UserControl
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
                    ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal4').modal('show');", true);

                }
                else
                {
                    DeleteLeaveGridView.DataSource = dt;
                    DeleteLeaveGridView.DataBind();
                    lblmessage.Text = string.Empty;
                    lblmessage.Visible = false;
                    ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal4').modal('show');", true);
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
                ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal4').modal('show');", true);
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

                //int id = Convert.ToInt32(DeleteLeaveGridView.Rows[e.RowIndex].Cells[0].Text);
                string fullName = DeleteLeaveGridView.Rows[e.RowIndex].Cells[1].Text + " " + DeleteLeaveGridView.Rows[e.RowIndex].Cells[2].Text;
                string startDate = DeleteLeaveGridView.Rows[e.RowIndex].Cells[4].Text;
                string endDate = DeleteLeaveGridView.Rows[e.RowIndex].Cells[5].Text;

                DBConnection con = new DBConnection();
                con.DeleteLeave(fullName, DateTime.Parse(startDate), DateTime.Parse(endDate));

                //string successMessage = "Record has been deleted.";
                //string script = $"<script>showSuccessAlert(\"{successMessage}\");</script>";
                //ClientScript.RegisterStartupScript(GetType(), "ShowSuccessAlert", script);
                //ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alertMessage", "alert('Record Deleted Successfully')", true);
                BindGridView();

            }
            catch (Exception ex)
            {
                //string errorMessage = "Failed to delete the record.";
                //string script = $"<script>showWarningAlert(\"{errorMessage}\");</script>";
                //ClientScript.RegisterStartupScript(GetType(), "ShowWarningAlert", script);

                Custom.ErrorHandle(ex, Response);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal4').modal('show');", true);

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
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal4').modal('show');", true);
        }

        protected void DeleteLeaveGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                if (e.Row.RowIndex == DeleteLeaveGridView.SelectedIndex)
                {
                    e.Row.CssClass = "selected-row";
                }
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal4').modal('show');", true);
        }

        protected void DeleteLeaveGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //String script = "$('#myModal6').modal('show')";
            //ClientScriptManager.RegisterStartupScript(this.GetType(), "keepModalOpen", script,true);
            // ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('.modal').modal('show');", true);
            DeleteLeaveGridView.SelectedIndex = DeleteLeaveGridView.SelectedRow.RowIndex;
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal4').modal('show');", true);
        }




    }
}
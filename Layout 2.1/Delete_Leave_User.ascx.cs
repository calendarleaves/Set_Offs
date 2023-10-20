using SetOffs1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Layout_2._1
{
    public partial class Delete_Leave_User : System.Web.UI.UserControl
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
                // string email = Session["ID"].ToString();

                DataTable dt = new DataTable();
                DBConnection con = new DBConnection();

                Employee emp = new Employee();
                emp = con.GetEmployee(Session["Id"] as string);
                string name = emp.FirstName + " " + emp.LastName;
                dt = con.GetAllEmployeesLeaveLikeName(name);

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
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
            }
        }

        protected void DeleteLeaveGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string fullname = DeleteLeaveGridView.Rows[e.RowIndex].Cells[1].Text + " " + DeleteLeaveGridView.Rows[e.RowIndex].Cells[2].Text;
                string startDate = DeleteLeaveGridView.Rows[e.RowIndex].Cells[4].Text;
                string endDate = DeleteLeaveGridView.Rows[e.RowIndex].Cells[5].Text;
                string LeaveType = DeleteLeaveGridView.Rows[e.RowIndex].Cells[3].Text;
                string TotalDays = DeleteLeaveGridView.Rows[e.RowIndex].Cells[6].Text;

                if (LeaveType == "Work From  Home")
                {
                    TotalDays = "0";
                }


                DBConnection con = new DBConnection();
                con.DeleteLeave(fullname, DateTime.Parse(startDate), DateTime.Parse(endDate));
                con.UpdateLeaveAfterDelete(fullname, TotalDays);
                BindGridView();

                Response.Redirect("Calendar.aspx");
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
        protected void DeleteLeaveGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {

                    if (e.Row.RowIndex == DeleteLeaveGridView.SelectedIndex)
                    {
                        e.Row.CssClass = "selected-row";
                    }
                    CultureInfo culture = new CultureInfo("en-GB");
                    DateTime StartDate = Convert.ToDateTime(e.Row.Cells[4].Text,culture);

                    if (StartDate < DateTime.Today)
                    {
                        Button btnDelete = e.Row.FindControl("btnDelete") as Button;
                        btnDelete.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
            }
        }
        protected void DeleteLeaveGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                DeleteLeaveGridView.SelectedIndex = DeleteLeaveGridView.SelectedRow.RowIndex;
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
            }
            }
    }
}
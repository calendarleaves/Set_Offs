using SetOffs1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.AccessControl;
using static System.Collections.Specialized.BitVector32;
namespace Layout_2._1
{
    public partial class LeaveApproval : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGridView();

            }
        }

        protected void BindGridView()
        {
            try
            {
                DBConnection d = new DBConnection();
                DataTable ds = new DataTable();
                ds = d.LeaveApproval();

                GridView1.DataSource = ds;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void UpdateRowInDatabase(string leaveType, string approvalStatus)
        {
            DBConnection d = new DBConnection();
            d.UpdateRowInDatabase2(leaveType,approvalStatus);
        }

        protected void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Approve" || e.CommandName == "Reject")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[rowIndex];
                string LeaveType = row.Cells[1].Text;
                string ApprovalStatus = e.CommandName == "Approve" ? "approved" : "rejected";
                DBConnection d = new DBConnection();
                UpdateRowInDatabase( LeaveType,ApprovalStatus);
                BindGridView();
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal90').modal('show');", true);
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                 string approvalStatus = DataBinder.Eval(e.Row.DataItem, "ApprovalStatus").ToString().ToLower();

                Button approveButton = e.Row.FindControl("btnUpdate") as Button;
                Button rejectButton = e.Row.FindControl("btnUpdate2") as Button;

                 if (approvalStatus == "approved" || approvalStatus == "rejected")
                {
                    if (approveButton != null)
                    {
                        approveButton.Enabled = false;
                        approveButton.CssClass = "approved-rejected-row"; 
                    }
                    
                    if (rejectButton != null)
                    {
                        rejectButton.Enabled = false;
                        rejectButton.CssClass = "approved-rejected-row"; 

                    }
                    e.Row.CssClass = "approved-rejected-row";
                }
            }
        }
    }
}

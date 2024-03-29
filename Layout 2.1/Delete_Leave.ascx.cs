﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
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
            try
            {
                if (!IsPostBack)
                {
                    BindGridView();
                }
            }
            catch(Exception ex) {

                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
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
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
            }
            //ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "$('#myModal4').modal('show')", true);
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
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
            }
           ScriptManager.RegisterStartupScript(this,GetType(), "Popup", "$('#myModal4').modal('show')", true);
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
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
            }
            
            ScriptManager.RegisterStartupScript(this, GetType(), "Popup", "$('#myModal4').modal('show')", true);
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
                }
            }
         catch(Exception ex) {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
            }
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal4').modal('show');", true);
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
             ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal4').modal('show');", true);
        }

        protected void DeleteLeaveGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string fullName = DeleteLeaveGridView.Rows[e.RowIndex].Cells[1].Text + " " + DeleteLeaveGridView.Rows[e.RowIndex].Cells[2].Text;
                string startDate = DeleteLeaveGridView.Rows[e.RowIndex].Cells[4].Text;
                string endDate = DeleteLeaveGridView.Rows[e.RowIndex].Cells[5].Text;

                CultureInfo culture = new CultureInfo("en-GB");
                DateTime sDate = Convert.ToDateTime(startDate, culture);
                DateTime eDate = Convert.ToDateTime(endDate, culture);

                DBConnection con = new DBConnection();
                con.DeleteLeave(fullName,sDate,eDate);

                BindGridView();
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
            }
        }
    }
}
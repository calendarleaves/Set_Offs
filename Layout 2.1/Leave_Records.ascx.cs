using SetOffs1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Layout_2._1
{
    public partial class Leave_Records : System.Web.UI.UserControl
    {
        //string usId;
       //string usId = HttpContext.Current.Session["ID"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            string usId="";
            try
            {
                if (Session["ID"] != null)
                {
                    usId = HttpContext.Current.Session["ID"].ToString();
                }

                DBConnection d = new DBConnection();

                //get leave balance
                DataTable dt1 = new DataTable();
                if (usId == "admin@flexur.com")
                {
                    //dt1 = d.GetLeaveBalance();
                    //GridView5.DataSource = dt1;
                    //GridView5.DataBind();
                    //GridView5.Columns[0].Visible = false;
                    GridView5.Visible = false;
                }
                else
                {
                    dt1 = d.GetLeaveBalance(usId);
                    CultureInfo culture = new CultureInfo("en-GB");
                    foreach (DataRow row in dt1.Rows)
                    {
                        double leaveBalance = Convert.ToDouble(row["LeaveBalance"], culture);
                        string formattedLeaveBalance = leaveBalance.ToString("0.#");
                        row["LeaveBalance"] = formattedLeaveBalance;
                    }

                    GridView5.DataSource = dt1;
                    GridView5.DataBind();
                    GridView5.Columns[0].Visible = false;
                }


                //leave record list

                DataTable dt = new DataTable();
                if (usId == "admin@flexur.com")
                {
                    dt = d.GetAllLeaveRecords();

                    if (dt.Rows.Count == 0)
                    {
                        GridView4.DataSource = null;
                        GridView4.DataBind();
                        GridView4.Columns[0].Visible = true;
                        lblMsg.Text = "No Records!";

                    }
                    else
                    {
                        GridView4.DataSource = dt;
                        GridView4.DataBind();
                        GridView4.Width = Unit.Percentage(97);
                        lblMsg.Text = string.Empty;
                        lblMsg.Visible = false;
                    }


                }
                else
                {
                    dt = d.GetUserLeaveRecords(usId);

                    if (dt.Rows.Count == 0)
                    {
                        GridView4.DataSource = null;
                        GridView4.DataBind();
                        lblMsg.Text = "No Records!";

                    }
                    else
                    {
                        GridView4.DataSource = dt;
                        GridView4.DataBind();
                        GridView4.Columns[0].Visible = false;
                        lblMsg.Text = string.Empty;
                        lblMsg.Visible = false;
                    }

                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
            }

        }

        protected void closeLRec_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                Server.Transfer("Calendar.aspx");
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                Custom.ErrorHandle(ex, Response);
            }
        }

    }
}
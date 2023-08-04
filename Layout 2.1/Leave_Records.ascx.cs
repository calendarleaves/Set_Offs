using SetOffs1;
using System;
using System.Collections.Generic;
using System.Data;
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
            if (Session["ID"] != null)
            {
                usId = HttpContext.Current.Session["ID"].ToString();
            }
          
            DBConnection d = new DBConnection();
            DataTable dt = new DataTable();
            if (usId == "admin@flexur.com")
            {
                 dt = d.GetAllLeaveRecords();

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
                    lblMsg.Text = string.Empty;
                    lblMsg.Visible = false;
                }
                            
                
            }
            else {
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
        
    }
}
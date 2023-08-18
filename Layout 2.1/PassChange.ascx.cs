using SetOffs1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace Layout_2._1
{
    public partial class PassChange : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] != null || Session["ID"] as String != "")
            {

                ////Added Dropdown Profile details 
                //DBConnection d = new DBConnection();
                //DataTable dt = d.GetProfileDataTable(Session["Id"] as string);

                //details.DataSource = dt;
                //details.DataBind();

            }
          
        }

        protected void closeChangepass(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Calendar 1.aspx");
        }

        protected void ChangePass(object sender, EventArgs e)
        {
            try
            {
                error.Text = "";


                string s = Session["Id"] as string;
                Employee employee = new Employee();
                DBConnection con = new DBConnection();
                employee = con.GetEmployee(s);

                if (oldpassbox.Text == "" || newpassbox.Text.Length < 8)
                {
                    oldpasserror.Text = " * Please Password at least have 8 characters";
                    oldpassbox.Focus();
                }
                else if (newpassbox.Text == "" || newpassbox.Text.Length < 8)
                {
                    newpasserror.Text = " * Please Password at least have 8 characters";
                    newpassbox.Focus();
                }
                else if (confirmpassbox.Text == "" || confirmpassbox.Text.Length < 8)
                {
                    newpasserror.Text = " * Please Password at least have 8 characters";
                    newpassbox.Focus();
                }
                else if (newpassbox.Text == confirmpassbox.Text)
                {


                    if (DBConnection.VerifyPassword(oldpassbox.Text, employee.Password))
                    {
                        con.UpdatePassword(employee.Email, newpassbox.Text);
                        Response.Redirect("Calendar 1.aspx");
                    }
                    else
                    {
                        error.Text = "Old password is wrong.";
                        oldpassbox.Focus();
                    }
                }
                else
                {
                    error.Text = "Confirm password is not match.";
                    confirmpassbox.Focus();
                   
                }
                //if (Submit.Text == "Confirm Password")
                //{ }
                //else
                //{


                //    if (DBConnection.VerifyPassword(oldpassbox.Text, employee.Password))
                //    {
                //        Submit.Text = "Confirm Password";

                //        oldpassbox.ReadOnly=true;
                //        newpassbox.ReadOnly = true;
                //    }

                //}
            }
            catch(Exception ex)
            {

            }
            ScriptManager.RegisterStartupScript(this, GetType(), "keepModalOpen", "$('#myModal15').modal('show');", true);



        }
    }
}
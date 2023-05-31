using SetOffs1;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Layout_2._1
{
    public partial class WebForm1 : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        { 
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();
               DBConnection con =new DBConnection();
                employee=con.GetEmployee(UsernameTextBox.Text);



                if (UsernameTextBox.Text == "")
                {
                    {
                        user.Text = " * Please Enter valid data";
                    }
                }
                else
                {
                    user.Text = "";
                }

                if (PasswordTextBox.Text == "")
                {
                    {
                        pass.Text = " * Please Enter valid data";
                    }
                }
                else
                {
                    pass.Text = "";
                }
                if (UsernameTextBox.Text==employee.Email && PasswordTextBox.Text==employee.Password)
                {
                    Session["ID"] = UsernameTextBox.Text;

                    Response.Redirect("Calendar 1.aspx");

                }
                else
                {
                    loginfail.Text = "   * Authentication Failed  ";
                }

            }
            catch (Exception ex)
            {
                Response.Write(ex.Message.ToString());
            }

        }


    }
}
    

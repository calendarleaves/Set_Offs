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
    {    protected void Page_Load(object sender, EventArgs e)
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
                { { user.Text = " * Please Fill Username "; } }
                else
                { user.Text = "";}

                if (PasswordTextBox.Text == "")
                {{pass.Text = " * Please Fill Password"; } }
                else
                { pass.Text = ""; }

                if (UsernameTextBox.Text==employee.Email && PasswordTextBox.Text==employee.Password)
                { Session["ID"] = UsernameTextBox.Text;
                   Response.Redirect("Calendar 1.aspx"); }

                else
                {
                    if (UsernameTextBox.Text !="" && PasswordTextBox.Text != "")
                    { loginfail.Text = "* Username or password is incorrect  ";}
                    else { loginfail.Text = ""; }
                }
            }
            catch (Exception ex)
            {
                Response.Write("server down");
            }

        }}}
    

using SetOffs1;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace Layout_2._1
{
    public partial class WebForm1 : System.Web.UI.Page
    { protected void Page_Load(object sender, EventArgs e)
        {
            Session["ID"] = null;
            
        }
        protected void Login_Click(object sender, EventArgs e)
        {
            try
            {
                Employee employee = new Employee();
                DBConnection con = new DBConnection();
                employee = con.GetEmployee(UsernameTextBox.Text);

                if (PasswordTextBox.Text == "")
                {
                    pass.Text = " *";
                    PasswordTextBox.Focus();
                }
                else
                { pass.Text = ""; }

                if (UsernameTextBox.Text == "")
                {
                    user.Text = " * ";
                    UsernameTextBox.Focus();
                }
                else
                { user.Text = ""; }
                var pass1 = HttpUtility.HtmlEncode(PasswordTextBox.Text);

                PasswordTextBox.Text = DBConnection.HashPassword(pass1);
                if (UsernameTextBox.Text == employee.Email && DBConnection.VerifyPassword(pass1, employee.Password))
                {
                    
                    Session["ID"] = UsernameTextBox.Text;
                    //Response.Redirect("Calendar.aspx");
                    HandleSuccessfulAuthentication();
                    //FormsAuthentication.RedirectFromLoginPage(username, false);
                }
                else
                {
                  /*  if (UsernameTextBox.Text != "" && PasswordTextBox.Text != "")
                    { error.Text = "* Username or password is incorrect  "; }
                    else { error.Text = ""; } */

                    if (UsernameTextBox.Text == "" && PasswordTextBox.Text == "")
                    {
                        error.Text = "* Fill approprite data  ";
                    }
                    else if (UsernameTextBox.Text == "" && PasswordTextBox.Text != "")
                    {
                        error.Text = "* Fill Username  ";
                    }
                    else if (UsernameTextBox.Text != "" && PasswordTextBox.Text == "")
                    {
                        error.Text = "* Fill Password  ";
                    }
                    else if (UsernameTextBox.Text != "" && PasswordTextBox.Text != "")
                    {
                        error.Text = "* Username or password is incorrect  ";
                    }
                    else { error.Text = ""; }
                }
            }
            catch (Exception ex)
            {
                Custom.ErrorHandle(ex, Response,Context);
                
            }

        }
        protected void HandleSuccessfulAuthentication()
        {
            Response.Redirect("Calendar.aspx");
        }
    } }
    


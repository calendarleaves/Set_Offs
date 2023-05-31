using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using SetOffs1;


namespace Login_Page
{
    // hi bhima this is for demo purpose
    
        public partial class WebForm1 : System.Web.UI.Page
        {
            SqlConnection con = new SqlConnection("Data Source=192.168.11.215,1433;Initial Catalog=Setoffs;User ID=user;Password=***********");
            protected void Page_Load(object sender, EventArgs e)
            { }
            protected void Submit_Click(object sender, EventArgs e)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("Select Username,Password from Log where Username='" + UsernameTextBox.Text + "'and Password='" + PasswordTextBox.Text + " '", con);
                    con.Open();

                    SqlDataReader rdr = cmd.ExecuteReader();

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
                    if (rdr.Read())
                    {
                        Session["ID"] = UsernameTextBox.Text;
                        Response.Write("Succesfully logged in");

                    }
                    else
                    {
                        Response.Write("Authentication Failed");
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex.Message.ToString());
                }

            }


        }
 }

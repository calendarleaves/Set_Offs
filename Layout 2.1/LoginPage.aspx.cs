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
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-HDH00MK;Initial Catalog=PCCOE;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        { 
        }
        protected void Submit_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select Email,Password from Employee where Email='" + UsernameTextBox.Text + "'and Password='" + PasswordTextBox.Text + " '", con);
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
    

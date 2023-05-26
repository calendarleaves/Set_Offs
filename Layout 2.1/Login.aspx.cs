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
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2VT3DAG;Initial Catalog=db1;Integrated Security=True");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void sbt_Click(object sender, EventArgs e)
        {

            //SqlCommand cmd = new SqlCommand("Select email,PASSWORD from Employee where email='" + textuser.Text + "'and Password='" + textpass.Text + " '", con);
            //con.Open();
            Employee emp= new Employee();
            DBConnection cmd = new DBConnection();
            emp=cmd.GetEmployee(textuser.Text);



            if (emp.Password == "pass")
            {
                Response.Write("Authentication Failed");
            }
            else if (emp.Password == textpass.Text)
            {

                Session["ID"] = emp.Id;
                Response.Redirect("Calendar 1.aspx");
            }   
            else
            {
                Response.Write("Please Enter Currect Password");
            }
            
            }
            
        }
    }

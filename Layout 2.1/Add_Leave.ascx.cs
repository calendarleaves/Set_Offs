using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Layout_2._1
{
    public partial class Add_Leave : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-45HGR8T;Initial Catalog=Setoffs;Integrated Security=True";

            // Get the value from the text box
            string nameValue = txtName.Text;

            // Create the SQL query to insert the value into the table
            string insertQuery = "INSERT INTO Trial1 (name) VALUES (@Name)";

            try
            {
                // Create a new SqlConnection using the connection string
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Open the connection
                    connection.Open();

                    // Create a new SqlCommand with the query and the connection
                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        // Add a parameter to the command to avoid SQL injection
                        command.Parameters.AddWithValue("@Name", nameValue);

                        // Execute the query
                        command.ExecuteNonQuery();
                    }
                }

                // If the execution reaches here, the insertion was successful
                // You can add any additional code or messages if needed
                Response.Write("Data inserted successfully!");
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the database operation
                // You can display an error message or log the exception details
                Response.Write("An error occurred: " + ex.Message);
            }

            DateTime selectedDate = Calendar1.SelectedDate;

            // Insert the selected date into the Trial1 table
            InsertIntoTrial1(selectedDate);

            // Optionally, close the modal pop-up after inserting the date
            //PopupForm.Hide();
        }

        private void InsertIntoTrial1(DateTime selectedDate)
        {
            // Implement your database connection and insert logic here.
            // This is just a sample to demonstrate the concept.

            // For simplicity, assume you are using SqlConnection and SqlCommand
            string connectionString = "Data Source=DESKTOP-45HGR8T;Initial Catalog=Setoffs;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string insertQuery = "INSERT INTO Trial1 (Date) VALUES (@SelectedDate)";
                SqlCommand command = new SqlCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@SelectedDate", selectedDate);

                try
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Handle the exception appropriately.
                }
            }
        }


    }
}
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class _Default : System.Web.UI.Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            d_u.Visible = false;
            if(Session["role"] == null)
            {
                Session["role"] = "";
            }

            if (!IsPostBack)
            {
                // SQL query to retrieve data from the database
                string query = "SELECT UserId, Role FROM UserDetails";

                // Create a SqlConnection and a SqlCommand
                using (SqlConnection connection = new SqlConnection(connectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Open the connection
                    connection.Open();

                    // Execute the query and get a SqlDataReader
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Set the data source and bind it to the Repeater
                        Repeater1.DataSource = reader;
                        Repeater1.DataBind();
                    }
                }
            }

        }

        protected void myRepeater_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "ItemClick")
            {
                // Retrieve the command argument (ID in this case)
                int clickedID = Convert.ToInt32(e.CommandArgument);

                // Perform any action with the clicked ID (e.g., redirect to a details page)
                Response.Redirect($"DetailsPage.aspx?ID={clickedID}");
            }
        }

        protected void pastdata(object sender, EventArgs e)
        {
            // SQL query to retrieve data from the database
            string query = "SELECT UserId, Role FROM UserDetails";

            // Create a SqlConnection and a SqlCommand
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Open the connection
                connection.Open();

                // Execute the query and get a SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Set the data source and bind it to the Repeater
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                }
            }
        }
        protected void currentdata(object sender, EventArgs e)
        {
            // SQL query to retrieve data from the database
            string query = "SELECT UserId, Role FROM UserDetails";

            // Create a SqlConnection and a SqlCommand
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Open the connection
                connection.Open();

                // Execute the query and get a SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Set the data source and bind it to the Repeater
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                }
            }

        }
        protected void upcommingdata(object sender, EventArgs e)
        {
            // SQL query to retrieve data from the database
            string query = "SELECT UserId, Role FROM UserDetails";

            // Create a SqlConnection and a SqlCommand
            using (SqlConnection connection = new SqlConnection(connectionString))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                // Open the connection
                connection.Open();

                // Execute the query and get a SqlDataReader
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Set the data source and bind it to the Repeater
                    Repeater1.DataSource = reader;
                    Repeater1.DataBind();
                }
            }
        }

        // quiz attend link
        protected void attendquiz(object sender, EventArgs e)
        {
            Response.Redirect("~/Content_Pages/Quiz.aspx");
        }

        // quiz create link
        protected void createquiz(object sender, EventArgs e)
        {

        }

        // manage quiz link
        protected void managequiz(object sender, EventArgs e)
        {

        }
    }
}
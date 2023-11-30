using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Session["role"] = "";
            if(!IsPostBack)
            {
                Email.Text = "";
                Password.Text = "";
            }
            if(Request.Cookies["authcookie"] != null)
            {
                if(Request.Cookies["authcookie"]["username"] == Email.Text && Request.Cookies["authcookie"]["password"] == Password.Text)
                {
                    Response.Redirect("~/Default.aspx");
                }
            }
        }

        protected void login_Click(object sender, EventArgs e)
        {
            //Response.Redirect("~/User/Home.aspx");
            
           /* string captchaText = Session["Captcha"] as string;
            if (captchaText == captcha.Text)
            {*/
            string password = Password.Text.ToString();
            string hashedPassword = HashPassword(password);

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                string query = "SELECT Email, Role, Password FROM Users WHERE Email = @email";

                SqlCommand cmdd = new SqlCommand(query, con);
                cmdd.Parameters.AddWithValue("@email", Email.Text);

                SqlDataReader q1 = cmdd.ExecuteReader();
                q1.Read();

                if (q1.HasRows)
                {
                    string l_email = q1.GetString(0);
                    string l_password = q1.GetString(2);

                    if (l_password == hashedPassword)
                    {
                        if (RememberMe.Checked == true)
                        {
                            Response.Cookies["authcookie"]["username"] = Email.Text;
                            Response.Cookies["authcookie"]["password"] = Password.Text;
                            Response.Cookies["authcookie"].Expires = DateTime.Now.AddDays(1);
                        }
                        Session["username"] = Email.Text;
                        Session["role"] = q1.GetValue(1).ToString();
                        Response.Redirect("~/Default.aspx");
                    }
                    con.Close();
                }
                else
                {
                    clicklabel.Text = "Username and Password not available";
                    Email.Text = "";
                    Password.Text = "";
                }
            }



            /*}
            else
            {
                clicklabel.Text = "CAPTCHA is not valid. Please try again.";
            }*/
            
        }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }
    }
}
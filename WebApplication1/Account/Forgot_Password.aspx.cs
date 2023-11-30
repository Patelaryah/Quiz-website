using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class Forgot_Password : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            multiview.ActiveViewIndex = 0;
        }

        //send otp
        protected void sendotp(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                string query = "SELECT Email FROM Users WHERE Email = @email";

                SqlCommand cmdd = new SqlCommand(query, con);
                cmdd.Parameters.AddWithValue("@email", email.Text);

                SqlDataReader q1 = cmdd.ExecuteReader();
                q1.Read();

                if (q1.HasRows)
                {
                    q1.Close();
                    
                    con.Close();

                    Random random = new Random();
                    int randomNum = random.Next(100000, 1000000);

                    using (SqlConnection conn = new SqlConnection(constr))
                    {
                        conn.Open();
                        string query1 = "INSERT INTO otp(Otps, user) values(@otps, @user)";
                        SqlCommand cmd = new SqlCommand(query1, conn);
                        cmd.Parameters.AddWithValue("@user", email.Text);
                        cmd.Parameters.AddWithValue("@otps", randomNum);
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }

                    string toEmail = email.Text;
                    try
                    {
                        MailMessage mailMessage = new MailMessage("pikapikapikachu7726@gmail.com", toEmail);
                        mailMessage.Subject = "Hello from ASP.NET";
                        mailMessage.Body = "This is an automated email sent from ASP.NET." +
                            "welcome to BrainStormer." +
                            "OTP: " + randomNum +
                            "";

                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                        smtpClient.Credentials = new System.Net.NetworkCredential()
                        {
                            UserName = "pikapikapikachu7726@gmail.com",
                            Password = "ASH-SERENA"
                        };

                        smtpClient.EnableSsl = true;
                        smtpClient.Send(mailMessage);
                    }
                    catch (Exception ex)
                    {
                        label5.Text = "Error sending email: " + ex.Message;
                    }
                }
                else
                {
                    label5.Text = "You are not registered";
                }
            }
        }
        // view 1 submit button
        protected void submit(object sender, EventArgs e)
        {
            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                string query = "SELECT Otps FROM otp WHERE otps = @otp";

                SqlCommand cmdd = new SqlCommand(query, con);
                cmdd.Parameters.AddWithValue("@otp", otp.Text);

                SqlDataReader q1 = cmdd.ExecuteReader();
                q1.Read();

                if (q1.HasRows)
                {
                    multiview.ActiveViewIndex = 1;
                }
                else
                {
                    label5.Text = "Enter valid OTP";
                }
            }
        }
        // view2 submit button
        protected void forgotpassword(object sender, EventArgs e)
        {
            string Password = password.Text.ToString();
            string hashedPassword = HashPassword(Password);

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                SqlCommand cmdd = new SqlCommand("Forgot_Password", con);
                cmdd.Parameters.AddWithValue("@password", hashedPassword);
                con.Close();
                Response.Redirect("~/Account/Login.aspx");
            }
        }
        // hash password
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
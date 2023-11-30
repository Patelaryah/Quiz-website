using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Web.Security;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Mail;

namespace WebApplication1.Account
{
    public partial class Registration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["role"] = "";
            multiview.ActiveViewIndex = 0;
            if(!IsPostBack)
            {
                firstname.Text = "";
                lastname.Text = "";
                email_f1.Text = "";
                phone_f1.Text = "";
                password_f1.Text = "";
                repassword_f1.Text = "";
                male_f1.Checked = false;
                female_f1.Checked = false;
                other_f1.Checked = false;
                dateofbirth_f1.Text = "";
                //country_f1.SelectedIndex = 0;
                state_f1.SelectedIndex = 0;
                district_f1.Text = "";
                city_f1.Text = "";
                department_f1.SelectedIndex = 0;

                org_name_f2.Text = "";
                email_f2.Text = "";
                phone_f2.Text = "";
                password_f2.Text = "";
                repassword_f2.Text = "";
                //country_f2.SelectedIndex = 0;
                state_f2.SelectedIndex = 0;
                district_f2.Text = "";
                city_f2.Text = "";
                address_f2.Text = "";

                sname_f3.Text = "";
                email_f3.Text = "";
                phone_f3.Text = "";
                password_f3.Text = "";
                repassword_f3.Text = "";
                address_f3.Text = "";
                //country_f3.SelectedIndex = 0;
                state_f3.SelectedIndex = 0;
                district_f3.Text = "";
                city_f3.Text = "";
            
            }
        }

        protected void school_Click(object sender, EventArgs e)
        {
            multiview.ActiveViewIndex = 3;
        }

        protected void user_Click(object sender, EventArgs e)
        {
            multiview.ActiveViewIndex = 1;
        }

        protected void org_Click(object sender, EventArgs e)
        {
            multiview.ActiveViewIndex = 2;
        }

        protected void RegistrationButton_s_click(object sender, EventArgs e)
        {
            string Password_f3 = password_f3.Text.ToString();
         
            string hashedPassword = HashPassword(Password_f3);
            
            string Role = "School/College";

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                
            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();
                    
                string query = "SELECT Username, role FROM Users WHERE Username = @SchoolName";

                SqlCommand cmdd = new SqlCommand(query, con);
                cmdd.Parameters.AddWithValue("@SchoolName", sname_f3.Text);

                SqlDataReader q1 = cmdd.ExecuteReader();
                q1.Read();
                
                if (q1.HasRows)
                {
                    string s_user = q1.GetString(0);
                    string s_role = q1.GetString(1);
                    if (s_user == sname_f3.Text && s_role == Role)
                    {
                        s1.Text = "School Name is already taken";
                    }
                    con.Close();
                }
                else
                {
                    q1.Close();

                    using (SqlCommand cmd = new SqlCommand("College", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@SchoolName", sname_f3.Text.ToString());
                        cmd.Parameters.AddWithValue("@Email_f3", email_f3.Text.ToString());
                        cmd.Parameters.AddWithValue("@Phone_No_f3", phone_f3.Text);
                        cmd.Parameters.AddWithValue("@Role", Role.ToString());
                        //cmd.Parameters.AddWithValue("@Country_f3", country_f3.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@State_f3", state_f3.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@District_f3", district_f3.Text);
                        cmd.Parameters.AddWithValue("@City_f3", city_f3.Text);
                        cmd.Parameters.AddWithValue("@Pincode_f3", pincode_f3.Text);
                        cmd.Parameters.AddWithValue("@Address_f3", address_f3.Text.ToString());
                        cmd.Parameters.AddWithValue("@Password_f3", hashedPassword);

                        string toEmail = email_f3.Text;
                        SendEmail(toEmail);
                        
                        cmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Account Created Successfully')</script>");
                        Response.Redirect("~/Account/Login.aspx");
                        con.Close();

                    }
                }
            }
        }
        
        protected void RegistrationButton_o_click(object sender, EventArgs e)
        {
            string Password_f2 = password_f2.Text.ToString();

            string hashedPassword = HashPassword(Password_f2);

            string Role = "Organizer";

            string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                string query = "SELECT Username, role FROM Users WHERE Username = @organizerName";

                SqlCommand cmdd = new SqlCommand(query, con);
                cmdd.Parameters.AddWithValue("@OrganizerName", org_name_f2.Text);

                SqlDataReader q1 = cmdd.ExecuteReader();
                q1.Read();

                if (q1.HasRows)
                {
                    string o_user = q1.GetString(0);
                    string o_role = q1.GetString(1);
                    if (o_user == org_name_f2.Text && o_role == Role)
                    {
                        o1.Text = "Organizer Name is already taken";
                    }
                    con.Close();
                }
                else
                {
                    //SendEmail();
                    q1.Close();

                    using (SqlCommand cmd = new SqlCommand("Organizer", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@OrganizerName", org_name_f2.Text);
                        cmd.Parameters.AddWithValue("@Email_f2", email_f2.Text);
                        cmd.Parameters.AddWithValue("@Phone_No_f2", phone_f2.Text);
                        cmd.Parameters.AddWithValue("@Role", Role);
                        //cmd.Parameters.AddWithValue("@Country_f2", country_f2.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@State_f2", state_f2.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@District_f2", district_f2.Text);
                        cmd.Parameters.AddWithValue("@City_f2", city_f2.Text);
                        cmd.Parameters.AddWithValue("@Pincode_f2", pincode_f2.Text);
                        cmd.Parameters.AddWithValue("@Address_f2", address_f2.Text);
                        cmd.Parameters.AddWithValue("@Password_f2", hashedPassword);

                        string toEmail = email_f2.Text;
                        SendEmail(toEmail);

                        cmd.ExecuteNonQuery();
                        Response.Write("<script>alert('Account Created Successfully')</script>");

                        Response.Redirect("~/Account/Login.aspx");

                        con.Close();
                    }
                }
            }

        }

        protected void RegistrationButton_u_click(object sender, EventArgs e)
        {
            if (male_f1.Checked == false && female_f1.Checked == false && other_f1.Checked == false)
            {
                gender_uu.Text = "Select Gender";
            }
            else
            {
                string Password_f1 = password_f1.Text.ToString();
                
                string hashedPassword = HashPassword(Password_f1);
                
                string Role = "User";

                string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                
                using (SqlConnection con = new SqlConnection(constr))
                {
                    con.Open();

                    string query = "SELECT Username, Role, Email FROM Users WHERE Username = @username";

                    SqlCommand cmdd = new SqlCommand(query, con);
                    cmdd.Parameters.AddWithValue("@username", firstname.Text);

                    SqlDataReader q1 = cmdd.ExecuteReader();
                    q1.Read();
                    if (q1.HasRows)
                    {
                        string s_user = q1.GetString(0);
                        string s_role = q1.GetString(1);
                        string s_email = q1.GetString(2);
                        if (s_user == firstname.Text && s_role == Role && s_email == email_f1.Text)
                        {
                            u1.Text = "User Name is already taken";
                        }
                        con.Close();
                    }
                    else
                    {
                        q1.Close();

                        using (SqlCommand cmd = new SqlCommand("User", con))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@Firstname", firstname.Text);
                            cmd.Parameters.AddWithValue("@Lastname", lastname.Text);
                            cmd.Parameters.AddWithValue("@Email_f1", email_f1.Text);
                            cmd.Parameters.AddWithValue("@Phone_No_f1", phone_f1.Text);

                            if (male_f1.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@Gender", male_f1.Text);
                            }
                            else if (female_f1.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@Gender", female_f1.Text);
                            }
                            else if (other_f1.Checked == true)
                            {
                                cmd.Parameters.AddWithValue("@Gender", other_f1.Text);
                            }
                            cmd.Parameters.AddWithValue("@DateOfBirth", dateofbirth_f1.Text);
                            cmd.Parameters.AddWithValue("@Role", Role);
                            //cmd.Parameters.AddWithValue("@Country_f1", country_f1.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@State_f1", state_f1.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@District_f1", district_f1.Text);
                            cmd.Parameters.AddWithValue("@City_f1", city_f1.Text);
                            cmd.Parameters.AddWithValue("@Pincode_f1", pincode_f1.Text);
                            cmd.Parameters.AddWithValue("@Department", department_f1.SelectedValue.ToString());
                            cmd.Parameters.AddWithValue("@Password_f1", hashedPassword);

                            string toEmail = email_f1.Text;
                            SendEmail(toEmail);

                            cmd.ExecuteNonQuery();
                            Response.Write("<script>alert('Account Created Successfully')</script>");

                            Response.Redirect("~/Account/Login.aspx");
                            con.Close();
                        }
                    }
                }
            }
        }

        // simple to hash password
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);
                byte[] hashBytes = sha256.ComputeHash(bytes);
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

        //SendEmail();            
        private void SendEmail(string toEmail)
        {
            try
            {
              /*  string toEmail = "";
                string toEmail = "arypatel80@gmail.com";
                if (multiview.ActiveViewIndex == 1)
                {
                    toEmail = email_f1.Text.ToString();
                }
                else if (multiview.ActiveViewIndex == 2)
                {

                    toEmail = email_f2.Text.ToString();
                }
                else if (multiview.ActiveViewIndex == 3)
                {
                    toEmail = email_f3.Text.ToString();
                }*/

                MailMessage mailMessage = new MailMessage("pikapikapikachu7726@gmail.com", toEmail);
                mailMessage.Subject = "Hello from ASP.NET";
                mailMessage.Body = "This is an automated email sent from ASP.NET." +
                    "welcome to BrainStormer.";

                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587);
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtpClient.Credentials = new System.Net.NetworkCredential()
                {
                    UserName = "pikapikapikachu7726@gmail.com",
                    Password = "ASH-SERENA"
                };
                
                //smtpClient.UseDefaultCredentials = true;
                smtpClient.EnableSsl = true;
                
                smtpClient.Send(mailMessage);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending email: " + ex.Message);
            }
        }
    }
}
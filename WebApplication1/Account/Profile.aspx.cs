using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Account
{
    public partial class Profile : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (Session["role"].Equals("User"))
            {
                user_u(sender, e);
                if(TextBox4.Text == "false")
                {
                    link4.Visible = true;
                }
                else
                {
                    link4.Visible = false;
                }
                
            }
            else if (Session["role"].Equals("Organizer"))
            {
                org_u(sender, e);
                if (TextBox4.Text == "false")
                {
                    link4.Visible = true;
                }
                else
                {
                    link4.Visible = false;
                }
            }
            else if (Session["role"].Equals("School/College"))
            {
                school(sender, e);
                if (TextBox4.Text == "false")
                {
                    link4.Visible = true;
                }
                else
                {
                    link4.Visible = false;
                }
            }
        }

        // on load school data show
        protected void school(object sender, EventArgs e)
        {
            //string un = "arypatel15@gmail.com";
            //string rl = "School/College";
            string un = Session["username"].ToString();
            string rl = Session["role"].ToString();
            
            label1.Text = "School/College Name: ";
            d2.Visible = false;
            d6.Visible = false;
            d7.Visible = false;
            d9.Visible = false;
            d10.Visible = false;
            d15.Visible = false;

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                string query1 = "SELECT * FROM UserDetails WHERE email = @SchoolName AND Role = @role";

                SqlCommand cmdd = new SqlCommand(query1, con);
                cmdd.Parameters.AddWithValue("@SchoolName", un);
                cmdd.Parameters.AddWithValue("@role", rl);
                SqlDataReader q1 = cmdd.ExecuteReader();
                q1.Read();

                if (q1.HasRows)
                {
                    uid.Text = q1.GetSqlInt32(0).ToString();
                    TextBox1.Text = q1.GetString(5);
                    TextBox3.Text = q1.GetString(7);
                    if(q1.IsDBNull(8))
                    {
                        TextBox4.Text = "false";
                    }
                    TextBox5.Text = q1.GetValue(9).ToString();
                    //TextBox10.Text = q1.GetString(12);
                    TextBox11.Text = q1.GetString(13);
                    TextBox12.Text = q1.GetString(14);
                    TextBox13.Text = q1.GetString(15);
                    TextBox14.Text = q1.GetValue(16).ToString();
                    TextBox8.Text = q1.GetString(17);
                    
                    con.Close();
                }
                else
                {
                    TextBox1.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox10.Text = "";
                    TextBox11.Text = "";
                    TextBox12.Text = "";
                    TextBox13.Text = "";
                    TextBox14.Text = "";
                    TextBox8.Text = "";
                }

            }
        }

        // on load user data show
        protected void user_u(object sender, EventArgs e)
        {
            //string un = "a@gmail.com";
            //string rl = "User";
            string rl = Session["role"].ToString();
            string un = Session["username"].ToString();

            label1.Text = "User Name: ";
            d8.Visible = false;
            d10.Visible = false;
            d15.Visible = false;

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                string query1 = "SELECT * FROM UserDetails WHERE email = @uname AND Role = @role";

                SqlCommand cmdd = new SqlCommand(query1, con);
                cmdd.Parameters.AddWithValue("@uname", un);
                cmdd.Parameters.AddWithValue("@role", rl);

                SqlDataReader q1 = cmdd.ExecuteReader();
                q1.Read();

                if (q1.HasRows)
                {
                    uid.Text = q1.GetInt32(0).ToString();
                    TextBox1.Text = q1.GetString(2);
                    TextBox2.Text = q1.GetString(3);
                    TextBox3.Text = q1.GetString(7);
                    if(q1.IsDBNull(8))
                    {
                        TextBox4.Text = "false";
                    }
                    TextBox5.Text = q1.GetValue(9).ToString();
                    TextBox6.Text = q1.GetString(10);
                    //date      11
                    TextBox7.Text = q1.GetDateTime(11).ToString();
                    TextBox7.Text = q1.GetValue(11).ToString();
                    TextBox9.Text = q1.GetString(18);
                    //TextBox10.Text = q1.GetString(12);
                    TextBox11.Text = q1.GetString(13);
                    TextBox12.Text = q1.GetString(14);
                    TextBox13.Text = q1.GetString(15);
                    TextBox14.Text = q1.GetValue(16).ToString();

                    con.Close();
                }
                else
                {
                    TextBox1.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox10.Text = "";
                    TextBox11.Text = "";
                    TextBox12.Text = "";
                    TextBox13.Text = "";
                    TextBox14.Text = "";
                    TextBox8.Text = "";
                }

            }
        }

        // on load organization data show
        protected void org_u(object sender, EventArgs e)
        {
            //string un = "arypatel80@gmail.com";
            //string rl = "Organization";
            string un = Session["username"].ToString();
            string rl = Session["role"].ToString();
            label1.Text = "Organizer Name: ";
            d2.Visible = false;
            d6.Visible = false;
            d7.Visible = false;
            d9.Visible = false;
            d10.Visible = false;
            d15.Visible = false;

            using (SqlConnection con = new SqlConnection(constr))
            {
                
                con.Open();

                string query1 = "SELECT * FROM UserDetails where email = @orgname AND Role = @role";

                SqlCommand cmdd = new SqlCommand(query1, con);
                cmdd.Parameters.AddWithValue("@orgname", un);
                cmdd.Parameters.AddWithValue("@role", rl);

                SqlDataReader q1 = cmdd.ExecuteReader();
                q1.Read();

                if (q1.HasRows)
                {
                    
                    uid.Text = q1.GetInt32(0).ToString();
                    TextBox1.Text = q1.GetString(4);
                    TextBox3.Text = q1.GetString(7);
                    
                    if(q1.IsDBNull(8))
                    {
                        TextBox4.Text = "false";
                    }
                    TextBox5.Text = q1.GetSqlValue(9).ToString();
                    //TextBox10.Text = q1.GetString(12);
                    TextBox11.Text = q1.GetString(13);
                    TextBox12.Text = q1.GetString(14);
                    TextBox13.Text = q1.GetString(15);
                    TextBox14.Text = q1.GetSqlValue(16).ToString();
                    TextBox8.Text = q1.GetString(17);

                    con.Close();
                }
                else
                {
                    
                    TextBox1.Text = "";
                    TextBox3.Text = "";
                    TextBox4.Text = "";
                    TextBox5.Text = "";
                    TextBox10.Text = "";
                    TextBox11.Text = "";
                    TextBox12.Text = "";
                    TextBox13.Text = "";
                    TextBox14.Text = "";
                    TextBox8.Text = "";
                }

            }
            
        }

        // save button
        protected void save(object sender, EventArgs e)
        {
            try
            {
                if (Session["role"].Equals("User"))
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        // change in db userdetails
                        con.Open();

                        string query1 = "UPDATE UserDetails SET firstname = @fn, lastname = @ln, phone_no = @phone, gender = @gender, date_of_birth = @dob, state = @state, district = @district, city = @city, pincode = @pincode, department = @department WHERE UserId = @id";

                        SqlCommand c = new SqlCommand(query1, con);
                        c.Parameters.AddWithValue("@fn", TextBox1.Text);
                        c.Parameters.AddWithValue("@ln", TextBox2.Text);
                        c.Parameters.AddWithValue("@phone", TextBox5.Text);
                        c.Parameters.AddWithValue("@gender", TextBox6.Text);
                        c.Parameters.AddWithValue("@dob", TextBox7.Text);
                        c.Parameters.AddWithValue("@department", TextBox9.Text);
                        //c.Parameters.AddWithValue("@country", TextBox10.Text);
                        c.Parameters.AddWithValue("@state", TextBox11.Text);
                        c.Parameters.AddWithValue("@district", TextBox12.Text);
                        c.Parameters.AddWithValue("@city", TextBox13.Text);
                        c.Parameters.AddWithValue("@pincode", TextBox14.Text);
                        c.Parameters.AddWithValue("@id", uid.Text);

                        c.ExecuteNonQuery();

                        con.Close();
                    }
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        // change in db users
                        con.Open();

                        string query2 = "UPDATE Users SET Username = @fn WHERE UserId = @id";
                        SqlCommand cc = new SqlCommand(query2, con);
                        cc.Parameters.AddWithValue("@fn", TextBox1.Text);
                        cc.Parameters.AddWithValue("@id", uid.Text);


                        int rowsAffected = cc.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Account Changed Successfully')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Account Changed Unsuccessfully')</script>");
                        }
                            con.Close();

                    }
                    //Response.Write("<script>alert('Account Changed Successfully')</script>");
                    user_u(sender, e);
                }
                else if (Session["role"].Equals("Organizer"))
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        //change in db userdetails
                        con.Open();

                        string query1 = "UPDATE UserDetails SET orgname = @orgname, phone_no = @phone, address = @address, state = @state, district = @district, city = @city, pincode = @pincode WHERE UserId = @id";

                        SqlCommand cm = new SqlCommand(query1, con);
                        cm.Parameters.AddWithValue("@orgname", TextBox1.Text);
                        cm.Parameters.AddWithValue("@phone", TextBox5.Text);
                        cm.Parameters.AddWithValue("@address", TextBox8.Text);
                        //cm.Parameters.AddWithValue("@country", TextBox10.Text);
                        cm.Parameters.AddWithValue("@state", TextBox11.Text);
                        cm.Parameters.AddWithValue("@district", TextBox12.Text);
                        cm.Parameters.AddWithValue("@city", TextBox13.Text);
                        cm.Parameters.AddWithValue("@pincode", TextBox14.Text);
                        cm.Parameters.AddWithValue("@id", uid.Text);

                        //cm.ExecuteNonQuery();

                        int rowsAffected = cm.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Account Changed Successfully')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Account Changed Unsuccessfully')</script>");
                        }

                        con.Close();
                    }

                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        // change in db users
                        con.Open();

                        string query2 = "UPDATE Users SET Username = @fn WHERE UserId = @id";
                        SqlCommand cmm = new SqlCommand(query2, con);
                        cmm.Parameters.AddWithValue("@fn", TextBox1.Text);
                        cmm.Parameters.AddWithValue("@id", uid.Text);

                        //cmm.ExecuteNonQuery();

                        int rowsAffected = cmm.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Account Changed Successfully')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Account Changed Unsuccessfully')</script>");
                        }

                        con.Close();

                    }

                    //Response.Write("<script>alert('Account Changed Successfully')</script>");
                    org_u(sender, e);

                }
                else if (Session["role"].Equals("School/College"))
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        con.Open();

                        string query1 = "UPDATE UserDetails SET sname = @sname, phone_no = @phone, address = @address, state = @state, district = @district, city = @city, pincode = @pincode WHERE UserId = @id";


                        SqlCommand cmdd = new SqlCommand(query1, con);
                        cmdd.Parameters.AddWithValue("@sname", TextBox1.Text);
                        cmdd.Parameters.AddWithValue("@phone", TextBox5.Text);
                        cmdd.Parameters.AddWithValue("@address", TextBox8.Text);
                        //cmdd.Parameters.AddWithValue("@country", TextBox10.Text);
                        cmdd.Parameters.AddWithValue("@state", TextBox11.Text);
                        cmdd.Parameters.AddWithValue("@district", TextBox12.Text);
                        cmdd.Parameters.AddWithValue("@city", TextBox13.Text);
                        cmdd.Parameters.AddWithValue("@pincode", TextBox14.Text);
                        cmdd.Parameters.AddWithValue("@id", uid.Text);

                        int rowsAffected = cmdd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Account Changed Successfully')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Account Changed Unsuccessfully')</script>");
                        }

                        con.Close();
                    }
                    using (SqlConnection con = new SqlConnection(constr))
                    {
                        // change in db users
                        con.Open();

                        string query2 = "UPDATE Users SET Username = @fn, WHERE UserId = @id";
                        SqlCommand cmd = new SqlCommand(query2, con);
                        cmd.Parameters.AddWithValue("@fn", TextBox1.Text);
                        cmd.Parameters.AddWithValue("@id", uid.Text);

                        //cmd.ExecuteNonQuery();

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            Response.Write("<script>alert('Account Changed Successfully')</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Account Changed Unsuccessfully')</script>");
                        }

                        con.Close();

                    }

                    //Response.Write("<script>alert('Account Changed Successfully')</script>");
                    school(sender, e);
                }
            }
            catch (Exception ex)
            {
                error.Text = ex.Message;
            }
        }

        // email status link button
        protected void emailstatus(object sender, EventArgs e)
        {
            string un = Session["username"].ToString();
            string rl = Session["role"].ToString();

            Random random = new Random();
            int randomNum = random.Next(100000, 1000000);

            using (SqlConnection conn = new SqlConnection(constr))
            {
                conn.Open();
                string query1 = "INSERT INTO otp(Otps, user) values(@otps, @user)";
                SqlCommand cmd = new SqlCommand(query1, conn);
                cmd.Parameters.AddWithValue("@user", un);
                cmd.Parameters.AddWithValue("@otps", randomNum);
                cmd.ExecuteNonQuery();
                conn.Close();
            }

            MailMessage mailMessage = new MailMessage("pikapikapikachu7726@gmail.com", un);
            mailMessage.Subject = "Hello from ASP.NET";
            mailMessage.Body = "This is an automated email sent from ASP.NET." +
                            "welcome to BrainStormer." +
                            "OTP: " + randomNum +
                            "";

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

        // sent otp
        protected void otp(object sender, EventArgs e)
        {
            string un = Session["username"].ToString();
            string rl = Session["role"].ToString();

            using (SqlConnection connn = new SqlConnection(constr))
            {
                connn.Open();

                string query = "SELECT Otps FROM otp WHERE otps = @otp";

                SqlCommand cmdd = new SqlCommand(query, connn);
                cmdd.Parameters.AddWithValue("@otp", textbox15.Text);

                SqlDataReader q1 = cmdd.ExecuteReader();
                q1.Read();

                if (q1.HasRows)
                {
                    using (SqlConnection con = new SqlConnection(constr))
                    {

                        con.Open();

                        string query1 = "UPDATE UserDetails SET email_status = @value WHERE email = @orgname AND Role = @role";

                        SqlCommand cmmd = new SqlCommand(query1, con);
                        cmmd.Parameters.AddWithValue("@orgname", un);
                        cmmd.Parameters.AddWithValue("@role", rl);
                        cmdd.Parameters.AddWithValue("@value", true);

                        cmdd.ExecuteNonQuery();

                        con.Close();
                    }
                }
                else
                {
                    Response.Write("Enter valid otp");
                }
            }
        }
    }
}
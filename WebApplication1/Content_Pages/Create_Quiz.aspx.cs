using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Content_Pages
{
    public partial class Create_Quiz : System.Web.UI.Page
    {
        string constr = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            Session["role"] = "";
            if(!IsPostBack)
            {
                MultiView.ActiveViewIndex = 0;
            }
            
        }

        protected void nextview(object sender, EventArgs e)
        {
            MultiView.ActiveViewIndex = 1;
            D18.Visible = true;
            D17.Visible = false;
        }

        protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
        {

            //Response.Write("<script>alert('Account Changed Unsuccessfully')</script>");
            switch (DropDownList2.SelectedValue)
            {
                case "1":
                    D9.Visible = true;
                    D11.Visible = true;
                    D10.Visible = false;
                    break;

                case "2":
                    D9.Visible = false;
                    D10.Visible = true;
                    D11.Visible = true;
                    break;

                case "3":
                    D9.Visible = false;
                    D10.Visible = true;
                    D11.Visible = true;
                    break;

                case "4":
                    D9.Visible = false;
                    D10.Visible = true;
                    D11.Visible = true;
                    break;

            }
        }

        protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (DropDownList3.SelectedValue)
            {
                case "o1":
                    D12.Visible = true;
                    D13.Visible = true;
                    D14.Visible = false;
                    D15.Visible = false;
                    D16.Visible = false;
                    D17.Visible = true;
                    break;
                case "o2":
                    D12.Visible = true;
                    D13.Visible = true;
                    D14.Visible = true;
                    D15.Visible = true;
                    D16.Visible = false;
                    D17.Visible = true;
                    break;
                case "o3":
                    D12.Visible = true;
                    D13.Visible = true;
                    D14.Visible = true;
                    D15.Visible = true;
                    D16.Visible = true;
                    D17.Visible = true;
                    break;
            }
        }

        protected void Addquestion_Click(object sender, EventArgs e)
        {
            string un = "asd";
            string rl = "User";
            //string un = Session["username"].ToString();
            //string rl = Session["role"].ToString();
            Byte[] data;
            int time = (int.Parse(TextBox3.Text) * 60) + int.Parse(TextBox4.Text);
            if (DropDownList2.SelectedIndex == 2 || DropDownList2.SelectedIndex == 3 || DropDownList2.SelectedIndex == 4)
            {
                HttpPostedFile postfile = file1.PostedFile;
                Stream stream = postfile.InputStream;
                BinaryReader binaryReader = new System.IO.BinaryReader(stream);
                data = binaryReader.ReadBytes((int)stream.Length);

            }
            else
            {
                data = new Byte[0];
            }

            using (SqlConnection con = new SqlConnection(constr))
            {
                con.Open();

                string query = "INSERT INTO Quiz(username, role, quizname, description, subject, time, qtype, qfile, qname, ono, option1, option2, option3, option4, option5, ans) " +
                    "VALUES(@uname, @role, @quizname, @description, @subject, @time, @qtype, @qfile, @qname, @ono, @option1, @option2, @option3, @option4, @option5, @ans)";

                SqlCommand cmdd = new SqlCommand(query, con);
                cmdd.Parameters.AddWithValue("@uname", un);
                cmdd.Parameters.AddWithValue("@role", rl);
                cmdd.Parameters.AddWithValue("@quizname", TextBox1.Text);
                cmdd.Parameters.AddWithValue("@description", TextBox2.Text);
                cmdd.Parameters.AddWithValue("@subject", DropDownList1.SelectedItem.Text);
                cmdd.Parameters.AddWithValue("@time", time);
                cmdd.Parameters.AddWithValue("@qtype", DropDownList2.SelectedItem.Text);
                cmdd.Parameters.AddWithValue("@qfile", data);
                if(DropDownList2.SelectedIndex == 2 || DropDownList2.SelectedIndex == 3 || DropDownList2.SelectedIndex == 4)
                {
                    cmdd.Parameters.AddWithValue("@qname", TextBox6.Text);
                }
                else
                {
                    cmdd.Parameters.AddWithValue("@qname", TextBox5.Text);
                }
                cmdd.Parameters.AddWithValue("@ono", DropDownList3.SelectedItem.Text);
                cmdd.Parameters.AddWithValue("@option1", TextBox7.Text);
                cmdd.Parameters.AddWithValue("@option2", TextBox8.Text);
                cmdd.Parameters.AddWithValue("@option3", TextBox9.Text);
                cmdd.Parameters.AddWithValue("@option4", TextBox10.Text);
                cmdd.Parameters.AddWithValue("@option5", TextBox11.Text);
                cmdd.Parameters.AddWithValue("@ans", TextBox12.Text);

                cmdd.ExecuteNonQuery();
                con.Close();

                DropDownList2.SelectedIndex = 0;
                DropDownList3.SelectedIndex = 0;
                file1.Dispose();
                TextBox5.Text = "";
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox8.Text = "";
                TextBox9.Text = "";
                TextBox10.Text = "";
                TextBox11.Text = "";
                TextBox12.Text = "";
            }


                //Response.Redirect("~/Account/Login.aspx");
        }

        protected void Save_Click(object sender, EventArgs e)
        {
            Response.Redirect("~");
        }

        protected void Unnamed8_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/");
        }
    }
}
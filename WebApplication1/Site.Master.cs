using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Timeout = 120;
            if (Session["role"].Equals(""))
            {
                labelo.Visible = true;
                labels.Visible = true;
                labell.Visible = false;
                user_name.Visible = false;
                labelp.Visible = false;
            }
            else if(Session["role"].Equals("School/College"))
            {
                labelo.Visible = false;
                labels.Visible = false;
                labell.Visible = true;
                user_name.Visible = true;
                labelp.Visible = true;
                user_name.Text = "[ Welcome" + Session["username"].ToString() + " ]";
            }
            else if (Session["role"].Equals("Organizer"))
            {
                labelo.Visible = false;
                labels.Visible = false;
                labell.Visible = true;
                labelp.Visible = true;
                user_name.Visible = true;
                user_name.Text = "[ Welcome" + Session["username"].ToString() + " ]";
            }
            else if (Session["role"].Equals("User"))
            {
                labelo.Visible = false;
                labels.Visible = false;
                labell.Visible = true;
                user_name.Visible = true;
                labelp.Visible = true;
                user_name.Text = "[ Hii" + Session["username"].ToString() + " ]";
            }
            else if (Session["role"].Equals("Admin"))
            {
                labelo.Visible = false;
                labels.Visible = false;
                labell.Visible = true;
                user_name.Visible = true;
                labelp.Visible = false;
                user_name.Text = "Admin";
            }
        }

        protected void loginpage_(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        protected void signup_(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Registration");
        }
        protected void logout_(object sender, EventArgs e)
        {
            Session["role"] = "";
            Session["username"] = "";
            labelo.Visible = true;
            labels.Visible = true;
            labell.Visible = false;
            user_name.Visible = false;
            labelp.Visible = false;
            Response.Redirect("~/Default.aspx");
        }
        protected void homepage_(object sender, EventArgs e)
        {
            //Response.Redirect("~/Default.aspx");
            Response.Redirect("~/Content_Pages/Quiz.aspx");
        }
        protected void aboutpage_(object sender, EventArgs e)
        {
            Response.Redirect("~/About.aspx");
        }
        protected void contactpage_(object sender, EventArgs e)
        {
            Response.Redirect("~/Contact.aspx");
        }
        protected void profile_(object sender, EventArgs e)
        {
            Response.Redirect("~/Account/Profile.aspx");
        }
    }
}
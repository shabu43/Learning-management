using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;

namespace PL
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            LoginDAL course = new LoginDAL();

            course.email = txtEmail.Text;
            course.password = txtPassword.Text;
            


            CourseHandler courseHandler = new CourseHandler();

            if (courseHandler.VerifyUser(course) == true)
            {
                Session["user"] = txtEmail.Text;
                Session["pass"] = txtPassword.Text;
                Response.Redirect("Home.aspx");

            }
            else if (courseHandler.VerifyAdmin(course) == true)
            {
                Session["user"] = txtEmail.Text;
                string id = txtPassword.Text;
                Session["pass"] = txtPassword.Text;

                Response.Redirect("Home.aspx");
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Wrong Email or Password!.')</script>");
            }
        }
    }
}
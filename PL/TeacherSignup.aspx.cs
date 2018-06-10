using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace PL
{
    public partial class TeacherSignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Teacher course = new Teacher();

            course.teacherName= txtName.Text;
            course.email = txtEmail.Text;
            course.password = txtPassword.Text;



            CourseHandler courseHandler = new CourseHandler();

            if (courseHandler.GetAuthorityPassword(course.password) == true)
            {
                if (courseHandler.AddNewTeacher(course) == true)
                {

                    Response.Redirect("Login.aspx");

                }
            }
            else
            {
                Response.Write(@"<script language='javascript'>alert('Wrong Password!.')</script>");
            }
        }
    }
}
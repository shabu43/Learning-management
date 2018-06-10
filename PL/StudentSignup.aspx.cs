using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL
{
    public partial class StudentSignup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            Student course = new Student();

            course.studentName = txtName.Text;
            course.idNumber = txtId.Text;
            course.email = txtEmail.Text;
            course.password = txtPassword.Text;



            CourseHandler courseHandler = new CourseHandler();

           
                if (courseHandler.AddNewStudent(course) == true)
                {

                    Response.Redirect("Login.aspx");

                }
            
        }
    }
}
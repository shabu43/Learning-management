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
    public partial class AddCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null || (string)Session["pass"]!="123")
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Course course = new Course();

           

            Teacher user1 = new Teacher();

          

            
            user1.email = (string)Session["user"];
            user1.password = (string)Session["pass"];

            CourseHandler courseHandler = new CourseHandler();
            CourseDBAccess courseDB = new CourseDBAccess();

           
            courseDB.GetTeacherDetails(user1);

          
                course.teacherID = user1.teacherID;
               
            

            course.courseName = txtCourseName.Text;
            course.courseCode = txtCourseCode.Text;
            course.semester = txtSemester.Text;
            course.year = txtYear.Text;
            course.enrollKey = txtEnrollKey.Text;
            


          

            if (courseHandler.AddNewCourse(course) == true)
            {
                Response.Redirect("Home.aspx");
            }
        }
    }
}
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;

namespace PL
{
    public partial class AddNewNotice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null || (string)Session["pass"] != "123")
            {
                Response.Redirect("Home.aspx");
            }

        }
        protected void btnNotice_Click(object sender, EventArgs e)
        {

            int ad=Convert.ToInt32(Request.QueryString["id"]);
            Notice course = new Notice();

            course.notice = txtCourseCode.Text;
            course.date = txtCourseName.Text;
            course.courseID = Convert.ToInt32(Request.QueryString["id"]);
            


            CourseHandler courseHandler = new CourseHandler();

            if (courseHandler.AddNewNotice(course) == true)
            {
                string adi = Request.QueryString["id"];

                string url = "DetailCourse.aspx?id=" + adi;
                Response.Redirect(url);
                
            }
        }
    }
}
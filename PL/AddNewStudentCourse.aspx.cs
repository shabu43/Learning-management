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
    public partial class AddNewStudentCourse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null )
            {
                Response.Redirect("Home.aspx");
            }
        }

        protected void btnNotice_Click(object sender, EventArgs e)
        {
            int cid = Convert.ToInt32(Request.QueryString["cid"]);
            int sid = Convert.ToInt32(Request.QueryString["sid"]);
          

            CourseHandler courseHandler = new CourseHandler();

            Course course = new Course();
            string ek =txtCourseCode.Text;



            if (courseHandler.AddNewStudentCourse(cid, sid) == true && courseHandler.GetCourseDetails(cid, ek) == true)
            {
                string adi = Request.QueryString["cid"];

                string url = "DetailCourse.aspx?id=" + adi;
                Response.Redirect(url);

            }
        }
    }
}
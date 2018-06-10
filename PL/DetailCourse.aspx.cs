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
    public partial class DetailCourse : System.Web.UI.Page
    {
        
        CourseHandler courseHandler = null;
        protected void Page_Load(object sender, EventArgs e)
        {

         courseHandler = new CourseHandler();
            
             int ccid = Convert.ToInt32(Request.QueryString["id"]);


             if (courseHandler.QuizStat(ccid) == true)
             {

                 Session["setq"] = "1";
             }

            try{
                
            if (!IsPostBack)
            {
                if (Session["user"] == null)
                {
                    Response.Redirect("Home.aspx");
                }
                else
                {
                    int NId = Convert.ToInt32(Request.QueryString["id"]);
                    BindData(NId);
                    BindData1(NId);
                   
                }
            }
            }
            catch{
                throw;
            }

        }
        private void BindData( int NId)
        {
            GridView1.DataSource = courseHandler.GetNotice(NId);
            GridView1.DataBind();


        }
        private void BindData1(int NId)
        {

            GridView2.DataSource = courseHandler.GetDiscussion(NId);
            GridView2.DataBind();


        }
        protected void btnQuiz_Click(object sender, EventArgs e)
        {

            Response.Redirect("Home.aspx");
        }
        protected void btnMark_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }
        protected void btnNotice_Click(object sender, EventArgs e)
        {
            string ad =Request.QueryString["id"];

            string url = "AddNewNotice.aspx?id=" + ad;
          Response.Redirect(url);
        }
         protected void btnPost_Click(object sender, EventArgs e)
        {
            Discussion course = new Discussion();

            Student user = new Student();

            Teacher user1 = new Teacher();
            
            user.studentName = "";
            user.idNumber = "";
            user.email = (string)Session["user"];
            user.password = (string)Session["pass"];

           
            user1.email = (string)Session["user"];
            user1.password = (string)Session["pass"];

            CourseHandler courseHandler = new CourseHandler();
            CourseDBAccess courseDB = new CourseDBAccess();

            courseDB.GetStudentDetails(user);
            courseDB.GetTeacherDetails(user1);

            if (user.studentName != "")
            {
                course.post = txtPost.Text;
                course.name = user.studentName;
                course.email = user.email;
                course.courseID = Convert.ToInt32(Request.QueryString["id"]);

            }
            else
            {
                course.post = txtPost.Text;
                course.name = user1.teacherName;
                course.email = user1.email;
                course.courseID = Convert.ToInt32(Request.QueryString["id"]);
            }
           
                if (courseHandler.AddNewDiscussion(course) == true)
                {
                    int idd = Convert.ToInt32(Request.QueryString["id"]);
                    Response.Redirect("DetailCourse.aspx?id=" + idd);
                }

           
        }
    }
}
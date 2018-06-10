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
    public partial class Authontication : System.Web.UI.Page
    {   

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Login First');window.location ='Home.aspx';", true);
            }

            else
            {
                

                Discussion course = new Discussion();

                Student user = new Student();

               

                user.studentName = "";
                user.idNumber = "";
                user.email = (string)Session["user"];
                user.password = (string)Session["pass"];

               

                CourseHandler courseHandler = new CourseHandler();
                CourseDBAccess courseDB = new CourseDBAccess();

                courseDB.GetStudentDetails(user);
               

                int cId = Convert.ToInt32(Request.QueryString["id"]);
                int SId =user.studentID;

                if (courseHandler.GetStudentCourse(cId, SId) == true || (string)Session["pass"]=="123")
                {
                    Response.Redirect("DetailCourse.aspx?id=" + cId);
                }
                else
                {
                    Response.Redirect("AddNewStudentCourse.aspx?cid=" + cId + "&sid=" + SId);
                    
                }

                




              
              
            }

        }
    }
}
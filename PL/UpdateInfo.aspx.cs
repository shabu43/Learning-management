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
    public partial class UpdateInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["user"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            if ((string)Session["pass"] == "123")
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Under Construction');window.location ='Home.aspx';", true);
            }

            Student user = new Student();



            user.studentName = "";
            user.idNumber = "";
            user.email = (string)Session["user"];
            user.password = (string)Session["pass"];




            CourseHandler courseHandler = new CourseHandler();
            CourseDBAccess courseDB = new CourseDBAccess();

            courseDB.GetStudentDetails(user);



            txtId.Text = user.idNumber;
            txtName.Text = user.studentName;
            txtEmail.Text = user.email;
            txtPassword.Text = user.password;
            int x = Convert.ToInt32(user.studentID);
            ; txtStudentID.Text = x.ToString();




        }
        protected void btnSubmit1_Click(object sender, EventArgs e)
        {
            Student course = new Student();

            course.studentName = txtName.Text;
            course.idNumber = txtId.Text;
            course.email = txtEmail.Text;
            course.password = txtPassword.Text;
            course.studentID = Convert.ToInt32(txtStudentID.Text);


            CourseHandler courseHandler = new CourseHandler();


            if (courseHandler.UpdateStudentInfo(course) == true)
            {

                Response.Redirect("Logout.aspx");

            }

        }
    }
}
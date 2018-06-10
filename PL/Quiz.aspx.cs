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
    public partial class Quiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Home.aspx");
            }
           
            CourseHandler courseHandler = new CourseHandler();
            if (IsPostBack == false)
            {
                BindData();
            }
        }

        private void BindData()
        {

            CourseHandler courseHandler = new CourseHandler();

            Student user = new Student();
            user.studentName = "";
            user.idNumber = "";
            user.email = (string)Session["user"];
            user.password = (string)Session["pass"];
           
            CourseDBAccess courseDB = new CourseDBAccess();

            courseDB.GetStudentDetails(user);

            int cid =Convert.ToInt32(Request.QueryString["id"]);
            int sid = user.studentID;
            int id = 1;
            id = id + 1;
            GridView1.DataSource = courseHandler.GetQuestionList(cid,sid);
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            BindData();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            BindData();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            if (Session["setq"] != null)
            {
                Label lblID = GridView1.Rows[e.RowIndex].FindControl("lblID") as Label;

                TextBox txtLastName = GridView1.Rows[e.RowIndex].FindControl("txtLastName") as TextBox;
                Label lblI1 = GridView1.Rows[e.RowIndex].FindControl("lblI1") as Label;
                Label lblI2 = GridView1.Rows[e.RowIndex].FindControl("lblI2") as Label;
                Label lblI3 = GridView1.Rows[e.RowIndex].FindControl("lblI3") as Label;

                CourseHandler courseHandler = new CourseHandler();

                Student user = new Student();
                user.studentName = "";
                user.idNumber = "";
                user.email = (string)Session["user"];
                user.password = (string)Session["pass"];

                CourseDBAccess courseDB = new CourseDBAccess();

                courseDB.GetStudentDetails(user);

                QuizAns quiz = new QuizAns();

                quiz.courseID = Convert.ToInt32(Request.QueryString["id"]);
                quiz.studentID = user.studentID;
                quiz.questionID = Convert.ToInt32(lblID.Text.Trim());
                quiz.Ans = txtLastName.Text;


                //Let us now update the database
                courseHandler.UpdateQuizAns(quiz);


                //end the editing and bind with updated records.
                GridView1.EditIndex = -1;
                BindData();
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Login First');", true);
            }

         
            
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("AddEmployee.aspx");
        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged2(object sender, EventArgs e)
        {

        }
    }
}
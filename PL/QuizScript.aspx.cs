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
    public partial class QuizScript : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || (string)Session["pass"] != "123")
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

            

            

            int cid = Convert.ToInt32(Request.QueryString["cid"]);
            int sid = Convert.ToInt32(Request.QueryString["sid"]);
            int id = 1;
            id = id + 1;
            GridView1.DataSource = courseHandler.GetQuestionListscript(cid, sid);
            GridView1.DataBind();
        }
    }
}
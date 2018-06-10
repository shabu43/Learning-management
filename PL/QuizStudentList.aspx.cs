using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL
{
    public partial class QuizStudentList : System.Web.UI.Page
    {
       
        CourseHandler courseHandler = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || (string)Session["pass"] != "123" )
             {
                Response.Redirect("Home.aspx");
             }
            courseHandler = new CourseHandler();

            if (!IsPostBack)
            {

               int NId = Convert.ToInt32(Request.QueryString["id"]);
               BindData(NId);     

             }
            
        }
        private void BindData(int NId)
        {
            GridView1.DataSource = courseHandler.GetStudentList(NId);
            GridView1.DataBind();


        }
    }
}
using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL
{
    public partial class EndQuiz : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null || (string)Session["pass"] != "123")
            {
                Response.Redirect("Home.aspx");
            }

            CourseHandler courseHandler = new CourseHandler();

            int cid = Convert.ToInt32(Request.QueryString["id"]);

            courseHandler.EndQuizz(cid);
            Session["setq"] = null;

            Response.Redirect("DetailCourse.aspx?id=" + cid);
        }
    }
}
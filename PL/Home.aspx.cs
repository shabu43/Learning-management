using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DAL;
using BLL;
using System.Data;

namespace PL
{
    public partial class Default : System.Web.UI.Page
    {

        CourseHandler courseHandler = null;
        protected void Page_Load(object sender, EventArgs e)
        {
           
             courseHandler = new CourseHandler();



            try{
            if (!IsPostBack)
            {
                Session["id"]= Session["user"];
                BindData();
            }
            }
            catch{
                throw;
            }
             
       

        }
        private void BindData()
        {
            GridView1.DataSource = courseHandler.GetCourseList();
            GridView1.DataBind();
        }
       
        protected void Calendar1_SelectionChanged(object sender, EventArgs e)
        {

        }
        
    }
}
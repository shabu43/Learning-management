using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PL
{
    public partial class CourseMaterialDownload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null)
            {
                Response.Redirect("Home.aspx");
            }
            int ad = Convert.ToInt16(Request.QueryString["id"]);

            if (!IsPostBack)
            {

                DataTable fileList = FileUtilities1.GetFileList(ad);
                gvFiles.DataSource = fileList;
                gvFiles.DataBind();
            }

            // Get the file id from the query string


            // Get the file from the database
            DataTable file = FileUtilities1.GetAFile(ad);
            DataRow row = file.Rows[0];

            string name = (string)row["Name"];
            string contentType = (string)row["ContentType"];
            Byte[] data = (Byte[])row["Data"];

            // Send the file to the browser
            Response.AddHeader("Content-type", contentType);
            Response.AddHeader("Content-Disposition", "attachment; filename=" + name);
            Response.BinaryWrite(data);
            Response.Flush();
            Response.End();
        }
    }
}
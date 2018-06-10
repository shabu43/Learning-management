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
    public partial class DownloadAssignment : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            int ad = Convert.ToInt16(Request.QueryString["id"]);


            if (Session["user"] == null || (string)Session["pass"] != "123")
            {
                Response.Redirect("Home.aspx");
            }
            if (!IsPostBack)
            {
                
                DataTable fileList = FileUtilities.GetFileList(ad);
                gvFiles.DataSource = fileList;
                gvFiles.DataBind();
            }

            // Get the file id from the query string
           

            // Get the file from the database
            DataTable file = FileUtilities.GetAFile(ad);
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
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
    public partial class AssignmentUpload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int ad = Convert.ToInt32(Request.QueryString["id"]);
           

                if (Session["user"] == null )
                {
                    Response.Redirect("Home.aspx");
                }

                string pass=(string)Session["pass"];
                if(pass == "123")
                {
                    DataTable fileList = FileUtilities.GetFileList(ad);
                    gvFiles.DataSource = fileList;
                    gvFiles.DataBind();
                }
            
        }


        protected void btnUpload_Click(object sender, EventArgs e)
        {
            // Although I put only one http file control on the aspx page,
            // the following code can handle multiple file controls in a single aspx page.
            HttpFileCollection files = Request.Files;
            foreach (string fileTagName in files)
            {
                HttpPostedFile file = Request.Files[fileTagName];
                if (file.ContentLength > 0)
                {
                    // Due to the limit of the max for a int type, the largest file can be
                    // uploaded is 2147483647, which is very large anyway.
                    int size = file.ContentLength;
                    string name = file.FileName;
                    int position = name.LastIndexOf("\\");
                    name = name.Substring(position + 1);
                    string contentType = file.ContentType;
                    byte[] fileData = new byte[size];
                    file.InputStream.Read(fileData, 0, size);
                    int d = Convert.ToInt32(Request.QueryString["id"]);
                    
                    FileUtilities.SaveFile(name,d, contentType, size, fileData);
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Asssignment sent');", true);
                }
            }
            int ad = Convert.ToInt32(Request.QueryString["id"]);
            DataTable fileList = FileUtilities.GetFileList(ad);
            gvFiles.DataSource = fileList;
            gvFiles.DataBind();
        }
    }
}
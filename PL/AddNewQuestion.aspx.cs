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
    public partial class AddNewQuestion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadDropdownList();

            if (Session["user"] == null || (string)Session["pass"] != "123")
            {
                Response.Redirect("Home.aspx");
            }
            else if (Convert.ToInt32(Request.QueryString["qid"]) == 1)
            {

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('Question Saved. Click ok to add another!');", true);

            }
        }

        protected void LoadDropdownList()
        {
            try
            {
                DropDownList1.Items.Add(new ListItem("-select-", "0"));
                DropDownList1.Items.Add(new ListItem("MCQ", "MCQ"));
                DropDownList1.Items.Add(new ListItem("True/False", "True/False"));
                DropDownList1.Items.Add(new ListItem("Short Ques.", "Short Ques"));
            }
            catch
            { }
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            Question ques = new Question();

            ques.QuestionFor = "-Q. " + txtQuestion.Text;
            ques.ChoiceA = "A: " + txtA.Text;
            ques.ChoiceB = "B. "+txtB.Text;
            ques.ChoiceC = "C. " + txtC.Text;
            ques.ChoiceD = "D. " + txtD.Text;
            ques.TeacherAns = txtAns.Text;
            ques.StudentAns = "";
            ques.set = "0";
            ques.courseID = Convert.ToInt32(Request.QueryString["id"]);

            ques.QuestionType = DropDownList1.SelectedValue;

            QuestionHandler quesHandler = new QuestionHandler();

           
            if (quesHandler.AddNewQuestion(ques) == true)
            {

                Response.Redirect("AddNewQuestion.aspx?id=" + Convert.ToInt32(Request.QueryString["id"]) + "&qid=" + 1);
               
            }
           
            
        }
    }
}
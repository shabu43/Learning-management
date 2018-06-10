using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class QuestionHandler
    {
        QuestionDBAccess quesDB = null;

        public QuestionHandler()
        {
            quesDB = new QuestionDBAccess();
        }

        public bool AddNewQuestion(Question ques)
        {
            return quesDB.AddNewQuestion(ques);
        }
    }
}

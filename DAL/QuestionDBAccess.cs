using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DAL
{
    public class QuestionDBAccess
    {
        public bool AddNewQuestion(Question ques)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@question",ques.QuestionFor),
                new SqlParameter("@choiceA",ques.ChoiceA),
                new SqlParameter("@choiceB",ques.ChoiceB),
                new SqlParameter("@choiceC",ques.ChoiceC),
                new SqlParameter("@choiceD",ques.ChoiceD),
                new SqlParameter("@teacherAns",ques.TeacherAns),
                new SqlParameter("@studentAns",ques.StudentAns),
                new SqlParameter("@questionFor",ques.QuestionType),
                new SqlParameter("@set",ques.set),
                 new SqlParameter("@courseID",ques.courseID),
            };
            return SqlDBHelper.ExecuteNonQuery("AddNewQuestion", CommandType.StoredProcedure, parameters);
        }
    }
}

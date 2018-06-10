using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
   public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionFor { get; set; }
        public string ChoiceA { get; set; }
        public string ChoiceB { get; set; }
        public string ChoiceC { get; set; }
        public string ChoiceD { get; set; }
        public string TeacherAns { get; set; }
        public string StudentAns { get; set; }
        public string QuestionType { get; set; }

        public string set { get; set; }

        public int courseID { get; set; }
    }
}

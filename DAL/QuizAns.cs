using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class QuizAns
    {
        public int courseID { get; set; }
        public int studentID { get; set; }
        public int questionID { get; set; }
        public string Ans { get; set; }
       
    }
}

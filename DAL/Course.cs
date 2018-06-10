using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Course
    {
        public int courseID { get; set; }
        public string courseCode { get; set; }
        public string courseName { get; set; }
        public string semester { get; set; }
        public string year { get; set; }
        public string enrollKey { get; set; }


        public int teacherID { get; set; }
    }
}

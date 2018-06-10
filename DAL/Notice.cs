using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class Notice
    {
        public int noticeID { get; set; }
        public string notice { get; set; }
        public string date { get; set; }
        public int courseID { get; set; }
        
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class CourseHandler
    {
         CourseDBAccess courseDB = null;
       

        public CourseHandler()
        {
           
            courseDB = new CourseDBAccess();
        }

        public bool AddNewCourse(Course course)
        {
            return courseDB.AddNewCourse(course);
        }
        public List<Course> GetCourseList()
        {
            return courseDB.GetCourseList();
        }
        public List<Notice> GetNotice(int NId)
        {
            return courseDB.GetNotice(NId);
        }
        public bool AddNewNotice(Notice course)
        {
            return courseDB.AddNewNotice(course);
        }
        public bool AddNewTeacher(Teacher course)
        {
            
            return courseDB.AddNewTeacher(course);
        }


        public bool GetAuthorityPassword(string p)
        {
            return courseDB.GetAuthorityPassword(p);
        }

        public bool AddNewStudent(Student course)
        {
            return courseDB.AddNewStudent(course);
        }

        public bool VerifyUser(LoginDAL course)
        {
            return courseDB.VerifyUser(course);
        }

        public bool VerifyAdmin(LoginDAL course)
        {
            return courseDB.VerifyAdmin(course);
        }

        

        public bool AddNewDiscussion(Discussion course)
        {
            return courseDB.AddNewDiscussion(course);
        }

        public List<Discussion> GetDiscussion(int NId)
        {
            return courseDB.GetDiscussion(NId);
        }

       

        public bool AddNewStudentCourse(int cid, int sid)
        {
            return courseDB.AddNewStudentCourse(cid, sid);
        }

        public bool GetStudentCourse(int cId, int SId)
        {
            return courseDB.GetStudentCourse(cId, SId);
        }


        public List<StudentCourseList> GetStudentList(int NId)
        {
            return courseDB.GetStudentList(NId);
        }
        public bool UpdateStudentInfo(Student course)
        {
            return courseDB.UpdateStudentInfo(course);
        }

        public List<GetQuizQuestion> GetQuestionList(int cid, int sid)
        {
            return courseDB.GetQuestionList(cid, sid);
        }


        public bool UpdateQuizAns(QuizAns quiz)
        {
            return courseDB.UpdateQuizAns(quiz);
        }

        public bool StartQuizz(int cid)
        {
            return courseDB.StartQuizz(cid);
        }

        public object GetQuestionListscript(int cid, int sid)
        {
            return courseDB.GetQuestionListscript(cid, sid);
        }

        public bool EndQuizz(int cid)
        {
            return courseDB.EndQuizz(cid);
        }

        public bool QuizStat(int ccid)
        {
            return courseDB.QuizStat(ccid);
        }

       

        public bool GetCourseDetails(int cid, string ek)
        {
            return courseDB.GetCourseDetails(cid,ek);
        }
    }
}

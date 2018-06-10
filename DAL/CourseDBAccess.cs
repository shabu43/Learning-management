using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;


namespace DAL
{
    public class CourseDBAccess
    {

        
        private static void OpenConnection(SqlConnection connection)
        {
            connection.ConnectionString = "Data Source=MUSHFIQUE;Initial Catalog=ExamSystem;Integrated Security=True";
            connection.Open();
        }


        public bool AddNewCourse(Course course)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@courseCode",course.courseCode),
                new SqlParameter("@courseName",course.courseName),
                new SqlParameter("@semester",course.semester),
                new SqlParameter("@year",course.year),
                new SqlParameter("@enrollKey",course.enrollKey),
                
            };
                if (SqlDBHelper.ExecuteNonQuery("AddNewCourse", CommandType.StoredProcedure, parameters) == true)
                {
                    SqlParameter[] parameters1 = new SqlParameter[]
                     {
                          new SqlParameter("@courseID",course.courseID),
                          new SqlParameter("@teacherID",course.teacherID),
                          
                
            };
                    return SqlDBHelper.ExecuteNonQuery("AddNewTeacherCourse", CommandType.StoredProcedure, parameters1);

                }
                else
                {
                    return false;
                }
            }
            catch
            {
                throw;
            }

        }
        public bool AddNewNotice(Notice notice)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@notice",notice.notice),
                new SqlParameter("@date",notice.date),
                new SqlParameter("@courseID",notice.courseID),
                
                
            };
                return SqlDBHelper.ExecuteNonQuery("AddNewNotice", CommandType.StoredProcedure, parameters);
            }
            catch
            {
                throw;
            }

        }
        public List<Course> GetCourseList()
        {
            List<Course> listCourse = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteSelectCommand("GetCourseList", CommandType.StoredProcedure))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    listCourse = new List<Course>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        Course course = new Course();
                        course.courseID = Convert.ToInt32(row["courseID"]);
                        course.courseCode = row["courseCode"].ToString();
                        course.courseName = row["courseName"].ToString();
                        course.semester = row["semester"].ToString();
                        course.year = row["year"].ToString();
                        course.enrollKey = row["enrollKey"].ToString();


                        listCourse.Add(course);
                    }
                }
            }

            return listCourse;
        }
        public List<Notice> GetNotice(int NId)
        {

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@courseID", NId)
            };

            List<Notice> listNotice = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table1 = SqlDBHelper.ExecuteParamerizedSelectCommand("GetNotice", CommandType.StoredProcedure, parameters))
            {
                //check if any record exist or not
                if (table1.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    listNotice = new List<Notice>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table1.Rows)
                    {
                        Notice course = new Notice();

                        course.notice = row["notice"].ToString();
                        course.date = row["date"].ToString();



                        listNotice.Add(course);
                    }
                }
            }

            return listNotice;
        }
        public bool AddNewTeacher(Teacher course)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@fullName",course.teacherName),
                new SqlParameter("@email",course.email),
                new SqlParameter("@password",course.password),
                
                
            };
                return SqlDBHelper.ExecuteNonQuery("AddNewTeacher", CommandType.StoredProcedure, parameters);
            }
            catch
            {
                throw;
            }

        }

        public SqlParameter[] parameters { get; set; }

        public bool GetAuthorityPassword(string p)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@password", p)
            };

            

            
            using (DataTable table1 = SqlDBHelper.ExecuteParamerizedSelectCommand("GetPassword", CommandType.StoredProcedure, parameters))
            {
                //check if any record exist or not
                if (table1.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

           
        }

        public bool AddNewStudent(Student course)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@fullName",course.studentName),
                new SqlParameter("@IdNumber",course.idNumber),
                new SqlParameter("@email",course.email),
                new SqlParameter("@password",course.password),
                
                
            };
                return SqlDBHelper.ExecuteNonQuery("AddNewStudent", CommandType.StoredProcedure, parameters);
            }
            catch
            {
                throw;
            }
        }

        public bool VerifyUser(LoginDAL course)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@password", course.password),
                new SqlParameter("@email", course.email)
            };




            using (DataTable table1 = SqlDBHelper.ExecuteParamerizedSelectCommand("GetStudentUser", CommandType.StoredProcedure, parameters))
            {
                //check if any record exist or not
                if (table1.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        public bool VerifyAdmin(LoginDAL course)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@password", course.password),
                new SqlParameter("@email", course.email)
            };




            using (DataTable table1 = SqlDBHelper.ExecuteParamerizedSelectCommand("GetTeacherUser", CommandType.StoredProcedure, parameters))
            {
                //check if any record exist or not
                if (table1.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }


        public Student GetStudentDetails(Student user)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@email", user.email),
                new SqlParameter("@password", user.password)
            };

            

            //Lets get the list of all employees in a datataable
            using (DataTable table1 = SqlDBHelper.ExecuteParamerizedSelectCommand("GetStudentDetails", CommandType.StoredProcedure, parameters))
            {
                //check if any record exist or not
                if (table1.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                  

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table1.Rows)
                    {

                        user.studentID = Convert.ToInt32(row["studentID"]);
                        user.studentName = row["fullName"].ToString();
                        user.idNumber = row["IdNumber"].ToString();
                        user.email = row["email"].ToString();
                        user.password = row["password"].ToString();


                       
                    }
                }
            }
            return user;

           
        }

        public Teacher GetTeacherDetails(Teacher user1)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@email", user1.email),
                new SqlParameter("@password", user1.password)
            };



            //Lets get the list of all employees in a datataable
            using (DataTable table1 = SqlDBHelper.ExecuteParamerizedSelectCommand("GetTeacherDetails", CommandType.StoredProcedure, parameters))
            {
                //check if any record exist or not
                if (table1.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees


                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table1.Rows)
                    {

                        user1.teacherID = Convert.ToInt32(row["teacherID"]);
                        user1.teacherName = row["fullName"].ToString();
                        user1.email = row["email"].ToString();
                        user1.password = row["password"].ToString();



                    }
                }
            }
            return user1;

        }

        public bool AddNewDiscussion(Discussion course)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Name",course.name),
                new SqlParameter("@courseID",course.courseID),
                new SqlParameter("@post",course.post),
                new SqlParameter("@email",course.email),
                
                
            };
                return SqlDBHelper.ExecuteNonQuery("AddNewDiscussion", CommandType.StoredProcedure, parameters);
            }
            catch
            {
                throw;
            }
        }

        public List<Discussion> GetDiscussion(int NId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@courseID", NId)
            };

            List<Discussion> listDiscussion = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table1 = SqlDBHelper.ExecuteParamerizedSelectCommand("GetDiscussion", CommandType.StoredProcedure, parameters))
            {
                //check if any record exist or not
                if (table1.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    listDiscussion = new List<Discussion>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table1.Rows)
                    {
                        Discussion course = new Discussion();

                        course.name = row["Name"].ToString();
                        course.courseID = Convert.ToInt32(row["courseID"]);
                        course.post = row["post"].ToString();
                        course.email = row["email"].ToString();


                        listDiscussion.Add(course);
                    }
                }
            }

            return listDiscussion;
        }



       

       

        public bool AddNewStudentCourse(int cid, int sid)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@courseID",cid),
                new SqlParameter("@studentID",sid),
                

            };
                return SqlDBHelper.ExecuteNonQuery("AddNewStudentCourse", CommandType.StoredProcedure, parameters);
            }
            catch
            {
                throw;
            }
        }

        public bool GetStudentCourse(int cId, int SId)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@courseID",cId),
                new SqlParameter("@studentID",SId),
                

            };
                using (DataTable table1 = SqlDBHelper.ExecuteParamerizedSelectCommand("GetStudentCourse", CommandType.StoredProcedure, parameters))
                {
                    //check if any record exist or not
                    if (table1.Rows.Count > 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        public List<StudentCourseList> GetStudentList(int NId)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@courseID", NId)
                
            };


            List<StudentCourseList> user = null;
            //Lets get the list of all employees in a datataable
            using (DataTable table1 = SqlDBHelper.ExecuteParamerizedSelectCommand("GetStudentList", CommandType.StoredProcedure, parameters))
            {
                user = new List<StudentCourseList>();
                //check if any record exist or not
                if (table1.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees


                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table1.Rows)
                    {
                        StudentCourseList course = new StudentCourseList();

                        course.studentID = Convert.ToInt32(row["studentID"]);
                        course.studentName = row["fullName"].ToString(); ;
                        course.idNumber = row["IdNumber"].ToString();
                        course.email = row["email"].ToString();
                        course.password = row["password"].ToString();
                        course.courseID = NId;

                        user.Add(course);

                    }
                }
            }
            return user;
        }

        public bool UpdateStudentInfo(Student course)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                 new SqlParameter("@studentID",course.studentID),
                new SqlParameter("@fullName",course.studentName),
                new SqlParameter("@IdNumber",course.idNumber),
                new SqlParameter("@email",course.email),
                new SqlParameter("@password",course.password),
                
                
            };
                return SqlDBHelper.ExecuteNonQuery("UpdateStudentInfo", CommandType.StoredProcedure, parameters);
            }
            catch
            {
                throw;
            }
        }

        public List<GetQuizQuestion> GetQuestionList(int cid, int sid)
        {

            
                SqlParameter[] parameters = new SqlParameter[]
                 {
                     new SqlParameter("@courseID", cid),
                
                      new SqlParameter("@setq", "1"),                         
                };
           

            List<GetQuizQuestion> listCourse = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("GetQuestionList", CommandType.StoredProcedure, parameters))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    listCourse = new List<GetQuizQuestion>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        GetQuizQuestion course = new GetQuizQuestion();

                        course.QuestionID = Convert.ToInt32(row["questionID"]);
                        course.QuestionFor = row["question"].ToString();
                        course.ChoiceA = row["ChoiceA"].ToString();
                        course.ChoiceB = row["ChoiceB"].ToString();
                        course.ChoiceC = row["ChoiceC"].ToString();
                        course.ChoiceD = row["ChoiceD"].ToString();
                        course.TeacherAns = row["teacherAns"].ToString();
                      

                        DataTable table2 = new DataTable();
                        using (SqlConnection connection = new SqlConnection())
                        {
                            OpenConnection(connection);
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = connection;
                            cmd.CommandTimeout = 0;

                            cmd.CommandText = "SELECT * FROM StudentAns "
                                + "WHERE  courseID=@CID and studentID=@SID and questionID=@QID";
                            cmd.CommandType = CommandType.Text;
                            SqlDataAdapter adapter = new SqlDataAdapter();

                            cmd.Parameters.Add("@CID", SqlDbType.Int);
                            cmd.Parameters.Add("@SID", SqlDbType.Int);
                            cmd.Parameters.Add("@QID", SqlDbType.Int);
                            cmd.Parameters["@CID"].Value = cid;
                            cmd.Parameters["@SID"].Value = sid;
                            cmd.Parameters["@QID"].Value = Convert.ToInt32(row["questionID"]);

                            adapter.SelectCommand = cmd;
                            adapter.Fill(table2);

                            connection.Close();
                        }
                        if (table2.Rows.Count > 0)
                        {
                            foreach (DataRow row1 in table2.Rows)
                            {
                                course.StudentAns = row1["ans"].ToString();
                            }
                        }
                        else
                        {
                            course.StudentAns = "";
                        }
                       
                            course.StudentAnsLabel = "Your Ans: ";
                            course.TeacherAnsLabel = "Student Ans: ";




                            course.QuestionType = "[" + row["questionFor"].ToString() + "]";
                        course.set = row["setq"].ToString();
                        course.courseID = Convert.ToInt32(row["courseID"].ToString());

                       
                        listCourse.Add(course);
                    }
                }
            }

            return listCourse;
        }
        public List<GetQuizQuestion> GetQuestionListscript(int cid, int sid)
        {


            SqlParameter[] parameters = new SqlParameter[]
                 {
                     new SqlParameter("@courseID", cid),
                
                      new SqlParameter("@setq", "0"),                         
                };


            List<GetQuizQuestion> listCourse = null;

            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("GetQuestionList", CommandType.StoredProcedure, parameters))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    //Lets go ahead and create the list of employees
                    listCourse = new List<GetQuizQuestion>();

                    //Now lets populate the employee details into the list of employees
                    foreach (DataRow row in table.Rows)
                    {
                        GetQuizQuestion course = new GetQuizQuestion();

                        course.QuestionID = Convert.ToInt32(row["questionID"]);
                        course.QuestionFor = row["question"].ToString();
                        course.ChoiceA = row["ChoiceA"].ToString();
                        course.ChoiceB = row["ChoiceB"].ToString();
                        course.ChoiceC = row["ChoiceC"].ToString();
                        course.ChoiceD = row["ChoiceD"].ToString();
                        course.TeacherAns = row["teacherAns"].ToString();

                        DataTable table2 = new DataTable();
                        using (SqlConnection connection = new SqlConnection())
                        {
                            OpenConnection(connection);
                            SqlCommand cmd = new SqlCommand();
                            cmd.Connection = connection;
                            cmd.CommandTimeout = 0;

                            cmd.CommandText = "SELECT * FROM StudentAns "
                                + "WHERE  courseID=@CID and studentID=@SID and questionID=@QID";
                            cmd.CommandType = CommandType.Text;
                            SqlDataAdapter adapter = new SqlDataAdapter();

                            cmd.Parameters.Add("@CID", SqlDbType.Int);
                            cmd.Parameters.Add("@SID", SqlDbType.Int);
                            cmd.Parameters.Add("@QID", SqlDbType.Int);
                            cmd.Parameters["@CID"].Value = cid;
                            cmd.Parameters["@SID"].Value = sid;
                            cmd.Parameters["@QID"].Value = Convert.ToInt32(row["questionID"]);

                            adapter.SelectCommand = cmd;
                            adapter.Fill(table2);

                            connection.Close();
                        }
                        if (table2.Rows.Count > 0)
                        {
                            foreach (DataRow row1 in table2.Rows)
                            {
                                course.StudentAns = row1["ans"].ToString();
                            }
                        }
                        else
                        {
                            course.StudentAns = "";
                        }

                        course.StudentAnsLabel = "Your Ans: ";
                        course.TeacherAnsLabel = "Student Ans: ";




                        course.QuestionType = row["questionFor"].ToString();
                        course.set = row["setq"].ToString();
                        course.courseID = Convert.ToInt32(row["courseID"].ToString());


                        listCourse.Add(course);
                    }
                }
            }

            return listCourse;
        }

        public bool UpdateQuizAns(QuizAns quiz)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@courseID",quiz.courseID),
                new SqlParameter("@studentID",quiz.studentID),
                new SqlParameter("@questionID",quiz.questionID),
                new SqlParameter("@Ans",quiz.Ans),
                
                
            };
                if (SqlDBHelper.ExecuteNonQuery("UpdateQuizAns", CommandType.StoredProcedure, parameters) == true)
                {
                    return true;
                }
                else
                {
                    SqlParameter[] parameters1 = new SqlParameter[]
            {
                new SqlParameter("@courseID",quiz.courseID),
                new SqlParameter("@studentID",quiz.studentID),
                new SqlParameter("@questionID",quiz.questionID),
                new SqlParameter("@Ans",quiz.Ans),
                
                
            };
                    return SqlDBHelper.ExecuteNonQuery("AddNewQuizAns", CommandType.StoredProcedure, parameters1);
                }
            }
            catch
            {
                throw;
            }
        }



        public bool StartQuizz(int cid)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@courseID",cid),
                 new SqlParameter("@setq","1"),
              
                

            };
                return SqlDBHelper.ExecuteNonQuery("StartQuiz", CommandType.StoredProcedure, parameters);
            }
            catch
            {
                throw;
            }
        }

        public bool EndQuizz(int cid)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@courseID",cid),
                 new SqlParameter("@setq","0"),
              
                

            };
                return SqlDBHelper.ExecuteNonQuery("StartQuiz", CommandType.StoredProcedure, parameters);
            }
            catch
            {
                throw;
            }
        }

        public bool QuizStat(int ccid)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@courseID", ccid),
                new SqlParameter("@setq", "1"),
               
            };




            using (DataTable table1 = SqlDBHelper.ExecuteParamerizedSelectCommand("QuizStat", CommandType.StoredProcedure, parameters))
            {
                //check if any record exist or not
                if (table1.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        

        public bool GetCourseDetails(int cid, string ek)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@courseID", cid),
                new SqlParameter("@ek", ek),
               
            };



            //Lets get the list of all employees in a datataable
            using (DataTable table = SqlDBHelper.ExecuteParamerizedSelectCommand("GetCourseDetails", CommandType.StoredProcedure, parameters))
            {
                //check if any record exist or not
                if (table.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

        }
    }
    
}

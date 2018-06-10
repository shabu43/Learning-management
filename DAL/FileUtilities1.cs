using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class FileUtilities1
    {
        private static void OpenConnection(SqlConnection connection)
        {
            connection.ConnectionString = "Data Source=MUSHFIQUE;Initial Catalog=ExamSystem;Integrated Security=True";
            connection.Open();
        }

        // Get the list of the Filess in the database
        public static DataTable GetFileList(int ad)
        {
            DataTable fileList = new DataTable();
            using (SqlConnection connection = new SqlConnection())
            {
                OpenConnection(connection);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;


                cmd.CommandText = "SELECT ID, Name, courseID, ContentType, Size FROM CourseMaterial where courseID=" + ad + ";";

                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();

                adapter.SelectCommand = cmd;
                adapter.Fill(fileList);

                connection.Close();
            }

            return fileList;
        }

        // Save a file into the database
        public static void SaveFile(string name, int ad, string contentType,
            int size, byte[] data)
        {
            using (SqlConnection connection = new SqlConnection())
            {
                OpenConnection(connection);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;

                string commandText = "INSERT INTO CourseMaterial (Name, courseID, ContentType, Size, Data) VALUES(@Name, @courseID, @ContentType, @Size, @Data)";
                cmd.CommandText = commandText;
                cmd.CommandType = CommandType.Text;

                cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@courseID", SqlDbType.Int);
                cmd.Parameters.Add("@ContentType", SqlDbType.NVarChar, 50);
                cmd.Parameters.Add("@size", SqlDbType.Int);
                cmd.Parameters.Add("@Data", SqlDbType.VarBinary);

                cmd.Parameters["@Name"].Value = name;
                cmd.Parameters["@courseID"].Value = ad;
                cmd.Parameters["@ContentType"].Value = contentType;
                cmd.Parameters["@size"].Value = size;
                cmd.Parameters["@Data"].Value = data;
                cmd.ExecuteNonQuery();

                connection.Close();
            }
        }

        // Get a file from the database by ID
        public static DataTable GetAFile(int id)
        {
            DataTable file = new DataTable();
            using (SqlConnection connection = new SqlConnection())
            {
                OpenConnection(connection);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandTimeout = 0;

                cmd.CommandText = "SELECT ID, Name, ContentType, Size, Data FROM CourseMaterial "
                    + "WHERE  ID=@ID";
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter adapter = new SqlDataAdapter();

                cmd.Parameters.Add("@ID", SqlDbType.Int);
                cmd.Parameters["@ID"].Value = id;

                adapter.SelectCommand = cmd;
                adapter.Fill(file);

                connection.Close();
            }

            return file;
        }
    }
}

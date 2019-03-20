using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SQLite;
using System.Diagnostics;

namespace _475FinalProject
{
    public partial class UpdateProfile : System.Web.UI.Page
    {
        private int studentID;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "";
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies == null)
            {
                Server.Transfer("Login.aspx");
            }
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version=3;");
            m_dbConnection.Open();


            string User_Name = string.Empty;
            string User_Password = string.Empty;
            User_Name = reqCookies["UserName"].ToString();
            User_Password = reqCookies["Password"].ToString();
            int UW_ID = Int32.Parse(User_Name);

            string sql = "SELECT ID FROM Student WHERE UW_ID = " + UW_ID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            string teststring = "";
            while (reader.Read())
            {
                teststring = teststring + reader["ID"];
            }
            studentID = Int32.Parse(teststring);


            // displaying the table
            sql = "SELECT * FROM Degree;";
            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();
            teststring = "";
            while (reader.Read())
            {
                teststring = teststring + "<br />" + "ID: " + reader["ID"] + "<br />" + "Degree: " + reader["DegreeName"] + "<br />";
            }
            Label1.Text = teststring;
            m_dbConnection.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("AuditDegree.aspx");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Server.Transfer("ReviewProfessor.aspx");
        }

        protected void Button4_Click(object sender, EventArgs e)
        {

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version=3;");
            m_dbConnection.Open();
            string sql = "DELETE FROM Completed_Courses WHERE Student_ID = " + studentID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "DELETE FROM Student WHERE ID = " + studentID + ";";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "DELETE FROM Degree_In_Progress WHERE Student_ID = " + studentID + ";";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();

            sql = "UPDATE Student_Review SET Student_ID = " + 0 + " WHERE Student_ID = " + studentID + ";";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            
            HttpCookie userInfo = HttpContext.Current.Request.Cookies["userInfo"];
            HttpContext.Current.Response.Cookies.Remove("userInfo");
            userInfo.Expires = DateTime.Now.AddDays(-10);
            userInfo.Value = null;
            HttpContext.Current.Response.SetCookie(userInfo);
            m_dbConnection.Close();
            
            Server.Transfer("Login.aspx");
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            if ((TextBox2.Text == String.Empty) || (TextBox3.Text == String.Empty))
            {
                Label2.Text = "Please enter a department and a level";
                return;
            }
            TextBox1.Text = TextBox1.Text.Replace(";", "");
            TextBox2.Text = TextBox2.Text.Replace(";", "");
            TextBox3.Text = TextBox3.Text.Replace(";", "");

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version=3;");
            m_dbConnection.Open();
            // checking class existence
            string sql = "SELECT * FROM Class WHERE Class.Department = '" + TextBox2.Text + "' AND Class.Level = " + TextBox3.Text + ";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count == 0)
            {
                Label2.Text = "Please make sure your department and level are valid";
                return;
            }

            // getting class ID
            SQLiteDataReader reader = command.ExecuteReader();
            string teststring = "";
            while (reader.Read())
            {
                teststring = teststring + reader["ID"];
            }
            int classID = Int32.Parse(teststring);
            sql = "DELETE FROM Completed_Courses WHERE Class_ID = " + classID + ";";
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            TextBox1.Text = TextBox1.Text.Replace(";", "");
            if ((TextBox1.Text == String.Empty))
            {
                Label2.Text = "Please enter a valid course ID";
                return;
            }
            // update degree

            TextBox1.Text = TextBox1.Text.Replace(";", "");
            TextBox2.Text = TextBox2.Text.Replace(";", "");
            TextBox3.Text = TextBox3.Text.Replace(";", "");

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version=3;");
            m_dbConnection.Open();
            string sql = "SELECT * FROM Degree_In_Progress WHERE Student_ID = " + studentID + ";";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            int count = Convert.ToInt32(command.ExecuteScalar());
            if (count == 0)
            {
                sql = "INSERT INTO Degree_In_Progress(Student_ID, Degree_ID, IsComplete) VALUES (" + studentID + "," + TextBox1.Text + "," + 0 + ");";
            }
            else
            {
                sql = "UPDATE Degree_In_Progress SET Degree_ID = " + TextBox1.Text + " WHERE Student_ID = " + studentID + ";";
            }
            command = new SQLiteCommand(sql, m_dbConnection);
            command.ExecuteNonQuery();
            m_dbConnection.Close();
        }
    }
}
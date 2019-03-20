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
    public partial class AuditDegree : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                string User_Name = string.Empty;
                string User_Password = string.Empty;
                User_Name = reqCookies["UserName"].ToString();
                User_Password = reqCookies["Password"].ToString();
                int UW_ID = Int32.Parse(User_Name);

                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version=3;");
                m_dbConnection.Open();

                string sql = "SELECT ID FROM Student WHERE UW_ID = " + UW_ID + ";";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                string teststring = "";
                while (reader.Read())
                {
                    teststring = teststring + reader["ID"];
                }

                int studentID = Int32.Parse(teststring); // Convert UW_ID to Student_ID

                sql = "SELECT Course_Name AS 'Required Course' FROM Degree_Requirement, Class WHERE Degree_ID = 1 AND Degree_Requirement.Class_ID IS NOT NULL AND Degree_Requirement.Class_ID = Class.ID ORDER BY Class.Level ASC;";
                command = new SQLiteCommand(sql, m_dbConnection);
                reader = command.ExecuteReader(); // Creates reader object
                teststring = "";
                while (reader.Read())
                {
                    teststring = teststring + reader["Required Course"] + "<br />";
                }
                Label1.Text = teststring;

                // Query 2: Classification credits
                sql = "SELECT Classification, CreditCount AS 'Credits Needed' FROM Degree_Requirement WHERE Degree_ID = 1 AND Class_ID IS NULL AND Classification IS NOT NULL ORDER BY Classification ASC;";
                command = new SQLiteCommand(sql, m_dbConnection);
                reader = command.ExecuteReader(); // Creates reader object
                teststring = "";
                while (reader.Read())
                {
                    teststring = teststring + reader["Classification"] + ": " + reader["Credits Needed"] + "<br />";
                }
                Label2.Text = teststring;

                // Query 3: CSS Level Courses
                sql = "SELECT (Department || ' ' || Level) AS 'Department and Level', CreditCount AS 'Credits Needed' FROM Degree_Requirement WHERE Degree_ID = 1 AND Class_ID IS NULL AND Classification IS NULL AND Department IS NOT NULL ORDER BY Classification ASC;";
                command = new SQLiteCommand(sql, m_dbConnection);
                reader = command.ExecuteReader();
                teststring = "";
                while (reader.Read())
                {
                    teststring = teststring + reader["Credits Needed"] + " of at least " + reader["Department and Level"] + " level classes" + "<br />";
                }
                Label3.Text = teststring;

                // Query 4: General electives
                sql = "SELECT Level, CreditCount AS 'Credits Needed' FROM Degree_Requirement WHERE Degree_ID = 1 AND Class_ID IS NULL AND Classification IS NULL AND Department IS NULL AND Level IS NOT NULL ORDER BY Classification ASC;";
                command = new SQLiteCommand(sql, m_dbConnection);
                reader = command.ExecuteReader();
                teststring = "";
                while (reader.Read())
                {
                    teststring = teststring + reader["Credits Needed"] + " of at least " + reader["Level"] + " level classes" + "<br />";
                }
                Label4.Text = teststring;

                // Query 5: Total Credits for Graduation
                sql = "SELECT CreditCount AS 'Total Credits for Graduation' FROM Degree_Requirement WHERE Degree_ID = 1 AND Class_ID IS NULL AND Classification IS NULL AND Department IS NULL AND Level IS NULL;";
                command = new SQLiteCommand(sql, m_dbConnection);
                reader = command.ExecuteReader();
                teststring = "";
                while (reader.Read())
                {
                    teststring = teststring + reader["Total Credits for Graduation"] + " total credits for graduation " + "<br />";
                }
                Label5.Text = teststring;

                // Set for student's current progress
                // Query 1: Classes still needed
                sql = "SELECT Class.Course_Name AS 'Required Courses' FROM Class, (SELECT Class_ID FROM Degree_Requirement WHERE Degree_ID = 1 AND Degree_Requirement.Class_ID IS NOT NULL EXCEPT SELECT Class_ID FROM Completed_Courses WHERE Student_ID = " + studentID + ") AS temp WHERE Class.ID = temp.Class_ID ORDER BY Level;";
                command = new SQLiteCommand(sql, m_dbConnection);
                reader = command.ExecuteReader();
                teststring = "";
                while (reader.Read())
                {
                    teststring = teststring + reader["Required Courses"] + "<br />";
                }
                Label6.Text = teststring;

                // Query 2: Current progress towards credit classifications
                sql = "SELECT Classification, SUM(Credits) AS 'Current Credits' FROM Completed_Courses, Class WHERE Completed_Courses.Student_ID = " + studentID + " AND Completed_Courses.Class_ID = Class.ID AND Classification IS NOT NULL GROUP BY Classification;";
                command = new SQLiteCommand(sql, m_dbConnection);
                reader = command.ExecuteReader();
                teststring = "";
                while (reader.Read())
                {
                    teststring = teststring + reader["Classification"] + ": " + reader["Current Credits"] + "<br />";
                }
                Label7.Text = teststring;

                // Query 3: Student's total credits
                sql = "SELECT SUM(Credits) AS 'Your Total Credits' FROM Completed_Courses, Class WHERE Completed_Courses.Student_ID = " + studentID + " AND Completed_Courses.Class_ID = Class.ID;";
                command = new SQLiteCommand(sql, m_dbConnection);
                reader = command.ExecuteReader();
                teststring = "Your Total Credits: ";
                while (reader.Read())
                {
                    teststring = teststring + reader["Your Total Credits"];
                }
                Label8.Text = teststring;

                m_dbConnection.Close();
            }
            else
            {
                Server.Transfer("Login.aspx");
            }
        }
    }
}
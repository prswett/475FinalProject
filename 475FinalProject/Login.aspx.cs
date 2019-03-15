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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/Lecture03 ;Version=3;");
            m_dbConnection.Open();

            string sql = "SELECT * FROM Employee;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/Lecture03 ;Version=3;");
            m_dbConnection.Open();

            if (TextBox1.Text != String.Empty & TextBox2.Text != String.Empty)
            {
                //might not need '' for a number studentID
                string sql = "SELECT * FROM Student WHERE Student.StudentUWID = '" + TextBox1.Text + "' AND Student.Password = '" + TextBox2.Text + "';";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                int count = Convert.ToInt32(command.ExecuteScalar());
                if(count == 0)
                {
                    Label1.Text = "Incorrect Login Please Try Again";
                }
                else
                {
                    HttpCookie userInfo = new HttpCookie("userInfo");
                    userInfo["UserName"] = TextBox1.Text;
                    userInfo["Password"] = TextBox2.Text;
                    userInfo.Expires.Add(new TimeSpan(1, 0, 0));
                    Response.Cookies.Add(userInfo);
                    Server.Transfer("UserHub.aspx");
                }
            }
            else
            {
                Label1.Text = "Incorrect Login Please Try Again";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("Student.aspx");
        }
    }
}
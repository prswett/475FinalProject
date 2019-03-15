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
    public partial class About : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/Lecture03 ;Version=3;");
            m_dbConnection.Open();

            string sql = "SELECT * FROM Employee;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
            SQLiteDataReader reader = command.ExecuteReader();
            string teststring = "";
            while (reader.Read())
            {
                teststring = teststring + "ID: " + reader["Id"] + " name: " + reader["name"] + " phone: " + reader["phone"] + " homePhone: " + reader["homePhone"] + "<br />";
                Debug.WriteLine("ID: " + reader["Id"] + " name: " + reader["name"] + " phone: " + reader["phone"] + " homePhone: " + reader["homePhone"]);
            }
            Label1.Text = teststring;

            /*
            HttpCookie userInfo = new HttpCookie("userInfo");
            userInfo["UserName"] = "Annathurai";
            userInfo["UserColor"] = "Black";
            userInfo.Expires.Add(new TimeSpan(0, 1, 0));
            Response.Cookies.Add(userInfo);
            */
        }



        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/Lecture03 ;Version=3;");
            m_dbConnection.Open();

            if (TextBox1.Text != String.Empty & TextBox2.Text != String.Empty & TextBox4.Text != String.Empty
                & TextBox5.Text != String.Empty & TextBox6.Text != String.Empty & TextBox7.Text != String.Empty)
            {
                string sql = "SELECT * FROM Student WHERE Student.StudentUWID = '" + TextBox1.Text + "' AND Student.Email = '" + TextBox5.Text + "';";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                int count = Convert.ToInt32(command.ExecuteScalar());
                if (count == 0)
                {
                    if (TextBox6.Equals(TextBox7))
                    {
                        string insertSQL = "INSERT into Student (StudentUWID, FirstName, MiddleName, LastName, Email, Password) " +
                            "VALUES (" + TextBox1.Text + ", '" + TextBox2.Text + "','" + TextBox3.Text + "','"
                            + TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "');";
                        SQLiteCommand insertCommand = new SQLiteCommand(insertSQL, m_dbConnection);
                        command.ExecuteNonQuery();
                        HttpCookie userInfo = new HttpCookie("userInfo");
                        userInfo["UserName"] = TextBox1.Text;
                        userInfo["Password"] = TextBox6.Text;
                        userInfo.Expires.Add(new TimeSpan(1, 0, 0));
                        Response.Cookies.Add(userInfo);
                        Server.Transfer("UserHub.aspx");
                    }
                    else
                    {
                        Label1.Text = "Passwords do not match. Please Try Again";
                    }
                }
                else
                {
                    Label1.Text = "Sorry a user with this student ID or Email already exists. Please Try Again";
                }
            }
            else
            {
                Label1.Text = "Incorrect Login Please Try Again";
            }
        }
    }
}
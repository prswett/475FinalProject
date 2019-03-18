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
    public partial class ProfessorInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label2.Text = "";
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies == null)
            {
              Server.Transfer("Login.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version=3;");
            m_dbConnection.Open();

            TextBox1.Text = TextBox1.Text.Replace(";", "");
            TextBox2.Text = TextBox2.Text.Replace(";", "");
            if ((TextBox1.Text != String.Empty) && (TextBox2.Text != String.Empty))
            {
                string sql = "SELECT Professor.FirstName, Professor.LastName, Class.Course_Name, Rating.AvgTeacherScore, Rating.AvgWorkLoadAmount, Rating.AvgGrade, Rating.MostPrevalentStyle_ID, Style.Description FROM Professor, Rating, Class, Style WHERE Professor.FirstName = '" + TextBox1.Text + "' AND Professor.LastName = '" + TextBox2.Text + "' AND Rating.Professor_ID = Professor.ID" + " AND Class.ID = Rating.Class_ID AND Style.ID = Rating.MostPrevalentStyle_ID;";
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                SQLiteDataReader reader = command.ExecuteReader();
                string teststring = "";

                //reader command works like scanner bringing in 1 column at a time
                //while there is a next column with data read it and concatonate it to the already existing string
                while (reader.Read())
                {
                    teststring = teststring + "<br />" + "First Name: " + reader["FirstName"] + "<br />" + " Last Name: " + reader["LastName"] + "<br />"
                        + " Course Name: " + reader["Course_Name"] + "<br />" + " Average Teacher Score: " + reader["AvgTeacherScore"] + "<br />" + " Average Work Load: "
                        + reader["AvgWorkLoadAmount"] + "<br />" + " Average Grade: " + reader["AvgGrade"] + "<br />" + " Most Prevalent Style: " + reader["Description"] + "<br />";
                }
                //set the label on the page equal to the results read in from the query
                Label2.Text = teststring;
                m_dbConnection.Close();
            }
            else
            {
                Label2.Text = "Please enter a First name AND a last name.";
            }
        }
    }
}
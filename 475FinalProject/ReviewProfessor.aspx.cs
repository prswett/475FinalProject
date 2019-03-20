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
    public partial class ReviewProfessor : System.Web.UI.Page
    {
        private int studentID;
        protected void Page_Load(object sender, EventArgs e)
        {
            Label3.Text = "";
            Label4.Text = "";
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies == null)
            {
                //Server.Transfer("Login.aspx");
            }

            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version=3;");
            m_dbConnection.Open();
            /*
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
            studentID = Int32.Parse(teststring);*/

            /*
            // displaying the table
            sql = "SELECT * FROM Style;";
            command = new SQLiteCommand(sql, m_dbConnection);
            reader = command.ExecuteReader();
            teststring = "";

            //reader command works like scanner bringing in 1 column at a time
            //while there is a next column with data read it and concatonate it to the already existing string
            while (reader.Read())
            {
                teststring = teststring + "<br />" + "ID: " + reader["ID"] + "<br />" + "StyleDescription: " + reader["StyleDescription"] + "<br />";
            }
            Label4.Text = teststring;*/
            studentID = 106;
            m_dbConnection.Close();
        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version=3;");
                m_dbConnection.Open();

                TextBox1.Text = TextBox1.Text.Replace(";", "");
                TextBox2.Text = TextBox2.Text.Replace(";", "");
                TextBox3.Text = TextBox3.Text.Replace(";", "");
                TextBox4.Text = TextBox4.Text.Replace(";", "");
                TextBox5.Text = TextBox5.Text.Replace(";", "");
                TextBox7.Text = TextBox7.Text.Replace(";", "");
                TextBox8.Text = TextBox8.Text.Replace(";", "");
                TextBox9.Text = TextBox9.Text.Replace(";", "");
                //if user typed into both of the text boxes 
                if ((TextBox1.Text != String.Empty) && (TextBox2.Text != String.Empty) && (TextBox3.Text != String.Empty) && (TextBox4.Text != String.Empty) && (TextBox5.Text != String.Empty) && (DropDownList1.Text != String.Empty) && (TextBox7.Text != String.Empty) && (TextBox8.Text != String.Empty) && (TextBox9.Text != String.Empty))
                {
                    // checking class existence
                    string sql = "SELECT * FROM Class WHERE Class.Department = '" + TextBox2.Text + "' AND Class.Level = " + TextBox3.Text + ";";
                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count == 0)
                    {
                        Label3.Text = "Please make sure your department and level are valid";
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

                    // checking professor existence
                    sql = "SELECT * FROM Professor WHERE Professor.FirstName = '" + TextBox4.Text + "' AND Professor.LastName = '" + TextBox5.Text + "';";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    count = Convert.ToInt32(command.ExecuteScalar());
                    if (count == 0)
                    {
                        Label3.Text = "Please make sure your Professor first and last names are valid";
                        return;
                    }
                    // getting professor ID
                    reader = command.ExecuteReader();
                    teststring = "";
                    while (reader.Read())
                    {
                        teststring = teststring + reader["ID"];
                    }
                    int professorID = Int32.Parse(teststring);

                    // checking rating existence with professor
                    sql = "SELECT * FROM Rating WHERE CLASS_ID = " + classID + " AND Professor_ID = " + professorID + ";";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    count = Convert.ToInt32(command.ExecuteScalar());

                    // if no rating exists, insert
                    if (count == 0)
                    {
                        sql = "INSERT into Rating (Class_ID, Professor_ID, AvgTeacherScore, AvgWorkLoadAmount, AvgGrade, MostPrevalentStyle_ID) VALUES (" + classID + ", " + professorID + "," + 0 + "," + 0 + "," + 0 + "," + 1 + ");";
                        command = new SQLiteCommand(sql, m_dbConnection);
                        command.ExecuteNonQuery();
                    }

                    // getting ratingID for insert into student Review
                    sql = "SELECT * FROM Rating WHERE Rating.Class_ID = " + classID + " AND Rating.Professor_ID = " + professorID + ";";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    count = Convert.ToInt32(command.ExecuteScalar());
                    if (count == 0)
                    {
                        Label3.Text = "Something went wrong, oops.";
                        return;
                    }
                    reader = command.ExecuteReader();
                    teststring = "";
                    while (reader.Read())
                    {
                        teststring = teststring + reader["ID"];
                    }
                    int ratingID = Int32.Parse(teststring);

                    int styleID = Int32.Parse(DropDownList1.SelectedValue);

                    // Insert into student Review
                    sql = "INSERT into Student_Review (Student_ID, Rating_ID, StyleDescription_ID, TeacherScore, WorkLoadAmount, Grade, Review) " + "VALUES (" + studentID + ", " + ratingID + "," + styleID + ",'" + TextBox7.Text + "','" + TextBox8.Text + "','" + TextBox9.Text + "','" + TextBox1.Text + "');";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();

                    // Insert into Completed Courses
                    sql = "INSERT into Completed_Courses (Student_ID, Class_ID) " + "VALUES (" + studentID + ", " + classID + ");";
                    command = new SQLiteCommand(sql, m_dbConnection);
                    command.ExecuteNonQuery();

                    m_dbConnection.Close();
                    Label3.Text = "Course Added.";
                }
                else
                {
                    Label3.Text = "Please fill out all fields.";
                }
            }
            catch (Exception excp)
            {
                Label3.Text = "Course already exists.";
            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("UserHub.aspx");
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
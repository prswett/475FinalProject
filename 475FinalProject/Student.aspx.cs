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

            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                Server.Transfer("UserHub.aspx");
            }
            
            /*
            //create connection to db
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475Project ;Version=3;");
            m_dbConnection.Open();

            //create sequel query
            string sql = "SELECT * FROM Student;";
            SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

            //execute the reader command
            SQLiteDataReader reader = command.ExecuteReader();
            string teststring = "HI";

            //reader command works like scanner bringing in 1 column at a time
            //while there is a next column with data read it and concatonate it to the already existing string
            while (reader.Read())
            {
                teststring = teststring + "ID: " + reader["ID"] + " UW_ID: " + reader["UW_ID"]
                    + " FirstName: " + reader["FirstName"] + " MiddleName: " + reader["MiddleName"] + " LastName: " 
                    + reader["LastName"] + " Email: " + reader["Email"] + " Password: " + reader["Password"] + "<br />";
            }
            //set the label on the page equal to the results read in from the query
            Label1.Text = teststring;
            m_dbConnection.Close();
            
            //testing to retrieve cookie info from the user
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
            //open db connection 
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version=3;");
            m_dbConnection.Open();

            //check to see if the user typed things into the textboxes
            if (TextBox1.Text != String.Empty && TextBox2.Text != String.Empty && TextBox4.Text != String.Empty
                && TextBox5.Text != String.Empty && TextBox6.Text != String.Empty && TextBox7.Text != String.Empty)
            {

                TextBox1.Text = TextBox1.Text.Replace(";", "");
                TextBox2.Text = TextBox2.Text.Replace(";", "");
                TextBox3.Text = TextBox3.Text.Replace(";", "");
                TextBox4.Text = TextBox4.Text.Replace(";", "");
                TextBox5.Text = TextBox5.Text.Replace(";", "");
                TextBox6.Text = TextBox6.Text.Replace(";", "");
                TextBox7.Text = TextBox7.Text.Replace(";", "");
                //see if the information they typed into the boxes already exists in the db
                //can't have a user with the same uwid or email as someone already in the db
                string sql = "SELECT * FROM Student WHERE Student.UW_ID = " + TextBox1.Text + " OR Student.Email = '" + TextBox5.Text + "';";
 
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                //if there is no one in the db with that information yet
                try
                {

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    if (count == 0)
                    {
                        //check to see if the password and confirm password boxes match
                        if (TextBox6.Text.Equals(TextBox7.Text))
                        {
                            //if they do then insert new user info into the db
                            string insertSQL = "INSERT into Student (UW_ID, FirstName, MiddleName, LastName, Email, Password) " +"VALUES ("  + int.Parse(TextBox1.Text) + ", '" + TextBox2.Text + "','" + TextBox3.Text + "','"+ TextBox4.Text + "','" + TextBox5.Text + "','" + TextBox6.Text + "');";
                            //create command and insert using the execute non query command which is used for data modification
                            SQLiteCommand insertCommand = new SQLiteCommand(insertSQL, m_dbConnection);
                            insertCommand.ExecuteNonQuery();
                            m_dbConnection.Close();
                            
                            
                            HttpCookie userInfo = new HttpCookie("userInfo");
                            userInfo["UserName"] = TextBox1.Text;
                            userInfo["Password"] = TextBox6.Text;
                            userInfo.Expires.Add(new TimeSpan(1, 0, 0));
                            Response.Cookies.Add(userInfo);

                            //transfer then to the userhub page
                            Server.Transfer("UserHub.aspx");
                            
                        }
                        //password and confirm password do not match
                        else
                        {
                            Label1.Text = "Passwords do not match. Please Try Again";
                        }
                    }
                    else
                    //tried to signup with information already in the db
                    {
                        Label1.Text = "Sorry a user with this student ID or Email already exists. Please Try Again";
                    }
                }
                catch (SQLiteException sqle)
                {
                    Label1.Text = "Sorry an error has occured please try again";
                }
            }
            else
            //if the text boxes are empty
            {
                Label1.Text = "Please make sure all text boxes are not empty";
            }
        }
    }
}
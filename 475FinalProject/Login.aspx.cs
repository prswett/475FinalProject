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

            
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                Server.Transfer("UserHub.aspx");
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        //when the login button is clicked
        protected void Button1_Click(object sender, EventArgs e)
        {

            //create object that holds a connection to the db and open it
            SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version=3;");
            m_dbConnection.Open();

            //if user typed into both of the text boxes 
            if (TextBox1.Text != String.Empty && TextBox2.Text != String.Empty)
            {

                //create a query to look for a user in the db with a matching UW ID and Password
                TextBox1.Text = TextBox1.Text.Replace(";", "");
                TextBox2.Text = TextBox2.Text.Replace(";", "");

                string sql = "SELECT * FROM Student WHERE Student.UW_ID = " + TextBox1.Text + " AND Student.Password = '" + TextBox2.Text + "';";
                Label1.Text = sql; 
                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                try
                {
                    //If the amount of results returned is 0 then try again
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count == 0)
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
                catch (SQLiteException sqle)
                {
                    Label1.Text = "Sorry your login information is incorrect please try again";
                }

            }
            //if there is not user text in both textboxes tell them to try again
            else
            {
                Label1.Text = "Incorrect Login Please Try Again";
            }
        }

        //if they click the signup button they will be redirected to the signin page
        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("Student.aspx");
        }
    }
}
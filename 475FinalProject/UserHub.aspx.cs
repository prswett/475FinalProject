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
    public partial class UserHub : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
            string User_name = string.Empty;
            string User_color = string.Empty;
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                User_name = reqCookies["UserName"].ToString();
                User_color = reqCookies["UserColor"].ToString();

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
            }
            */

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
            Server.Transfer("Review.aspx");
            */
        }
    }
}
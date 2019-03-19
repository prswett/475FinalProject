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
            
            
            HttpCookie reqCookies = Request.Cookies["userInfo"];
            if (reqCookies != null)
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version=3;");
                m_dbConnection.Open();

                string User_Name = string.Empty;
                string User_Password = string.Empty;
                User_Name = reqCookies["UserName"].ToString();
                User_Password = reqCookies["Password"].ToString();
                int UW_ID = Int32.Parse(User_Name);

                string sql = "SELECT FirstName, LastName FROM Student WHERE UW_ID = " + UW_ID + ";";

                SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);
                SQLiteDataReader reader = command.ExecuteReader();
                string teststring = "";
                while (reader.Read())
                {
                    teststring = teststring + reader["FirstName"] + " " + reader["LastName"];
                }
                Label1.Text = teststring;
                m_dbConnection.Close();
            }
            else
            {
                Server.Transfer("Login.aspx");
            }
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            
            Server.Transfer("UpdateProfile.aspx");
            
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            
            Server.Transfer("ClassSearch.aspx");
            
        }
    }
}
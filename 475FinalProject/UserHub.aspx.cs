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
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475Project ;Version=3;");
                m_dbConnection.Open();


            }
            else
            {
                Server.Transfer("Login.aspx");
            }
            

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /*
            Server.Transfer("UpdateProfile.aspx");
            */
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            /*
            Server.Transfer("SearchClass.aspx");
            */
        }
    }
}
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
    public partial class Class : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie reqCookies = Request.Cookies["classSelect"];
            if (reqCookies != null)
            {
                try
                {
                    string department = reqCookies["Department"].ToString();
                    int classname;
                    try
                    {
                        classname = Convert.ToInt32(reqCookies["ClassName"]);
                    }
                    catch
                    {
                        classname = 0;
                    }

                    SQLiteConnection connection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version = 3");
                    connection.Open();

                    string output = "SELECT * FROM Class WHERE Class.Department LIKE '" + department +
                        "' AND Class.Level = " + classname;

                    output.Replace(";", " ");
                    output += ";";

                    SQLiteCommand command = new SQLiteCommand(output, connection);

                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count == 0)
                    {
                        Label2.Text = "No results found. Please try again";
                    }
                    else
                    {
                        //print results here
                        SQLiteDataReader reader = command.ExecuteReader();
                        output = "";

                        while (reader.Read())
                        {
                            output += "<b>Class</b>: " + reader["Department"] + " " + reader["Course_Name"] + "<br /><b>Description</b>: " +
                            reader["Description"] + " " + "<br /><b>Credits</b>: " + reader["Credits"] + "<br />";

                        }

                        Label2.Text = output;
                    }
                    connection.Close();
                }
                catch (SQLiteException sqle)
                {
                    Label2.Text = "No results found. Please try again";
                }


            }
            else
            {
                Label2.Text = "No class found";
            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version = 3");
                connection.Open();
                if (TextBox1.Text != String.Empty & TextBox2.Text != String.Empty)
                {
                    string sql = "Select * From Class Where Class.Level = " + TextBox2.Text + " AND Class.Department LIKE '" + TextBox1.Text + "';";

                    SQLiteCommand command = new SQLiteCommand(sql, connection);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count == 0)
                    {
                        Label2.Text = "No class found. Please try again";
                    }
                    else
                    {
                        //print results here
                        SQLiteDataReader reader = command.ExecuteReader();
                        string output = "";

                        while (reader.Read())
                        {
                            output += "<b>Class</b>: " + reader["Department"] + " " + reader["Course_Name"] + "<br /><b>Description</b>: " +
                            reader["Description"] + " " + "<br /><b>Credits</b>: " + reader["Credits"] + "<br />";

                        }

                        Label2.Text = output;
                    }
                }
                else
                {
                    Label2.Text = "Please enter a class department and name";
                }
                connection.Close();
            }
            catch (SQLiteException sqle)
            {
                Label2.Text = "";
            }
        }

        protected void Button2_Click1(object sender, EventArgs e)
        {
            Server.Transfer("ClassSearch.aspx");
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


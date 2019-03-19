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
    public partial class ClassSearch : System.Web.UI.Page
    {
        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection m_dbConnection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version=3;");
                m_dbConnection.Open();

                //Teacher name, attitude, teaching style, overall teacher score, workload, grade, class names, credits, quarter, year
                if (TextBox1.Text != String.Empty || TextBox2.Text != String.Empty || TextBox3.Text != String.Empty || TextBox4.Text != String.Empty || TextBox5.Text != String.Empty ||
                    TextBox6.Text != String.Empty || TextBox7.Text != String.Empty || TextBox8.Text != String.Empty || TextBox9.Text != String.Empty || TextBox10.Text != String.Empty ||
                    TextBox11.Text != String.Empty)
                {

                    //output += "Class: " + reader["Department"] + " " + reader["Level"] + " " + reader["Course_Name"] + " "
                    //+"Professor: " + reader["FirstName"] + " " + reader["Last_Name"] + " "
                    //+ "Avg Grade " + reader["AvgGrade"] + " " + "Avg Work Load " + reader["AvgWorkLoadAmount"] + " "
                    //+ "Teacher Score " + reader["AvgTeacherScore"] + " " + "Teaching Style " + reader["Style.Description"] + " "
                    //+ "Quarter: " + reader["Quarter"] + " " + reader["Year"] + " Credits " + reader["Credits"] + "<br />";


                    /*string sql = "SELECT Class.Department, Class.Level, Class.Course_Name, Professor.FirstName, Professor.LastName, Rating.AvgGrade, " +
                        "Rating.AvgWorkLoadAmount, Rating.AvgTeacherScore, Style.Description AS Style, Class_Information.Quarter, Class_Information.Year, Class.Credits " +
                        "FROM Class, Professor, Rating, Style, Class_Information WHERE Class.ID = Rating.Class_ID AND Professor.ID = Rating.Professor_ID " +
                        "AND Class.ID = Class_Information.Class_ID AND Style.ID = Rating.MostPrevalentStyle_ID ";*/

                    string sql = "SELECT * FROM Class, Professor, Rating, Style, Class_Information WHERE Class.ID = Rating.Class_ID AND Professor.ID = Rating.Professor_ID " +
                        "AND Class.ID = Class_Information.Class_ID AND Style.ID = Rating.MostPrevalentStyle_ID ";

                    string firstname = TextBox1.Text;
                    string lastname = TextBox2.Text;
                    string teachingstyle = TextBox3.Text;
                    int teacherscore = 0;
                    int workload = 0;
                    int grade = 0;
                    int credit = 0;
                    int level = 0;

                    string classname = TextBox7.Text;

                    if (TextBox8.Text != String.Empty)
                    {
                        try
                        {
                            credit = Convert.ToInt32(TextBox8.Text);
                        }
                        catch (Exception error)
                        {
                            credit = 0;
                        }

                    }

                    string quarter = TextBox9.Text;
                    string year = TextBox10.Text;

                    if (firstname != String.Empty)
                    {
                        sql += " AND Professor.FirstName = '" + firstname + "' ";
                    }

                    if (lastname != String.Empty)
                    {
                        sql += " AND Professor.LastName = '" + lastname + "' ";
                    }

                    if (teachingstyle != String.Empty)
                    {
                        sql += " AND Style.Description = '" + teachingstyle + "' ";
                    }

                    if (TextBox4.Text != String.Empty)
                    {
                        try
                        {

                            teacherscore = Convert.ToInt32(TextBox4.Text);
                        }
                        catch (Exception error)
                        {
                            teacherscore = 0;
                        }

                        sql += " AND Rating.AvgTeacherScore >= " + teacherscore + " ";
                    }

                    if (TextBox5.Text != String.Empty)
                    {
                        try
                        {
                            workload = Convert.ToInt32(TextBox5.Text);
                        }
                        catch (Exception error)
                        {
                            workload = 0;
                        }

                        sql += " AND Rating.AvgWorkLoadAmount >= " + workload + " ";
                    }


                    if (TextBox6.Text != String.Empty)
                    {
                        try
                        {
                            grade = Convert.ToInt32(TextBox6.Text);
                        }
                        catch (Exception error)
                        {
                            grade = 0;
                        }
                        sql += " AND Rating.AvgGrade >= " + grade + " ";
                    }

                    if (classname != String.Empty)
                    {
                        sql += "AND Class.Course_Name = '" + classname + "' ";
                    }

                    sql += " AND Class.Credits >= '" + credit + "' ";

                    if (quarter != String.Empty)
                    {
                        sql += " AND Class_Information.Quarter = '" + quarter + "' ";
                    }

                    if (year != String.Empty)
                    {
                        sql += " AND Class_Information.Quarter = '" + year + "' ";
                    }

                    if (TextBox11.Text != String.Empty)
                    {
                        level = Convert.ToInt32(TextBox11.Text);
                        sql += " AND Class.Level = " + level + " ";
                    }
                    sql.Replace(';', ' ');

                    sql += ";";

                    SQLiteCommand command = new SQLiteCommand(sql, m_dbConnection);

                    int count = 0;

                    object result = command.ExecuteScalar();
                    result = (result == DBNull.Value) ? null : result;
                    count = Convert.ToInt32(result);

                    if (count == 0)
                    {
                        Label1.Text = "No results found. Please try again";
                    }
                    else
                    {
                        //print results here
                        SQLiteDataReader reader = command.ExecuteReader();
                        string output = "";

                        while (reader.Read())
                        {
                            output += "<br /><b>Class</b>: " + reader["Department"] + "        " + reader["Level"] + "        " + reader["Course_Name"] + "        "
                                + "<b>Professor</b>: " + reader["FirstName"] + "        " + reader["LastName"] + "        "
                                + "<br />        <b>Avg Grade</b> " + reader["AvgGrade"] + "        " + "<b>Avg Work Load</b> " + reader["AvgWorkLoadAmount"] + "        "
                                + "<b>Teacher Score</b> " + reader["AvgTeacherScore"] + "        " + "<b>Teaching Style</b> " + reader["StyleDescription"] + "         "
                                + "<br />        <b>Quarter</b>: " + reader["Quarter"] + "        " + reader["Year"] + " <b>Credits</b> " + reader["Credits"] + "<br /><br />";

                        }

                        Label1.Text = output;
                    }


                }
                else
                {
                    Label1.Text = "Please fill at least one text box for a search";
                }
                m_dbConnection.Close();
            }
            catch (SQLiteException sqle)
            {
                Label1.Text = "Please enter valid values and try again";
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection connection = new SQLiteConnection("Data Source = |DataDirectory|/475ProjV3.db ;Version = 3");
                connection.Open();
                if (TextBox12.Text != String.Empty & TextBox13.Text != String.Empty)
                {
                    int temp = 0;
                    if (TextBox13.Text != String.Empty)
                    {
                        try
                        {
                            temp = Convert.ToInt32(TextBox13.Text);
                        }
                        catch (Exception error)
                        {
                            temp = 0;
                        }
                    }

                    string sql = "Select * From Class Where Class.Level = " + temp + " AND Class.Department = '" + TextBox12.Text;
                    sql.Replace(';', ' ');
                    sql += "';";

                    SQLiteCommand command = new SQLiteCommand(sql, connection);
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    if (count == 0)
                    {
                        Label2.Text = "No class found. Please try again";
                    }
                    else
                    {
                        HttpCookie classSelect = new HttpCookie("classSelect");
                        classSelect["Department"] = TextBox12.Text;
                        classSelect["ClassName"] = TextBox13.Text;
                        classSelect.Expires.Add(new TimeSpan(1, 0, 0));
                        Response.Cookies.Add(classSelect);
                        connection.Close();
                        Server.Transfer("Class.aspx");

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
                Label2.Text = "Please enter a class department and name";
            }
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox6_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox8_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox9_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox10_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox11_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox12_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox13_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;

namespace WebApplication12
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void login_Click(object sender, EventArgs e)
        {
            string pass = TextBox2.Text.ToString();
            string pri = "";
            string cs = WebConfigurationManager.ConnectionStrings["PP"].ConnectionString;
            SqlConnection con = new SqlConnection(cs);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "select * from password where name = @name";
            cmd.Parameters.AddWithValue("@name", TextBox1.Text.ToString().Trim());
            cmd.Connection = con;
            using (con)
            {
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {

                    pass = Convert.ToString(rd["pass"]);
                    pri = Convert.ToString(rd["privelege"]);
                }
                else
                {
                    error.Text = "Username or Password is incorrect";
                }
            }
            if(pass == TextBox2.Text.ToString())
            {   
                HttpCookie co = new HttpCookie("auth");
                co["random"] = DateTime.Now.GetHashCode().ToString();
                Session["user"] = TextBox1.Text.ToString().Trim();
                Session["cookie"] = co["random"].ToString();
                Session["privelege"] = pri;
                Response.Cookies.Add(co);
                if(pri == "admin")
                {
                    Server.Transfer("companies.aspx");
                }
                else if(pri == "student")
                {
                    Server.Transfer("Profile.aspx");
                }
                else if(pri == "recruiter")
                {
                    Server.Transfer("sel_stu.aspx");
                }
            }
            else
            {
                error.Text = "Username or Password is incorrect";

            }
        }

        protected void signup_Click(object sender, EventArgs e)
        {
            Server.Transfer("Register.aspx");
        }
    }
}
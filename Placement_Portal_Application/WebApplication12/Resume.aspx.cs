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
    public partial class Resume : System.Web.UI.Page
    {
        string cs = WebConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        { HttpCookie co;
            co = Request.Cookies["auth"];
            if (co == null) { Server.Transfer("login.aspx"); }
            if (Session["user"] == null)
            {
                co.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(co);
                Server.Transfer("login.aspx");
            }
            else if (Session["cookie"].ToString() != co["random"].ToString())
            {
                Session.Clear();
                co.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(co);
                Server.Transfer("login.aspx");
            }
            Response.Cookies.Add(co);
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(cs);
                string s = "select * from resume,student where reg_no=@r_no and reg_no=reg_number";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@r_no", Convert.ToInt32(Request.QueryString["reg_no"]));
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    Label11.Text = rd["reg_no"].ToString();
                    Label12.Text = rd["name"].ToString();
                    Label13.Text = rd["branch"].ToString();
                    Label14.Text = rd["email"].ToString();
                    Label15.Text = rd["phone_number"].ToString();
                    TextBox1.Text = rd["cgpa"].ToString();
                    Session["cgpa"] = Convert.ToDecimal(rd["cgpa"].ToString());
                    TextBox2.Text = rd["objective"].ToString();
                    TextBox3.Text = rd["interests"].ToString();
                    TextBox4.Text = rd["Proj_intern"].ToString();
                    TextBox5.Text = rd["refer"].ToString();
                }
                else
                {
                    Session["ul"] = 1;
                    cmd.CommandText = "select * from student where reg_no=@r_no";
                    con.Close();
                    con.Open();
                    rd = cmd.ExecuteReader();
                    if (rd.Read())
                    {
                        Label11.Text = rd["reg_no"].ToString();
                        Label12.Text = rd["name"].ToString();
                        Label13.Text = rd["branch"].ToString();
                        Label14.Text = rd["email"].ToString();
                        Label15.Text = rd["phone_number"].ToString();
                    }
                }
                con.Close();
                if(Session["privelege"].ToString()== "recruiter")
                {
                    TextBox1.Enabled = false;
                    TextBox2.Enabled = false;
                    TextBox3.Enabled = false;
                    TextBox4.Enabled = false;
                    TextBox5.Enabled = false;
                    Button1.Enabled = false;
                    Button1.Visible = false;
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(cs);
            string s1 = "INSERT INTO resume values(@r_no,@a,@b,@c,@d,@e)";
            string s2 = "UPDATE resume set objective = @a,interests = @b,Proj_intern= @c,cgpa = @e,refer = @d where reg_number = @r_no";
            SqlCommand cmd = new SqlCommand(s1, con);
            cmd.Parameters.AddWithValue("@r_no", Convert.ToInt32(Request.QueryString["reg_no"]));
            cmd.Parameters.AddWithValue("@a", TextBox2.Text);
            cmd.Parameters.AddWithValue("@b", TextBox3.Text);
            cmd.Parameters.AddWithValue("@c", TextBox4.Text);
            cmd.Parameters.AddWithValue("@d", TextBox5.Text);
            cmd.Parameters.AddWithValue("@e",Convert.ToDecimal( TextBox1.Text));
            Session["cgpa"] = Convert.ToDecimal(TextBox1.Text.ToString());
            con.Open();
            if (Session["ul"]!=null)
            {
                cmd.ExecuteNonQuery();
                Session["ul"] = null;
            }
            else
            {
                cmd.CommandText = s2;
                cmd.ExecuteNonQuery();
            }
            con.Close();
            Server.Transfer(Request.FilePath);
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Server.Transfer("Profile.aspx");
        }
    }
}
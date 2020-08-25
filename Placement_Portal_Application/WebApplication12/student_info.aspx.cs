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
    public partial class WebForm5 : System.Web.UI.Page
    {
        string cs = WebConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.Visible = false;
            if (!IsPostBack)
            {
                RadioButtonList1.Items.Add("Registration number");
                RadioButtonList1.Items.Add("Student name");
                RadioButtonList1.Items.Add("Branch");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {   
            string s = TextBox1.Text.Trim();
            string s1 = RadioButtonList1.SelectedItem.Text;
            if(s1 == "Registration number")
            {
                SqlConnection con = new SqlConnection(cs);
                string s2 = "select * from student where reg_no = @rno";
                SqlCommand cmd = new SqlCommand(s2, con);
                try
                {
                    cmd.Parameters.AddWithValue("@rno", Convert.ToInt32(s));
                }
                catch(Exception eex)
                {
                    return;
                }
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (!rd.Read())
                {
                    return;
                }
                else
                {
                    GridView1.Visible = true;
                    con.Close();
                    con.Open();
                    rd = cmd.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                }
                con.Close();
            }
            else if(s1 == "Student name")
            {
                SqlConnection con = new SqlConnection(cs);
                string s2 = "select * from student where name LIKE @rno";
                SqlCommand cmd = new SqlCommand(s2, con);
                cmd.Parameters.AddWithValue("@rno", "%" + s + "%");
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (!rd.Read())
                {
                    return;
                }
                else
                {
                    GridView1.Visible = true;
                    con.Close();
                    con.Open();
                    rd = cmd.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                }
                con.Close();
            }
            else if(s1 == "Branch")
            {
                SqlConnection con = new SqlConnection(cs);
                string s2 = "select * from student where branch LIKE @rno";
                SqlCommand cmd = new SqlCommand(s2, con);
                cmd.Parameters.AddWithValue("@rno", "%"+s+"%");
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (!rd.Read())
                {
                    return;
                }
                else
                {
                    GridView1.Visible = true;
                    con.Close();
                    con.Open();
                    rd = cmd.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                }
                con.Close();
            }
        }
    }
}
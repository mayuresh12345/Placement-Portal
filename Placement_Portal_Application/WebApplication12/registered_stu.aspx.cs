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
    public partial class WebForm9 : System.Web.UI.Page
    {
        string cs = WebConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(cs);
                string s = "select student.reg_no RegistrationNumber,student.name Name,branch Branch,email Email,phone_number Ph_no from student,reg_com,company where student.reg_no=reg_com.reg_no and company.company_id=reg_com.company_id and recruiter = @a and pending !=@b and status = @c";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@a", Session["user"].ToString());
                cmd.Parameters.AddWithValue("@b", "Yes");
                cmd.Parameters.AddWithValue("@c", "NA");
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (!rd.Read())
                {
                    return;
                }
                else
                {
                    con.Close();
                    con.Open();
                    rd = cmd.ExecuteReader();
                    GridView1.DataSource = rd;
                    GridView1.DataBind();
                }
                con.Close();
            }
        }
        protected void Update_company(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Update")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                int id = Convert.ToInt32(row.Cells[3].Text);
                SqlConnection con = new SqlConnection(cs);
                string s = "UPDATE reg_com set status=@a where reg_no= @b and company_id=@c";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@a", "selected");
                cmd.Parameters.AddWithValue("@b", id);
                cmd.Parameters.AddWithValue("@c", Convert.ToInt32(Request.QueryString["c_id"]));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Server.Transfer(Request.FilePath);
            }
            else if (e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                int id = Convert.ToInt32(row.Cells[3].Text);
                SqlConnection con = new SqlConnection(cs);
                string s = "UPDATE reg_com set status=@a where reg_no= @b and company_id=@c";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@a", "No");
                cmd.Parameters.AddWithValue("@b", id);
                cmd.Parameters.AddWithValue("@c", Convert.ToInt32(Request.QueryString["c_id"]));
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Server.Transfer(Request.FilePath);
            }
            else if(e.CommandName == "View")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                int id = Convert.ToInt32(row.Cells[3].Text);
                Server.Transfer("~/Resume.aspx?reg_no=" + id.ToString());
            }
        }
    }
}
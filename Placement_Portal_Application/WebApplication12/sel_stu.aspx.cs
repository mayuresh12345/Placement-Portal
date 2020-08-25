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
    public partial class WebForm10 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cs = WebConfigurationManager.ConnectionStrings["PP"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                string s = "select student.reg_no RegistrationNumber,student.name Name,branch Branch,email Email,phone_number Ph_no from student,reg_com,company where student.reg_no=reg_com.reg_no and company.company_id=reg_com.company_id and recruiter = @a and pending !=@b and status = @c";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@a", Session["user"].ToString());
                cmd.Parameters.AddWithValue("@b", "Yes");
                cmd.Parameters.AddWithValue("@c", "selected");
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
    }
}
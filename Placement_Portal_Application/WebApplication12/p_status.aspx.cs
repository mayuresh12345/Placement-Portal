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
    public partial class WebForm6 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cs = WebConfigurationManager.ConnectionStrings["PP"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand();
                string s = "select company.company_id CompanyID,name,status from reg_com,company where reg_no = @r_no and company.company_id=reg_com.company_id";
                cmd.CommandText = "select reg_no from student where name = @name";
                cmd.Parameters.AddWithValue("@name", Session["user"].ToString());
                cmd.Connection = con;
                con.Open();
                int r_no=0;
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    r_no = Convert.ToInt32(rd["reg_no"].ToString());
                }
                con.Close();
                cmd.CommandText = s;
                con.Open();
                cmd.Parameters.AddWithValue("@r_no", r_no);
                rd = cmd.ExecuteReader();              
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
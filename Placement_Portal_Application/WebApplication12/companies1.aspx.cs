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
    public partial class WebForm7 : System.Web.UI.Page
    {
        string cs = WebConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(cs);
                string s = "select company_id,name Company_name,eligibility,job_profile,job_description,offer,compensation,OT_DATE from company where pending != @yes and company_id NOT IN (select company_id from student,reg_com where student.reg_no = reg_com.reg_no and name = @name)";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@yes", "Yes");
                cmd.Parameters.AddWithValue("@name", Session["user"].ToString());
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
                int c_id = Convert.ToInt32(row.Cells[1].Text);
                decimal e1 = Convert.ToDecimal(row.Cells[3].Text);
                if (Convert.ToDecimal(Session["cgpa"].ToString()) < e1)
                {
                    Response.Write("<script>alert('not eligible, Low cgpa!!!')</script>");
                    Server.Transfer(Request.FilePath);
                    return;
                }
                SqlConnection con = new SqlConnection(cs);
                string s = "INSERT INTO reg_com Values(@reg_no,@company_id,@status) ";
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select reg_no from student where name = @name";
                cmd.Parameters.AddWithValue("@name", Session["user"].ToString());
                cmd.Connection = con;
                con.Open();
                int r_no = 0;
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    r_no = Convert.ToInt32(rd["reg_no"].ToString());
                }
                con.Close();
                cmd.CommandText = s;
                cmd.Parameters.AddWithValue("@reg_no",r_no);
                cmd.Parameters.AddWithValue("@company_id", c_id);
                cmd.Parameters.AddWithValue("@status", "NA");
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Successfully Registered!')</script>");
                Server.Transfer(Request.FilePath);
            }
        }
    }    
}
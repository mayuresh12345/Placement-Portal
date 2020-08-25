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
    public partial class WebForm8 : System.Web.UI.Page
    {
        string cs = WebConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SqlConnection con = new SqlConnection(cs);
                string s = "select company.company_id,name Company_name,eligibility,job_profile,job_description,offer,compensation,OT_DATE from company,reg_com where company.company_id = reg_com.company_id and reg_no=@r_no";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@r_no", Convert.ToInt32(Request.QueryString["reg_no"]));
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
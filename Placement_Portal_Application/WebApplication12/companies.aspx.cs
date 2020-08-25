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
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cs = WebConfigurationManager.ConnectionStrings["PP"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                string s = "select name Company_name,eligibility,job_profile,job_description,offer,compensation,OT_DATE from company where pending != @yes";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@yes","Yes");
               
                    con.Open();
                    SqlDataReader rd = cmd.ExecuteReader() ;
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
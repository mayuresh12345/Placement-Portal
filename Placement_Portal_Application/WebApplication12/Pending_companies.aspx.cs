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
    public partial class WebForm3 : System.Web.UI.Page
    {
        string cs = WebConfigurationManager.ConnectionStrings["PP"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {            
            if (!IsPostBack)
            {  
                SqlConnection con = new SqlConnection(cs);
                string s = "select name Company_name,eligibility,job_profile,job_description,offer,compensation,OT_DATE from company where pending = @yes";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@yes", "Yes");
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
            if(e.CommandName == "Update")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string id = row.Cells[2].Text;
                SqlConnection con = new SqlConnection(cs);
                string s = "UPDATE company set pending = @no where name = @id ";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@no", "No");
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Server.Transfer(Request.FilePath);
            }
            else if(e.CommandName == "Delete")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = GridView1.Rows[index];
                string id = row.Cells[2].Text;
                SqlConnection con = new SqlConnection(cs);
                string s = "Delete company where name = @id ";
                SqlCommand cmd = new SqlCommand(s, con);
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                Server.Transfer(Request.FilePath);
            }
        }   
    }
}
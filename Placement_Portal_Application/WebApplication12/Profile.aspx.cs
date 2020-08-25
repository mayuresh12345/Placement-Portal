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
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cs = WebConfigurationManager.ConnectionStrings["PP"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select * from student where name = @name";
                cmd.Parameters.AddWithValue("@name", Session["user"].ToString());
                cmd.Connection = con;
                con.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    reg_no.Text = rd["reg_no"].ToString();
                    name.Text = rd["name"].ToString();
                    email.Text = rd["email"].ToString();
                    branch.Text = rd["branch"].ToString();
                    ph_number.Text = rd["phone_number"].ToString();
                    con.Close();
                }
            }
        }
    }
}
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
    public partial class Site2 : System.Web.UI.MasterPage
    {
        HttpCookie co;
        protected void Page_Load(object sender, EventArgs e)
        {
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
                string cs = WebConfigurationManager.ConnectionStrings["PP"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
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
                HyperLink4.NavigateUrl = "~/reg_companies.aspx?reg_no=" + r_no.ToString();
                HyperLink5.NavigateUrl = "~/Resume.aspx?reg_no=" + r_no.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Clear();
            co = Request.Cookies["auth"];
            co.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(co);
            Server.Transfer("login.aspx");
        }
    }
}
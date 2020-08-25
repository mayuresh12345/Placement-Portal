using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace WebApplication12
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Validate_number(object source, ServerValidateEventArgs e)
        {
            var x = e.Value.Length;
            if (x != 10)
                e.IsValid = false;
            else
                e.IsValid = true;
        }



        protected void Button1_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string cs = WebConfigurationManager.ConnectionStrings["PP"].ConnectionString;
                SqlConnection con = new SqlConnection(cs);
                con.Open();
                SqlCommand cmd = new SqlCommand();

                cmd.Connection = con;
                string pri = "student";
                cmd.CommandText = "INSERT INTO  password VALUES ('" + TextBox2.Text + "','" + TextBox8.Text + "' , '"+ pri +"')";
                cmd.ExecuteNonQuery();
                con.Close();

                con.Open();
                cmd.CommandText = "INSERT INTO student VALUES('" + TextBox1.Text + "', '" + TextBox2.Text + "' ,'" + TextBox6.Text + "','" + TextBox4.Text + "','" + TextBox3.Text + "')";
                cmd.Connection = con;
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('Successfully Registered!')</script>");

            }
           
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }
    }
}
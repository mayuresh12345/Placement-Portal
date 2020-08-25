using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication12
{
    public partial class Site1 : System.Web.UI.MasterPage
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

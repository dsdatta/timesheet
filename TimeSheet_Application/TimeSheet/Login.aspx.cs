using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
namespace TimeSheet
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Label1.Visible = false;                         
                }

      
        protected void createUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateUser.aspx");
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {

            var user = BLL.Login.AuthenticateUser(TextBox1.Text, TextBox2.Text);

            if (user)
            {
                Session["name"] = TextBox1.Text;
                Response.Redirect("MainPage.aspx");
            }
            else
            {
                Label1.Visible = true;
                Label1.Text = "Wrong details";
                Label1.ForeColor = System.Drawing.Color.Red;

            }
        }
    }
}
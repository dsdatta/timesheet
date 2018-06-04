using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TimeSheet
{
    public partial class CreateUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ASPxLabel1.Visible = false;
        }

 

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx");
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ASPxTextBox1.Text != "" && ASPxTextBox2.Text != "" && ASPxTextBox3.Text != "")
            {
                BLL.Login.SaltHash(ASPxTextBox1.Text, ASPxTextBox2.Text);

                ASPxTextBox1.Text = "";
                ASPxTextBox2.Text = "";
                ASPxTextBox3.Text = "";
            }
            else
            {
                ASPxLabel1.Visible = true;
                ASPxLabel1.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
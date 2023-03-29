using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    LOGIN_MST_BAL bal = new LOGIN_MST_BAL();
    LOGIN_MST_DAL dal = new LOGIN_MST_DAL();

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        //if (TextBox1_usernm.Text == "kartik" & TextBox2_upwd.Text == "kartik")
        //{
        //    Response.Redirect("Dashboard.aspx");
        //}
        if (TextBox1_usernm.Text != "" & TextBox2_upwd.Text != "")
        {
            try
            {
                bal.User_Name = TextBox1_usernm.Text;
                bal.User_Pwd = TextBox2_upwd.Text;

                string rvalue = dal.ValidateUser(bal);
                if (rvalue == "Success")
                {
                    string script = "<script type = 'text/javascript'>alert('User Found Successfully!');</script>";
                    Session["user"] = TextBox1_usernm.Text;//store unm in session var and use to display unm on other pages
                    Session["pswd"] = TextBox2_upwd.Text;//store upwd in session var and use to display upwd on other pages
                    Response.Redirect("Dashboard.aspx");
                }
                else
                {
                    string script = "<script type = 'text/javascript'>alert('User Not Found!');</script>";
                    Response.Redirect("Login.aspx");
                }
            }
            catch (Exception ex)
            {
                string script = "<script type = 'text/javascript'>alert('Someting is wrong!');</script>";
            }
        }
        else
        {
            Response.Redirect("Login.aspx");
        }
    }

    protected void TextBox1_usernm_TextChanged(object sender, EventArgs e)
    {

    }
}
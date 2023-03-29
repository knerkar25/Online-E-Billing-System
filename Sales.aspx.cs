using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Sales : System.Web.UI.Page
{
    STD_MST_BAL bal = new STD_MST_BAL();
    STD_MST_DAL dal = new STD_MST_DAL();

    protected void Page_Load(object sender, EventArgs e)
    {
       
        if (IsPostBack == false)
        {
           // lbl_CartItems.Text = Request.QueryString["cnt"];
            Lbl_unm.Text = Session["user"].ToString();
            BindDataList();
            
        }
    }
    public void BindDataList()
    {
        DataTable dt = new DataTable();
        dt = dal.Bindall();
        DataList1.DataSource = dt;
        DataList1.DataBind();
    }
    protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
    {
        //Button b1=(Button)e.Item.FindControl("Btn_addtocart");
        //int pid = Convert.ToInt32(b1.ToolTip.ToString());
        //Response.Redirect("MyCart.aspx?PID=" + pid);    //query string sending id value to mycart page

        if (e.CommandName == "cmdnm_AddToCart")
        {
            //Response.Redirect("MyCart.aspx?id="+e.CommandArgument.ToString());
            try
            {
                int itemid = Convert.ToInt32(e.CommandArgument.ToString());     //itemid
                string username = Session["user"].ToString();                       //username
                string userpswd=Session["pswd"].ToString();                     //userpwd
                string Tdate = DateTime.Today.ToString("dd-MM-yyyy");           //today's date

                string rvalue = dal.InsertToCart(itemid, username,userpswd, Tdate);
                if (rvalue == "Success")
                {
                    string script = "<script type = 'text/javascript'>alert('Item Added To Cart Successfully!');</script>"; }
                else
                {   string script = "<script type = 'text/javascript'>alert('Cannot Insert Item To Cart!');</script>";  }
            }
            catch (Exception ex)
            {
                string script = "<script type = 'text/javascript'>alert('Updated Successfully!');</script>";
            }           
        }
    }

    protected void Imgbtn_cart_Click(object sender, ImageClickEventArgs e)
    {
        Response.Redirect("Cart.aspx");
    }

    protected void Btn_search_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = dal.search_product_Bind(TxtBox_search.Text);
        DataList1.DataSource = dt;
        DataList1.DataBind();
    }

    protected void Btn_clear_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt = dal.Bindall();
        DataList1.DataSource = dt;
        DataList1.DataBind();
    }

    protected void DataList1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
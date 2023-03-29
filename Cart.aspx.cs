using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Cart : System.Web.UI.Page
{
    CART_MST_BAL bal = new CART_MST_BAL();
    CART_MST_DAL dal = new CART_MST_DAL();
    int pid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
            if (IsPostBack == false)
            {
                BindCart();
                lbl_todaysdate.Value= DateTime.Today.ToString("MM/dd/yyyy");
        }
    }
    public void BindCart()
    {
        string unm = Session["user"].ToString(); string upwd = Session["pswd"].ToString();
        DataTable dt = new DataTable();
        dt = dal.BindCart(unm, upwd);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindCart();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd_arg = e.CommandName;
        int pid = Convert.ToInt32(e.CommandArgument);
        string unm = Session["user"].ToString();
        string upswd = Session["pswd"].ToString();
        if (cmd_arg == "del")
        {
            string rvalue = dal.DeleteCartItem(unm, upswd, pid);
            if (rvalue == "Success")
            {
                string script = "<script type='text/javascript'>alert('Success!')</script>";
                GridView1.EditIndex = -1;
                BindCart();
            }
            else
            {
                string script = "<script type='text/javascript'>alert('Error!;')</script>";
                GridView1.EditIndex = -1;
                BindCart();
            }
        }   
        else { }
    }
    protected void btn_continue_Click(object sender, EventArgs e)
    {
        Response.Redirect("Sales.aspx");
    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {}
    protected void ImgBtn_minus_Click(object sender, ImageClickEventArgs e)
    {        
    }
    protected void ImgBtn_plus_Click(object sender, ImageClickEventArgs e)
    {
    }

    protected void btn_checkout_Click(object sender, EventArgs e)
    {
        string unm = Session["user"].ToString(); string upwd = Session["pswd"].ToString();
        try
        {
            //GENERATE ODER TOTAL 
            int Total = GenrateTotal();
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('total purchase of: " + Total + "Rs');", true);
            lbl_total.Text = Total.ToString();
            
            DisableOrderEditing();//DISABLE ORDER EDITING   
            string ordernumber = GenrateOrderNumber(); //GENERATE ORDER NUMBER

            //INSERT USER'S ORDER TO DATABASE 
            //STEP 1.FOR ALL ROWS IN THE GRIDVIEW GET THE VALUES OF THEIR COLUMNS
            for (int i = 0; i < GridView1.Rows.Count; i++)
            {
                bal.Order_No = ordernumber;                                             //ORDER NUMBER               
                bal.PPR = Convert.ToInt32(GridView1.Rows[i].Cells[3].Text);             //PRODUCT PRICE
                bal.PID = Convert.ToInt32(GridView1.Rows[i].Cells[6].Text);             //PRODUCT ID
                bal.User_ID = Convert.ToInt32(GridView1.Rows[i].Cells[7].Text);         //USER ID
                                                                                        //bal.User_Name =unm;
                                                                                        //bal.User_Pwd =upwd;
                TextBox tb = (TextBox)GridView1.Rows[i].FindControl("txtbox_qty");      //PRODUCT QUANTITY
                bal.Quantity = Convert.ToInt32(tb.Text.ToString());

                //STEP 2. INSERT ABOVE VALUES TO DATABASE TABLE: Tbl_Orders
                string rvalue = dal.InsertOrdr(bal);
                if (rvalue == "Success")
                {
                    //Label1.Text = "Record Added Successfully";
                    //Label1.Visible = true;
                    //reset();
                    img_success.Visible = true;
                    Lbl_status.Visible = true;
                    Lbl_status.Text = "Your Order is placed Successfully";
                }
                else
                {
                    Lbl_status.Visible = true;
                    Lbl_status.Text = "Opps!!! something went wrong";
                }
            }
            PrintInvoice(ordernumber, Total);
        }              
        catch (Exception e1)
        {
            Lbl_status.Visible = true;
            Lbl_status.Text = "Opps!!! something went wrong" + e1;
        }      
    }
    public void PrintInvoice(string a,int b)
    {
        Session["Orderno"] = a;
        Session["Total"] = b;
        Response.Redirect("Invoice.aspx");//*****************************************
    }
    public string GenrateOrderNumber()
    {
        Random rand = new Random();
        long randnum2 = (long)(rand.NextDouble() * 9000000000) + 1000000000;
        return randnum2.ToString();
    }
    public Int32 GenrateTotal()
    {
        int Total = 0;
        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            string Price = GridView1.Rows[i].Cells[3].Text;
            TextBox tb = (TextBox)GridView1.Rows[i].FindControl("txtbox_qty");          
            string Qty = tb.Text.ToString();
            Total += Convert.ToInt32(Price) * Convert.ToInt32(Qty);
        }
        return Total;
    }
    public void DisableOrderEditing()
    { GridView1.Enabled = false; }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }

    protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        Session["payment_type"] = RadioButtonList1.SelectedItem.Value;
    }
}
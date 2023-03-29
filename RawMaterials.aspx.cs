using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;

public partial class RawMaterials : System.Web.UI.Page
{
    STD_MST_BAL bal = new STD_MST_BAL();
    STD_MST_DAL dal = new STD_MST_DAL();
    int pid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        //System.Threading.Thread.Sleep(2000);
        if (IsPostBack==false)
        {   BindGrid(); }
    }
    public void BindGrid()
    {
        DataTable dt = new DataTable();
        dt = dal.Bindall();
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Btn_Insert_Click(object sender, EventArgs e)
    {
        try
        {
            bal.PCode=TextBox_pcd.Text;
            bal.PName= TextBox_pnm.Text;
            bal.PPrice=Convert.ToInt32(TextBox_ppr.Text);

            if (FileUpload1.HasFile)
            {
                string fname = FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath("~/product_img/"+fname));
                bal.PImg = "~/product_img/" + fname;
            }

            if (TextBox_pcd.Text == "" || TextBox_pnm.Text == "" || TextBox_ppr.Text == "" || bal.PImg == "")
            { }
            else
            {
            string rvalue = dal.Insert(bal);           
            if (rvalue=="Success")
            {
                Label1.Text = "Record Added Successfully";
                Label1.Visible = true;
                reset();
                BindGrid();
            }
            else
            {
                Label1.Text = "Something Went Wrong";
                Label1.Visible = true;
            }
            }
               
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
            Label1.Visible = true;
        }
    }
    public void reset()
    {
        TextBox_pcd.Text = "";
        TextBox_pnm.Text = "";
        TextBox_ppr.Text = "";    
    }
    protected void Btn_Update_Click(object sender, EventArgs e)
    {    
        try
        {
            int pro_id = Convert.ToInt32(ViewState["PID"]);
            string img = "";
            if (FileUpload1.HasFile)
            {
                string fname = FileUpload1.FileName;
                FileUpload1.SaveAs(Server.MapPath("~/product_img/" + fname));
                img = "~/product_img/" + fname;
            }
            if (TextBox_pcd.Text == "" || TextBox_pnm.Text == "" || TextBox_ppr.Text == "" || img == "")
            { }
            else
            {
            string rvalue = dal.Update(pro_id, TextBox_pcd.Text, TextBox_pnm.Text, Convert.ToInt32(TextBox_ppr.Text), img);

            if (rvalue == "Success")
            {
                Label1.Text = "Record Updated Successfully";
                Label1.Visible = true;
                reset();
                BindGrid();
                Btn_Insert.Visible = true;
            }
            else
            {
                Label1.Text = "Something Went Wrong";
                Label1.Visible = true;
            }
            }
            
        }
        catch (Exception ex)
        {
            Label1.Text = ex.Message;
            Label1.Visible = true;
        }
    }
    protected void Btn_Reset_Click(object sender, EventArgs e)
    {
        reset();
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.BindGrid();
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        string cmd_arg = e.CommandName;
        ViewState["PID"] = Convert.ToInt32(e.CommandArgument);
        pid = Convert.ToInt32(e.CommandArgument);

        if (cmd_arg == "edt")
        {
            Btn_Insert.Visible = false;

            GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            string prod_code = row.Cells[2].Text;
            string prod_name = row.Cells[3].Text;
            string prod_price = row.Cells[4].Text;

            ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Code: " + prod_code +
            "\\nName: " + prod_name + "\\nprice: " + prod_price + "');", true);

            TextBox_pcd.Text = prod_code;
            TextBox_pnm.Text = prod_name;
            TextBox_ppr.Text = prod_price;

            
        }
        else if (cmd_arg == "del")
        {
            string result = dal.Delete(pid);
            if (result == "Success")
            {

                string script = "<script type = 'text/javascript'>alert('Deleted Successfully!');</script>";
                GridView1.EditIndex = -1;
                BindGrid();
            }
            else
            {
                string script = "<script type = 'text/javascript'>alert('Error!');</script>";
                GridView1.EditIndex = -1;
                BindGrid();

            }
        }
    }

    protected void TextBox_pcd_TextChanged(object sender, EventArgs e)
    {

    }
}
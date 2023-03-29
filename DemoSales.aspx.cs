using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DemoSales : System.Web.UI.Page
{
    STD_MST_BAL bal = new STD_MST_BAL();
    STD_MST_DAL dal = new STD_MST_DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        { BindDataList(); }
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

    }
}
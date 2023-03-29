using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iTextSharp.text;
using iTextSharp.text.html.simpleparser;
using iTextSharp.text.pdf;

using System.Data.SqlClient;



public partial class Invoice : System.Web.UI.Page
{
    CART_MST_DAL dal = new CART_MST_DAL();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack == false)
        {
            Lbl_orderno.Text = Session["Orderno"].ToString();
            Lbl_date.Text = DateTime.Today.ToString("MM/dd/yyyy");
            Lbl_total.Text = Session["Total"].ToString();
            Lbl_paytyp.Text = Session["payment_type"].ToString();
            BindOrder();
            
        }      
    }
    public void BindOrder()
    {
       
        DataTable dt = new DataTable();
        dt = dal.BindOrder(Lbl_orderno.Text);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }
    protected void Btb_printInvoice_Click(object sender, EventArgs e)
    {

    }

    protected void Btn_PDF_Click(object sender, EventArgs e)
    {
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("content-disposition", "attachment;filename=GridViewData.pdf");
        //Response.Cache.SetCacheability(HttpCacheability.NoCache);
        //StringWriter sw = new StringWriter();
        //HtmlTextWriter hw = new HtmlTextWriter(sw);
        //Panel1.RenderControl(hw);
        //StringReader sr = new StringReader(sw.ToString());
        //Document pdfDoc = new Document(PageSize.A4, 10, 10, 0, 0);
        //HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        //PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        //pdfDoc.Open();
        //htmlparser.Parse(sr);
        //pdfDoc.Close();
        //Response.Write(pdfDoc);
        //Response.End();

        Response.Clear();
        //this clears the Response of any headers or 
    
        //ma
        Response.ContentType = "application/pdf";

        Response.AddHeader("content-disposition", "attachment;filename=DataTable.pdf");
        Response.Cache.SetCacheability(HttpCacheability.NoCache);

        StringWriter sw = new StringWriter();

        HtmlTextWriter hw = new HtmlTextWriter(sw);
        GridView1.RenderControl(hw);
        StringReader sr = new StringReader(sw.ToString());
        Document pdfDoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);


        HTMLWorker htmlparser = new HTMLWorker(pdfDoc);
        PdfWriter.GetInstance(pdfDoc, Response.OutputStream);
        pdfDoc.Open();
        htmlparser.Parse(sr);
        pdfDoc.Close();
        Response.Write(pdfDoc);
        Response.End();
    }
    public override void VerifyRenderingInServerForm(Control control)
    {
        /* Verifies that the control is rendered */
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
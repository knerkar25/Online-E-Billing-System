using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default_dynamic_row : System.Web.UI.Page
{
    //public string con = ConfigurationManager.ConnectionStrings["OnlineInvoiceBillingSystem1ConnectionString"].ConnectionString;
    //SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            ViewState["PreviousTable"] = null;
            SetInitialRow();
        }
    }
    private void SetInitialRow()
    {
        DataTable dt = new DataTable();
        DataRow dr = null;
        dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

        dt.Columns.Add(new DataColumn("Column1", typeof(string)));
        dt.Columns.Add(new DataColumn("Column2", typeof(string)));
        dt.Columns.Add(new DataColumn("Column3", typeof(string)));

        dt.Columns.Add(new DataColumn("Column4", typeof(string)));
        dt.Columns.Add(new DataColumn("Column5", typeof(string)));
        dt.Columns.Add(new DataColumn("Column6", typeof(string)));

        dr = dt.NewRow();

        dr["Column1"] = string.Empty;
        dr["Column2"] = string.Empty;
        dr["Column3"] = string.Empty;

        dr["Column4"] = "Qualification";
        dr["Column5"] = "Branch";
        dr["Column6"] = "Batch";

        dt.Rows.Add(dr);
        //dr = dt.NewRow();
        //Store the DataTable in ViewState

        ViewState["CurrentTable"] = dt;
        Gridview1.DataSource = dt;
        Gridview1.DataBind();
    }

    private void SetPreviousDB()
    {
        int rowIndex = 0;
        if (ViewState["PreviousTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["PreviousTable"];
            if (dt.Rows.Count > 0)
            {
                Response.Write(Gridview1.Rows.Count);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox1");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox2");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox3");

                    Label lbl4 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("Label1");
                    Label lbl5 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("Label2");
                    Label lbl6 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("Label3");

                    box1.Text = dt.Rows[i]["qualification"].ToString();
                    box2.Text = dt.Rows[i]["batch"].ToString();
                    box3.Text = dt.Rows[i]["branch"].ToString();

                    lbl4.Text = "Qualification";
                    lbl5.Text = "Branch";
                    lbl6.Text = "Batch";

                    rowIndex++;
                }
            }
        }
        DataTable dt1 = (DataTable)ViewState["PreviousTable"];
        if (dt1.Rows.Count > 1)
        {
            //GridView1.FooterRow.FindControl("txtFooter1") as TextBox;
            LinkButton LinkButton1 = Gridview1.FooterRow.FindControl("LinkButton1") as LinkButton;
            LinkButton1.Visible = true;
        }
    }
    private void SetPreviousData()
    {
        int rowIndex = 0;
        if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox1");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox2");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox3");

                    Label lbl4 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("Label1");
                    Label lbl5 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("Label2");
                    Label lbl6 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("Label3");

                    box1.Text = dt.Rows[i]["Column1"].ToString();
                    box2.Text = dt.Rows[i]["Column2"].ToString();
                    box3.Text = dt.Rows[i]["Column3"].ToString();

                    lbl4.Text = "Qualification";
                    lbl5.Text = "Branch";
                    lbl6.Text = "Batch";

                    rowIndex++;
                }
            }
        }
        DataTable dt1 = (DataTable)ViewState["CurrentTable"];
        if (dt1.Rows.Count > 1)
        {
            //GridView1.FooterRow.FindControl("txtFooter1") as TextBox;
            LinkButton LinkButton1 = Gridview1.FooterRow.FindControl("LinkButton1") as LinkButton;
            LinkButton1.Visible = true;
        }
    }
    private void AddNewRowToGrid()
    {
        int rowIndex = 0;

        if (ViewState["PreviousTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["PreviousTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox1");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox2");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox3");

                    Label lbl4 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("Label1");
                    Label lbl5 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("Label2");
                    Label lbl6 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("Label3");

                    drCurrentRow = dtCurrentTable.NewRow();

                    dtCurrentTable.Rows[i - 1]["qualification"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["batch"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["branch"] = box3.Text;

                    dtCurrentTable.Rows[i - 1]["qualification1"] = "Qualification";
                    dtCurrentTable.Rows[i - 1]["batch1"] = "Branch";
                    dtCurrentTable.Rows[i - 1]["branch1"] = "Batch";

                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["PreviousTable"] = dtCurrentTable;

                Gridview1.DataSource = dtCurrentTable;
                Gridview1.DataBind();
                SetPreviousDB();
            }
        }
        else if (ViewState["CurrentTable"] != null)
        {
            DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
            DataRow drCurrentRow = null;
            if (dtCurrentTable.Rows.Count > 0)
            {
                for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                {
                    //extract the TextBox values
                    TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox1");
                    TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox2");
                    TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("TextBox3");

                    Label lbl4 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("Label1");
                    Label lbl5 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("Label2");
                    Label lbl6 = (Label)Gridview1.Rows[rowIndex].Cells[0].FindControl("Label3");

                    drCurrentRow = dtCurrentTable.NewRow();

                    dtCurrentTable.Rows[i - 1]["Column1"] = box1.Text;
                    dtCurrentTable.Rows[i - 1]["Column2"] = box2.Text;
                    dtCurrentTable.Rows[i - 1]["Column3"] = box3.Text;

                    dtCurrentTable.Rows[i - 1]["Column4"] = "Qualification";
                    dtCurrentTable.Rows[i - 1]["Column5"] = "Branch";
                    dtCurrentTable.Rows[i - 1]["Column6"] = "Batch";

                    rowIndex++;
                }
                dtCurrentTable.Rows.Add(drCurrentRow);
                ViewState["CurrentTable"] = dtCurrentTable;

                Gridview1.DataSource = dtCurrentTable;
                Gridview1.DataBind();
                //Set Previous Data on Postbacks
                SetPreviousData();
            }
        }
        else
        {
            Response.Write("ViewState is null");
        }
    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {
        AddNewRowToGrid();
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        LinkButton lb = (LinkButton)sender;
        GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
        int rowID = gvRow.RowIndex + 1;
        if (ViewState["PreviousTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["PreviousTable"];
            if (dt.Rows.Count > 1)
            {
                if (gvRow.RowIndex < dt.Rows.Count - 1)
                {
                    //Remove the Selected Row data
                    dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
                }
            }
            ViewState["PreviousTable"] = dt;
            //Re bind the GridView for the updated data
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
            int rowIndex = 0;
            foreach (GridViewRow row in Gridview1.Rows)
            {
                TextBox TextBox1 = row.FindControl("TextBox1") as TextBox;
                TextBox TextBox2 = row.FindControl("TextBox2") as TextBox;
                TextBox TextBox3 = row.FindControl("TextBox3") as TextBox;

                TextBox1.Text = dt.Rows[rowIndex]["qualification"].ToString();
                TextBox2.Text = dt.Rows[rowIndex]["batch"].ToString();
                TextBox3.Text = dt.Rows[rowIndex]["branch"].ToString();
                rowIndex++;
            }
            if (dt.Rows.Count > 1)
            {
                LinkButton LinkButton1 = Gridview1.FooterRow.FindControl("LinkButton1") as LinkButton;
                LinkButton1.Visible = true;
            }
        }
        else if (ViewState["CurrentTable"] != null)
        {
            DataTable dt = (DataTable)ViewState["CurrentTable"];
            if (dt.Rows.Count > 1)
            {
                if (gvRow.RowIndex < dt.Rows.Count - 1)
                {
                    //Remove the Selected Row data
                    dt.Rows.Remove(dt.Rows[dt.Rows.Count - 1]);
                }
            }
            ViewState["CurrentTable"] = dt;
            //Re bind the GridView for the updated data
            Gridview1.DataSource = dt;
            Gridview1.DataBind();
            int rowIndex = 0;
            foreach (GridViewRow row in Gridview1.Rows)
            {
                TextBox TextBox1 = row.FindControl("TextBox1") as TextBox;
                TextBox TextBox2 = row.FindControl("TextBox2") as TextBox;
                TextBox TextBox3 = row.FindControl("TextBox3") as TextBox;

                TextBox1.Text = dt.Rows[rowIndex]["Column1"].ToString();
                TextBox2.Text = dt.Rows[rowIndex]["Column2"].ToString();
                TextBox3.Text = dt.Rows[rowIndex]["Column3"].ToString();
                rowIndex++;
            }
            if (dt.Rows.Count > 1)
            {
                LinkButton LinkButton1 = Gridview1.FooterRow.FindControl("LinkButton1") as LinkButton;
                LinkButton1.Visible = true;
            }
        }
    }
    //protected void btnsaveinfo_Click(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow row in Gridview1.Rows)
    //    {
    //        TextBox TextBox1 = row.FindControl("TextBox1") as TextBox;
    //        TextBox TextBox2 = row.FindControl("TextBox2") as TextBox;
    //        TextBox TextBox3 = row.FindControl("TextBox3") as TextBox;

    //        con.Open();
    //        cmd.Connection = con;
    //        cmd.CommandType = CommandType.Text;
    //        cmd.CommandText = "insert into qualification values('" + TextBox1.Text + "','" + TextBox2.Text + "','" + TextBox3.Text + "') ";
    //        cmd.ExecuteNonQuery();
    //        con.Close();
    //    }
    //    BindGrid();
    //}
    //private void BindGrid()
    //{
    //    DataTable dt = new DataTable();
    //    con.Open();
    //    cmd.Connection = con; ;
    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = "select * from qualification";
    //    cmd.ExecuteNonQuery();
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);

    //    da.Fill(dt);

    //    if (dt.Rows.Count > 0)
    //    {
    //        gvqualification.DataSource = dt;
    //        gvqualification.DataBind();
    //    }
    //    else
    //    {
    //        gvqualification.DataSource = null;
    //        gvqualification.DataBind();
    //    }
    //    con.Close();
    //}
    //protected void lnkshowall_Click(object sender, EventArgs e)
    //{
    //    int rowIndex = 0;
    //    DataTable dt = new DataTable();
    //    con.Open();
    //    cmd.Connection = con; ;
    //    cmd.CommandType = CommandType.Text;
    //    cmd.CommandText = "select qualification,batch,branch,qualification1,batch1,branch1 from qualification";
    //    cmd.ExecuteNonQuery();
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);

    //    da.Fill(dt);

    //    if (dt.Rows.Count > 0)
    //    {
    //        Gridview1.DataSource = dt;
    //        Gridview1.DataBind();

    //        foreach (GridViewRow row in Gridview1.Rows)
    //        {
    //            TextBox TextBox1 = row.FindControl("TextBox1") as TextBox;
    //            TextBox TextBox2 = row.FindControl("TextBox2") as TextBox;
    //            TextBox TextBox3 = row.FindControl("TextBox3") as TextBox;

    //            TextBox1.Text = dt.Rows[rowIndex]["qualification"].ToString();
    //            TextBox2.Text = dt.Rows[rowIndex]["batch"].ToString();
    //            TextBox3.Text = dt.Rows[rowIndex]["branch"].ToString();
    //            rowIndex++;
    //        }
    //        ViewState["PreviousTable"] = dt;
    //    }
    //    else
    //    {
    //        Gridview1.DataSource = null;
    //        Gridview1.DataBind();
    //    }
    //    con.Close();
    //}
}
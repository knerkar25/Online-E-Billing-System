using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for STD_MST_DAL
/// </summary>
public class STD_MST_DAL
{
    STD_MST_BAL bal = new STD_MST_BAL();
    public string constr = ConfigurationManager.ConnectionStrings["OnlineInvoiceBillingSystem1ConnectionString"].ConnectionString;
    SqlConnection con = new SqlConnection();

    public DataTable Bindall()
    {
        try
        {
            DataTable dt = new DataTable();
            con.ConnectionString = constr;
            SqlCommand cmd = new SqlCommand("sp_view_rawmaterial",con);
            cmd.CommandType = CommandType.StoredProcedure;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            con.Close();
            return null;
        }
        finally
        { con.Close(); }
    }
    public string Insert(STD_MST_BAL bal1)
    {
        try {
            con.ConnectionString = constr;
            SqlCommand cmd = new SqlCommand("sp_insert_rawaterial", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_pcd", SqlDbType.NChar).Value = bal1.PCode;
            cmd.Parameters.Add("@prm_pnm", SqlDbType.NChar).Value = bal1.PName;
            cmd.Parameters.Add("@prm_ppr", SqlDbType.Int).Value = bal1.PPrice;
            cmd.Parameters.Add("@prm_pimg", SqlDbType.NChar).Value = bal1.PImg;
            con.Open();
            cmd.ExecuteNonQuery();
            return "Success";
        }
        catch (Exception ex){
            con.Close();
            return "Error";
        }
        finally {
            con.Close();
        }
    }
    public string InsertToCart(int itemid,string username, string userpswd,string Tdate)
    {
        try
        {
            con.ConnectionString = constr;
            SqlCommand cmd = new SqlCommand("sp_usercart", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_itemid", SqlDbType.Int).Value = itemid;
            cmd.Parameters.Add("@prm_username", SqlDbType.NChar).Value = username;
            cmd.Parameters.Add("@prm_userpswd", SqlDbType.NChar).Value = userpswd;
            cmd.Parameters.Add("@prm_date", SqlDbType.NChar).Value = Tdate;
            con.Open();
            cmd.ExecuteNonQuery();
            return "Success";
        }
        catch (Exception ex)
        {
            con.Close();
            return "Error";
        }
        finally
        {
            con.Close();
        }
    }
    public string Delete(int product_id)
    {
        try
        {
            con.ConnectionString = constr;
            SqlCommand cmd = new SqlCommand("sp_delete_rawmaterial", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_pid", SqlDbType.Int).Value = product_id;
            con.Open();
            cmd.ExecuteNonQuery();
            return "Success";
        }
        catch (Exception ex)
        {
            con.Close();
            return "Error";
        }
        finally
        {
            con.Close();
        }
    }
    public string Update(int pid,string pcd,string pnm,int ppr,string pimg)
    {
        try
        { 
            con.ConnectionString = constr;
            SqlCommand cmd = new SqlCommand("sp_update_rawmaterial", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_pid", SqlDbType.Int).Value = pid;
            cmd.Parameters.Add("@prm_pcd", SqlDbType.NChar).Value =pcd;
            cmd.Parameters.Add("@prm_pnm", SqlDbType.NChar).Value = pnm;
            cmd.Parameters.Add("@prm_ppr", SqlDbType.Int).Value = ppr;
            cmd.Parameters.Add("@prm_pimg",SqlDbType.NChar).Value = pimg;

            con.Open();
            cmd.ExecuteNonQuery();
            return "Success";

            //con.Open();
            //cmd.ExecuteNonQuery();
            //return "Success";
        }
        catch (Exception ex)
        {
            con.Close();
            return "Error";
        }
        finally
        {
            con.Close();
        }

    }
    public DataTable search_product_Bind(string search_item)
    {
        try
        {
            DataTable dt = new DataTable();
            con.ConnectionString = constr;
            SqlCommand cmd = new SqlCommand("sp_searched_item", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_search_item", SqlDbType.NChar).Value = search_item;
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        catch (Exception ex)
        {
            con.Close();
            return null;
        }
        finally
        { con.Close(); }
    }
}
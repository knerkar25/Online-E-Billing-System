using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CART_MST_DAL
/// </summary>
public class CART_MST_DAL
{

    CART_MST_BAL bal = new CART_MST_BAL();
    public string constr = ConfigurationManager.ConnectionStrings["OnlineInvoiceBillingSystem1ConnectionString"].ConnectionString;
    SqlConnection con = new SqlConnection();

    public DataTable BindCart(string unm,string upswd)
    {
        try
        {
            DataTable dt = new DataTable();
            con.ConnectionString = constr;
            SqlCommand cmd = new SqlCommand("sp_view_cart", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_unm", SqlDbType.NVarChar).Value = unm;
            cmd.Parameters.Add("@prm_upwd", SqlDbType.NVarChar).Value = upswd;
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

    public string DeleteCartItem(string unm, string upswd, int pid)
    {
        try {
            con.ConnectionString = constr;
            SqlCommand cmd = new SqlCommand("DeleteCartItem",con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_unm",SqlDbType.NVarChar).Value = unm;
            cmd.Parameters.Add("@prm_upswd", SqlDbType.NVarChar).Value = upswd;
            cmd.Parameters.Add("@prm_pid", SqlDbType.Int).Value = pid;
            con.Open();
            cmd.ExecuteNonQuery();
            return "Success";
        }
        catch (Exception e)
        {
            con.Close();
            return "Error";
        }
        finally { con.Close(); }
    }

    public string InsertOrdr(CART_MST_BAL bal1)
    {
        try
        {
            con.ConnectionString = constr;
            SqlCommand cmd = new SqlCommand("sp_insert_orders", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_ono", SqlDbType.NChar).Value = bal1.Order_No;
            
            cmd.Parameters.Add("@prm_uid", SqlDbType.Int).Value = bal1.User_ID;
            //cmd.Parameters.Add("@prm_unm", SqlDbType.NChar).Value = bal.User_Name;
            //cmd.Parameters.Add("@prm_upswd", SqlDbType.NChar).Value=bal.User_Pwd;

            cmd.Parameters.Add("@prm_pid", SqlDbType.Int).Value = bal1.PID;
            cmd.Parameters.Add("@prm_ppr", SqlDbType.NChar).Value = bal1.PPR;
            cmd.Parameters.Add("@prm_qty", SqlDbType.NChar).Value = bal1.Quantity;
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
    public DataTable BindOrder(string ordernum)
    {
        DataTable dt = new DataTable();
        con.ConnectionString = constr;
        SqlCommand cmd = new SqlCommand("sp_view_order", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@prm_ordernum", SqlDbType.NVarChar).Value = ordernum;
        con.Open();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.Fill(dt);
        return dt;
    }

}
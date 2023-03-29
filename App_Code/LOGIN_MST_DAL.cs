using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for LOGIN_MST_DAL:  
/// used to handle login related functions.
/// </summary>
public class LOGIN_MST_DAL
{
    LOGIN_MST_BAL BAL = new LOGIN_MST_BAL();
    string constr=ConfigurationManager.ConnectionStrings["OnlineInvoiceBillingSystem1ConnectionString"].ConnectionString;
    SqlConnection con = new SqlConnection();

    public string ValidateUser(LOGIN_MST_BAL bal1)
    {
        try
        {
            con.ConnectionString = constr;
            SqlCommand cmd = new SqlCommand("sp_validate_user", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@prm_unm", SqlDbType.NChar).Value = bal1.User_Name;
            cmd.Parameters.Add("@prm_upwd", SqlDbType.NChar).Value = bal1.User_Pwd;
            con.Open();
            //cmd.ExecuteNonQuery();
            object count = cmd.ExecuteScalar();
            if (Convert.ToInt32(count) > 0)
            { return "Success"; }
            else
            { return "Error"; }
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
}
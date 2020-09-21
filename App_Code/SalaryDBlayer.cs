using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.IO;

public class SalaryDBlayer : System.Web.UI.Page

{
    private SqlConnection contoEmpDetails;
	public SalaryDBlayer()
	{
        contoEmpDetails = new SqlConnection(ConfigurationManager.ConnectionStrings
                                            ["TestDB1ConnectionString"].ToString());
    }

    public void fnAuthenticate(int EmpId, out string EmpName, 
        out string EmpBand, out string BaseLoc, out int iStatus)
    {
        SqlCommand cmd_GetDetails = new SqlCommand("RETEMPDETAILS",
    contoEmpDetails);

        cmd_GetDetails.CommandType = CommandType.StoredProcedure;
        cmd_GetDetails.Parameters.AddWithValue("@EMPID", EmpId);

        SqlParameter p_out_Empname = new SqlParameter("@EMPNAME", SqlDbType.VarChar,25);
        p_out_Empname.Direction = ParameterDirection.Output;
        cmd_GetDetails.Parameters.Add(p_out_Empname);

        SqlParameter p_out_JobBand = new SqlParameter("@JOBBAND", SqlDbType.Char,1);
        p_out_JobBand.Direction = ParameterDirection.Output;
        cmd_GetDetails.Parameters.Add(p_out_JobBand);

        SqlParameter p_out_BaseLoc = new SqlParameter("@BASELOC", SqlDbType.VarChar,30);
        p_out_BaseLoc.Direction = ParameterDirection.Output;
        cmd_GetDetails.Parameters.Add(p_out_BaseLoc);

        SqlParameter p_out_Status = new SqlParameter("@STATUS", SqlDbType.Int);
        p_out_Status.Direction = ParameterDirection.Output;
        cmd_GetDetails.Parameters.Add(p_out_Status);

        try
        {
            contoEmpDetails.Open();
            int IrET = Convert.ToInt32(cmd_GetDetails.ExecuteNonQuery());
        }
        catch
        {
        }
        finally
        {
            contoEmpDetails.Close();
            if (Convert.ToInt16(p_out_Status.Value) == 0)
            {
                EmpName = Convert.ToString(p_out_Empname.Value);
                EmpBand = Convert.ToString(p_out_JobBand.Value);
                BaseLoc = Convert.ToString(p_out_BaseLoc.Value);
                iStatus = Convert.ToInt16(p_out_Status.Value);
            }
            else
            {
                EmpName = "";
                EmpBand = "";
                BaseLoc = "";
                iStatus = Convert.ToInt16(p_out_Status.Value);
            }
        } 
    }

    public int fnSaveDetails(int EmpId, string EmpName, 
        string EmpJobBand, string BaseLocation, double salary)
    {
        SqlCommand cmd_GetDetails = new SqlCommand("savedetails",
                                    contoEmpDetails);

        cmd_GetDetails.CommandType = CommandType.StoredProcedure;
        cmd_GetDetails.Parameters.AddWithValue("@EMPID", EmpId);
        cmd_GetDetails.Parameters.AddWithValue("@EMPNAME", EmpName);
        cmd_GetDetails.Parameters.AddWithValue("@JOBBAND", EmpJobBand);
        cmd_GetDetails.Parameters.AddWithValue("@BASELOC", BaseLocation);
        cmd_GetDetails.Parameters.AddWithValue("@SALARY", salary);

        SqlParameter p_out_Status = new SqlParameter("@STATUS", SqlDbType.Int);
        p_out_Status.Direction = ParameterDirection.Output;
        cmd_GetDetails.Parameters.Add(p_out_Status);

            contoEmpDetails.Open();
            int IrET = Convert.ToInt32(cmd_GetDetails.ExecuteNonQuery());
            contoEmpDetails.Close();
            if (Convert.ToInt16(p_out_Status.Value) == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }
        }

    public DataSet fnGetSalaryDetails(int EmpId)
        {
            SqlDataAdapter daEmpid;
            DataSet dsEmpid = new DataSet();
            daEmpid = new SqlDataAdapter("Select * From "+
                "SALDETAILS_115514 where EMPID = " + EmpId,
                contoEmpDetails);
            daEmpid.Fill(dsEmpid, "SALDETAILS_115514");
            return dsEmpid;
        }

    public DataSet fnGetSalaryDetails()
    {
        SqlDataAdapter daEmpid;
        DataSet dsEmpSal = new DataSet();
        daEmpid = new SqlDataAdapter("Select * From SALDETAILS_115514",contoEmpDetails);
        daEmpid.Fill(dsEmpSal, "SALDETAILS_115514");
        return dsEmpSal;
    }
//Function to save data in .CSV File
    public void StoreDetailsInCSVFile(DataSet ds)
    {
        StreamWriter sw = new StreamWriter("E:\\Salary dashboard\\salary\\emp.csv");
        DataTable dt = ds.Tables[0];
        int iColCount = dt.Columns.Count;
        for (int i = 0; i < iColCount; i++)
        {
            sw.Write(dt.Columns[i]);
            if (i < iColCount - 1)
            {
                sw.Write(",");
            }
        }
        sw.Write(sw.NewLine);
        // Now write all the rows.
        foreach (DataRow dr in dt.Rows)
        {
            for (int i = 0; i < iColCount; i++)
            {
                if (!Convert.IsDBNull(dr[i]))
                {
                    sw.Write(dr[i].ToString());
                }
                if (i < iColCount - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
        }
        sw.Close();
    }

    public int fnRetEmpId()
    {
        SqlCommand cmd_GetEmpId = new SqlCommand("RETEMPID", contoEmpDetails);
        cmd_GetEmpId.CommandType = CommandType.StoredProcedure;

        SqlParameter p_out_EmpId = new SqlParameter("@EMPID", SqlDbType.Int);
        p_out_EmpId.Direction = ParameterDirection.Output;
        cmd_GetEmpId.Parameters.Add(p_out_EmpId);

        contoEmpDetails.Open();
        cmd_GetEmpId.ExecuteNonQuery();
        contoEmpDetails.Close();
        return Convert.ToInt16(p_out_EmpId.Value);
    }
}

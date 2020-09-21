using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class SalDisplay : System.Web.UI.Page
{
    protected DataSet dsSalDetails = new DataSet();

    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(0));
        Response.Cache.SetNoStore();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        string BaseLoc = Session["BaseLoc"].ToString();
        lblEmpId.Text = Session["EmpId"].ToString();
        lblEmpName.Text = Session["EmpName"].ToString();
        lblJobBand.Text = Session["EmpBand"].ToString();
        lblLoc.Text = Session["BaseLoc"].ToString();
        lblTotalSal.Text = Session["Salary"].ToString();

        if (BaseLoc == "Bhubhaneshwar" || BaseLoc == "Chandigarh" || BaseLoc == "Trivandrum" || BaseLoc == "Mangalore")
        {
            lblAllType.Text = "Allowance";
            lblAllowane.Text = "5 %";
        }
        else
        {
            lblAllType.Text = "Travel Allowance";
            lblAllowane.Text = "2 %";
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        int EmpId;
        string EmpName;
        string EmpJobBand;
        string BaseLocation;
        double salary = Convert.ToDouble(Session["Salary"].ToString());
        EmpId = Convert.ToInt32(Session["EmpId"]);
        EmpName = Session["EmpName"].ToString();
        EmpJobBand = Session["EmpBand"].ToString();
        BaseLocation = Session["BaseLoc"].ToString();
        SalaryDBlayer Obj = new SalaryDBlayer();
        int iRet = Obj.fnSaveDetails(EmpId,EmpName,EmpJobBand,BaseLocation,salary);
        DataSet ds = new DataSet();
        ds = Obj.fnGetSalaryDetails();
        Obj.StoreDetailsInCSVFile(ds);
        if(iRet==0)
        {
            Response.Write("<script>alert('Salary Details saved successfully')</script>");
            
        }
        else
        {
            Response.Write("<script>alert('Salary Details Generated Already')</script>");
            Server.Transfer("Home.aspx");
        }
    }
    }


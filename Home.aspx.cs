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

public partial class _Default : System.Web.UI.Page
{

    protected int EmpId = 0;
    protected string EmpName = "";
    protected string EmpBand = "";
    protected string BaseLoc = "";
    protected double Salary = 0.00;
    protected int iStatus = 0;

    protected void Page_Init(object Sender, EventArgs e)
    {
        Response.Cache.SetCacheability(HttpCacheability.NoCache);
        Response.Cache.SetExpires(DateTime.Now.AddSeconds(0));
        Response.Cache.SetNoStore();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Label2.Visible = false;
        Label3.Visible = false;
        Label4.Visible = false;
        lblBaseLoc.Visible = false;
        lblEmpBand.Visible = false;
        lblEmpName.Visible = false;
        btnCalc.Visible = false;
        if(!IsPostBack)
        {
            drpEmpLocation.DataSource = SqlDataSource1;
            drpEmpLocation.DataValueField = "BASELOC";
            drpEmpLocation.DataTextField = "BASELOC";
            drpEmpLocation.DataBind();
        }
    }
    protected void btnCalc_Click(object sender, EventArgs e)
    {

            EmpId = Convert.ToInt32(txtEmpId.Text);
            EmpName = txtEmpName.Text;
            EmpBand = drpEmpBand.SelectedItem.ToString();
            BaseLoc = drpEmpLocation.SelectedItem.ToString();
            Session["EmpId"] = txtEmpId.Text;
            Session["EmpName"] = txtEmpName.Text;
            Session["EmpBand"] = drpEmpBand.SelectedItem.ToString();
            Session["BaseLoc"] = drpEmpLocation.SelectedItem.ToString();
            _Default Obj = new _Default();
            Obj.fnCalSalary(EmpBand, BaseLoc);
            Response.Write("<script>alert('Salary Calculated Successfully')</script>");
            Response.Redirect("SalDisplay.aspx");
    }

    private void fnCalSalary(string EmpBand, string BaseLoc)
    {
        if (EmpBand == "B")
        {
            if (BaseLoc == "Bhubhaneshwar" || BaseLoc == "Chandigarh" || BaseLoc == "Trivandrum" || BaseLoc == "Mangalore")
            {
                Salary = Convert.ToDouble(11000 + ((10 + 8 + 5) * 11000) / 100);
            }

            else
            {
                Salary = Convert.ToDouble(11000 + ((10 + 8 + 2) * 11000) / 100);
            }
        }

        if (EmpBand == "C")
        {
            if (BaseLoc == "Bhubhaneshwar" || BaseLoc == "Chandigarh" || BaseLoc == "Trivandrum" || BaseLoc == "Mangalore")
            {
                Salary = Convert.ToDouble(13000 + ((15 + 12 + 5) * 13000) / 100);
            }

            else
            {
                Salary = Convert.ToDouble(13000 + ((15 + 12 + 2) * 13000) / 100);
            }
        }


        if (EmpBand == "D")
        {
            if (BaseLoc == "Bhubhaneshwar" || BaseLoc == "Chandigarh" || BaseLoc == "Trivandrum" || BaseLoc == "Mangalore")
            {
                Salary = Convert.ToDouble(18000 + ((18 + 15 + 5) * 18000) / 100);
            }
            else
            {
                Salary = Convert.ToDouble(18000 + ((15 + 18 + 2) * 18000) / 100);
            }
        }


        if (EmpBand == "E")
        {
            if (BaseLoc == "Bhubhaneshwar" || BaseLoc == "Chandigarh" || BaseLoc == "Trivandrum" || BaseLoc == "Mangalore")
            {
                Salary = Convert.ToDouble(22000 + ((20 + 18 + 5) * 22000) / 100);
            }

            else
            {
                Salary = Convert.ToDouble(22000 + ((20 + 18 + 2) * 22000) / 100);
            }
        }
        Session["Salary"] = Convert.ToDouble(Salary).ToString();

    }

    protected void btnCalSalaryXisting_Click(object sender, EventArgs e)
    {
        EmpId = Convert.ToInt32(Session["EmpId"]);
        EmpName = Session["EmpName"].ToString();
        EmpBand = Session["EmpBand"].ToString();
        BaseLoc = Session["BaseLoc"].ToString();

        if (iStatus == 0)
        {
            _Default Obj = new _Default();
            Obj.fnCalSalary(EmpBand, BaseLoc);
            Response.Write("<script>alert('Salary Calculated Successfully')</script>");
            Response.Redirect("SalDisplay.aspx");
        }
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        SalaryDBlayer Obj = new SalaryDBlayer();
        int EmpId = Obj.fnRetEmpId();
        txtEmpId.Text = EmpId.ToString();
        txtEmpId.Enabled = false;
        txtEmpName.Visible = true;
        drpEmpBand.Visible = true;
        drpEmpLocation.Visible = true;
        btnCalc.Visible = true;
        btnCalSalaryXisting.Visible = false;
        btnGetEmpDetails.Visible = false;
        Label2.Visible = true;
        Label3.Visible = true;
        Label4.Visible = true;
    }

    protected void btnGetEmpDetails_Click(object sender, EventArgs e)
    {
        RequiredFieldValidator2.Enabled = false;
        RequiredFieldValidator3.Enabled = false;
        RequiredFieldValidator4.Enabled = false;
        RegularExpressionValidator2.Enabled = false;
        EmpId = Convert.ToInt32(txtEmpId.Text);

        SalaryDBlayer objCalc = new SalaryDBlayer();

        objCalc.fnAuthenticate(EmpId, out EmpName, out EmpBand, out BaseLoc, out iStatus);
        if (iStatus == 0)
        {
            Session["EmpId"] = Convert.ToInt32(EmpId);
            Session["EmpName"] = EmpName.ToString();
            Session["EmpBand"] = Convert.ToChar(EmpBand);
            Session["BaseLoc"] = BaseLoc.ToString();
            lblEmpName.Text = EmpName.ToString();
            lblEmpBand.Text = EmpBand.ToString();
            lblBaseLoc.Text = BaseLoc.ToString();
            Label2.Visible = true;
            Label3.Visible = true;
            Label4.Visible = true;
            lblBaseLoc.Visible = true;
            lblEmpBand.Visible = true;
            lblEmpName.Visible = true;
            btnCalSalaryXisting.Visible = true;
            //btnCalc.Visible = true;
        }
        else
        {

            Response.Write("<script>alert('Employ Records Not found')</script>");
            btnCalSalaryXisting.Visible = false;
        }
    }
}

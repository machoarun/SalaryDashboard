<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="_Default" Title="Untitled Page" Theme="ThemeOne"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table style="width: 100%">
        <tr>
            <td align="center">
    <div style="text-align: center">
        <table width=1024px;>
            <tr>
                <td align="left" style="width: 184px; height: 35px">
                </td>
                <td align="left" style="width: 411px; height: 35px">
                    &nbsp;<asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" OnClick="LinkButton1_Click"
                        ToolTip="Click here for calculation of salary for New Employ">Click Here to Calculate Salary For New Employ</asp:LinkButton></td>
                <td align="left" style="width: 243px; height: 35px">
                </td>
            </tr>
            <tr>
                <td style="width: 184px; height: 35px" align="left">
                    <asp:Label ID="Label1" runat="server" Text="Employee Id"></asp:Label></td>
                <td style="width: 411px; height: 35px" align="left">
                    <asp:TextBox ID="txtEmpId" runat="server" ToolTip="Enter Employ Number"></asp:TextBox>
                    &nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmpId"
                        ErrorMessage="Enter the Employee ID">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="txtEmpId" ErrorMessage="*" ValidationExpression="[0-9]*"></asp:RegularExpressionValidator>
                    &nbsp;<asp:Button ID="btnGetEmpDetails" runat="server" Font-Size="Smaller" 
                        onclick="btnGetEmpDetails_Click" Text="Get Employee" />
                    </td>
                <td align="left" style="width: 243px; height: 35px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 184px; height: 35px" align="left">
                    <asp:Label ID="Label2" runat="server" Text="Employee Name"></asp:Label></td>
                <td style="width: 411px; height: 35px" align="left">
                    &nbsp;<asp:Label ID="lblEmpName" runat="server"></asp:Label><br />
                    <asp:TextBox ID="txtEmpName" runat="server" Visible="False"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmpName"
                        ErrorMessage="Enter the Employee Name">*</asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" 
                        ControlToValidate="txtEmpName" ErrorMessage="*" 
                        ValidationExpression="[a-zA-Z0-9]*"></asp:RegularExpressionValidator>
                </td>
                <td align="left" style="width: 243px; height: 35px">
                    &nbsp;</td>
            </tr>
            <tr>
                <td style="width: 184px; height: 35px" align="left">
                    <asp:Label ID="Label3" runat="server" Text="Employee JobBand"></asp:Label></td>
                <td style="width: 411px; height: 35px" align="left">
                    <asp:Label ID="lblEmpBand" runat="server"></asp:Label>
                    <br />
                    <asp:DropDownList ID="drpEmpBand" runat="server" Visible="False">
                        <asp:ListItem Selected="True">--Select--</asp:ListItem>
                        <asp:ListItem>B</asp:ListItem>
                        <asp:ListItem>C</asp:ListItem>
                        <asp:ListItem>D</asp:ListItem>
                        <asp:ListItem Value="E"></asp:ListItem>
                    </asp:DropDownList>&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                        runat="server" ControlToValidate="drpEmpBand" ErrorMessage="Select Employ Job Band"
                        InitialValue="--Select--">*</asp:RequiredFieldValidator></td>
                <td align="left" style="width: 243px; height: 35px">
                </td>
            </tr>
            <tr>
                <td style="width: 184px; height: 35px" align="left">
                    <asp:Label ID="Label4" runat="server" Text="Base Location"></asp:Label></td>
                <td style="width: 411px; height: 35px" align="left">
                    <asp:Label ID="lblBaseLoc" runat="server"></asp:Label>
                    <br />
                    <asp:DropDownList ID="drpEmpLocation" runat="server" Visible="False"
                         AppendDataBoundItems="True">
                        <asp:ListItem>--Select--</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="drpEmpLocation"
                        ErrorMessage="Select Base Location" InitialValue="--Select--">*</asp:RequiredFieldValidator></td>
                <td align="left" style="width: 243px; height: 35px">
                </td>
            </tr>
            <tr>
                <td style="width: 184px; height: 17px">
                    &nbsp;</td>
                <td style="width: 411px; height: 17px" align="left">
                    <asp:Button ID="btnCalc" runat="server" Text="Calculate Salary" 
                        OnClick="btnCalc_Click" Font-Size="Smaller"/>
                    <asp:Button ID="btnCalSalaryXisting" runat="server" OnClick="btnCalSalaryXisting_Click"
                        Text="Calculate Salary" Visible="False" UseSubmitBehavior="False" 
                        Font-Size="Smaller" />
                </td>
                <td align="left" style="width: 243px; height: 17px">
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:TestDB1ConnectionString %>"
                        SelectCommand="SELECT [BASELOC] FROM [BASELOC_115514]"></asp:SqlDataSource>
                </td>
            </tr>
            <tr>
                <td style="height: 17px" align="left" colspan="3">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" Width="317px" />
                </td>
            </tr>
        </table>
    </div>
            </td>
        </tr>
    </table>
</asp:Content>


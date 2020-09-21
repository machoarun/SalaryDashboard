<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="SalDisplay.aspx.cs" Inherits="SalDisplay" Title="Untitled Page"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    &nbsp; &nbsp; &nbsp;&nbsp;<br />
    <br />
    <div style="text-align: center">
        &nbsp;</div>
    <br />
    &nbsp; &nbsp;&nbsp;
    <div style="text-align: center">
        <table style="border-left-color: silver; border-bottom-color: silver; border-top-style: ridge; border-top-color: silver; border-right-style: ridge; border-left-style: ridge; border-right-color: silver; border-bottom-style: ridge; background-color: #99cc99;">
            <tr>
                <td style="width: 410px; height: 202px;">
        <table width=1024px>
            <tr>
                <td style="width: 189px; height: 32px" align="left">
                    <asp:Label ID="Label4" runat="server" Text="Employee Id:"></asp:Label></td>
                <td style="width: 210px; height: 32px" align="left">
                    <asp:Label ID="lblEmpId" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 31px" align="left">
                    <asp:Label ID="Label5" runat="server" Text="Employee Name:"></asp:Label></td>
                <td style="width: 210px; height: 31px" align="left">
                    <asp:Label ID="lblEmpName" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 35px" align="left">
                    <asp:Label ID="Label7" runat="server" Text="JobBand:"></asp:Label></td>
                <td style="width: 210px; height: 35px" align="left">
                    <asp:Label ID="lblJobBand" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 29px" align="left">
                    <asp:Label ID="Label9" runat="server" Text="Base Location:"></asp:Label></td>
                <td style="width: 210px; height: 29px" align="left">
                    <asp:Label ID="lblLoc" runat="server" Text="Label"></asp:Label></td>
            </tr>
            <tr>
                <td style="width: 189px; height: 29px" align="left">
                    <asp:Label ID="lblAllType" runat="server" Text="Label: "></asp:Label></td>
                <td style="width: 210px; height: 29px" align="left">
                    <asp:Label ID="lblAllowane" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
                    <br />
        <table>
            <tr>
                <td style="width: 126px; height: 21px">
                    <asp:Label ID="Label2" runat="server" Text="Total Salary Rs."></asp:Label></td>
                <td style="width: 100px; height: 21px">
                    <asp:Label ID="lblTotalSal" runat="server" Text="Label"></asp:Label></td>
            </tr>
        </table>
                    &nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;<br />
    <div style="text-align: center">
        <table>
            <tr>
                <td style="width: 100px; height: 25px">
                    <asp:Button ID="btnSave" runat="server" Text="Save Details" OnClick="btnSave_Click" /></td>
            </tr>
        </table>
    </div>
</asp:Content>


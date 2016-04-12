<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UploadRRCandidate.aspx.cs" Inherits="RecMgmt_UploadRRCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="page">
        <h2>
            Upload Recruitment Candidates</h2>
        <table width="80%" align="center">
            <tr>
                <td align="right" colspan="4">
                    <asp:LinkButton ID="lbBack" runat="server" CssClass="lblHistory" OnClick="lbBack_Click">Back</asp:LinkButton>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 25%">
                    Client Name :
                </td>
                <td align="left" style="width: 25%">
                    <asp:Label ID="lblClient" runat="server"></asp:Label>
                </td>
                <td align="right" style="width: 25%">
                    RR Number :
                </td>
                <td align="left" style="width: 25%">
                    <asp:Label ID="lblRRNumber" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Designation :
                </td>
                <td align="left">
                    <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                </td>
                <td align="right">
                    Location :
                </td>
                <td align="left">
                    <asp:Label ID="lblLocation" runat="server"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="right">
                    File From :
                </td>
                <td colspan="3">
                    <asp:DropDownList ID="ddlFileForm" runat="server" CssClass="DropDown" ValidationGroup="save">
                        <asp:ListItem Value="0">-- File From--</asp:ListItem>
                        <asp:ListItem Value="1">naukri.com</asp:ListItem>
                        <asp:ListItem Value="2">timesjob.com</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cv1" runat="server" ControlToValidate="ddlFileForm" ErrorMessage="*"
                        ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="save"
                        Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Upload Excel Sheet :
                </td>
                <td align="left">
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="TxtBox" />
                </td>
                <td align="center" colspan="2">
                    <asp:Button ID="btn_Upload" runat="server" CssClass="btnCancel" OnClick="btn_Upload_Click"
                        Text="Upload" />
                    &nbsp;<asp:Button ID="btn_Save" runat="server" CssClass="btnSave" OnClick="btn_Save_Click"
                        Text="Save" ValidationGroup="save" />
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                    <asp:Label ID="lblRid" runat="server" Visible="false"></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="center" colspan="4">
                    <asp:Panel ID="Panel1" runat="server" ScrollBars="Auto" Height="350px" Width="1000px">
                        <asp:GridView ID="GridView1" runat="server" CssClass="mGrid">
                            <AlternatingRowStyle CssClass="alt" />
                            <FooterStyle CssClass="footer" />
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

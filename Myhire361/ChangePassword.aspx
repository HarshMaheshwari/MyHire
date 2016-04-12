<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ChangePassword.aspx.cs" Inherits="ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <center>
        <div id="page" style="width: 600px">
            <h2>
                Change Password</h2>
            <table width="100%" cellpadding="5" cellspacing="4">
                <tr>
                    <td align="right">
                        Current Password :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="TxtBox" SetFocusOnError="true"
                            ValidationGroup="sv" TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="*" ValidationGroup="lg"
                            SetFocusOnError="true" ControlToValidate="txtCurrentPassword" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        New Password :&nbsp;
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtNPswrd" runat="server" CssClass="TxtBox" ValidationGroup="sv"
                            TextMode="Password"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="*" ValidationGroup="lg"
                            SetFocusOnError="true" ControlToValidate="txtNPswrd" ForeColor="Red"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        Confirm New Password :
                    </td>
                    <td align="left">
                        <asp:TextBox ID="txtCPswrd" runat="server" CssClass="TxtBox" SetFocusOnError="true"
                            ValidationGroup="lg" TextMode="Password"></asp:TextBox>
                        <asp:CompareValidator ID="cv1" runat="server" ControlToCompare="txtNPswrd" ControlToValidate="txtCPswrd"
                            ErrorMessage="*" SetFocusOnError="true" ValidationGroup="lg" ForeColor="Red"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="left">
                        <p align="center">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btnNew" ValidationGroup="lg"
                                OnClick="btnSubmit_Click" /></p>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>

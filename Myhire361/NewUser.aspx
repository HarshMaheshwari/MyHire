<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="NewUser.aspx.cs" Inherits="NewUser" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<%--    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
         <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" EnablePartialRendering="true">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <div id="page">
                    <h2>
                        New&nbsp;User
                    </h2>
                    <table width="70%">
                        <tr>
                            <td align="right" width="50%">
                                User Name :
                            </td>
                            <td align="left" width="50%">
                                <asp:TextBox ID="txtName" runat="server" CssClass="TxtBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                          <tr>
                            <td align="right">
                                Mobile No :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMobileNo" runat="server" CssClass="TxtBox"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender runat="server" ID="txtfieldextender" TargetControlID="txtMobileNo" FilterMode="ValidChars" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNo"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                              
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Email Id :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="TxtBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txtEmail"
                                    ErrorMessage="Wrong" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                    ValidationGroup="Save"></asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Password :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPssswrd" runat="server" CssClass="TxtBox" TextMode="Password"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtPssswrd"
                                    ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Role :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlRole" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlRole"
                                    ErrorMessage="Select" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True"
                                    Type="Integer" ValidationGroup="Save" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Reporting Manager :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlManager" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlManager"
                                    ErrorMessage="Select" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True"
                                    Type="Integer" ValidationGroup="Save" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                &nbsp;
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="2">
                                <asp:Button ID="btnSave" runat="server" CssClass="btnSave" OnClick="btnSave_Click"
                                    Text="Save" ValidationGroup="Save" />
                                &nbsp;
                                <asp:Button ID="btnCncl" runat="server" CssClass="btnCancel" OnClick="btnCncl_Click"
                                    Text="Cancel" />
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

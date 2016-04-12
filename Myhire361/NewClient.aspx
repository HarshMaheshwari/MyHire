<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="NewClient.aspx.cs" Inherits="NewClient" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <center>
        <div id="page">
            <h2>
                <asp:Label ID="lblHdr" runat="server"></asp:Label>&nbsp;Client
            </h2>
            <table width="100%">
                <tr>
                    <td align="right" width="25%">
                        Client Code :
                    </td>
                    <td align="left" width="25%">
                        <asp:TextBox ID="txtCode" runat="server" CssClass="TxtBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCode"
                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" width="25%">
                        Client Name :
                    </td>
                    <td align="left" width="25%">
                        <asp:TextBox ID="txtClient" runat="server" CssClass="TxtBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtClient"
                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="25%">
                        Contact Name :
                    </td>
                    <td align="left" width="25%">
                        <asp:TextBox ID="txtCntct" runat="server" CssClass="TxtBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtCntct"
                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" width="25%">
                        Contact Email Id :
                    </td>
                    <td align="left" width="25%">
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="TxtBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail"
                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="25%">
                        Date Of Birth :
                    </td>
                    <td align="left" width="25%">
                        <asp:TextBox ID="txtDob" runat="server" CssClass="TxtBox"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDob"
                            PopupButtonID="txtDob" Format="dd-MMM-yyyy">
                        </asp:CalendarExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Wrong"
                            ForeColor="Red" SetFocusOnError="true" ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                            ControlToValidate="txtDob" ValidationGroup="Save"></asp:RegularExpressionValidator>
                    </td>
                    <td align="right" width="25%">
                        Contact Phone :
                    </td>
                    <td align="left" width="25%">
                        <asp:TextBox ID="txtPhn" runat="server" CssClass="TxtBox"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPhn"
                            ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td align="right" width="25%">
                        Consultant Assigned :
                    </td>
                    <td align="left" width="25%">
                        <asp:DropDownList ID="ddlConsultant" runat="server" CssClass="DropDown" AppendDataBoundItems="True">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlConsultant"
                            ErrorMessage="Select" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True"
                            Type="Integer" ValidationGroup="Save" ValueToCompare="0"></asp:CompareValidator>
                    </td>
                    <td align="right" width="25%">
                        Date Of Anniversary :
                    </td>
                    <td align="left" width="25%">
                        <asp:TextBox ID="txtDoa" runat="server" CssClass="TxtBox"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDoa"
                            PopupButtonID="txtDoa" Format="dd-MMM-yyyy">
                        </asp:CalendarExtender>
                        <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Wrong"
                            ForeColor="Red" SetFocusOnError="true" ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                            ControlToValidate="txtDoa" ValidationGroup="Save"></asp:RegularExpressionValidator>
                    </td>
                </tr>

               
                <tr>
                    <td align="right" width="25%">
                        Website :
                    </td>
                    <td align="left" width="25%">
                        <asp:TextBox ID="txtWebsite" runat="server" CssClass="TxtBox"></asp:TextBox>
                    </td>
                    <td align="right" width="25%">
                        Location :
                    </td>
                    <td align="left" width="25%">
                        <asp:DropDownList ID="ddlLocation" runat="server" CssClass="DropDown" AppendDataBoundItems="True">
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlLocation"
                            ErrorMessage="Select" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True"
                            Type="Integer" ValidationGroup="Save" ValueToCompare="0"></asp:CompareValidator>
                    </td>
                </tr>

                  <tr>
                    <td align="right" width="25%">
                        Client Source :
                    </td>
                    <td align="left" width="25%">
                        <asp:TextBox ID="txtClientSource" runat="server" CssClass="TxtBox"></asp:TextBox>
                    </td>
                    <td align="right" width="25%">
                       
                    </td>
                    <td align="left" width="25%">
                       
                    </td>
                </tr>
                <tr>
                    <td align="right" width="25%">
                        Email Alert :
                    </td>
                    <td align="left" width="25%">
                        <asp:RadioButtonList ID="rbtnEmail" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td align="right" width="25%">
                        SMS Alert :
                    </td>
                    <td align="left" width="25%">
                        <asp:RadioButtonList ID="rbtnSMS" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="1">Yes</asp:ListItem>
                            <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                   <tr>
                    <td align="right" width="25%">
                      
                    </td>
                    <td align="left" width="25%">
                         <asp:Image ID="imgpic" runat="server" Height="120px" Width="100px" ToolTip="Client Logo" />
                       </td>
                    <td align="left" width="25%"  valign="top">
                        
                   
                    </td>
                    <td align="left" width="25%"  valign="top">
                     
                         <asp:Image ID="ImgIHPick" runat="server" Height="120px" Width="100px" ToolTip="India Hiring Logo" />
         
                    </td>
                </tr>
                 <tr>
                    <td align="right" width="25%">
                       Client Logo :
                    </td>
                    <td align="left" width="25%">
                         <asp:FileUpload ID="ClientLogo" runat="server" CssClass="TxtBox" />
                        
                                  
                    </td>
                    <td align="right" width="25%"  valign="top">
                        
                    India Hiring Logo :
                    </td>
                    <td align="left" width="25%"  valign="top">
                       
                    <asp:FileUpload ID="FUIndHiring" runat="server" CssClass="TxtBox" />
                    </td>
                </tr>
                <tr>
                    <td align="right" colspan="4">
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
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
</asp:Content>

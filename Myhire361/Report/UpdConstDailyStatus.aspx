<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdConstDailyStatus.aspx.cs" Inherits="Report_UpdConstDailyStatus" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 347px;
        }
        .auto-style2 {
            width: 171px;
        }
        .auto-style3 {
            width: 221px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Update Consultant Daily Status</h2>
            <table>
                <tr align="center">
                 
                    <td>Date :</td><td>
                         <asp:TextBox ID="txtDDate" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:CalendarExtender ID="CltxtDDate" runat="server" Format="dd-MMM-yyyy"
                                PopupButtonID="txtDDate" TargetControlID="txtDDate">
                            </asp:CalendarExtender>
                            <asp:RegularExpressionValidator ID="Rev4" runat="server" ControlToValidate="txtDDate"
                                Display="Dynamic" ErrorMessage="Eg. 31-May-2013 " ForeColor="Red" SetFocusOnError="true"
                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                ValidationGroup="save" Font-Size="Small"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="RFVtxtDDate" runat="server" ControlToValidate="txtDDate"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                     
                                    </td>
                    
                      <td>  
                             <asp:Label ID="lblmsg" runat="server"  Font-Bold="true" ></asp:Label>
                          <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_OnClick" ValidationGroup="save" CssClass="btnSave"/>
                    </td>
                    
                </tr>

            </table>
        </div>
    </center>
</asp:Content>



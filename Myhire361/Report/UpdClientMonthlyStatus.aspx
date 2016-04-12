<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdClientMonthlyStatus.aspx.cs" Inherits="Report_UpdClientMonthlyStatus" %>

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
                Update Client Monthly Status</h2>
            <table>
                <tr align="center">
                 
                    <td align="right">Month :</td><td align="left" style="width:200px;">
                        <asp:TextBox ID="txtMonth" runat="server" CssClass="TxtBox" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CltxtMonth" runat="server" Format="MMM-yyyy"
                                PopupButtonID="txtMonth" TargetControlID="txtMonth" DefaultView="Months">
                            </asp:CalendarExtender>
                            <asp:RegularExpressionValidator ID="Rev4" runat="server" ControlToValidate="txtMonth"
                                Display="Dynamic" ErrorMessage="Eg. May-2015 " ForeColor="Red" SetFocusOnError="true"
                                ValidationExpression="(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                ValidationGroup="save" Font-Size="Small"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="RFVtxtMonth" runat="server" ControlToValidate="txtMonth"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                   
                    
                      <td  style="width:200px;">  
                           <asp:Label ID="lblmsg" runat="server"  Font-Bold="true" ></asp:Label>
                          <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_OnClick" ValidationGroup="save" CssClass="btnSave"/>
                    </td>
                    
                </tr>

            </table>
        </div>
    </center>
</asp:Content>




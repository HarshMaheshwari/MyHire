<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConstDailyStatusRpt.aspx.cs" Inherits="Report_ConstDailyStatusRpt" %>

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
                 Consultant Daily Status</h2>
           
            <table>
               <tr>
                   
                    <td width="25%" align="right" colspan="3">
                        <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg" Height="30px" Width="40px" OnClick="lbtnDownload_Click" 
                    ToolTip="Download in Excel"/>
                    </td>
                </tr>

                <tr align="center">
                 
                    <td align="right">Date :</td><td  align="center">
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
                    
                      <td align="left">  
                           
                          <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_OnClick" ValidationGroup="Search" CssClass="btnSave"/>
                    </td>
                    
                </tr>

            </table>
            <table> <asp:GridView ID="gdvDWS" runat="server" CssClass="mRprtGrid" AutoGenerateColumns="true"
                             HeaderStyle-ForeColor="White"   onsorting="gdvDWS_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="USR_Name">
                            <HeaderStyle BackColor="#CC0000" />
                            <Columns>
                               
                            </Columns>
                        </asp:GridView>  </table>
        </div>
    </center>
</asp:Content>


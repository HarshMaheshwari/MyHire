<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultantPerformanceMonthly.aspx.cs" Inherits="Report_ConsultantPerformanceMonthly" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Consultant Monthly Performance</h2>
            
                   
                <table>
                  <tr>
                   <td>
                      Client
                   </td>
                      <td>Consultant</td>
                      <td>Month and Year</td>
                    <td  align="right" >
                        <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg" Height="30px" Width="40px" OnClick="lbtnDownload_Click" 
                    ToolTip="Download in Excel"/>
                    </td>
                </tr>
                    <tr align="center">
                                                    <td align="center">
                                <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                 <asp:DropDownList ID="ddlConsultant" runat="server" AppendDataBoundItems="True" CssClass="DropDown"  Width="170px">
                            </asp:DropDownList>
                            </td>
                            <td align="center">
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
                    
                      <td align="left">  
                           
                          <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_OnClick" ValidationGroup="Search" CssClass="btnSave"/>
                    </td>
                     
                  </tr>
              
                </table>

           
            <table width="100%">
                <tr><td>
                   <asp:Panel ID="pnlUpload" runat="server" Width="1194px" ScrollBars="Auto" Height="800px">
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                 <asp:GridView ID="gdvDWS" runat="server" CssClass="mRprtGrid" AutoGenerateColumns="true" onrowcreated="gdvDWS_RowCreated" 
                             HeaderStyle-ForeColor="White"   onsorting="gdvDWS_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="USR_Name">
                            <HeaderStyle BackColor="#CC0000" />
                            <Columns>
                               
                            </Columns>
                        </asp:GridView> 
                 </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvDWS" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                </td></tr>
            </table>
        </div>
    </center>
</asp:Content>



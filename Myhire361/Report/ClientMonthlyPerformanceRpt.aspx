<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClientMonthlyPerformanceRpt.aspx.cs" Inherits="Report_ClientMonthlyPerformanceRpt" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <style type="text/css">
        .FixedHeader {
            position: absolute;
            font-weight: bold;
            vertical-align:text-bottom;
           
            
        }      
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Client Monthly Performance</h2>
            <table>
                 <tr>
                   
                    <td width="25%" align="right" colspan="3">
                        <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg" Height="30px" Width="40px" OnClick="lbtnDownload_Click" 
                    ToolTip="Download in Excel"/>
                    </td>
                </tr>

                <tr align="center">
                 
                    <td align="right">Month :</td><td  align="center">
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
                   <asp:Panel ID="pnlUpload" runat="server" Width="1190" ScrollBars="Auto" Height="800px">
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <%-- <div style="height: 400px; width:95%; overflow: auto" align="center">--%>
                 <asp:GridView ID="gdvDWS" runat="server" HeaderStyle-CssClass="FixedHeader1" CssClass="mRprtGrid" HeaderStyle-BackColor="YellowGreen"
                      AlternatingRowStyle-BackColor="WhiteSmoke" AutoGenerateColumns="true" 
                             HeaderStyle-ForeColor="White"  onsorting="gdvDWS_Sorting" AllowSorting="true"  OnRowDataBound="gdvDWS_RowDataBound">
                            <HeaderStyle BackColor="#CC0000"  />
                   
                            <Columns>
                                
                                     
                            </Columns>
                        
                        </asp:GridView>   
                              <%-- </div>   --%> 
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






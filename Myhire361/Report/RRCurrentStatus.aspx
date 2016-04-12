<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RRCurrentStatus.aspx.cs" Inherits="Report_RRCurrentStatus" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>RR Current Status</h2>
            
                   
                <table width="100%">
                  <tr>
                   <td>
                      Client
                   </td>
                      <td>Client HR</td>
                      <td>Consultant</td>
                      <td>Role</td>
                      <td>Designation</td>
                      <td>Location</td>
                      <td>RR Status</td>

                    <td  align="right" >
                        <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg" Height="30px" Width="40px" OnClick="lbtnDownload_Click" 
                    ToolTip="Download in Excel"/>
                    </td>
                </tr>
                    <tr align="center">
                                                    <td align="center">
                                <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="150px">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                <asp:DropDownList ID="ddlRequest" runat="server" AppendDataBoundItems="True" CssClass="DropDown" Width="150px">
                            </asp:DropDownList>
                 
                            </td>
                        <td>   <asp:DropDownList ID="ddlConsultant" runat="server" AppendDataBoundItems="True" CssClass="DropDown"  Width="150px">
                            </asp:DropDownList></td>
                            <td align="center">
                         <asp:TextBox ID="txtRole" runat="server" CssClass="TxtBox" Width="100px"></asp:TextBox>
                 
                                    </td>
                        <td align="center">
                         <asp:TextBox ID="txtDesignation" runat="server" CssClass="TxtBox" Width="100px"></asp:TextBox>
                 
                                    </td>
                         <td align="center">
                            <asp:DropDownList ID="ddlLocation" runat="server" AppendDataBoundItems="True" CssClass="DropDown" Width="150px">
                            </asp:DropDownList>
                 
                                    </td>
                        <td>
                                  <asp:DropDownList ID="ddlRequestStatus" runat="server" AppendDataBoundItems="True"
                                CssClass="DropDown" Width="150px">
                                 <asp:ListItem Text="All" Value="0"></asp:ListItem>
                               <asp:ListItem Text="Open" Value="Open"></asp:ListItem>
                                 <asp:ListItem Text="Partialy Closed" Value="Partialy Closed"></asp:ListItem>
                                   <asp:ListItem Text="Closed" Value="Closed"></asp:ListItem>
                                     <asp:ListItem Text="Hold" Value="Hold"></asp:ListItem>
                                      <asp:ListItem Text="Mapping" Value="Mapping"></asp:ListItem>
                                       <asp:ListItem Text="Submitted" Value="Submitted"></asp:ListItem>
                                 <asp:ListItem Text="Not Planned" Value="Not Planned"></asp:ListItem>
                              </asp:DropDownList>
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
                            <HeaderStyle BackColor="#CC0000" Width="100%" />
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



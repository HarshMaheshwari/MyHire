<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RprtClientStatus.aspx.cs" Inherits="Report_RprtClientStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="page">
        <h2>
            Client Candidate Status</h2>
        <table width="100%">
            <tr>
                <td align="center" width="20%">
                    Client Name :
                </td>
                <td width="20%" align="center">
                    From Date
                </td>
                <td align="center" width="20%">
                    To Date
                </td>
                <td width="20%" align="center">
                     <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg" Height="30px" Width="40px" OnClick="lbtnDownload_Click" 
                    ToolTip="Download in Excel"/>
                </td>
            </tr>
            <tr>
                <td align="center" width="20%">
                    <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                    </asp:DropDownList>
                </td>
                <td width="20%" align="center">
                    <asp:TextBox ID="txtFrom" runat="server"></asp:TextBox>
                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfrom"
                        PopupButtonID="txtfrom" Format="dd-MMM-yyyy">
                    </asp:CalendarExtender>
                </td>
                <td width="20%" align="center">
                    <asp:TextBox ID="txtTo" runat="server"></asp:TextBox>
                      <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                        PopupButtonID="txtTo" Format="dd-MMM-yyyy">
                    </asp:CalendarExtender>
                </td>
                <td width="20%" align="center">
                    <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" OnClick="btnSearch_Click"
                        Text="Search" />
                  
                </td>
            </tr>
            <tr>
                <td colspan="4" align="center">
              
                    <asp:Panel ID="pnlCompany" runat="server" Width="1100px" ScrollBars="Auto" Height="400px">
                       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                        <asp:GridView ID="gdvCompany" runat="server" CssClass="mRprtGrid" AutoGenerateColumns="False"
                            OnRowDataBound="gdvCompany_RowDataBound" HeaderStyle-ForeColor="White" onsorting="gdvCompany_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                            <HeaderStyle BackColor="#CC0000" />
                            <Columns>
                                <asp:TemplateField HeaderText="Id" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Client_Id")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="S.No." SortExpression="Client_Id">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client Name" SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client Manager" SortExpression="USR_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblManager" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Position/Request" SortExpression="TotalRequest">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTPosition" runat="server" Text='<%#Eval("TotalRequest")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total Identified"  SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTotalIdentified" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Identified"   SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdentified" runat="server" Font-Bold="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Calls/Task"   SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCallsTask" runat="server"  Font-Bold="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Suitable/Not Interested"   SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSuitableNtInt" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Suitable Interested"   SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblSuitInterst" runat="server" Font-Bold="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Pending Approval"   SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPending" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Approved" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblApproved" runat="server" Font-Bold="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rejected"   SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRejected" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CV Shared with client"   SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCVShared" runat="server" Font-Bold="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CV Rejected By Client"   SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCVRejected" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Interview Scheduled" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblInterScadule" runat="server" Font-Bold="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Interview Done"   SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblInterviewDone" runat="server" Font-Bold="true"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Interview Selected" >
                                    <ItemTemplate>
                                        <asp:Label ID="lblSelected" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Interview Rejected"   SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntRejected" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Offered"   SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblOffered" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Shortlisted"   SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShortList" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Joined"   SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblJoined" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                          </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvCompany" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                     </asp:Panel>

                    
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

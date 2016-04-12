<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RprtPositionStatus.aspx.cs" Inherits="Report_RprtPositionStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Client Designation Status</h2>
            <table width="100%">
                <tr>
                    <td align="center" width="20%">
                        Client
                    </td>
                    <td align="center" width="20%">
                        Designation
                    </td>
                    <td align="center" width="20%">
                        From Date
                    </td>
                    <td align="center" width="20%">
                        To Date
                    </td>
                    <td align="center">
                       <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg" Height="30px" Width="40px" OnClick="lbtnDownload_Click" 
                    ToolTip="Download in Excel"/>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtDesigantion" runat="server" CssClass="TxtBox"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtFrom" runat="server" CssClass="TxtBox"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfrom"
                            PopupButtonID="txtfrom" Format="dd-MMM-yyyy">
                        </asp:CalendarExtender>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtTo" runat="server" CssClass="TxtBox"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo"
                            PopupButtonID="txtTo" Format="dd-MMM-yyyy">
                        </asp:CalendarExtender>
                    </td>
                    <td align="center">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" OnClick="btnSearch_Click"
                            Text="Search" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5" align="center">
                        <asp:Panel ID="pnlPosition" runat="server" Width="1100px" ScrollBars="Auto" Height="400px">
                           <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                            <asp:GridView ID="gdvPosition" runat="server" CssClass="mRprtGrid" AutoGenerateColumns="False"
                                OnRowDataBound="gdvPosition_RowDataBound" HeaderStyle-ForeColor="White" onsorting="gdvPosition_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Client_Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RequestId" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRId" runat="server" Text='<%#Eval("Request_Id")%>'></asp:Label>
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
                                    <asp:TemplateField HeaderText="Designation" SortExpression="Designation">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Client Manager" SortExpression="USR_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblManager" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Location" SortExpression="City_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Total Identified"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalIdentified" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Identified"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIdentified" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Calls/Task"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCallsTask" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Suitable/Not Interested"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSuitableNtInt" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Suitable Interested"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSuitInterst" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Pending Approval"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPending" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approved"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApproved" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rejected"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRejected" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CV Shared with client"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCVShared" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CV Rejected By Client"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCVRejected" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interview Scheduled"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInterScadule" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interview Done"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblInterviewDone" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interview Selected"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSelected" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Interview Rejected"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblIntRejected" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Offered"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOffered" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shortlisted"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblShortList" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Joined"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblJoined" runat="server"></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                            
             </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvPosition" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>

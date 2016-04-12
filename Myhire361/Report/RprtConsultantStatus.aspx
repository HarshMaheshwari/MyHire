<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RprtConsultantStatus.aspx.cs" Inherits="Report_RprtConsultantStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Consultant Status</h2>
            <table width="100%">
                <tr>
                    <td align="center" width="20%" id="Consultant" runat="server">
                        Consultant
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
                    <td align="center" width="20%" id="ConsultantDropdown" runat="server">
                        <asp:DropDownList ID="ddlConsultant" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
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
                        <asp:Button ID="Button1" runat="server" CssClass="btnCancel" OnClick="btnSearch_Click"
                            Text="Search" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <center>
                            <asp:Panel ID="pnlConsultant" runat="server" Width="1100px" ScrollBars="Auto" Height="400px">
                              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                <asp:GridView ID="gdvConsultant" runat="server" CssClass="mRprtGrid" AutoGenerateColumns="False"
                                    OnRowDataBound="gdvConsultant_RowDataBound" DataKeyNames="USR_ID" HeaderStyle-ForeColor="White" onsorting="gdvConsultant_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="USR_Name">
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("USR_ID")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="S.No." SortExpression="USR_ID">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Consultant" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsultant" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Positions" SortExpression="TotalRequest">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPosition" runat="server" Text='<%#Eval("TotalRequest")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total Identified" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTotalIdentified" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Identified" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIdentified" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Calls/Task" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCallsTask" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Suitable/Not Interested" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSuitableNtInt" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Suitable Interested" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSuitInterst" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Pending Approval" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPending" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Approved" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApproved" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Rejected" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRejected" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CV Shared with client" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCVShared" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CV Rejected By Client" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCVRejected" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Interview Scheduled" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInterScadule" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Interview Done" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblInterviewDone" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Interview Selected" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSelected" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Interview Rejected" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIntRejected" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Offered" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOffered" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Shortlisted" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShortList" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Joined" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJoined" runat="server"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                  </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvConsultant" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                            </asp:Panel>
                        </center>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>

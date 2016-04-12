<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RprtInterview.aspx.cs" Inherits="Report_RprtInterview" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
        <h2>All Interview Schedule</h2>
            <table width="100%">
                
                <tr>
                    <td align="center" width="20%">
                        Client
                    </td>
                    <td align="center" width="20%">
                        Designation
                    </td>
                    <td align="center" width="20%">
                        From Date</td>
                    <td align="center" width="20%">
                        To Date</td>
                   <td align="center"> 
                   <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg" Height="30px" Width="40px" OnClick="lbtnDownload_Click" 
                    ToolTip="Download in Excel"/></td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" 
                            CssClass="DropDown" Width="200px">
                        </asp:DropDownList>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtDesigantion" runat="server" CssClass="TxtBox" Width="200px"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtfrom" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfrom" PopupButtonID="txtfrom" Format="dd-MMM-yyyy">
                        </asp:CalendarExtender>
                    </td>
                    <td align="center">
                        <asp:TextBox ID="txtTo" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                          <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtTo" PopupButtonID="txtTo" Format="dd-MMM-yyyy">
                        </asp:CalendarExtender>
                    </td>
                    <td align="center">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search" 
                            OnClick="btnSearch_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                        <asp:GridView ID="gdvInterview" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                            OnPageIndexChanging="gdvInterview_PageIndexChanging" GridLines="Both" CssClass="mRprtGrid"
                            EmptyDataText="No interview is scheduled." PageSize="20" Width="100%" HeaderStyle-ForeColor="White" onsorting="gdvInterview_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                            <AlternatingRowStyle CssClass="alt" />
                            <FooterStyle CssClass="footer" />
                            <Columns>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Client_Id")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="RID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRId" runat="server" Text='<%#Eval("Request_Id")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client Name"  SortExpression="Client_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Designation" SortExpression="Designation">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Candidate Name" SortExpression="Candidate_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblName" runat="server" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Consultant" SortExpression="USR_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblConsultant" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Candidate Status" SortExpression="Candidate_Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCandStatus" runat="server" Text='<%#Eval("Candidate_Status")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Interview Date" SortExpression="FollowUp_Date">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIntervDate" runat="server" Text='<%#Eval("FollowUp_Date")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action" Visible="false">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="ViewButton" CommandName="View" runat="server" Text="View" CssClass="lbtnFView" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                          </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvInterview" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>

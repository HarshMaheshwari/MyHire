<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="TodayReport.aspx.cs" Inherits="Report_TodayReport" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Today's Report</h2>
            <table width="100%">
                <tr>
                    <td align="right">
                        Current Login User
                    </td>
                    <td>
                        <asp:Button ID="btnRefresh" runat="server" CssClass="btnCancel" Text="Refresh" OnClick="btnRefresh_Click" />
                    </td>
                    <td width="50%">
                        Today&#39;s Task</td>
                </tr>
                <tr>
                    <td align="center" colspan="2" valign="top">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gdvLoginUser" runat="server" CssClass="mGrid" AutoGenerateColumns="False"
                                    PageSize="20" Width="90%" HeaderStyle-ForeColor="White" onsorting="gdvLoginUser_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="USR_Name">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <FooterStyle CssClass="footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("LogRecord_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUsrID" runat="server" Text='<%#Eval("USR_ID")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="User Name" SortExpression="USR_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUser" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Login Date" SortExpression="LoginDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("LoginDate")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Login Time" SortExpression="LoginTime">
                                            <ItemTemplate>
                                                <asp:Label ID="lblTime" runat="server" Text='<%#Eval("LoginTime")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnRefresh" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                    <td valign="top">
                     <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                            <ContentTemplate>
                        <asp:GridView ID="gdvReport" runat="server" CssClass="mGrid" AutoGenerateColumns="False"
                            PageSize="20" Width="90%" onrowdatabound="gdvReport_RowDataBound" HeaderStyle-ForeColor="White" onsorting="gdvReport_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="USR_Name">
                            <AlternatingRowStyle CssClass="alt" />
                            <FooterStyle CssClass="footer" />
                            <Columns>
                                <asp:TemplateField HeaderText="Id" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("USR_ID")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="User Name" SortExpression="USR_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblUser" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Identified" SortExpression="USR_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblIdentified" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Task" SortExpression="USR_Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblTask" runat="server"></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>

                         </ContentTemplate>
                            <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="btnRefresh" EventName="Click" />
                            </Triggers>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>

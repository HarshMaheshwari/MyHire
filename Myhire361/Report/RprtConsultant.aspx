<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RprtConsultant.aspx.cs" Inherits="Report_RprtConsultant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
  <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                User - Report</h2>
            <table width="90%">
                <tr>
                    <td align="right">
                         <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg" Height="30px" Width="40px" OnClick="lbtnDownload_Click" 
                    ToolTip="Download in Excel"/>
                    </td>
                </tr>
            </table>
             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
            <asp:GridView ID="gdvUser" runat="server" AutoGenerateColumns="False" CssClass="mRprtGrid"
                Width="80%" AllowPaging="True" EmptyDataText="No Record Found" PageSize="30"
                OnPageIndexChanging="gdvUser_PageIndexChanging" HeaderStyle-ForeColor="White" onsorting="gdvUser_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="USR_Name">
                <AlternatingRowStyle CssClass="alt" />
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <FooterStyle CssClass="footer" />
                <Columns>
                    <asp:TemplateField HeaderText="S.No." SortExpression="USR_Name">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="User Name" SortExpression="USR_Name">
                        <ItemTemplate>
                            <asp:Label ID="lblUser" runat="server" Font-Bold="true" Text='<%#Eval("USR_Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Designation" SortExpression="Role_Name">
                        <ItemTemplate>
                            <asp:Label ID="lblDesig" runat="server" Text='<%#Eval("Role_Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Request Assigned" SortExpression="Position_Assigned">
                        <ItemTemplate>
                            <asp:Label ID="lblTtlaRqst" runat="server" Text='<%#Eval("Position_Assigned")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

             </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvUser" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
        </div>
    </center>
</asp:Content>

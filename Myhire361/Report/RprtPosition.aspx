<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RprtPosition.aspx.cs" Inherits="Report_RprtPosition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Position - Report</h2>
            <table width="95%">
                <tr>
                    <td align="right">
                        <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg" Height="30px" Width="40px" OnClick="lbtnDownload_Click" 
                    ToolTip="Download in Excel"/>
                    </td>
                </tr>
            </table>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
            <asp:GridView ID="gdvPosition" runat="server" AutoGenerateColumns="False" CssClass="mRprtGrid"
                Width="100%" AllowPaging="True" EmptyDataText="No Record Found" PageSize="30"
                OnPageIndexChanging="gdvPosition_PageIndexChanging" HeaderStyle-ForeColor="White" onsorting="gdvPosition_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                <AlternatingRowStyle CssClass="alt" />
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <FooterStyle CssClass="footer" />
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
                    <asp:TemplateField HeaderText="Designation" SortExpression="Designation">
                        <ItemTemplate>
                            <asp:Label ID="lblDesignation" runat="server" Text='<%#Eval("Designation")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Recieve Date" SortExpression="Recieve_Date">
                        <ItemTemplate>
                            <asp:Label ID="lblRcvDate" runat="server" Text='<%#Eval("Recieve_Date")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Location" SortExpression="City_Name">
                        <ItemTemplate>
                            <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City_Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Experience " SortExpression="Min_Experience">
                        <ItemTemplate>
                            <asp:Label ID="lblExprnce" runat="server" Text='<%#Eval("Min_Experience")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Min Salary " SortExpression="Min_Salary">
                        <ItemTemplate>
                            <asp:Label ID="lblMinSalary" runat="server" Text='<%#Eval("Min_Salary")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Max Salary " SortExpression="Max_Salary">
                        <ItemTemplate>
                            <asp:Label ID="lblMaxSalary" runat="server" Text='<%#Eval("Max_Salary")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Approving Manager" SortExpression="USR_Name">
                        <ItemTemplate>
                            <asp:Label ID="lblMngr" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

            
             </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvPosition" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
        </div>
    </center>
</asp:Content>

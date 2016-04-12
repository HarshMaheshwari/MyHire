<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RprtCompanyt.aspx.cs" Inherits="Report_RprtCompanyt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Client - Report</h2>
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
            <asp:GridView ID="gdvClient" runat="server" AutoGenerateColumns="False" CssClass="mRprtGrid"
                DataKeyNames="Client_Id" Width="100%" AllowPaging="True" EmptyDataText="No Record Found"
                PageSize="30" OnPageIndexChanging="gdvClient_PageIndexChanging" HeaderStyle-ForeColor="White" onsorting="gdvClient_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                <AlternatingRowStyle CssClass="alt" />
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <FooterStyle CssClass="footer" />
                <Columns>
                    <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Client_Id")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="S.No."  SortExpression="Client_Id">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Client Name" SortExpression="Client_Name">
                        <ItemTemplate>
                            <asp:Label ID="lblClient" runat="server" Font-Bold="true" Text='<%#Eval("Client_Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Client Manager"  SortExpression="USR_Name">
                        <ItemTemplate>
                            <asp:Label ID="lblAssigendTo" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact Person"  SortExpression="Person_Name">
                        <ItemTemplate>
                            <asp:Label ID="lblContact" runat="server" Text='<%#Eval("Person_Name")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Contact No" SortExpression="Person_Contact">
                        <ItemTemplate>
                            <asp:Label ID="lblPhnNo" runat="server" Text='<%#Eval("Person_Contact")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Total Request" SortExpression="Total_Position">
                        <ItemTemplate>
                            <asp:Label ID="lblTtlaRqst" runat="server" Font-Bold="true" Text='<%#Eval("Total_Position")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

               </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvClient" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
        </div>
    </center>
</asp:Content>

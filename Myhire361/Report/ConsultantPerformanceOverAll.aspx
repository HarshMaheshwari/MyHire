<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultantPerformanceOverAll.aspx.cs" Inherits="Report_ConsultantPerformanceOverAll" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Over All Consultants Performance</h2>
            <table width="95%">
              <tr><td align="right"> <asp:Label ID="lblCurrentDate" runat="server"  Font-Bold="true" ForeColor="Brown"></asp:Label></td></tr>
            </table>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

             <asp:GridView ID="gdvConsultantPer" runat="server" AutoGenerateColumns="true" CssClass="mRprtGrid"
                 Width="100%" AllowPaging="True" EmptyDataText="No Record Found"
                PageSize="30" OnPageIndexChanging="gdvConsultantPer_PageIndexChanging" HeaderStyle-ForeColor="White" onsorting="gdvConsultantPer_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="UserName">
                <AlternatingRowStyle CssClass="alt" />
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <FooterStyle CssClass="footer" />

                <%--<Columns>
        
        <asp:TemplateField HeaderText="Parameters" SortExpression="Candidate_Status">
                        <ItemTemplate>
                            <asp:Label ID="lblCandidateStatus" runat="server" Font-Bold="true" Text='<%#Eval("Candidate_Status") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

         <asp:TemplateField HeaderText="MTD" SortExpression="0">
                        <ItemTemplate>
                            <asp:Label ID="lblMTD" runat="server" Font-Bold="true" Text='<%#Eval("0")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

           <asp:TemplateField HeaderText="Last Month" SortExpression="1">
                        <ItemTemplate>
                            <asp:Label ID="lblLastMonth" runat="server" Font-Bold="true" Text='<%#Eval("1")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                     <asp:TemplateField HeaderText="Last Month-1" SortExpression="2">
                        <ItemTemplate>
                            <asp:Label ID="lblLastMonth1" runat="server" Font-Bold="true" Text='<%#Eval("2")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                  <asp:TemplateField HeaderText="Last Month-2" SortExpression="3">
                        <ItemTemplate>
                            <asp:Label ID="lblLastMonth2" runat="server" Font-Bold="true" Text='<%#Eval("3")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                        
                      

                     

                
                </Columns>--%>
            </asp:GridView>



               </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvConsultantPer" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
        </div>
    </center>
</asp:Content>


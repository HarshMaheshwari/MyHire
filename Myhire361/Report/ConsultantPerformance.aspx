<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultantPerformance.aspx.cs" Inherits="Report_ConsultantPerformance" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Consultant Performance</h2>
            <table width="95%">
             <tr><td align="right"> <asp:Label ID="lblCurrentDate" runat="server"  Font-Bold="true" ForeColor="Brown"></asp:Label></td></tr>
            </table>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
            <asp:GridView ID="gdvConsultantPer" runat="server" AutoGenerateColumns="False" CssClass="mRprtGrid"
                 Width="100%" AllowPaging="True" EmptyDataText="No Record Found"
                PageSize="30" OnPageIndexChanging="gdvConsultantPer_PageIndexChanging" HeaderStyle-ForeColor="White" onsorting="gdvConsultantPer_Sorting" AllowSorting="true"  CurrentSortDirection="asc" CurrentSortField="UserName">
                <AlternatingRowStyle CssClass="alt" />
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <FooterStyle CssClass="footer" />
                <Columns>
              <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("UserId")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="S.No."  SortExpression="UserId">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1 %>
                           
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Last Month-2" SortExpression="LastMonth2">
                        <ItemTemplate>
                            <asp:Label ID="lblLastMonth2" runat="server" Font-Bold="true" Text='<%#Eval("LastMonth2")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Last Month-1" SortExpression="LastMonth1">
                        <ItemTemplate>
                            <asp:Label ID="lblLastMonth1" runat="server" Font-Bold="true" Text='<%#Eval("LastMonth1")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Last Month" SortExpression="LastMonth">
                        <ItemTemplate>
                            <asp:Label ID="lblLastMonth" runat="server" Font-Bold="true" Text='<%#Eval("LastMonth")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Consultant Name" SortExpression="UserName">
                        <ItemTemplate>
                            <asp:Label ID="lblUserName" runat="server" Font-Bold="true" Text='<%#Eval("UserName")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="CV-Today" SortExpression="CVToday">
                        <ItemTemplate>
                            <asp:Label ID="lblCVToday" runat="server" Font-Bold="true" Text='<%#Eval("CVToday")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                     <asp:TemplateField HeaderText="CV-MTD" SortExpression="CVMTD">
                        <ItemTemplate>
                            <asp:Label ID="lblCVMTD" runat="server" Font-Bold="true" Text='<%#Eval("CVMTD")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                         <asp:TemplateField HeaderText="Interview-Today" SortExpression="InterviewDoneToday">
                        <ItemTemplate>
                            <asp:Label ID="lblInterviewDoneToday" runat="server" Font-Bold="true" Text='<%#Eval("InterviewDoneToday")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                         <asp:TemplateField HeaderText="Interview-MTD" SortExpression="InterviewDoneMTD">
                        <ItemTemplate>
                            <asp:Label ID="lblInterviewDoneMTD" runat="server" Font-Bold="true" Text='<%#Eval("InterviewDoneMTD")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>

                      <asp:TemplateField HeaderText="Interview-Tomorrow" SortExpression="InterviewTomorrow">
                        <ItemTemplate>
                            <asp:Label ID="lblInterviewTomorrow" runat="server" Font-Bold="true" Text='<%#Eval("InterviewTomorrow")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                       
                
                </Columns>
            </asp:GridView>

               </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvConsultantPer" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
        </div>
    </center>
</asp:Content>


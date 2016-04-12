<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultantPerformanceCM.aspx.cs" Inherits="Report_ConsultantPerformanceCM" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
 <asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Consultants Performance For Current Month</h2>
            <table width="95%">
              <tr><td align="right"> <asp:Label ID="lblCurrentDate" runat="server"  Font-Bold="true" ForeColor="Brown"></asp:Label></td></tr>
            </table>
              <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

             <asp:GridView ID="gdvConsultantPer" runat="server" AutoGenerateColumns="false" CssClass="mRprtGrid"
                 Width="100%" AllowPaging="True" EmptyDataText="No Record Found"
                PageSize="30" OnPageIndexChanging="gdvConsultantPer_PageIndexChanging" HeaderStyle-ForeColor="White" onsorting="gdvConsultantPer_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="FollowUp_Date">
                <AlternatingRowStyle CssClass="alt" />
                <EmptyDataRowStyle HorizontalAlign="Center" />
                <FooterStyle CssClass="footer" />
                <Columns>
                
                 <asp:TemplateField HeaderText="Date" SortExpression="FollowUp_Date">
                        <ItemTemplate>
                            <asp:Label ID="lblFollowUp_Date" runat="server" Font-Bold="true" Text='<%#Eval("FollowUp_Date")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Day" SortExpression="WeekDayname">
                        <ItemTemplate>
                            <asp:Label ID="lblWeekDayname" runat="server" Font-Bold="true" Text='<%#Eval("WeekDayname")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Interview Done" SortExpression="InterviewDone">
                        <ItemTemplate>
                            <asp:Label ID="lblInterviewDone" runat="server" Font-Bold="true" Text='<%#Eval("InterviewDone")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="Interview Scheduled" SortExpression="InterviewScheduled">
                        <ItemTemplate>
                            <asp:Label ID="lblInterviewScheduled" runat="server" Font-Bold="true" Text='<%#Eval("InterviewScheduled")%>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                          <asp:TemplateField HeaderText="CV Shared With Client" SortExpression="CVSharedWithClient">
                        <ItemTemplate>
                            <asp:Label ID="lblCVShared" runat="server" Font-Bold="true" Text='<%#Eval("CVSharedWithClient")%>'></asp:Label>
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


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MyWorkList.aspx.cs" Inherits="Recruitment_MyWorkList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="page">
                <h2>
                    My Worklist</h2>
                <table width="100%" align="center">
                    <tr>
                        <td align="center" valign="middle" width="80%">
                            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                         <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
                            <asp:GridView ID="gdvMyWorkList" runat="server" AutoGenerateColumns="False" DataKeyNames="Candidate_Id"
                                AllowPaging="True" Width="100%" OnPageIndexChanging="gdvMyWorkList_PageIndexChanging"
                                GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                                OnRowCommand="gdvMyWorkList_RowCommand" PageSize="25" HeaderStyle-ForeColor="White" onsorting="gdvMyWorkList_Sorting" AllowSorting="true" CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                                <AlternatingRowStyle CssClass="alt" />
                                <FooterStyle CssClass="footer" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No." SortExpression="Candidate_Id">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ID" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RRID" Visible="false"  SortExpression="RRCandidate_Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRRId" runat="server" Text='<%#Eval("RRCandidate_Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Client Name"  SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClntName" runat="server" Font-Bold="true" Text='<%#Eval("Client_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RR-No"  SortExpression="RRNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRRno" runat="server" Text='<%#Eval("RRNumber")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Name"  SortExpression="Candidate_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblName" runat="server" Font-Bold="true" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Mobile No."  Visible="false"  SortExpression="Mobile_No">
                                        <ItemTemplate>
                                            <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile_No")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="CTC"  SortExpression="Annual_Salary">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCTC" runat="server" Text='<%#Eval("Annual_Salary")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Recruiter Status"  SortExpression="Recruiter_Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRecStatus" runat="server" Text='<%#Eval("Recruiter_Status")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Approver Status"  SortExpression="Supervisor_Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblApproveStatus" runat="server" Text='<%#Eval("Supervisor_Status")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Candidate Status"  SortExpression="Candidate_Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCandStatus" runat="server" Text='<%#Eval("Candidate_Status")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sent By"  SortExpression="USR_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblSent" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="ConsultantID" Visible="false"  SortExpression="Consultant_Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblConsultantId" runat="server" Text='<%#Eval("Consultant_Id")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="ViewButton" CommandName="View" runat="server" Text="View" CssClass="lbtnEdit"
                                                Visible="false" />
                                            &nbsp;
                                              <asp:ImageButton ID="FollowUp" CommandName="FollowUp" runat="server" ImageUrl="~/Image/Followup.png" ToolTip="FollowUp"
                                                    Height="30px" Width="30px" />
                                            &nbsp;
                                            <asp:ImageButton ID="History" CommandName="History" runat="server" ImageUrl="~/Image/History.jpg" ToolTip="History" Height="30px"
                                        Width="30px"/>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>

                             </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvMyWorkList" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/MasterPage.master" CodeFile="VintroVideo.aspx.cs"
    Inherits="Recruitment_VintroVideo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <html>
    <head>

        <style type="text/css">
            .mGrid {
            }
        </style>

    </head>
    <body>
        <div id="page" align="center">
            <asp:GridView runat="server" AutoGenerateColumns="false" CssClass="mGrid" DataKeyNames="Que_Id"
                ID="gdvVideoQue" AllowPaging="True" EmptyDataText="Sorry! No Record Found."
                HeaderStyle-ForeColor="White" Width="755px">
                <Columns>
                    <asp:TemplateField HeaderText="Ques.No." SortExpression="Que_Id">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="40px" />
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Que_Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Question" SortExpression="Que_Type">
                        <ItemTemplate>
                            <asp:Label ID="lblques" runat="server" Text='<%#Eval("Que_Type") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Question Site" SortExpression="Que_Site">
                        <ItemTemplate>
                            <asp:Label ID="lblQueSite" runat="server" Text='<%#Eval("Que_Site") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>

                    <%-- <asp:TemplateField HeaderText="Question Site" SortExpression="Que_Site">
                        <ItemTemplate>
                           <asp:Button ID="Button1" CssClass="btnCancel" runat="server" Text="Send" /></td>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>--%>
                </Columns>
                <EmptyDataRowStyle ForeColor="Red" />
            </asp:GridView>


            <asp:GridView ID="gdvCandidate" runat="server" AutoGenerateColumns="False" DataKeyNames="Candidate_Id"
                                    AllowPaging="True" Width="100%" OnPageIndexChanging="gdvCandidate_PageIndexChanging"
                                    GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                                    OnRowCommand="gdvCandidate_RowCommand" PageSize="25" Visible="false">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <FooterStyle CssClass="footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RRID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRRId" runat="server" Text='<%#Eval("RRCandidate_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClntName" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RR-No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRRno" runat="server" Text='<%#Eval("RRNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="6%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Candidate_Name")%>' Font-Bold="true"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Current Employer">
                                            <ItemTemplate>
                                                <%#Eval("Current_Employer")%>  <br />
                                              <i>  <%#Eval("Current_Designation")%></i>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile_No")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CTC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCTC" runat="server" Text='<%#Eval("Annual_Salary")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Recruiter Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecStatus" runat="server" Text='<%#Eval("Recruiter_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Approver Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApproveStatus" runat="server" Text='<%#Eval("Supervisor_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Candidate Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCandStatus" runat="server" Text='<%#Eval("Candidate_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ConsultantID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsultantId" runat="server" Text='<%#Eval("Consultant_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="FollowUp" CommandName="FollowUp" runat="server" ImageUrl="~/Image/Followup.png"
                                                    ToolTip="FollowUp" Height="22px" Width="22px" />
                                                <asp:ImageButton ID="lbtnRRHistory" CommandName="RRHistory" ImageUrl="~/Image/RRHistory.png"
                                                    runat="server" ToolTip="RRHistory" Height="22px" Width="22px" />
                                                <asp:ImageButton ID="History" CommandName="History" runat="server" ImageUrl="~/Image/History.jpg"
                                                    ToolTip="History" Height="22px" Width="22px" />
                                                <asp:ImageButton ID="imgbtnVideo" runat="server" CommandName="Video" ImageUrl="~/Image/VideoIcon.png"
                                                    ToolTip="Send Video Link" Height="25px" Width="25px" />
                                                <asp:ImageButton ID="imgbtnViewVideo" runat="server" CommandName="ViewVideo" ImageUrl="~/Image/Video.png"
                                                    ToolTip="View Candidate Video" Height="22px" Width="22px" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="13%"/>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
            <table>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="btnSend" CssClass="btnCancel" runat="server" Text="Send"/></td>
                </tr>
            </table>

        </div>
    </body>
    </html>
</asp:Content>

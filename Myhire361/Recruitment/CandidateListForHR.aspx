<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CandidateListForHR.aspx.cs" Inherits="Recruitment_CandidateListForHR" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
            <center>
                <div id="page">
                    <h2>
                        RR Candidate List</h2>
                    <table width="100%" align="center">
                        <tr style="width: 90%">
                            <td align="right" valign="middle" colspan="4">
                                <asp:LinkButton ID="lbBack" runat="server" CssClass="lblHistory" OnClick="lbBack_Click">Back</asp:LinkButton>
                            </td>
                        </tr>
                        <tr style="width: 90%">
                            <td align="center" width="25%">
                                Name
                            </td>
                            <td align="center" width="25%">
                                Mobile No
                            </td>
                            <td align="center" width="25%">
                                CTC
                            </td>
                            <td align="center" width="25%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="width: 90%">
                            <td align="center" width="25%">
                                <asp:TextBox ID="txtName" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="center" width="25%">
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="center" width="25%">
                                <asp:TextBox ID="txtCtc" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                             <td align="center" width="25%">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" OnClick="btnSearch_Click"
                                    Text="Search" />
                                </td>
                            </tr>
                        <tr><td>
                                </td><td>
                                </td>
                            </tr> <tr><td>
                                </td><td>
                                </td>
                            </tr><tr><td>
                                </td><td>
                                </td>
                            </tr> <tr><td>
                                </td><td>
                                </td>
                            </tr>
                        <tr>
                            <td>
                                </td>
                             <td align="right" width="25%" valign="bottom">
                                <asp:Button ID="btnExcel" runat="server" CssClass="btnSave" OnClick="btnExcel_Click"
                                    Text="Excel Upload" Width="168px" />
                            </td>
                             <td align="left" width="25%" valign="bottom">
                                <asp:Button ID="btnCVs" runat="server" CssClass="btnSave" OnClick="btnCVs_Click"
                                    Text="CVs Upload" Width="143px" />
                            </td>
                           
                        </tr>
                        <tr style="width: 90%">
                            <td align="right" colspan="2" valign="middle">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" colspan="2" valign="middle">
                                Status :
                                <asp:DropDownList ID="ddlRecordStatus" runat="server" AutoPostBack="True" CssClass="DropDown"
                                    OnSelectedIndexChanged="ddlRecordStatus_SelectedIndexChanged" Width="100px">
                                    <asp:ListItem Selected="True" Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="gdvCandidate" runat="server" AutoGenerateColumns="False" DataKeyNames="Candidate_Id"
                                    AllowPaging="True" Width="100%" OnPageIndexChanging="gdvCandidate_PageIndexChanging"
                                    GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                                    OnRowCommand="gdvCandidate_RowCommand" PageSize="25">
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
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
</asp:Content>


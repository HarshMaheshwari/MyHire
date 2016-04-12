<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FollowUpHistory.aspx.cs" Inherits="Recruitment_FollowUpHistory" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <div id="page">
                    <h2>
                        FollowUp History</h2>
                    <table width="100%" align="center">
                        <tr>
                            <td align="right" valign="middle">
                                <asp:LinkButton ID="lbBack" runat="server" CssClass="lblHistory" OnClick="lbBack_Click">Back</asp:LinkButton>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" valign="middle">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:GridView ID="gdvFollowup" runat="server" AutoGenerateColumns="False" DataKeyNames="FollowUp_Id"
                                    AllowPaging="True" Width="100%" GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                                    OnRowCommand="gdvFollowup_RowCommand">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <FooterStyle CssClass="footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="FollowUp Id" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("FollowUp_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FollowUp Type">
                                            <ItemTemplate>
                                                <asp:Label ID="lblType" runat="server" Text='<%#Eval("FollowUp_Type")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FollowUp Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDate" runat="server" Text='<%#Eval("FollowUp_Date")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="FollowUp By">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBy" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="Supervisor Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblSupStatus" runat="server" Text='<%#Eval("Supervisor_Status")%>'></asp:Label>
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
                                         <asp:TemplateField HeaderText="Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFollowUp_Remarks" runat="server" Text='<%#Eval("FollowUp_Remarks")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" Visible="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ViewButton" CommandName="View" runat="server" ToolTip="View"
                                                    ImageUrl="~/Image/view.png" Width="22px" Height="22px" />
                                                &nbsp;
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemStyle Width="10%" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                    <asp:Panel ID="Panel1" runat="server" Width="60%" CssClass="pnlpopup">
                        <h2>
                            View FollowUp
                        </h2>
                        <table width="100%">
                            <tr>
                                <td align="right" width="25%">
                                    FollowUp Type
                                </td>
                                <td align="left" width="25%">
                                    <asp:Label ID="lblType" runat="server"></asp:Label>
                                </td>
                                <td align="right" width="25%">
                                    FollowUp Date :
                                </td>
                                <td align="left" width="25%">
                                    <asp:Label ID="lblDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="25%">
                                    FollowUp Time :
                                </td>
                                <td align="left" width="25%">
                                    <asp:Label ID="lblTime" runat="server"></asp:Label>
                                </td>
                                <td align="right" width="25%">
                                    FollowUp By :
                                </td>
                                <td align="left" width="25%">
                                    <asp:Label ID="lblBy" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="25%">
                                    Recruiter Status :
                                </td>
                                <td align="left" width="25%">
                                    <asp:Label ID="lblRecStatus" runat="server"></asp:Label>
                                </td>
                                <td align="right" width="25%">
                                    Supervisor Status :
                                </td>
                                <td align="left" width="25%">
                                    <asp:Label ID="lblSupStatus" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="25%">
                                    Candidate Status:
                                </td>
                                <td align="left" width="25%">
                                    <asp:Label ID="lblCandStatus" runat="server">
                                    </asp:Label>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="25%">
                                    Remark :
                                </td>
                                <td align="left" colspan="3" style="width: 50%">
                                    <asp:Label ID="lblRemark" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btnBack" runat="server" CssClass="btnCancel" Text="Ok" />
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="Panel1" TargetControlID="btn1dump"
                        CancelControlID="btnBack" BackgroundCssClass="modalbackground">
                    </asp:ModalPopupExtender>
                    <asp:Button ID="btn1dump" runat="server" Style="visibility: hidden" />
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

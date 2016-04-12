<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CandidateVideoList.aspx.cs" Inherits="Recruitment_CandidateVideoList" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="page">
        <center>
            <h2>
                Candidate Video List</h2>
            <table width="100%">
                <tr>
                    <td style="font-size: 12px; font-weight: bold">
                        <table width="100%">
                            <tr>
                                <td align="right" width="12%">
                                    Candidate Name :
                                </td>
                                <td align="left">
                                    <asp:Label ID="lblCandidate" runat="server"></asp:Label>
                                </td>
                                <td width="8%" align="right" id="tdRRNo" runat="server">
                                    RRNumber:
                                </td>
                                <td width="10%" align="left">
                                    <asp:Label ID="lblRRnumber" runat="server"></asp:Label>
                                </td>
                                <td width="8%" align="right" id="tdClient" runat="server">
                                    Client Name:
                                </td>
                                <td width="18%" align="left">
                                    <asp:Label ID="lblClient" runat="server"></asp:Label>
                                </td>
                                <td width="8%" align="right" id="tdDesg" runat="server">
                                    Designation:
                                </td>
                                <td width="18%" align="left">
                                    <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="gdvCandidate" runat="server" AutoGenerateColumns="False" DataKeyNames="CandidateVideo_Id"
                            AllowPaging="True" Width="90%" OnPageIndexChanging="gdvCandidate_PageIndexChanging"
                            GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                            OnRowCommand="gdvCandidate_RowCommand" PageSize="10">
                            <AlternatingRowStyle CssClass="alt" />
                            <FooterStyle CssClass="footer" />
                            <Columns>
                                <asp:TemplateField HeaderText="ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("CandidateVideo_Id")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="CID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCId" runat="server" Text='<%#Eval("Candidate_Id")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1%>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="5%" />
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client Name">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClntName" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" width="15%"/>
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Candidate Name" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCandidate" runat="server" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" Width="15%" />
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
                                <asp:TemplateField HeaderText="Video Name" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblVideo" runat="server" Text='<%#Eval("Video_Name")%>'></asp:Label>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Video Date" HeaderStyle-Width="9%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("CreationDate")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Video URL" HeaderStyle-Width="40%">
                                    <ItemTemplate>
                                        <asp:Label ID="lblURL" runat="server" Text='<%#Eval("VideoURL")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="imgbtnViewVideo" runat="server" CommandName="ViewVideo" ImageUrl="~/Image/Video.png"
                                            ToolTip="View Candidate Video" Height="22px" Width="22px"></asp:ImageButton>
                                        <asp:ImageButton ID="imgbtnVideo" runat="server" CommandName="Video" ImageUrl="~/Image/VideoIcon.png"
                                            ToolTip="Send Video Link" Height="25px" Width="25px"></asp:ImageButton>
                                    </ItemTemplate>
                                    <HeaderStyle HorizontalAlign="Center" />
                                    <ItemStyle HorizontalAlign="Center" />
                                    <ItemStyle Width="5%" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button ID="btnCancel" runat="server" CssClass="btnCancel" OnClick="btnCancel_Click"
                            Text="Cancel" />
                    </td>
                </tr>
            </table>
            <asp:Panel ID="Panel1" runat="server" Width="60%" CssClass="pnlpopup">
                <table width="100%">
                    <tr>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td width="95%">
                                        <h2>
                                            Send&nbsp; Video Link</h2>
                                    </td>
                                    <td>
                                        <asp:ImageButton ID="imgClose" runat="server" Height="35px" Width="35px" ToolTip="Close Popup"
                                            ImageUrl="~/Image/Close.jpg" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="50%">
                            Client Email Id :
                        </td>
                        <td align="left" width="50%" style="width: 50%">
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtEmail"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="Send"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="rev" runat="server" ControlToValidate="txtEmail"
                                Display="Dynamic" ErrorMessage="Invalid Email ID" ForeColor="Red" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                ValidationGroup="Send"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Button ID="btnSend" runat="server" CssClass="btnCancel" Text="Send" ValidationGroup="Send"
                                OnClick="btnSend_Click" />
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="Panel1" TargetControlID="btn1dump"
                CancelControlID="imgClose" BackgroundCssClass="modalbackground">
            </asp:ModalPopupExtender>
            <asp:Button ID="btn1dump" runat="server" Style="visibility: hidden" />
        </center>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ConsultantPerformanceDailyReport2.aspx.cs" Inherits="Report_ConsultantPerformanceDailyReport2" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <center>

        <table cellpadding="5" cellspacing="5" width="100%">
            <tr>

                <td align="left" valign="top">
                    <table class="tblbg" width="100%">
                        <thead>
                            <tr align="center" valign="top">
                                <td style="font-weight: bold"></td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td align="left">
                                    <table width="100%">
                                        <tr>
                                            <td style="width: 30%" align="center">Consultant
                                            </td>
                                            <td style="width: 30%" align="center">Candidate Status
                                            </td>
                                            <td style="width: 30%" align="center">From Date
                                            </td>
                                            <td style="width: 30%" align="center">To Date
                                            </td>
                                            <td style="width: 30%" align="right">&nbsp;&nbsp;&nbsp;      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                 
                         <asp:LinkButton ID="lbdownload" runat="server" CssClass="LinkBtn" OnClick="lbdownload_Click" ForeColor="Red">Export to Excel</asp:LinkButton>

                                            </td>

                                        </tr>
                                        <tr>
                                             <td align="center">
                                                <asp:DropDownList ID="ddlConsultant" runat="server" AppendDataBoundItems="True" CssClass="DropDown" Width="170px">
                                                </asp:DropDownList>
                                            </td>
                                            <td align="center">
                                                <asp:DropDownList ID="ddlCandidateStatus" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                                    Width="200px">
                                                </asp:DropDownList>
                                            </td>
                                           


                                            <td align="center">
                                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="TxtBox" Width="120px"></asp:TextBox>
                                                <asp:CalendarExtender ID="ce1" runat="server" PopupButtonID="txtStartDate" TargetControlID="txtStartDate"
                                                    Format="dd-MMM-yyyy" DefaultView="Months">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td align="center">
                                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="TxtBox" Width="120px"></asp:TextBox>
                                                <asp:CalendarExtender ID="ce2" runat="server" PopupButtonID="txtEndDate" TargetControlID="txtEndDate"
                                                    Format="dd-MMM-yyyy" DefaultView="Months">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td align="center">
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" OnClick="btnSearch_Click"
                                                    ValidationGroup="save" Text="Search" />
                                            </td>
                                        </tr>
                                        <tr>

                                            <td>
                                                <asp:RegularExpressionValidator ID="Rev1" runat="server" ErrorMessage="Wrong" SetFocusOnError="true"
                                                    ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                                    ControlToValidate="txtStartDate" ValidationGroup="save" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <asp:RegularExpressionValidator ID="Rev2" runat="server" ErrorMessage="Wrong" SetFocusOnError="true"
                                                    ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                                    ControlToValidate="txtEndDate" ValidationGroup="save" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <center>
                        <asp:GridView ID="GdvConsultantreport" runat="server" AutoGenerateColumns="False" DataKeyNames="Candidate_Id"
                            EmptyDataText="No Data Is Found" Width="90%" GridLines="None" CssClass="mGrid"
                            AllowPaging="True" ShowFooter="False" PageSize="30" OnPageIndexChanging="GdvConsultantreport_PageIndexChanging"
                            AllowSorting="True" OnSorting="GdvConsultantreport_Sorting">
                            <AlternatingRowStyle CssClass="alt" />
                            <FooterStyle CssClass="footer" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Candidate ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCandidateId" runat="server" Text='<%#Eval("Candidate_Id")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Consultant" SortExpression="Consultant" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <asp:Label ID="lblConsultant" runat="server" Text='<%#Eval("Consultant")%>'></asp:Label>
                                        &nbsp;&nbsp;
                                           
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client" SortExpression="Client" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText=" RR#" ControlStyle-Width="70px" SortExpression="RR#" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRR" runat="server" Text='<%#Eval("RRNumber")%>'></asp:Label>
                                        <%-- &nbsp;&nbsp;
                                            <asp:Label ID="lblLginTime" runat="server" Text='<%#Eval("LginTime")%>'></asp:Label>--%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <%--                        <asp:TemplateField HeaderText="Login Time">
                            <ItemTemplate>
                                <asp:Label ID="lblLginTime" runat="server" Text='<%#Eval("LginTime")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Role " SortExpression="Role" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <asp:Label ID="lblRole" runat="server" Text='<%#Eval("Role")%>'></asp:Label>
                                        <%-- &nbsp;&nbsp;
                                            <asp:Label ID="lblLgoutTime" runat="server" Text='<%#Eval("LgoutTime")%>'></asp:Label>--%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Date " SortExpression="Date" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                                        <%-- &nbsp;&nbsp;
                                            <asp:Label ID="lblLgoutTime" runat="server" Text='<%#Eval("StatusDate")%>'></asp:Label>--%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Candidate Name " SortExpression="Candidate" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCandidatename" runat="server" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                        <%-- &nbsp;&nbsp;
                                            <asp:Label ID="lblLgoutTime" runat="server" Text='<%#Eval("LgoutTime")%>'></asp:Label>--%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Candidate  Status  " SortExpression="Candidate_Status" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <asp:Label ID="lblCandidateStatus" runat="server" Text='<%#Eval("Candidate_Status")%>'></asp:Label>
                                        <%-- &nbsp;&nbsp;
                                            <asp:Label ID="lblLgoutTime" runat="server" Text='<%#Eval("LgoutTime")%>'></asp:Label>--%>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <%--                        <asp:TemplateField HeaderText="Logout Time">
                            <ItemTemplate>
                                <asp:Label ID="lblLgoutTime" runat="server" Text='<%#Eval("LgoutTime")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                            </Columns>
                        </asp:GridView>

                    </center>
                    <asp:Label ID="lblmsg" runat="server" Style="font-weight: 700" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>

    </center>
</asp:Content>


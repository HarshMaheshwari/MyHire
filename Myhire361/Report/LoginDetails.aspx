<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginDetails.aspx.cs" Inherits="Report_LoginDetails" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <center>
        
                <table cellpadding="5" cellspacing="5" width="100%">
                    <tr>
                       
                        <td align="left" valign="top">
                            <table class="tblbg" width="100%">
                                <thead>
                                    <tr align="center" valign="top">
                                        <td style="font-weight: bold">
                                            Login Screen
                                        </td>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td align="left">
                                            <table width="100%">
                                                <tr>
                                                   
                                                    <td style="width: 30%" align="center">
                                                        From Date
                                                    </td>
                                                    <td style="width: 30%" align="center">
                                                        To Date
                                                    </td>
                                                    <td style="width: 30%" align="right">
                                                    &nbsp;&nbsp;&nbsp;    Action  &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                 
                         <asp:LinkButton ID="lbdownload" runat="server" CssClass="LinkBtn" OnClick="lbdownload_Click" ForeColor="Red">Export to Excel</asp:LinkButton>
                     
                                                    </td>
                       
                                                </tr>
                                                <tr>
                                                    
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
                                                        <asp:Button ID="btnSearch" runat="server"  CssClass="btnCancel" OnClick="btnSearch_Click"
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
                                                    <td>
                                                        &nbsp;
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                </tbody>
                            </table>
                         <center> 
                             <div style="height:500px; width:auto; overflow:auto;">
                            <asp:GridView ID="GdvLoginDetail" runat="server" AutoGenerateColumns="False" DataKeyNames="USR_ID"
                                EmptyDataText="No Data Is Found" Width="90%"  GridLines="None" CssClass="mGrid"
                                AllowPaging="True" ShowFooter="False" PageSize="10000" 
                                AllowSorting="True" OnSorting="GdvLoginDetail_Sorting" Height="300px">
                                <AlternatingRowStyle CssClass="alt" />
                                <FooterStyle CssClass="footer" />
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <ItemStyle Width="50px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User ID" Visible="false" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsrId" runat="server" Text='<%#Eval("USR_ID")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" Date" SortExpression="Dates" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="lblLginNDate" runat="server" Text='<%#Eval("Date")%>'></asp:Label>
                                            &nbsp;&nbsp;
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Name" SortExpression="Usr_Name" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUsrName" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                    <asp:TemplateField HeaderText=" Incoming Time" SortExpression="Login Date" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                           <%-- <asp:Label ID="lblLginDate" runat="server" Text='<%#Eval("LogInDate")%>'></asp:Label>
                                            &nbsp;&nbsp;--%>
                                            <asp:Label ID="lblLginTime" runat="server" Text='<%#Eval("LginTime")%>'></asp:Label>
                                        </ItemTemplate>
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <%--                        <asp:TemplateField HeaderText="Login Time">
                            <ItemTemplate>
                                <asp:Label ID="lblLginTime" runat="server" Text='<%#Eval("LginTime")%>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Outgoing Time" SortExpression="logoutDate" HeaderStyle-ForeColor="White">
                                        <ItemTemplate>
                                            <%--<asp:Label ID="lblLgoutDate" runat="server" Text='<%#Eval("logoutDate")%>'></asp:Label>
                                            &nbsp;&nbsp;--%>
                                            <asp:Label ID="lblLgoutTime" runat="server" Text='<%#Eval("LgOutTime ")%>'></asp:Label>
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
                                </div>
                                </center>
                            <asp:Label ID="lblmsg" runat="server" Style="font-weight: 700" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
          
    </center>
</asp:Content>


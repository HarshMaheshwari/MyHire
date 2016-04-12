<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ClientHome.aspx.cs" Inherits="ClientHome" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="page">
        <h2>
            Recruitment Request Management</h2>
        <table width="100%" align="center">
            <%--<tr>
                <td align="left" width="50%">
                    &nbsp;
                </td>
                <td align="right">
                    <asp:LinkButton ID="lbtnDownload" runat="server" CssClass="lblHistory" OnClick="lbtnDownload_Click">Download</asp:LinkButton>
                </td>
            </tr>--%>
            <tr>
                <td colspan="2">
                    <%--<table width="100%">
                        <tr>
                            <td align="right">
                                Client :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="250px">
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                Designation :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDesigntn" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="5">
                                Status :
                                <asp:DropDownList ID="ddlRecordStatus" runat="server" AutoPostBack="True" CssClass="DropDown"
                                    OnSelectedIndexChanged="ddlRecordStatus_SelectedIndexChanged" Width="100px">
                                    <asp:ListItem Selected="True" Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>--%>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:GridView runat="server" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Request_Id"
                        ID="gdvRequest" AllowPaging="True" EmptyDataText="Sorry! No Record Found." 
                        OnPageIndexChanging="gdvRequest_PageIndexChanging" OnRowCommand="gdvRequest_RowCommand"
                        PageSize="20">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Request_Id") %>'></asp:Label></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RR Number">
                                <ItemTemplate>
                                    <asp:Label ID="lblRRNo" runat="server" Text='<%#Eval("RRNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Job Profile">
                                <ItemTemplate>
                                    <asp:Label ID="lblJob" runat="server" Text='<%#Eval("Job_Profile") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Client">
                                <ItemTemplate>
                                    <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Client Contact">
                                <ItemTemplate>
                                    <asp:Label ID="lblContact" runat="server" Text='<%#Eval("ClientManager") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Reporting Manager">
                                <ItemTemplate>
                                    <asp:Label ID="lblReporting" runat="server" Text='<%#Eval("ReportingManager") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesig" runat="server" Text='<%#Eval("Designation") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Location">
                                <ItemTemplate>
                                    <asp:Label ID="lbllocation" runat="server" Text='<%#Eval("City_Name") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Positions">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalPosition" runat="server" Text='<%#Eval("Total_Position") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Received Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblReciveDate" runat="server" Text='<%#Eval("Recieve_Date") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Target Closure Date" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblTtlClosureDate" runat="server" Text='<%#Eval("Closer_Date") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <%--   <asp:TemplateField HeaderText="Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblStatus" runat="server" Visible="false" Text='<%#Eval("Status") %>'></asp:Label>
                                    &nbsp;
                                    <asp:LinkButton ID="lbtnActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                        CssClass="lbtnView" />
                                </ItemTemplate>
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lbtnView" runat="server" ImageUrl="~/Image/view.png" Height="22px"
                                        Width="22px" CssClass="lbtnEdit" ToolTip="View" CommandName="View" />
                                    &nbsp;
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

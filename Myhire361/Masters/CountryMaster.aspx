<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CountryMaster.aspx.cs" Inherits="Masters_CountryMaster" %>

<%@ Register Src="~/Masters/MasterMenu.ascx" TagName="MstrMenu" TagPrefix="MCntrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="../Styles/SkopeMenu.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left" valign="top" width="180px">
                        <MCntrl:MstrMenu ID="VMenu" runat="server" />
                    </td>
                    <td align="center" valign="top">
                        <div id="page" style="height: 400px;">
                            <h2 align="center">
                                Country Master</h2>
                            <table width="60%">
                                <tr>
                                    <td>
                                        <table width="100%">
                                            <tr class="hdr">
                                                <td align="center">
                                                    Country Code
                                                </td>
                                                <td align="center">
                                                    Country Name
                                                </td>
                                                <td align="center" width="150px">
                                                    Action
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:TextBox ID="txtCode" runat="server" CssClass="TxtBox"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtCode"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox ID="txtCountry" runat="server" CssClass="TxtBox"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtCountry"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:Button ID="btnInsert" CssClass="btnNew" runat="server" OnClick="btnInsert_Click"
                                                        Text="Insert" ValidationGroup="insert"></asp:Button>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left">
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    Status :
                                                </td>
                                                <td align="center">
                                                    <asp:DropDownList ID="ddlRecordStatus" runat="server" AutoPostBack="True" CssClass="DropDown"
                                                        OnSelectedIndexChanged="ddlRecordStatus_SelectedIndexChanged" Width="100px">
                                                        <asp:ListItem Selected="True" Value="1">Active</asp:ListItem>
                                                        <asp:ListItem Value="0">Inactive</asp:ListItem>
                                                    </asp:DropDownList>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center">
                                        <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                                        <asp:GridView ID="gdvCountry" runat="server" AutoGenerateColumns="False" DataKeyNames="Cntry_Id"
                                            CellPadding="3" AllowPaging="True" Width="100%" OnPageIndexChanging="gdvCountry_PageIndexChanging"
                                            OnRowCancelingEdit="gdvCountry_RowCancelingEdit" OnRowEditing="gdvCountry_RowEditing"
                                            OnRowUpdating="gdvCountry_RowUpdating" CssClass="mGrid" GridLines="Vertical"
                                            OnRowDataBound="gdvCountry_RowDataBound" EmptyDataText="Sorry! No record found." HeaderStyle-ForeColor="White" onsorting="gdvCountry_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="Cntry_Name">
                                            <AlternatingRowStyle CssClass="alt" />
                                            <FooterStyle CssClass="footer" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Cntry_Id")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEId" runat="server" Text='<%#Bind("Cntry_Id")%>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Country Code" SortExpression="Cntry_Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Cntry_Code")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtECode" runat="server" CssClass="TxtBox" Text='<%#Bind("Cntry_Code")%>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Country Name" SortExpression="Cntry_Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCountry" runat="server" Text='<%#Eval("Cntry_Name")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtECountry" runat="server" CssClass="TxtBox" Text='<%#Bind("Cntry_Name")%>'></asp:TextBox>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="EditButton" CommandName="Edit" runat="server" ToolTip="Edit"
                                                            ImageUrl="~/Image/b_edit.png" Width="22px" Height="22px" />
                                                        &nbsp;
                                                        <asp:ImageButton ID="imgbtnActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                                            CssClass="lbtnView" ImageUrl="~/Image/b_drop.png" Height="22px" Width="22px"
                                                            ToolTip="Inactive" />
                                                        &nbsp;
                                                        <asp:ImageButton ID="imgbtnInActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                                            CssClass="lbtnView" ImageUrl="~/Image/Checked.png" Height="22px" Width="22px"
                                                            ToolTip="Active" />
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:LinkButton ID="UpdateButton" CommandName="Update" runat="server" Text="Update"
                                                            CssClass="lbtnUpdate"></asp:LinkButton>
                                                        &nbsp;
                                                        <asp:LinkButton ID="CancelUpdateButton" CommandName="Cancel" runat="server" Text="Cancel"
                                                            CssClass="lbtnCancel" />
                                                    </EditItemTemplate>
                                                    <ItemStyle Width="150px" HorizontalAlign="Center" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </div>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

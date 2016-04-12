<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RoleMaster.aspx.cs" Inherits="Masters_RoleMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <div id="page">
                    <h2 align="center">
                        Role Master</h2>
                    <table width="100%">
                        <tr>
                            <td>
                                <table width="100%">
                                    <tr class="hdr">
                                        <td align="center">
                                            Role Code
                                        </td>
                                        <td align="center">
                                            Role Name
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
                                            <asp:TextBox ID="txtName" runat="server" CssClass="TxtBox"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtName"
                                                ErrorMessage="*" ForeColor="Red" ValidationGroup="insert"></asp:RequiredFieldValidator>
                                        </td>
                                        <td align="center">
                                            <asp:Button ID="btnInsert" CssClass="btnNew" runat="server" OnClick="btnInsert_Click"
                                                Text="Insert" ValidationGroup="insert"></asp:Button>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
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
                            <td>
                                <asp:GridView ID="gdvRole" runat="server" AutoGenerateColumns="False" DataKeyNames="Role_Id"
                                    CellPadding="3" AllowPaging="True" Width="100%" OnPageIndexChanging="gdvRole_PageIndexChanging"
                                    OnRowCancelingEdit="gdvRole_RowCancelingEdit" OnRowEditing="gdvRole_RowEditing"
                                    OnRowUpdating="gdvRole_RowUpdating" CssClass="mGrid" GridLines="Vertical" OnRowDataBound="gdvRole_RowDataBound"
                                    EmptyDataText="No Data.">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <FooterStyle CssClass="footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Role_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:Label ID="lblEId" runat="server" Text='<%#Bind("Role_Id")%>'></asp:Label>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Role Code">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Role_Code")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtECode" runat="server" Text='<%#Bind("Role_Code")%>' CssClass="TxtBox"></asp:TextBox>
                                            </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Role Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Role_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:TextBox ID="txtEName" runat="server" Text='<%#Bind("Role_Name")%>' CssClass="TxtBox"></asp:TextBox>
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
                                                <asp:ImageButton ID="EditButton" CommandName="Edit" runat="server" ToolTip="Edit" ImageUrl="~/Image/b_edit.png" 
                                                Width="22px" Height="22px"/>
                                                &nbsp;
                                                <asp:LinkButton ID="lbActivate" runat="server" OnClick="lbActivate_Click" Font-Underline="false"
                                                    CssClass="lbtnView" />
                                            </ItemTemplate>
                                            <EditItemTemplate>
                                                <asp:LinkButton ID="UpdateButton" CommandName="Update" runat="server" Text="Update"
                                                    CssClass="lbtnUpdate"></asp:LinkButton>
                                                &nbsp;
                                                <asp:LinkButton ID="CancelUpdateButton" CommandName="Cancel" runat="server" Text="Cancel"
                                                    CssClass="lbtnCancel" />
                                            </EditItemTemplate>
                                            <ItemStyle Width="150px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

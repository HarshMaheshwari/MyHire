<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="StateMaster.aspx.cs" Inherits="Masters_StateMaster" %>

<%@ Register Src="~/Masters/MasterMenu.ascx" TagName="MstrMenu" TagPrefix="MCntrl" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table width="100%">
                <tr>
                    <td align="left" valign="top" width="200">
                        <MCntrl:MstrMenu ID="VMenu" runat="server" />
                    </td>
                    <td align="center">
                        <div id="page">
                            <h2>
                                State Master</h2>
                            <table width="60%">
                                <tr class="Label">
                                    <td>
                                        <table width="100%">
                                            <tr class="hdr">
                                                <td align="center">
                                                    State Code
                                                </td>
                                                <td align="center">
                                                    State Name
                                                </td>
                                                <td align="center">
                                                    Country
                                                </td>
                                                <td align="center" width="150px">
                                                    Action
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="center">
                                                    <asp:TextBox CssClass="TxtBox" ID="txtCode" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtCode"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:TextBox CssClass="TxtBox" ID="txtState" runat="server"></asp:TextBox>
                                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtState"
                                                        ErrorMessage="*" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                                </td>
                                                <td width="27%" align="center">
                                                    <asp:DropDownList ID="ddlCounrty" runat="server" CssClass="DropDown" AppendDataBoundItems="True">
                                                    </asp:DropDownList>
                                                    <asp:CompareValidator ID="cv1" runat="server" ControlToValidate="ddlCounrty" ErrorMessage="*"
                                                        ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="Save" ValueToCompare="0"></asp:CompareValidator>
                                                </td>
                                                <td align="center">
                                                    <asp:Button ID="btnInsert" CssClass="btnNew" runat="server" OnClick="btnInsert_Click"
                                                        Text="Insert" ValidationGroup="Save"></asp:Button>
                                                </td>
                                            </tr>
                                            <tr class="Label">
                                                <td align="right" colspan="2">
                                                    &nbsp;
                                                </td>
                                                <td align="right">
                                                    Status :
                                                </td>
                                                <td>
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
                                        <asp:GridView ID="gdvState" runat="server" AutoGenerateColumns="False" DataKeyNames="State_Id"
                                            CellPadding="3" AllowPaging="True" Width="100%" OnPageIndexChanging="gdvState_PageIndexChanging"
                                            OnRowCancelingEdit="gdvState_RowCancelingEdit" OnRowDataBound="gdvState_RowDataBound"
                                            OnRowEditing="gdvState_RowEditing" OnRowUpdating="gdvState_RowUpdating" GridLines="Vertical"
                                            CssClass="mGrid" EmptyDataText="Sorry! No record found." HeaderStyle-ForeColor="White" onsorting="gdvState_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="State_Name">
                                            <AlternatingRowStyle CssClass="alt" />
                                            <FooterStyle CssClass="footer" />
                                            <Columns>
                                                <asp:TemplateField HeaderText="ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("State_Id")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblEId" runat="server" Text='<%#Bind("State_Id")%>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="State Code" SortExpression="State_Code">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCode" runat="server" Text='<%#Eval("State_Code")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtECode" runat="server" CssClass="TxtBox" Text='<%#Bind("State_Code")%>'
                                                            ValidationGroup="update"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv11" runat="server" ControlToValidate="txtECode"
                                                            ErrorMessage="*" ValidationGroup="update"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="State Name"  SortExpression="State_Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblState" runat="server" Text='<%#Eval("State_Name")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:TextBox ID="txtEState" runat="server" CssClass="TxtBox" Text='<%#Bind("State_Name")%>'
                                                            BorderColor="Black" ValidationGroup="update"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtEState"
                                                            ErrorMessage="*" ValidationGroup="update"></asp:RequiredFieldValidator>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Country Name" SortExpression="Cntry_Name">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCountry" runat="server" Text='<%#Eval("Cntry_Name")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:DropDownList ID="ddlECntryName" CssClass="DropDown" runat="server" ValidationGroup="update"
                                                            AppendDataBoundItems="true">
                                                            <asp:ListItem Text="India" Value="1"></asp:ListItem>
                                                        </asp:DropDownList>
                                                        <asp:CompareValidator ID="cv1" runat="server" ErrorMessage="Select" Operator="NotEqual"
                                                            ValidationGroup="update" ValueToCompare="Select" ControlToValidate="ddlECntryName"></asp:CompareValidator>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Country ID" Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblCountryId" runat="server" Text='<%#Eval("Cntry_Id")%>'></asp:Label>
                                                    </ItemTemplate>
                                                    <EditItemTemplate>
                                                        <asp:Label ID="lblECountryId" runat="server" Text='<%#Eval("Cntry_Id")%>'></asp:Label>
                                                    </EditItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Status" Visible="false" SortExpression="Status">
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
                                <tr>
                                    <td align="center">
                                        &nbsp;
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

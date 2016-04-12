<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RRConsultant.aspx.cs" Inherits="RecMgmt_RRConsultant" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div id="page">
                <h2>
                    Recruitment Consultant</h2>
                <table width="100%" align="center">
                    <tr>
                        <td align="right" colspan="5">
                            <asp:LinkButton ID="lbBack" runat="server" CssClass="lblHistory" OnClick="lbBack_Click">Back</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                            Consultant :
                        </td>
                        <td align="left" width="20%">
                            <asp:DropDownList ID="ddlConsultant" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv9" runat="server" ControlToValidate="ddlConsultant" ErrorMessage="*"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"></asp:CompareValidator>
                        </td>
                        <td align="right" width="20%">
                            Date :
                        </td>
                        <td align="left" width="20%">
                            <asp:TextBox ID="txtDate" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                PopupButtonID="txtDate" TargetControlID="txtDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDate"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                        </td>
                        <td align="center" width="20%">
                            <asp:Button ID="btnsave" runat="server" CssClass="btnSave" OnClick="btnsave_Click"
                                Text="Save" ValidationGroup="save" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="5">
                            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
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
                    <tr>
                        <td colspan="5">
                            <asp:GridView ID="gdvConsultant" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                                CssClass="mGrid" DataKeyNames="Relation_Id" EmptyDataText="Sorry! No Record Found."
                                OnPageIndexChanging="gdvConsultan_PageIndexChanging" OnRowDataBound="gdvConsultan_RowDataBound">
                                <Columns>
                                    <asp:TemplateField HeaderText="Relation Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Relation_Id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="User Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblUser" runat="server" Text='<%#Eval("USR_Name") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email Id">
                                        <ItemTemplate>
                                            <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("USR_Email") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Assigned Date">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Assign_Date") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="imgbtnActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                                CssClass="lbtnView" ImageUrl="~/Image/b_drop.png" Height="22px" Width="22px"
                                                ToolTip="Inactive" />
                                            &nbsp;
                                            <asp:ImageButton ID="imgbtnInActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                                CssClass="lbtnView" ImageUrl="~/Image/Checked.png" Height="22px" Width="22px"
                                                ToolTip="Active" />
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

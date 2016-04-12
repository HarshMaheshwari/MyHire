<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UserList.aspx.cs" Inherits="UserList" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>--%>
      <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server" EnablePartialRendering="true">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <div id="page">
                    <asp:Panel ID="Panel2" runat="server">
                        <h2>
                            User List
                        </h2>
                        <table width="100%">
                         <tr>
                                <td align="left" colspan="6">
                                    <asp:Button ID="btnNew" runat="server" Text="New User" CssClass="btnNew" OnClick="btnNew_Click" />
                                </td>
                                </tr>
                            <tr>
                               
                                <td>User Name</td><td>Email Id</td><td>Role</td><td>Reporting Manager</td><td>Status</td><td></td>
                            </tr>
                             <tr>
                             
                                <td><asp:TextBox ID="txtUserNam" runat="server" CssClass="TxtBox" ></asp:TextBox></td>
                                <td><asp:TextBox ID="txtEmailId" runat="server" CssClass="TxtBox" ></asp:TextBox> </td>
                                <td>    <asp:DropDownList ID="ddlRole" runat="server" CssClass="DropDown" AppendDataBoundItems="True">
                              
                                </asp:DropDownList></td>
                                                   <td>    <asp:DropDownList ID="ddlManager" runat="server" CssClass="DropDown" AppendDataBoundItems="True">
                                                  
                                                    </asp:DropDownList></td>
                                                     <td>    <asp:DropDownList runat="server" ID="ddlStatus" class="chzn-select" Width="140px"  AutoPostBack="true" AppendDataBoundItems="True" OnSelectedIndexChanged="ddlStatus_SelectedIndexChanged">  </asp:DropDownList>
                                                   </td>
                                                    <td> <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search"  OnClick="btnSearch_Click"/></td>
                            </tr>
                            <tr>
                                <td colspan="6">
                                    <asp:GridView ID="gdvUser" runat="server" AutoGenerateColumns="False" DataKeyNames="USR_ID"
                                        CellPadding="3" AllowPaging="True" Width="100%" OnPageIndexChanging="gdvUser_PageIndexChanging"
                                        OnRowCancelingEdit="gdvUser_RowCancelingEdit" OnRowEditing="gdvUser_RowEditing"
                                        OnRowUpdating="gdvUser_RowUpdating" CssClass="mGrid" GridLines="Vertical" OnRowDataBound="gdvUser_RowDataBound"
                                        EmptyDataText="Sorry! No record found." HeaderStyle-ForeColor="White" onsorting="gdvUser_Sorting" AllowSorting="true"  CurrentSortDirection="Asc" CurrentSortField="USR_Name">
                                        <AlternatingRowStyle CssClass="alt" />
                                        <FooterStyle CssClass="footer" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("USR_ID")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblEId" runat="server" Text='<%#Eval("USR_ID")%>'></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="S.No." SortExpression="USR_ID">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="User Name" SortExpression="USR_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtEName" runat="server" Text='<%#Bind("USR_Name")%>' CssClass="TxtBox"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                               <asp:TemplateField HeaderText="Mobile No" SortExpression="USR_Mobile">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUSR_Mobile" runat="server" Text='<%#Eval("USR_Mobile")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtEUSR_Mobile" runat="server" Text='<%#Bind("USR_Mobile")%>' CssClass="TxtBox" ></asp:TextBox>
                                                  <asp:FilteredTextBoxExtender runat="server" ID="txtfieldextender" TargetControlID="txtEUSR_Mobile" FilterMode="ValidChars" FilterType="Numbers"></asp:FilteredTextBoxExtender>
                                                </EditItemTemplate> 
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email Id " SortExpression="USR_Email">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("USR_Email")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtEEmail" runat="server" Text='<%#Bind("USR_Email")%>' CssClass="TxtBox"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Role" SortExpression="Role_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRole" runat="server" Text='<%#Eval("Role_Name")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblERole" runat="server" Text='<%#Eval("USR_Role")%>' Visible="false"></asp:Label>
                                                    <asp:DropDownList ID="ddlERole" runat="server" CssClass="DropDown">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Reporting Manager" SortExpression="ReportingMgr">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblManager" runat="server" Text='<%#Eval("ReportingMgr")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblEManagerId" runat="server" Text='<%#Eval("ReportingMgr_Id")%>'
                                                        Visible="false"></asp:Label>
                                                    <asp:DropDownList ID="ddlEManager" runat="server" CssClass="DropDown">
                                                    </asp:DropDownList>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status" SortExpression="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblEStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" ItemStyle-HorizontalAlign="Center">
                                                <ItemTemplate>
                                                    <asp:ImageButton ID="lbtnEdit" CommandName="Edit" runat="server" ToolTip="Edit" ImageUrl="~/Image/b_edit.png"
                                                        Width="22px" Height="22px" />
                                                    <asp:ImageButton ID="imgbtnActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                                        CssClass="lbtnView" ImageUrl="~/Image/b_drop.png" Height="22px" Width="22px"
                                                        ToolTip="Inactive" />
                                                    &nbsp;
                                                    <asp:ImageButton ID="imgbtnInActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                                        CssClass="lbtnView" ImageUrl="~/Image/Checked.png" Height="22px" Width="22px"
                                                        ToolTip="Active" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="lbtnUpdate" CommandName="Update" runat="server" Text="Update"
                                                        CssClass="lbtnUpdate" />
                                                    &nbsp;
                                                    <asp:LinkButton ID="lbtnCancel" runat="server" Font-Underline="false" Text="Cancel"
                                                        CommandName="Cancel" CssClass="lbtnCancel" />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="6">
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

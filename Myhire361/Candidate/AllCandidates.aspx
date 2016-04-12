<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="AllCandidates.aspx.cs" Inherits="Recruitment_AllCandidates" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
<style type="text/css">
        .clsWrap
        {
            word-break: break-all;
        }
</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page" style="min-height: 450px">
            <h2>
                Candiadte List</h2>
            <table width="100%" align="center">
                <tr>
                    <td width="20%" align="center">
                        <asp:Button ID="btnAdd" runat="server" CssClass="btnSave" OnClick="btnAdd_Click"
                            Text="Add" />
                    </td>
                    <td width="20%" align="center">
                        Name
                    </td>
                    <td width="20%" align="center">
                        Mobile No
                    </td>
                    <td width="20%" align="center">
                        Email id
                    </td>
                    <td width="20%">
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center">
                    </td>
                    <td width="20%" align="center">
                        <asp:TextBox ID="txtName" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                    </td>
                    <td width="20%" align="center">
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                    </td>
                    <td width="20%" align="center">
                        <asp:TextBox ID="txtEmailId" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                    </td>
                    <td width="20%">
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center">
                        &nbsp;Experience
                    </td>
                    <td width="20%" align="center">
                        CTC
                    </td>
                    <td width="20%" align="center">
                        Key Skills/Industry
                    </td>
                    <td width="20%" align="center">
                        Location
                    </td>
                    <td width="20%">
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:TextBox ID="txtExpFrom" runat="server" Width="80px" CssClass="TxtBox"></asp:TextBox>
                        &nbsp;to
                        <asp:TextBox ID="txtExpTo" runat="server" Width="80px" CssClass="TxtBox"></asp:TextBox>
                    </td>
                    <td width="20%" align="center">
                        <asp:TextBox ID="txtCTCFrom" runat="server" Width="80px" CssClass="TxtBox"></asp:TextBox>
                        &nbsp;to
                        <asp:TextBox ID="txtCTCTo" runat="server" Width="80px" CssClass="TxtBox"></asp:TextBox>
                    </td>
                    <td width="20%" align="center">
                        <asp:TextBox ID="txtKeySkills" runat="server" CssClass="TxtBox"></asp:TextBox>
                    </td>
                    <td width="20%" align="center">
                        <asp:TextBox ID="txtLocation" runat="server" CssClass="TxtBox"></asp:TextBox>
                    </td>
                    <td align="center">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" OnClick="btnSearch_Click"
                            Text="Search" />
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle" colspan="5">
                        <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td colspan="5">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:GridView ID="gdvCandidate" runat="server" AutoGenerateColumns="False" DataKeyNames="Candidate_Id"
                                    AllowPaging="True" Width="100%" OnPageIndexChanging="gdvCandidate_PageIndexChanging"
                                    GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                                    OnRowCommand="gdvCandidate_RowCommand" PageSize="25" HeaderStyle-ForeColor="White"
                                    OnSorting="gdvCandidate_Sorting" AllowSorting="true" CurrentSortDirection="Desc"
                                    CurrentSortField="Client_Name">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <FooterStyle CssClass="footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" SortExpression="Candidate_Name" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile No." SortExpression="Mobile_No" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile_No")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email Id" SortExpression="Email" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Experience" SortExpression="WorkExp">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExp" runat="server" Text='<%#Eval("WorkExp")%>' Width="120px" CssClass="clsWrap"  ></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Left" Width="120px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Current Employer" SortExpression="Current_Employer">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCEmp" runat="server" Text='<%#Eval("Current_Employer")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                             <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Previous Employer" SortExpression="Previous_Employer" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPEmp" runat="server" Text='<%#Eval("Previous_Employer")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                                 <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Designation" SortExpression="Current_Designation">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesg" runat="server" Text='<%#Eval("Current_Designation")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                         <ItemStyle HorizontalAlign="Left" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CTC" SortExpression="Annual_Salary" HeaderStyle-Width="50px"
                                            ItemStyle-Width="50px">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCTC" runat="server" Text='<%#Eval("Annual_Salary")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                           <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="University/College" SortExpression="University" HeaderStyle-Width="40px"
                                            ItemStyle-Width="40px" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUni" runat="server" Text='<%#Eval("University")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                           <ItemStyle HorizontalAlign="Left" Width="40px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" HeaderStyle-Width="120px" ItemStyle-Width="120px">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ViewButton" ImageUrl="~/Image/view.png" Height="22px" Width="22px"
                                                    CommandName="View" runat="server" ToolTip="View" />
                                                <asp:ImageButton ID="EditButton" ImageUrl="~/Image/b_edit.png" Height="22px" Width="22px"
                                                    CommandName="Edit" runat="server" ToolTip="Edit" />
                                                <asp:ImageButton ID="lbtnHistory" runat="server" CommandName="History" ImageUrl="~/Image/History.jpg"
                                                    ToolTip="RRHistory"></asp:ImageButton>
                                                <asp:ImageButton ID="imgbtnVideo" runat="server" CommandName="Video" ImageUrl="~/Image/VideoIcon.png"
                                                    ToolTip="Send Video Link" Height="25px" Width="25px"></asp:ImageButton>
                                                <asp:ImageButton ID="imgbtnViewVideo" runat="server" CommandName="ViewVideo" ImageUrl="~/Image/Video.png"
                                                    ToolTip="View Candidate Video" Height="22px" Width="22px"></asp:ImageButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="120px" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>

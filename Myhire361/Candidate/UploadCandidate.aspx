<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="UploadCandidate.aspx.cs" Inherits="Candidate_UploadCandidate" %>

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
                Upload Resume</h2>
            <table width="100%" align="center">
                <tr>
                    <td width="20%" align="center">
                        Name
                    </td>
                    <td width="20%" align="center">
                        Mobile No
                    </td>
                   
                    <td width="20%" align="center">
                        Source
                    </td>
                    <td width="20%" align="left">
                        Action
                    </td>
                </tr>
                <tr>
                    <td width="20%" align="center">
                        <asp:TextBox ID="txtName" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                    </td>
                    <td width="20%" align="center">
                        <asp:TextBox ID="txtMobile" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                    </td>
                    
                    <td width="20%" align="center">
                        <asp:DropDownList class="chzn-select" ID="ddlSource" runat="server" AppendDataBoundItems="true"
                            Width="160px">
                        </asp:DropDownList>
                    </td>
                    <td width="20%">
                        <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" OnClick="btnSearch_Click"
                            Text="Search" />
                    </td>
                </tr>
                <tr>
                    <td align="center" valign="middle" colspan="4">
                        <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>

                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                            <ContentTemplate>
                                <asp:Panel ID="Panel1" runat="server">
                                    <asp:GridView ID="gdvCandidate" runat="server" AutoGenerateColumns="False" DataKeyNames="Candidate_Id"
                                        AllowPaging="false" Width="100%"  GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                                        HeaderStyle-ForeColor="White" OnSorting="gdvCandidate_Sorting" AllowSorting="true"
                                        CurrentSortDirection="Asc" CurrentSortField="CreationDate">
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
                                            <asp:TemplateField HeaderText="Name" SortExpression="Candidate_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile No." SortExpression="Mobile_No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile_No")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email Id" SortExpression="Email" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" Width="100px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Creation Date" SortExpression="CreationDate">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCreationDate" runat="server" Text='<%#Eval("CreationDate").ToString()%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="URL" SortExpression="Resumer_Id">
                                                <ItemTemplate>
                                               <asp:HyperLink ID="HyperLink3" runat="server" Target="HyperLink" NavigateUrl='<%# String.Format("http://{0}", Eval("Resumer_Id").ToString()) %>'
                                            Text='<%# Bind("Resumer_Id") %>'></asp:HyperLink>


                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="200px" />
                                                <ItemStyle HorizontalAlign="Left" Width="200px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Resume_Path" SortExpression="Resume_Path">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUrl" runat="server" Text='<%#Eval("Resume_Path")%>' Width="80px"
                                                        Visible="false"></asp:Label>
                                                    <asp:FileUpload ID="flUploadUrl" runat="server" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Source" SortExpression="Source">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSource" runat="server" Text='<%#Eval("Source")%>'></asp:Label>
                                                    <asp:TextBox ID="txtSource" runat="server" Text='<%#Eval("Source")%>' Width="120px"
                                                        Visible="false"></asp:TextBox>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="140px" />
                                                <ItemStyle HorizontalAlign="Left" Width="140px" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action" HeaderStyle-Width="60px" ItemStyle-Width="60px"
                                                Visible="false">
                                                <ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="lbtnEdit" ToolTip="Upload URL" ImageUrl="~/Image/Upload5.jpg"
                                                        Height="32px" Width="32px" Visible="false" />
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                                <ItemStyle HorizontalAlign="Left" Width="60px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </asp:Panel>
                                </td></tr>
                                <tr>
                                    <td align="center" valign="middle" colspan="4">
                                        <asp:Button ID="btnUpload" runat="server" CssClass="btnCancel" OnClick="btnUpload_Click"
                                            Text="Save" Width="100px" />
                                    </td>
                                </tr>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
        </div>
    </center>
</asp:Content>

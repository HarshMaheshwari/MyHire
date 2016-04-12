<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AssignCandidate.aspx.cs" Inherits="Recruitment_AssignCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $("[id*=chkHeader]").live("click", function () {

            var chkHeader = $(this);
            var grid = $(this).closest("table");
            $("input[type=checkbox]", grid).each(function () {
                if (chkHeader.is(":checked")) {
                    $(this).attr("checked", "checked");
                    $("td", $(this).closest("tr")).addClass("selected");
                } else {
                    $(this).removeAttr("checked");
                    $("td", $(this).closest("tr")).removeClass("selected");
                }
            });
        });
        $("[id*=chkRow]").live("click", function () {
            var grid = $(this).closest("table");
            var chkHeader = $("[id*=chkHeader]", grid);
            if (!$(this).is(":checked")) {
                $("td", $(this).closest("tr")).removeClass("selected");
                chkHeader.removeAttr("checked");
            } else {
                $("td", $(this).closest("tr")).addClass("selected");
                if ($("[id*=chkRow]", grid).length == $("[id*=chkRow]:checked", grid).length) {
                    chkHeader.attr("checked", "checked");
                }
            }
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <div id="page">
                    <h2>
                        Candidate List</h2>
                    <table width="100%">
                        <tr>
                            <td width="10%" align="right">
                                RRNumber:
                            </td>
                            <td width="23%">
                                <asp:Label ID="lblRRNumber" runat="server"></asp:Label>
                            </td>
                            <td width="10%" align="right">
                                Client Name:
                            </td>
                            <td width="23%">
                                <asp:Label ID="lblClient" runat="server"></asp:Label>
                            </td>
                            <td width="10%" align="right">
                                Designation:
                            </td>
                            <td width="23%">
                                <asp:Label ID="lblDesignation" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" align="center">
                        <tr style="width: 90%">
                            <td align="right" valign="middle" colspan="7">
                                <%--       <asp:LinkButton ID="lbBack" runat="server" CssClass="lblHistory" OnClick="lbBack_Click">Back</asp:LinkButton>--%>
                            </td>
                        </tr>
                        <tr style="width: 90%">
                            <td align="center" width="14%">
                                Designation
                            </td>
                            <td align="center" width="14%">
                                Industry
                            </td>
                            <td align="center" width="14%">
                                CTC
                            </td>
                            <td align="center" width="14%">
                                Work Exp
                            </td>
                            <td width="14%" align="center">
                                Current Location
                            </td>
                            <td width="14%" align="center">
                                Current Employer
                            </td>
                            <td align="center">
                            </td>
                        </tr>
                        <tr style="width: 90%">
                            <td align="center" width="13%">
                                <asp:TextBox ID="txtDesg" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                            </td>
                            <td align="center" width="13%">
                                <asp:TextBox ID="txtIndustry" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                            </td>
                            <td align="center" width="13%">
                                <asp:TextBox ID="txtCtc" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                            </td>
                            <td align="center" width="13%">
                                <asp:TextBox ID="txtExp" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                            </td>
                            <td width="13%" align="center">
                                <asp:TextBox ID="txtLocation" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                            </td>
                            <td width="13%" align="center">
                                <asp:TextBox ID="txtEmp" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" 
                                    Text="Search" onclick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="7">
                                <asp:GridView ID="gdvCandidate" runat="server" AutoGenerateColumns="False" DataKeyNames="Candidate_Id"
                                    AllowPaging="True" Width="100%" GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                                    PageSize="25" onpageindexchanging="gdvCandidate_PageIndexChanging" >
                                    <AlternatingRowStyle CssClass="alt" />
                                    <FooterStyle CssClass="footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderStyle-Width="5%">
                                            <HeaderTemplate>
                                                All<asp:CheckBox ID="chkHeader" runat="server" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkRow" runat="server" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Candidate Name" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCandidateName" runat="server" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile No" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMob" runat="server" Text='<%#Eval("Mobile_No")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="6%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email")%>' Font-Bold="true"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Work Exp" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblExp" runat="server" Text='<%#Eval("WorkExp")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CTC" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCTC" runat="server" Text='<%#Eval("Annual_Salary")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Current Location" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblLocation" runat="server" Text='<%#Eval("Current_Location")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Current Employer" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmployer" runat="server" Text='<%#Eval("Current_Employer")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Designation" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblDesg" runat="server" Text='<%#Eval("Current_Designation")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Industry" HeaderStyle-Width="10%">
                                            <ItemTemplate>
                                                <asp:Label ID="lblIndustry" runat="server" Text='<%#Eval("Industry")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="7">
                                <asp:Button ID="btnSave" runat="server" Text="Submit" CssClass="btnSave" 
                                    onclick="btnSave_Click"  />
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


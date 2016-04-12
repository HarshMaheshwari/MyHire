<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RRACandidateList_N.aspx.cs" Inherits="Recruitment_RRACandidateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <div id="page">
                    <h2>
                       RR Candidate List</h2>
                    <table width="100%" align="center">
                        <tr style="width: 90%">
                            <td align="right" valign="middle" colspan="4">
                                <asp:LinkButton ID="lbBack" runat="server" CssClass="lblHistory" OnClick="lbBack_Click">Back</asp:LinkButton>
                            </td>
                        </tr>

                         <tr style="width: 70%">
                           
                           <td align="right">
                                Client Name :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtClientname" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="left" width="230px">
                                RR-Number :  <asp:TextBox ID="txtRRNo" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="left">
                              
                            </td> </tr>
                          <tr style="width: 90%">
                            <td align="center" width="25%">
                               Refered 
                            </td>
                            <td align="center" width="25%">
                               Referd By
                            </td>
                            <td align="center" width="25%">
                               Show My Name
                            </td>
                            <td align="right" valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="width: 90%">
                            <td align="center" width="25%">
                                <asp:TextBox ID="txtRefered" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="center" width="25%">
                                 <asp:TextBox ID="txtRefBy" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="center" width="25%">
                               <asp:TextBox ID="txtShowName" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="center" valign="top">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" OnClick="btnSearch_Click"
                                    Text="Search" />
                            </td>
                        </tr>
                        <tr style="width: 90%">
                            <td align="right" valign="middle" colspan="2">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" colspan="2" valign="middle">
                                Status :
                                <asp:DropDownList ID="ddlRecordStatus" runat="server" AutoPostBack="True" 
                                    CssClass="DropDown" 
                                    OnSelectedIndexChanged="ddlRecordStatus_SelectedIndexChanged" Width="100px">
                                    <asp:ListItem Selected="True" Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:GridView ID="gdvRRCandidate" runat="server" AutoGenerateColumns="False" DataKeyNames="Candidate_Id"
                                    AllowPaging="True" Width="100%" OnPageIndexChanging="gdvRRCandidate_PageIndexChanging"
                                    GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                                    OnRowCommand="gdvRRCandidate_RowCommand" PageSize="25"
                                    HeaderStyle-ForeColor="White" onsorting="gdvRRCandidate_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="Refered">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <FooterStyle CssClass="footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RRID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRRId" runat="server" Text='<%#Eval("RRCandidate_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                        <asp:TemplateField HeaderText="Refered" SortExpression="Refered">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefered" runat="server" Text='<%#Eval("Refered")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Referd By" SortExpression="ReferdByNm">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRederdBy" runat="server" Text='<%#Eval("ReferdByNm")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Show My Name" SortExpression="ShowName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblShowName" runat="server" Text='<%#Eval("ShowName")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                            <asp:ImageButton ID="History" CommandName="History" runat="server" ImageUrl="~/Image/History.jpg"
                                                    ToolTip="History" Height="22px" Width="22px" />
                                                <asp:LinkButton ID="ViewButton" CommandName="View" runat="server" Text="View" CssClass="lbtnEdit"
                                                    Visible="false" />
                                                &nbsp;
                                                <asp:LinkButton ID="FollowUp" CommandName="FollowUp" runat="server" Text="FollowUp"
                                                    Visible="false" CssClass="lbtnEdit" />
                                                &nbsp;
                                                
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



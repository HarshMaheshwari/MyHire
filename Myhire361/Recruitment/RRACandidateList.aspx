<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RRACandidateList.aspx.cs" Inherits="Recruitment_RRACandidateList" %>

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
                        <td colspan="3">
                        <table width="100%">
                         <tr style="width: 70%">
                           
                           <td align="right">
                                Client Name :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtClientname" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="right" >
                                RR-Number : 
                            </td>
                            <td align="left">
                               <asp:TextBox ID="txtRRNo" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td> </tr>
                        </table>
                        </td>
                            <td align="right" valign="middle" >
                                <asp:LinkButton ID="lbBack" runat="server" CssClass="lblHistory" OnClick="lbBack_Click">Back</asp:LinkButton>
                            </td>
                        </tr>
                           
                         <tr style="width: 90%">
                            <td align="center" width="25%">
                                Name
                            </td>
                            <td align="center" width="25%">
                                Mobile No
                            </td>
                            <td align="center" width="25%">
                                CTC
                            </td>
                            <td align="right" valign="middle">
                                &nbsp;
                            </td>
                        </tr>
                        <tr style="width: 90%">
                            <td align="center" width="25%">
                                <asp:TextBox ID="txtName" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="center" width="25%">
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="center" width="25%">
                                <asp:TextBox ID="txtCtc" runat="server" CssClass="TxtBox"></asp:TextBox>
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
                                <asp:GridView ID="gdvCandidate" runat="server" AutoGenerateColumns="False" DataKeyNames="Candidate_Id"
                                    AllowPaging="True" Width="100%" OnPageIndexChanging="gdvCandidate_PageIndexChanging"
                                    GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                                    OnRowCommand="gdvCandidate_RowCommand" PageSize="25"
                                     HeaderStyle-ForeColor="White" onsorting="gdvCandidate_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="Refered">
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
                                     <asp:TemplateField HeaderText="Referred" SortExpression="Refered">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRefered" runat="server" Text='<%#Eval("Refered")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" width="50px"/>
                                            <ItemStyle HorizontalAlign="Left" width="50px"/>
                                        </asp:TemplateField>

                                             <asp:TemplateField HeaderText="Referred By" SortExpression="ReferdByNm">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRederdBy" runat="server" Text='<%#Eval("ReferdByNm")%>' Visible='<%#Eval("ShowName").ToString() == "Yes" ? true : false%>'></asp:Label>
                                                  
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" width="150px" />
                                            <ItemStyle HorizontalAlign="Left" width="150px" />
                                        </asp:TemplateField>

                                      <asp:TemplateField HeaderText="Name" SortExpression="Candidate_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" width="150px" />
                                            <ItemStyle HorizontalAlign="Left" width="150px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile No." SortExpression="Mobile_No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile_No")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center"  width="80px"/>
                                            <ItemStyle HorizontalAlign="Left"  width="80px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CTC" SortExpression="Annual_Salary">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCTC" runat="server" Text='<%#Eval("Annual_Salary")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" width="100px" />
                                            <ItemStyle HorizontalAlign="Left" width="100px" />
                                        </asp:TemplateField>
                                       <%-- <asp:TemplateField HeaderText="Recruiter Status" SortExpression="Recruiter_Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecStatus" runat="server" Text='<%#Eval("Recruiter_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" width="120px"/>
                                            <ItemStyle HorizontalAlign="Left" width="100px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Approver Status" SortExpression="Supervisor_Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApproveStatus" runat="server" Text='<%#Eval("Supervisor_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" width="120px" />
                                            <ItemStyle HorizontalAlign="Left"  width="100px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Candidate Status" SortExpression="Candidate_Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCandStatus" runat="server" Text='<%#Eval("Candidate_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center"  width="125px"/>
                                            <ItemStyle HorizontalAlign="Left" width="100px" />
                                        </asp:TemplateField>--%>

                                         <asp:TemplateField HeaderText="Overall Status" SortExpression="Overall_Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOverall_Status" runat="server" Text='<%#Eval("Overall_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center"  width="125px"/>
                                            <ItemStyle HorizontalAlign="Left" width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ConsultantID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsultantId" runat="server" Text='<%#Eval("Consultant_Id")%>'></asp:Label>
                                            </ItemTemplate>
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

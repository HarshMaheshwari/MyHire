<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CreditReferralPoint.aspx.cs" Inherits="Recruitment_CreditReferralPoint" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="page">
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <h2>
                    Credit Reference Point</h2>
                <table width="100%" align="center">
                    <tr>
                        <td colspan="2">
                            <table width="100%">
                                <tr>
                                    <td align="center" width="20%">
                                        Client Name
                                    </td>
                                    <td align="center" width="20%">
                                        Candidate Status
                                    </td>
                                    <td align="center" width="20%">
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" width="20%">
                                        <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                            Width="200px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="center" width="20%">
                                        <asp:DropDownList ID="ddlCandStatus" runat="server" CssClass="DropDown" AppendDataBoundItems="True">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="center">
                                        <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search" OnClick="btnSearch_Click" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" align="center">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView runat="server" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="RRCandidate_Id"
                                ID="gdvCreditPoint" AllowPaging="True" EmptyDataText="Sorry! No Record Found."
                                OnPageIndexChanging="gdvCreditPoint_PageIndexChanging" PageSize="20" HeaderStyle-ForeColor="White"
                                OnSorting="gdvCreditPoint_Sorting" AllowSorting="true" CurrentSortDirection="Asc"
                                CurrentSortField="Client_Name" OnRowCancelingEdit="gdvCreditPoint_RowCancelingEdit"
                                OnRowEditing="gdvCreditPoint_RowEditing" OnRowUpdating="gdvCreditPoint_RowUpdating">
                                <Columns>
                                    <asp:TemplateField HeaderText="S.No." SortExpression="RRCandidate_Id">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1%>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRRCandidate_Id" runat="server" Text='<%#Eval("RRCandidate_Id") %>'></asp:Label>
                                             <asp:Label ID="lblRequest_Id" runat="server" Text='<%#Eval("Request_Id") %>'></asp:Label>
                                          
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblERRCandidate_Id" runat="server" Text='<%#Eval("RRCandidate_Id") %>'></asp:Label>
                                            <asp:Label ID="lblERequest_Id" runat="server" Text='<%#Eval("Request_Id") %>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Client Name " SortExpression="Client_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name") %>'></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="140px" />
                                        <ItemStyle HorizontalAlign="Left" Width="140px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="RR Number" SortExpression="RRNumber">
                                        <ItemTemplate>
                                            <asp:Label ID="lblRRNo" runat="server" Text='<%#Eval("RRNumber") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Candidate Name" SortExpression="Candidate_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCandidate" runat="server" Text='<%#Eval("Candidate_Name") %>'></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                        <ItemStyle HorizontalAlign="Left" Width="130px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Refered By" SortExpression="ReferedByName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblReferedBy" runat="server" Text='<%#Eval("ReferedBy") %>' Visible="false"></asp:Label>
                                            <asp:Label ID="lblReferedByName" runat="server" Text='<%#Eval("ReferedByName") %>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                        <ItemStyle HorizontalAlign="Left" Width="130px" />
                                    </asp:TemplateField>
                                  
                                    <asp:TemplateField HeaderText="Candidate Status" SortExpression="Overall_Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblOverallStatus" runat="server" Text='<%#Eval("Overall_Status") %>'></asp:Label></ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="140px" />
                                        <ItemStyle HorizontalAlign="Left" Width="140px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Referral Point" SortExpression="TotalReferrerPts">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalReferrerPts" runat="server" Text='<%#Eval("TotalReferrerPts") %>'></asp:Label></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblETotalReferrerPts" runat="server" Text='<%#Eval("TotalReferrerPts") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="140px" />
                                        <ItemStyle HorizontalAlign="Left" Width="120px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Credited Point" SortExpression="TotalCreditPoint">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTotalCreditPoint" runat="server" Text='<%#Eval("TotalCreditPoint") %>'></asp:Label></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblETotalCreditPoint" runat="server" Text='<%#Eval("TotalCreditPoint") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle HorizontalAlign="Left" Width="120px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Balance" SortExpression="BalancePoint">
                                        <ItemTemplate>
                                            <asp:Label ID="lblBalance" runat="server" Text='<%#Eval("BalancePoint") %>'></asp:Label></ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEBalance" runat="server" Text='<%#Eval("BalancePoint") %>'></asp:Label>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                        <ItemStyle HorizontalAlign="Left" Width="120px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Credit Point">
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtCreditPoint" runat="server" Width="100px"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="*" ControlToValidate="txtCreditPoint"
                                                ForeColor="Red" SetFocusOnError="true" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator ID="cv1" runat="server" ErrorMessage="Greater!!" SetFocusOnError="true" ForeColor="Red"
                                                ControlToValidate="txtCreditPoint" Type="Double"  ValueToCompare='<%#Eval("BalancePoint") %>'
                                                ValidationGroup="Update" Operator="LessThanEqual" ></asp:CompareValidator>
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Left" Width="100px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="EditButton" CommandName="Edit" runat="server" ToolTip="Add Credit"
                                                ImageUrl="~/Image/b_edit.png" Width="22px" Height="22px" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="UpdateButton" CommandName="Update" runat="server" Text="Credit"
                                                CssClass="lbtnUpdate" ValidationGroup="Update"></asp:LinkButton>
                                            &nbsp;
                                            <asp:LinkButton ID="CancelUpdateButton" CommandName="Cancel" runat="server" Text="Cancel"
                                                CssClass="lbtnCancel" />
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Left" Width="110px" />
                                    </asp:TemplateField>
                                </Columns>
                                <EmptyDataRowStyle ForeColor="Red" />
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="gdvCreditPoint" EventName="RowCommand" />
            </Triggers>
        </asp:UpdatePanel>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Contract.aspx.cs" Inherits="Report_Contract" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

     <center>

        <table cellpadding="5" cellspacing="5" width="100%">
            <tr>

                <td align="left" valign="top">
                    <table class="tblbg" width="100%">
                        <thead>
                            <tr align="center" valign="top">
                                <td style="font-weight: bold"></td>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td align="left">
                                    <table width="100%">
                                        <tr>

                                            <td style="width: 30%" align="center">From Date
                                            </td>
                                            <td style="width: 30%" align="center">To Date
                                            </td>
                                            <td style="width: 30%" align="right">&nbsp;&nbsp;&nbsp;      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                 
                         <asp:LinkButton ID="lbdownload" runat="server" CssClass="LinkBtn" OnClick="lbdownload_Click" ForeColor="Red">Export to Excel</asp:LinkButton>

                                            </td>

                                        </tr>
                                        <tr>

                                            <td align="center">
                                                <asp:TextBox ID="txtStartDate" runat="server" CssClass="TxtBox" Width="120px"></asp:TextBox>
                                                <asp:CalendarExtender ID="ce1" runat="server" PopupButtonID="txtStartDate" TargetControlID="txtStartDate"
                                                    Format="dd-MMM-yyyy" DefaultView="Months">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td align="center">
                                                <asp:TextBox ID="txtEndDate" runat="server" CssClass="TxtBox" Width="120px"></asp:TextBox>
                                                <asp:CalendarExtender ID="ce2" runat="server" PopupButtonID="txtEndDate" TargetControlID="txtEndDate"
                                                    Format="dd-MMM-yyyy" DefaultView="Months">
                                                </asp:CalendarExtender>
                                            </td>
                                            <td align="center">
                                                <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" OnClick="btnSearch_Click"
                                                    ValidationGroup="save" Text="Search" />
                                            </td>
                                        </tr>
                                        <tr>

                                            <td>
                                                <asp:RegularExpressionValidator ID="Rev1" runat="server" ErrorMessage="Wrong" SetFocusOnError="true"
                                                    ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                                    ControlToValidate="txtStartDate" ValidationGroup="save" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>
                                                <asp:RegularExpressionValidator ID="Rev2" runat="server" ErrorMessage="Wrong" SetFocusOnError="true"
                                                    ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                                    ControlToValidate="txtEndDate" ValidationGroup="save" ForeColor="Red"></asp:RegularExpressionValidator>
                                            </td>
                                            <td>&nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </tbody>
                    </table>
                    <center>
                        <asp:GridView ID="GdvClientcelebration" runat="server" AutoGenerateColumns="False" DataKeyNames="Client_Id,Contact_PersonId"
                            EmptyDataText="No Data Is Found" Width="90%" GridLines="None" CssClass="mGrid" OnRowUpdating="GdvClientcelebration_RowUpdating"
                            AllowPaging="True" ShowFooter="False" PageSize="30" OnPageIndexChanging="GdvClientcelebration_PageIndexChanging"
                            AllowSorting="True" OnSorting="GdvClientcelebration_Sorting" OnRowCancelingEdit="GdvClientcelebration_RowCancelingEdit" OnRowEditing="GdvClientcelebration_RowEditing">
                            <AlternatingRowStyle CssClass="alt" />
                            <FooterStyle CssClass="footer" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <ItemTemplate>
                                        <%#Container.DataItemIndex+1 %>
                                    </ItemTemplate>
                                    <ItemStyle Width="50px" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client ID" Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblClientId" runat="server" Text='<%#Eval("Client_Id")%>'></asp:Label>
                                        <asp:Label ID="lblClntCntPrsnId" runat="server" Text='<%#Eval("Contact_PersonId")%>'></asp:Label>
                                    </ItemTemplate>
                                     <EditItemTemplate>
                                         <asp:Label ID="lblEId" runat="server" Text='<%#Eval("Client_Id")%>'></asp:Label>
                                          <asp:Label ID="lblEClntCntPrsnId" runat="server" Text='<%#Eval("Contact_PersonId")%>'></asp:Label>
                                          </EditItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="Person Name" ControlStyle-Width="100px" SortExpression="Person_Name" HeaderStyle-ForeColor="White" FooterStyle-Width="100px">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPersonName" runat="server" Text='<%#Eval("Person_Name")%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText=" Date Of Birth" ControlStyle-Width="100px" SortExpression="DOB" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                         <asp:Label ID="lblDOBP" runat="server" Text='<%#Eval("Person_Dob")%>'></asp:Label>
                                       
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                         <asp:TextBox ID="txtEDOBP" runat="server" Text='<%#Eval("Person_Dob")%>' Width="150px"></asp:TextBox>
                                        <asp:CalendarExtender ID="CalendarExtender1" runat="server"
                                            TargetControlID="txtEDOBP" PopupButtonID="txtEDOBP" Format="dd/MM/yyyy">
                                        </asp:CalendarExtender>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Anniversary" ControlStyle-Width="100px" SortExpression="Anniversary" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        
                                          <asp:Label ID="lblPerson_Anniversary" runat="server" Text='<%#Eval("Person_Anniversary")%>'></asp:Label>
                                    </ItemTemplate>
                                    <EditItemTemplate>
                                        <asp:TextBox ID="txtEPerson_Anniversary" runat="server" Text='<%#Eval("Person_Anniversary")%>'></asp:TextBox>

                                        <asp:CalendarExtender ID="CalendarExtender2" runat="server"
                                            TargetControlID="txtEPerson_Anniversary" PopupButtonID="txtEPerson_Anniversary" Format="dd/MM/yyyy">
                                        </asp:CalendarExtender>
                                    </EditItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Email" ControlStyle-Width="300px" SortExpression="Email" HeaderStyle-ForeColor="White">
                                    <ItemTemplate>
                                        <asp:Label ID="lblPDob" runat="server" Text='<%#Eval("Person_Email")%>'></asp:Label>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="EditButton" CommandName="Edit" runat="server" ToolTip="Edit"
                                            ImageUrl="~/Image/b_edit.png" Width="22px" Height="22px" />
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

                    </center>
                    <asp:Label ID="lblmsg" runat="server" Style="font-weight: 700" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>

    </center>

</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ClientContact.aspx.cs" Inherits="ClientContact" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <center>
                <div id="page">
                    <asp:Panel ID="Panel1" runat="server">
                        <h2>
                            Client Contact
                        </h2>
                           <table  width="100%">
                              <tr>
                            <td align="right" width="25%">
                                Client Name :
                            </td>
                              <td align="left" width="25%">
                                <asp:Label ID="lblClientNm" runat="server"></asp:Label>
                            </td>
                            <td align="right" width="25%">
                               Consultant Assigned : 
                            </td>
                            <td align="left" width="25%">
                               <asp:Label ID="lblAssignTo" runat="server" ></asp:Label> 
                            </td>
                          
                         

                        </tr>
                      
                                <tr>
                                  <td align="right" width="25%">
                            Contact Name :
                            </td>
                                   <td align="left" width="25%">
                             <asp:Label ID="lblContactName" runat="server" ></asp:Label>
                            </td>
                                   <td align="right" width="25%">
                            Contact Number :
                            </td>
                                   <td align="left" width="25%">
                             <asp:Label ID="lblContactNo" runat="server" ></asp:Label>
                            </td>
                            </tr>
                            </table>
                        <table width="100%">
                            <tr>
                                <td align="right" width="25%" valign="top">
                                    Contact Name :
                                </td>
                                <td align="left" width="25%" valign="top">
                                    <asp:TextBox ID="txtName" runat="server" CssClass="TxtBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtName" ErrorMessage="*"
                                        ForeColor="Red" SetFocusOnError="True" ValidationGroup="save"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="25%" valign="top">
                                    Contact No :
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtCntct" runat="server" CssClass="TxtBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCntct"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="save"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="25%">
                                    Email Id :
                                </td>
                                <td align="left" width="25%">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="TxtBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="save"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="txtEmail"
                                        ErrorMessage="Wrong" ForeColor="Red" SetFocusOnError="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                        ValidationGroup="Save"></asp:RegularExpressionValidator>
                                </td>
                                <td align="right" width="25%">
                                    Date of Birth :
                                </td>
                                <td align="left" width="25%">
                                    <asp:TextBox ID="txtDob" runat="server" CssClass="TxtBox"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDob"
                                        PopupButtonID="txtDob" Format="dd-MMM-yyyy">
                                    </asp:CalendarExtender>
                                    <asp:RegularExpressionValidator ID="Rev2" runat="server" ErrorMessage="Wrong" SetFocusOnError="true"
                                        ForeColor="Red" ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                        ControlToValidate="txtDob" ValidationGroup="Save"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="25%">
                                    Date of Anniversary :
                                </td>
                                <td align="left">
                                    <asp:TextBox ID="txtDoa" runat="server" CssClass="TxtBox"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtDoa"
                                        PopupButtonID="txtDoa" Format="dd-MMM-yyyy">
                                    </asp:CalendarExtender>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Wrong"
                                        ForeColor="Red" SetFocusOnError="true" ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                        ControlToValidate="txtDoa" ValidationGroup="Save"></asp:RegularExpressionValidator>
                                </td>
                                <td>
                                </td>
                                <td>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" colspan="4">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="4">
                                    <asp:Button ID="btnSave" runat="server" CssClass="btnSave" OnClick="btnSave_Click"
                                        Text="Save" ValidationGroup="Save" />
                                    &nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btnCancel" OnClick="btnCancel_Click"
                                        Text="Cancel" />
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="Panel2" runat="server">
                        <h2>
                            Client Contact List
                        </h2>
                        <table  width="100%">
                              <tr>
                            <td align="right" width="25%">
                                Client Name :
                            </td>
                              <td align="left" width="25%">
                                <asp:Label ID="lblClientNm2" runat="server"></asp:Label>
                            </td>
                            <td align="right" width="25%">
                               Consultant Assigned : 
                            </td>
                            <td align="left" width="25%">
                               <asp:Label ID="lblAssignTo2" runat="server" ></asp:Label> 
                            </td>
                          
                         

                        </tr>
                      
                                <tr>
                                  <td align="right" width="25%">
                            Contact Name :
                            </td>
                                   <td align="left" width="25%">
                             <asp:Label ID="lblContactName2" runat="server" ></asp:Label>
                            </td>
                                   <td align="right" width="25%">
                            Contact Number :
                            </td>
                                   <td align="left" width="25%">
                             <asp:Label ID="lblContactNo2" runat="server" ></asp:Label>
                            </td>
                            </tr>
                             
                            </table>
                        <table width="100%">
                            <tr>
                                <td align="left" style="width: 50%">
                                    <asp:Button ID="btnNew" runat="server" Text="New Contact" CssClass="btnNew" OnClick="btnNew_Click" />
                                </td>
                                <td align="right">
                                    <asp:LinkButton ID="lbBack" runat="server" CssClass="lblHistory" OnClick="lbBack_Click">Back</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="gdvContactPerson" runat="server" AutoGenerateColumns="False" DataKeyNames="Contact_PersonId"
                                        CellPadding="3" AllowPaging="True" Width="100%" OnPageIndexChanging="gdvContactPerson_PageIndexChanging"
                                        OnRowCancelingEdit="gdvContactPerson_RowCancelingEdit" OnRowEditing="gdvContactPerson_RowEditing"
                                        OnRowUpdating="gdvContactPerson_RowUpdating" CssClass="mGrid" GridLines="Vertical"
                                        OnRowDataBound="gdvContactPerson_RowDataBound" EmptyDataText="Sorry! No record found.">
                                        <AlternatingRowStyle CssClass="alt" />
                                        <FooterStyle CssClass="footer" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Contact_PersonId")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblEId" runat="server" Text='<%#Eval("Contact_PersonId")%>'></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Person_Name")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtEName" runat="server" Text='<%#Bind("Person_Name")%>' CssClass="TxtBox"
                                                        Width="120px"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contact No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCntct" runat="server" Text='<%#Eval("Person_Contact")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtECtnct" runat="server" Text='<%#Bind("Person_Contact")%>' CssClass="TxtBox"
                                                        Width="120px"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Email Id">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Person_Email")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtEEmail" runat="server" Text='<%#Bind("Person_Email")%>' CssClass="TxtBox"></asp:TextBox>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date of Birth">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDob" runat="server" Text='<%#Eval("Person_Dob")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtEDob" runat="server" Text='<%#Bind("Person_Dob")%>' CssClass="TxtBox"
                                                        Width="120px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtEDob"
                                                        PopupButtonID="txtEDob" Format="dd-MMM-yyyy">
                                                    </asp:CalendarExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Wrong"
                                                        ForeColor="Red" SetFocusOnError="true" ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                                        ControlToValidate="txtEDob" ValidationGroup="Update"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Date of Anniversary">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDoa" runat="server" Text='<%#Eval("Person_Anniversary")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtEDoa" runat="server" Text='<%#Bind("Person_Anniversary")%>' CssClass="TxtBox"
                                                        Width="120px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender3ED" runat="server" TargetControlID="txtEDoa"
                                                        PopupButtonID="txtEDoa" Format="dd-MMM-yyyy">
                                                    </asp:CalendarExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ErrorMessage="Wrong"
                                                        ForeColor="Red" SetFocusOnError="true" ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                                        ControlToValidate="txtEDoa" ValidationGroup="Update"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                                </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblEStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                     <asp:ImageButton ID="lbtnEdit" CommandName="Edit" runat="server" ToolTip="Edit" ImageUrl="~/Image/b_edit.png"
                                                    Width="22px" Height="22px" />
                                                  &nbsp;
                                                 <asp:ImageButton ID="imgbtnActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                        CssClass="lbtnView" ImageUrl="~/Image/b_drop.png" Height="22px" Width="22px"
                                        ToolTip="Inactive" />
                                   
                                    <asp:ImageButton ID="imgbtnInActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                        CssClass="lbtnView" ImageUrl="~/Image/Checked.png" Height="22px" Width="22px"
                                        ToolTip="Active" />
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:LinkButton ID="lbtnUpdate" CommandName="Update" runat="server" Text="Update"
                                                        ValidationGroup="Update" CssClass="lbtnUpdate" />
                                                    &nbsp;
                                                    <asp:LinkButton ID="lbtnCancel" runat="server" Font-Underline="false" CssClass="lbtnCancel"
                                                        Text="Cancel" CommandName="Cancel" />
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

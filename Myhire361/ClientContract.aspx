<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ClientContract.aspx.cs" Inherits="ClientContract" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
  <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>--%>
            <center>
                <div id="page">
                    <asp:Panel ID="Panel1" runat="server">
                        <h2>
                            Client Contract
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
                            <tr valign="top">
                                <td align="right" width="25%" valign="top">
                                    Contract Code :
                                </td>
                                <td align="left" width="25%" valign="top">
                                    <asp:TextBox ID="txtCode" runat="server" CssClass="TxtBox" Width="120px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCode"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="25%" valign="top">
                                    Contract Description :
                                </td>
                                <td align="left" valign="top">
                                    <asp:TextBox ID="txtDesc" runat="server" CssClass="TxtBox" Height="35px" TextMode="MultiLine"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtDesc"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="25%">
                                    Contract Start Date : 
                                </td>
                                <td align="left" width="25%">
                                     <asp:TextBox ID="txtStartDate" runat="server" CssClass="TxtBox" Width="120px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtStartDate"
                                        PopupButtonID="txtStartDate" Format="dd-MMM-yyyy">
                                    </asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtStartDate"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="Rev2" runat="server" ErrorMessage="Wrong" SetFocusOnError="true"
                                        ForeColor="Red" ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                        ControlToValidate="txtStartDate" ValidationGroup="Save"></asp:RegularExpressionValidator>

                                </td>
                                <td align="right" width="25%">
                                    Contract End Date :
                                </td>
                                <td align="left" width="25%">
                                    <asp:TextBox ID="txtEndDate" runat="server" CssClass="TxtBox" Width="120px"></asp:TextBox>
                                    <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtEndDate"
                                        PopupButtonID="txtEndDate" Format="dd-MMM-yyyy">
                                    </asp:CalendarExtender>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtEndDate"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Wrong"
                                        SetFocusOnError="true" ForeColor="Red" ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                        ControlToValidate="txtEndDate" ValidationGroup="Save"></asp:RegularExpressionValidator>

                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="25%">
                                   Client Type :
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlClientType" runat="server" CssClass="DropDown" AppendDataBoundItems="True" Width="130px">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                         <asp:ListItem Text="Full Time" Value="1"></asp:ListItem>
                                         <asp:ListItem Text="Contract" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CVddlClientType" runat="server" ControlToValidate="ddlClientType"
                            ErrorMessage="Select" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True"
                            Type="Integer" ValidationGroup="Save" ValueToCompare="0"></asp:CompareValidator>
                                </td>
                                <td align="right">
                                   Rate % 
                                </td>
                                <td align="left">
                                    
                                     <asp:TextBox ID="txtRatePer" runat="server" CssClass="TxtBox" Width="80px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVtxtRatePer" runat="server" ControlToValidate="txtRatePer"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                     <asp:FilteredTextBoxExtender ID="FTtxtRatePer" runat="server" TargetControlID="txtRatePer" 
                          ValidChars=".0123456789" ></asp:FilteredTextBoxExtender>


                                   
                                </td>
                            </tr>

                            <tr>
                                <td align="right" width="25%">
                                  Bill Date :
                                </td>
                                <td align="left">
                                    <asp:DropDownList ID="ddlBillDate" runat="server" CssClass="DropDown" AppendDataBoundItems="True" Width="130px">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                         <asp:ListItem Text="Joining Date" Value="1"></asp:ListItem>
                                         <asp:ListItem Text="Offered Date" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:CompareValidator ID="CVddlBillDate" runat="server" ControlToValidate="ddlBillDate"
                            ErrorMessage="Select" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True"
                            Type="Integer" ValidationGroup="Save" ValueToCompare="0"></asp:CompareValidator>
                                </td>
                                <td align="right">
                                   Payment Terms :
                                </td>
                                <td align="left">
                                    
                                   <asp:TextBox ID="txtPayTerms" runat="server" CssClass="TxtBox" Width="80px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFVtxtPayTerms" runat="server" ControlToValidate="txtPayTerms"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                     <asp:FilteredTextBoxExtender ID="FTtxtPayTerms" runat="server" TargetControlID="txtPayTerms" 
                          FilterType="Numbers" ></asp:FilteredTextBoxExtender>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" width="25%">
                                 Renewal Alert :
                                </td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rbtnAlert" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                        <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="right">
                                   Alert Before Days :
                                </td>
                                <td align="left">
                                    
                                   <asp:TextBox ID="txtAlertBDay" runat="server" CssClass="TxtBox" Width="80px"></asp:TextBox>
                                  <asp:FilteredTextBoxExtender ID="FTtxtAlertBDay" runat="server" TargetControlID="txtAlertBDay" 
                          FilterType="Numbers" ></asp:FilteredTextBoxExtender>
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
                            Client Contract List
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
                                <td align="left" style="width: 25%">
                                    <asp:Button ID="btnNew" runat="server" Text="New Contract" CssClass="btnNew" OnClick="btnNew_Click" />
                                   
                                </td>
                                <td align="center" style="width: 25%">
                                      <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                                    </td>
                                <td align="right">
                                    <asp:LinkButton ID="lbBack" runat="server" CssClass="lblHistory" OnClick="lbBack_Click">Back</asp:LinkButton>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <asp:GridView ID="gdvContracts" runat="server" AutoGenerateColumns="False" DataKeyNames="Contract_Id"
                                        CellPadding="3" AllowPaging="True" Width="100%" OnPageIndexChanging="gdvContracts_PageIndexChanging"
                                        OnRowCancelingEdit="gdvContracts_RowCancelingEdit" OnRowEditing="gdvContracts_RowEditing"
                                        OnRowUpdating="gdvContracts_RowUpdating" CssClass="mGrid" GridLines="Vertical"
                                        OnRowDataBound="gdvContracts_RowDataBound" EmptyDataText="Sorry! No record found.">
                                        <AlternatingRowStyle CssClass="alt" />
                                        <FooterStyle CssClass="footer" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="Id" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Contract_Id")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblEId" runat="server" Text='<%#Eval("Contract_Id")%>'></asp:Label>
                                                </EditItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="S.No.">
                                                <ItemTemplate>
                                                    <%#Container.DataItemIndex+1 %>
                                                </ItemTemplate>
                                                 <ItemStyle Width="3%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="3%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contract Code">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCode" runat="server" Text='<%#Eval("Contract_Code")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtECode" runat="server" Text='<%#Bind("Contract_Code")%>' CssClass="TxtBox"
                                                        Width="100px"></asp:TextBox>
                                                </EditItemTemplate>
                                                 <ItemStyle Width="6%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="6%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contract Description">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblDesc" runat="server" Text='<%#Eval("Contract_Description")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtEDesc" runat="server" Text='<%#Bind("Contract_Description")%>'
                                                        CssClass="TxtBox" Width="100px"></asp:TextBox>
                                                </EditItemTemplate>
                                                 <ItemStyle Width="10%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Contract Start Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblSDate" runat="server" Text='<%#Eval("StartDate")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtESDate" runat="server" Text='<%#Bind("StartDate")%>' CssClass="TxtBox"
                                                        Width="100px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtESDate"
                                                        PopupButtonID="txtESDate" Format="dd-MMM-yyyy">
                                                    </asp:CalendarExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Wrong"
                                                        SetFocusOnError="true" ForeColor="Red" ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                                        ControlToValidate="txtESDate" ValidationGroup="Update"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                                   <ItemStyle Width="9%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="9%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Contract End Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblEDate" runat="server" Text='<%#Eval("EndDate")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="txtEEDate" runat="server" Text='<%#Bind("EndDate")%>' CssClass="TxtBox"
                                                        Width="100px"></asp:TextBox>
                                                    <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtEEDate"
                                                        PopupButtonID="txtEEDate" Format="dd-MMM-yyyy">
                                                    </asp:CalendarExtender>
                                                    <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ErrorMessage="Wrong"
                                                        SetFocusOnError="true" ForeColor="Red" ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                                        ControlToValidate="txtEEDate" ValidationGroup="Update"></asp:RegularExpressionValidator>
                                                </EditItemTemplate>
                                                 <ItemStyle Width="9%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="9%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Client Type">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClientType" runat="server" Text='<%#Eval("Client_Typetxt")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                     <asp:Label ID="lblClientTypeId" runat="server" Text='<%#Eval("Client_Type")%>' Visible="false"></asp:Label>
                                                    <asp:DropDownList ID="ddlEClientType" runat="server" CssClass="DropDown" AppendDataBoundItems="True" Width="100px">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                         <asp:ListItem Text="Full Time" Value="1"></asp:ListItem>
                                         <asp:ListItem Text="Contract" Value="2"></asp:ListItem> </asp:DropDownList>
                                      <asp:CompareValidator ID="CVddlEClientType" runat="server" ControlToValidate="ddlEClientType"
                                       ErrorMessage="Select" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True"
                                        Type="Integer" ValidationGroup="Update" ValueToCompare="0"></asp:CompareValidator>
                                                </EditItemTemplate>
                                                 <ItemStyle Width="9%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="9%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Rate %">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRate" runat="server" Text='<%#Eval("RatePer")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                   <asp:TextBox ID="txtERatePer" runat="server" CssClass="TxtBox" Width="50px" Text='<%#Eval("RatePer")%>'></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFtxtERatePer" runat="server" ControlToValidate="txtERatePer"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                     <asp:FilteredTextBoxExtender ID="FTtxtERatePer" runat="server" TargetControlID="txtERatePer" 
                                            ValidChars=".0123456789" ></asp:FilteredTextBoxExtender>
                                                </EditItemTemplate>
                                                   <ItemStyle Width="5%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Bill Date">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblBillDate" runat="server" Text='<%#Eval("BillDatetxt")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                     <asp:Label ID="lblBilldateId" runat="server" Text='<%#Eval("BillDate")%>' Visible="false"></asp:Label>
                                                    <asp:DropDownList ID="ddlEBilldate" runat="server" CssClass="DropDown" AppendDataBoundItems="True" Width="110px">
                                        <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                         <asp:ListItem Text="Joining Date" Value="1"></asp:ListItem>
                                         <asp:ListItem Text="Offered Date" Value="2"></asp:ListItem> </asp:DropDownList>
                                      <asp:CompareValidator ID="CVddlEBilldate" runat="server" ControlToValidate="ddlEBilldate"
                                       ErrorMessage="Select" ForeColor="Red" Operator="NotEqual" SetFocusOnError="True"
                                        Type="Integer" ValidationGroup="Update" ValueToCompare="0"></asp:CompareValidator>
                                                </EditItemTemplate>
                                                 <ItemStyle Width="8%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="8%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Payment Terms">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPayTerms" runat="server" Text='<%#Eval("PaymentTearms")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                   <asp:TextBox ID="txtEPayTerms" runat="server" CssClass="TxtBox" Text='<%#Eval("PaymentTearms")%>' Width="60px" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFtxtEPayTerms" runat="server" ControlToValidate="txtEPayTerms"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                     <asp:FilteredTextBoxExtender ID="FTtxtEPayTerms" runat="server" TargetControlID="txtEPayTerms" 
                                           FilterType="Numbers" ></asp:FilteredTextBoxExtender>
                                                </EditItemTemplate>
                                                  <ItemStyle Width="5%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Renewal Alert">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAlert" runat="server" Text='<%#Eval("RenwalAlert")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblEAlert" runat="server" Text='<%#Eval("RenwalAlert")%>' Visible="false"></asp:Label>
                                                    <asp:RadioButtonList ID="rbtnEAlert" runat="server" RepeatDirection="Horizontal">
                                                        <asp:ListItem Value="1">Yes</asp:ListItem>
                                                        <asp:ListItem Selected="True" Value="0">No</asp:ListItem>
                                                    </asp:RadioButtonList>
                                                </EditItemTemplate>
                                                 <ItemStyle Width="7%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="7%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Alert Before Days">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblAlertBD" runat="server" Text='<%#Eval("AlertBeforeDays")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                   <asp:TextBox ID="txtEAlertBD" runat="server" CssClass="TxtBox" Text='<%#Eval("AlertBeforeDays")%>' Width="50px" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFtxtEAlertBD" runat="server" ControlToValidate="txtEAlertBD"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                     <asp:FilteredTextBoxExtender ID="FTtxtEAlertBD" runat="server" TargetControlID="txtEAlertBD" 
                                           FilterType="Numbers" ></asp:FilteredTextBoxExtender>
                                                </EditItemTemplate>
                                                   <ItemStyle Width="5%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="5%" HorizontalAlign="Center" />
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                                </ItemTemplate>
                                                <EditItemTemplate>
                                                    <asp:Label ID="lblEStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                                </EditItemTemplate>
                                                 <ItemStyle Width="6%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="6%" HorizontalAlign="Center" />
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
                                                    <asp:LinkButton ID="lbtnCancel" runat="server" Font-Underline="false" CommandName="Cancel"
                                                        Text="Cancel" CssClass="lbtnCancel" />
                                                </EditItemTemplate>
                                                 <ItemStyle Width="10%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="10%" HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                   
                </div>
            </center>
     <%--   </ContentTemplate>
    </asp:UpdatePanel>--%>
</asp:Content>

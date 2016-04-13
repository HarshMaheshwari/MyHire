<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="new_client.aspx.cs" Inherits="admin_new_new_client" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <link rel="Stylesheet" href="../Styles/PopupP.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

            <center>
                <div id="page">
                    <h2>
                        Client List
                    </h2>
               

                      <table width="100%">
                        <tr>
                            <td align="left">
                                <asp:Button ID="btnNew" runat="server" Text="New Client" CssClass="btnNew" OnClick="btnNew_Click" />
                            </td>
                        </tr>
                         <tr>
                            <td>
                            <table>
                              <tr>
                            <td align="center" width="20%">
                                Client Name
                            </td>
                              <td align="center" width="20%">
                                 Assigned To
                            </td>
                            <td align="center" width="20%">
                                Contact Name
                            </td>
                            <td align="center" width="20%">
                              Contact No
                            </td>
                          
                            <td align="center">
                           
                            </td>

                        </tr>
                        <tr>
                            <td align="center">
                                <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                             <td align="center">
                                <asp:TextBox ID="txtConsultantAss" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                            
                            </td>

                            <td align="center">
                                <asp:TextBox ID="txtContactName" runat="server" CssClass="TxtBox" Width="200px"></asp:TextBox>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                               
                            </td>
                           
                            <td align="center">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search"  OnClick="btnSearch_Click"/>
                            </td>
                        </tr>
                            
                            </table>
                               
                            </td>
                        </tr>

                        <tr>
                            <td>
                            
                                <asp:GridView ID="gdvClient" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                    DataKeyNames="Client_Id" Width="40%" AllowPaging="True" OnPageIndexChanging="gdvClient_PageIndexChanging"
                                    OnRowCommand="gdvClient_RowCommand" OnRowDataBound="gdvClient_RowDataBound" EmptyDataText="No Record Found" HeaderStyle-ForeColor="White" 
                                    onsorting="gdvClient_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <EmptyDataRowStyle/>
                                    <FooterStyle CssClass="footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Id" Visible="true" ItemStyle-Width="10" >
                                            <ItemTemplate >
                                               
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Client_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="S.No." SortExpression="Client_Id" ItemStyle-Width="10">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client Name"  SortExpression="Client_Name">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lnkBtnClientList" runat="server" Text='<%#Eval("Client_Name")%>' OnClick="lnkBtnClientList_Click" />
                                                 <%--<asp:Button ID="ViewButton" runat="server" Text='<%#Eval("Client_Name")%>'/>--%>
                                                <%--<asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name")%>' Font-Bold="true"></asp:Label>--%>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                   
                                        <asp:TemplateField HeaderText="Assigned To" Visible="false" SortExpression="USR_Name" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblAssigendTo" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contact Name" SortExpression="Person_Name" visible="false" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblContact" runat="server" Text='<%#Eval("Person_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email Id" SortExpression="Person_Email" Visible="false" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Person_Email")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contact No" SortExpression="Person_Contact" Visible="false" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblPhnNo" runat="server" Text='<%#Eval("Person_Contact")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Action" Visible="false">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="lbtnView" CommandName="View" runat="server" ToolTip="View" ImageUrl="~/Image/view.png"
                                                    Width="22px" Height="22px" />
                                                &nbsp;
                                                <asp:ImageButton ID="lbtnEdit" CommandName="Edit" runat="server" ToolTip="Edit" ImageUrl="~/Image/b_edit.png"
                                                    Width="22px" Height="22px" />
                                                &nbsp;
                                                 <asp:ImageButton ID="imgbtnActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                        CssClass="lbtnView" ImageUrl="~/Image/b_drop.png" Height="22px" Width="22px"
                                        ToolTip="Inactive" />
                                   
                                    <asp:ImageButton ID="imgbtnInActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                        CssClass="lbtnView" ImageUrl="~/Image/Checked.png" Height="22px" Width="22px"
                                        ToolTip="Active" />
                                                &nbsp;
                                                <asp:ImageButton ID="lbtnContact" CommandName="Contact" runat="server" ToolTip="Contacts"
                                                    ImageUrl="~/Image/Contacts.png" Width="22px" Height="22px" />

                                                 <asp:ImageButton ID="ImgAddress" runat="server" Font-Underline="false"
                                        CssClass="lbtnView" ImageUrl="~/Image/AddressP.png" Height="22px" Width="22px" CommandName="Address"
                                        ToolTip="Address" />&nbsp;
                                                    <asp:ImageButton ID="ImgContract" runat="server" Font-Underline="false" CommandName="Contract"
                                        CssClass="lbtnView" ImageUrl="~/Image/ContractP3.jpg" Height="22px" Width="22px"
                                        ToolTip="Contract" />
                                                  &nbsp;
                                               <asp:ImageButton ID="ImDocuments" runat="server" Font-Underline="false" 
                                        CssClass="lbtnView" ImageUrl="~/Image/DocumentsP.jpg" Height="22px" Width="22px" CommandName="Documents"
                                        ToolTip="Documents"  />
                                                    &nbsp;
                                               <asp:ImageButton ID="ImgDepartment" runat="server" Font-Underline="false" 
                                        CssClass="lbtnView" ImageUrl="~/Image/DepartmentsP2.jpg" Height="22px" Width="22px" CommandName="Departments"
                                        ToolTip="Departments"  /> &nbsp;
                                               <asp:ImageButton ID="ImgNewRequest" runat="server" Font-Underline="false" 
                                        CssClass="lbtnView" ImageUrl="~/Image/RequestP.jpg" Height="22px" Width="22px" CommandName="NewRR"
                                        ToolTip="Request"  />

                                              
                                            </ItemTemplate>
                                            <ItemStyle Width="28%" HorizontalAlign="Center" />
                                             <HeaderStyle Width="28%" HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                       
                                    </Columns>
                                </asp:GridView>
                               
                            </td>
                          <%--  <td>
                                <table>
                                    <tr>
                                          <asp:Label ID="Label1" runat="server" Text= "Assigned to :" ></asp:Label>
                                    </tr>
                                    <tr>
                                        <asp:Label ID="Label2" runat="server" Text="Contact Name:"></asp:Label>
                                    </tr>
                                    <tr>
                                           <asp:Label ID="Label3" runat="server" Text="Email ID:"></asp:Label>
                                    </tr>
                                    <tr>
                                        <asp:Label ID="Label4" runat="server" Text="Contact Number"></asp:Label>
                                    </tr>
                                    <tr>
                                          <asp:Label ID="Label5" runat="server" Text="Status" ></asp:Label>
                                    </tr>
                               
                                </table>
                                

                            </td>--%>
                            <td>
                                                <asp:ImageButton ID="lbtnEdit" CommandName="Edit" runat="server" ToolTip="Edit" ImageUrl="~/Image/b_edit.png"
                                                    Width="22px" Height="22px" />
                                                &nbsp;
                                                 <asp:ImageButton ID="imgbtnActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                        CssClass="lbtnView" ImageUrl="~/Image/b_drop.png" Height="22px" Width="22px"
                                        ToolTip="Inactive" />
                                   
                                    <asp:ImageButton ID="imgbtnInActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                        CssClass="lbtnView" ImageUrl="~/Image/Checked.png" Height="22px" Width="22px"
                                        ToolTip="Active" />
                                                &nbsp;
                                                <asp:ImageButton ID="lbtnContact" CommandName="Contact" runat="server" ToolTip="Contacts"
                                                    ImageUrl="~/Image/Contacts.png" Width="22px" Height="22px" />

                                                 <asp:ImageButton ID="ImgAddress" runat="server" Font-Underline="false"
                                        CssClass="lbtnView" ImageUrl="~/Image/AddressP.png" Height="22px" Width="22px" CommandName="Address"
                                        ToolTip="Address" />&nbsp;
                                                    <asp:ImageButton ID="ImgContract" runat="server" Font-Underline="false" CommandName="Contract"
                                        CssClass="lbtnView" ImageUrl="~/Image/ContractP3.jpg" Height="22px" Width="22px"
                                        ToolTip="Contract" />
                                                  &nbsp;
                                               <asp:ImageButton ID="ImDocuments" runat="server" Font-Underline="false" 
                                        CssClass="lbtnView" ImageUrl="~/Image/DocumentsP.jpg" Height="22px" Width="22px" CommandName="Documents"
                                        ToolTip="Documents"  />
                                                    &nbsp;
                                               <asp:ImageButton ID="ImgDepartment" runat="server" Font-Underline="false" 
                                        CssClass="lbtnView" ImageUrl="~/Image/DepartmentsP2.jpg" Height="22px" Width="22px" CommandName="Departments"
                                        ToolTip="Departments"  /> &nbsp;
                                               <asp:ImageButton ID="ImgNewRequest" runat="server" Font-Underline="false" 
                                        CssClass="lbtnView" ImageUrl="~/Image/RequestP.jpg" Height="22px" Width="22px" CommandName="NewRR"
                                        ToolTip="Request"  />
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
 


                </div>
                 <%--region for Documents --%>
              <asp:Button ID="btnPopupDoc" runat="server" Style="display: none" />
                  <asp:ModalPopupExtender ID="MPEDoc" runat="server" TargetControlID="btnPopupDoc"
                        PopupControlID="PnlDoc" CancelControlID="imgClose" BackgroundCssClass="mdlbgrgnd">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="PnlDoc" runat="server" Width="70%" Height="450px">
                        <center>
                            <div class="popup">
                                <h6>
                                   <asp:ImageButton ID="imgClose" runat="server" Height="40px" ToolTip="Close Popup"
                                        ValidationGroup="MClose" Width="40px" ImageUrl="~/Image/close-icon.png" /></h6>
                                       
                                <table >
                                    <tr>
                                        <td colspan="4" align="center">  <b style="font-size:26px">Client Documents</b>     
              
                                      
                                        </td>
                                    </tr>
                                    <tr><td colspan="4" align="center">
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

                                        </td></tr>


                                      <tr valign="top">
                                <td align="right" width="25%" valign="top">
                                    Document Type :
                                </td>
                                <td align="left" width="25%" valign="top">
                                     <asp:DropDownList ID="ddlDocType" runat="server" AppendDataBoundItems="True"
                                CssClass="DropDown">
                                 <asp:ListItem Text="Select Document Type" Value="0"></asp:ListItem>
                                 </asp:DropDownList>
                                 <asp:CompareValidator ID="CVddlDocType" runat="server" ControlToValidate="ddlDocType" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                                </td>
                                <td align="right" width="25%" valign="top">
                                    Document Name :
                                </td>
                                <td align="left" valign="top">
                                      <asp:TextBox ID="txtDocumentNm" runat="server" CssClass="TxtBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFtxtDocumentNm" runat="server" ControlToValidate="txtDocumentNm"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="hdnClientId" runat="server" />
                                </td>
                            </tr>
                               <tr>
                                <td align="right" width="25%">
                                    Attach Document :
                                </td>
                                <td align="left" width="25%" colspan="3">
                                     <asp:FileUpload ID="DocFile" runat="server" CssClass="TxtBox" />
                                    <asp:RequiredFieldValidator ID="RFDocFile" runat="server" ControlToValidate="DocFile"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                </td>
                               
                            </tr>
                         
                          
                            <tr>
                                <td align="center" colspan="4">
                                     <asp:Label ID="lblMsgd" runat="server"></asp:Label>
                                    <asp:Button ID="btnSave" runat="server" CssClass="btnSave" OnClick="btnSave_Click"
                                        Text="Save" ValidationGroup="Save" />
                                    &nbsp;
                                    <asp:Button ID="btnCancel" runat="server" CssClass="btnCancel" OnClick="btnCancel_Click"
                                        Text="Cancel" />
                                </td>
                            </tr>

                                    <tr><td align="center" colspan="4">
                                                <asp:GridView ID="gdvDocs" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                Width="100%" AllowPaging="True" OnPageIndexChanging="gdvDocs_PageIndexChanging"
                                OnRowCancelingEdit="gdvDocs_RowCancelingEdit" OnRowDataBound="gdvDocs_RowDataBound"
                                OnRowEditing="gdvDocs_RowEditing" OnRowUpdating="gdvDocs_RowUpdating" EmptyDataText="No Record Found."
                                DataKeyNames="DocId">
                                <AlternatingRowStyle CssClass="alt" />
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                <FooterStyle CssClass="footer" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("DocId")%>'></asp:Label>
                                            
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEId" runat="server" Text='<%#Eval("DocId")%>'></asp:Label>
                                            
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocType" runat="server" Text='<%#Eval("DocTypeName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEDocType" runat="server" Text='<%#Eval("DocTypeId")%>' Visible="false"></asp:Label>
                                            <asp:DropDownList ID="ddlEDocType" runat="server" CssClass="DropDown" Width="120px">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CVEddlDocType" runat="server" ControlToValidate="ddlEDocType" ErrorMessage="Select"
                                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="Update" ValueToCompare="0"
                                                Font-Size="Small"></asp:CompareValidator>
                                     </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDocNm" runat="server" Text='<%#Eval("DocName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtDocNm" runat="server" Text='<%#Bind("DocName")%>' CssClass="TxtBox"
                                                Width="160px" ></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RFEtxtDocNm" runat="server" ControlToValidate="txtDocNm"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                              
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Attach Document">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAttachDoc" runat="server" Text='<%#Eval("DocFile")%>'></asp:Label>
                                             </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                             <asp:Label ID="lblEAttachDoc" runat="server" Text='<%#Eval("DocFile")%>'></asp:Label>
                                              <asp:FileUpload ID="EDocFile" runat="server" CssClass="TxtBox" />
                                    <asp:RequiredFieldValidator ID="RFEDocFile" runat="server" ControlToValidate="EDocFile"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                             
                                    </EditItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Status" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblDStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblDEStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lbtnEdit" CommandName="Edit" runat="server" ToolTip="Edit" ImageUrl="~/Image/b_edit.png"
                                                    Width="22px" Height="22px" />
                                          &nbsp;
                                                 <asp:ImageButton ID="imgbtnDActivate" runat="server" Font-Underline="false" OnClick="imgbtnD_Activate_Click"
                                        CssClass="lbtnView" ImageUrl="~/Image/b_drop.png" Height="22px" Width="22px"
                                        ToolTip="Inactive" />
                                   
                                    <asp:ImageButton ID="imgbtnDInActivate" runat="server" Font-Underline="false" OnClick="imgbtnD_Activate_Click"
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


                                        </td></tr>
                               </table>

                         
                                     
                            </div>
                        </center>
                    </asp:Panel>
            <%--End--%> 


                   <%--region for Department --%>
              <asp:Button ID="btnPoupDep" runat="server" Style="display: none" />
                  <asp:ModalPopupExtender ID="MPEDep" runat="server" TargetControlID="btnPoupDep"
                        PopupControlID="PnlDep" CancelControlID="ImgCloseDep" BackgroundCssClass="mdlbgrgnd">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="PnlDep" runat="server" Width="70%" Height="450px">
                        <center>
                            <div class="popup">
                                <h6>
                                   <asp:ImageButton ID="ImgCloseDep" runat="server" Height="40px" ToolTip="Close Popup"
                                        ValidationGroup="MClose" Width="40px" ImageUrl="~/Image/close-icon.png" /></h6>
                                       
                                <table >
                                    <tr>
                                        <td colspan="4" align="center">  <b style="font-size:26px">Client Departments</b>     
              
                                      
                                        </td>
                                    </tr>
                                    <tr><td  colspan="4" align="center">
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

                                        </td></tr>

                                      <tr valign="top">
                                <td align="right" width="25%" valign="top">
                                    Department Code :
                                </td>
                                <td align="left" width="25%" valign="top">
                                      <asp:TextBox ID="txtDepCode" runat="server" CssClass="TxtBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFtxtDepCode" runat="server" ControlToValidate="txtDepCode"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SaveDp"></asp:RequiredFieldValidator>
                                </td>
                                <td align="right" width="25%" valign="top">
                                    Department Name :
                                </td>
                                <td align="left" valign="top">
                                      <asp:TextBox ID="txtDepartNm" runat="server" CssClass="TxtBox"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RFtxtDepartNm" runat="server" ControlToValidate="txtDepartNm"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="SaveDp"></asp:RequiredFieldValidator>
                                    <asp:HiddenField ID="hdnClientIdDep" runat="server" />
                                </td>
                            </tr>
                               <tr>
                                <td align="right" width="25%">
                                    Client Contact :
                                </td>
                                <td align="left" width="25%">
                                        <asp:DropDownList ID="ddlCLContact" runat="server" AppendDataBoundItems="True"
                                CssClass="DropDown">
                                 <asp:ListItem Text="Select Contact" Value="0"></asp:ListItem>
                                 </asp:DropDownList>
                               
                                </td>

                                    <td align="right" width="25%">
                                    Portfolio Manager :
                                </td>
                                <td align="left" width="25%">
                                        <asp:DropDownList ID="ddlPortfolio" runat="server" AppendDataBoundItems="True"
                                CssClass="DropDown">
                                 <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                 </asp:DropDownList>
                               
                                </td>
                               
                            </tr>

                                      <tr>
                                <td align="right" width="25%">
                                    Team Lead :
                                </td>
                                <td align="left" width="25%">
                                        <asp:DropDownList ID="ddlTeamLead" runat="server" AppendDataBoundItems="True"
                                CssClass="DropDown">
                                 <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                 </asp:DropDownList>
                               
                                </td>

                               
                            </tr>
                         
                          
                            <tr>
                                <td align="center" colspan="4">
                                     <asp:Label ID="lblMsgdp" runat="server"></asp:Label>
                                    <asp:Button ID="btnSaveDp" runat="server" CssClass="btnSave" OnClick="btnSaveDp_Click"
                                        Text="Save" ValidationGroup="Savedp" />
                                    &nbsp;
                                    <asp:Button ID="btnCanceldp" runat="server" CssClass="btnCancel" OnClick="btnCanceldp_Click"
                                        Text="Cancel" />
                                </td>
                            </tr>

                                    <tr><td align="center" colspan="4">
                                                <asp:GridView ID="gdvDP" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                Width="100%" AllowPaging="True" OnPageIndexChanging="gdvDP_PageIndexChanging"
                                OnRowCancelingEdit="gdvDP_RowCancelingEdit" OnRowDataBound="gdvDP_RowDataBound"
                                OnRowEditing="gdvDP_RowEditing" OnRowUpdating="gdvDP_RowUpdating" EmptyDataText="No Record Found."
                                DataKeyNames="DepId">
                                <AlternatingRowStyle CssClass="alt" />
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                <FooterStyle CssClass="footer" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("DepId")%>'></asp:Label>
                                            
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEId" runat="server" Text='<%#Eval("DepId")%>'></asp:Label>
                                            
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department Code" SortExpression="DeparmentCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDeparmentCode" runat="server" Text='<%#Eval("DeparmentCode")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEDepCode" runat="server" Text='<%#Bind("DeparmentCode")%>' CssClass="TxtBox"
                                                Width="160px" ></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RFtxtEDepCode" runat="server" ControlToValidate="txtEDepCode"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                              
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Department Name" SortExpression="DepartmentName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblDepNm" runat="server" Text='<%#Eval("DepartmentName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEDepNm" runat="server" Text='<%#Bind("DepartmentName")%>' CssClass="TxtBox"
                                                Width="160px" ></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RFtxtEDepNm" runat="server" ControlToValidate="txtEDepNm"
                                        ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                              
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Client Contact" SortExpression="Person_Name">
                                        <ItemTemplate>
                                            <asp:Label ID="lblContact" runat="server" Text='<%#Eval("Person_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEContactId" runat="server" Text='<%#Eval("ContactId")%>' Visible="false"></asp:Label>
                                            <asp:DropDownList ID="ddlEContactId" runat="server" CssClass="DropDown" Width="150px">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CVEddlEContactId" runat="server" ControlToValidate="ddlEContactId" ErrorMessage="Select"
                                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="Update" ValueToCompare="0"
                                                Font-Size="Small"></asp:CompareValidator>
                                     </EditItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Portfolio Manager" SortExpression="PortfolioName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPortfolio" runat="server" Text='<%#Eval("PortfolioName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEPortfolioId" runat="server" Text='<%#Eval("PortfolioMgrId")%>' Visible="false"></asp:Label>
                                            <asp:DropDownList ID="ddlEPortfolioId" runat="server" CssClass="DropDown" Width="150px">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CVddlEPortfolioId" runat="server" ControlToValidate="ddlEPortfolioId" ErrorMessage="Select"
                                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="Update" ValueToCompare="0"
                                                Font-Size="Small"></asp:CompareValidator>
                                     </EditItemTemplate>
                                    </asp:TemplateField>

                                       <asp:TemplateField HeaderText="Team Lead" SortExpression="TeamLeadName">
                                        <ItemTemplate>
                                            <asp:Label ID="lblTeamLead" runat="server" Text='<%#Eval("TeamLeadName")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblETeamLeadId" runat="server" Text='<%#Eval("TeamLeadMgrId")%>' Visible="false"></asp:Label>
                                            <asp:DropDownList ID="ddlETeamLeadId" runat="server" CssClass="DropDown" Width="150px">
                                                </asp:DropDownList>
                                                <asp:CompareValidator ID="CVddlETeamLeadId" runat="server" ControlToValidate="ddlETeamLeadId" ErrorMessage="Select"
                                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="Update" ValueToCompare="0"
                                                Font-Size="Small"></asp:CompareValidator>
                                     </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status" >
                                        <ItemTemplate>
                                            <asp:Label ID="lblDPStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblDPEStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="lbtnEdit" CommandName="Edit" runat="server" ToolTip="Edit" ImageUrl="~/Image/b_edit.png"
                                                    Width="22px" Height="22px" />
                                          &nbsp;
                                                 <asp:ImageButton ID="imgbtnDActivateDP" runat="server" Font-Underline="false" OnClick="imgbtnD_ActivateDP_Click"
                                        CssClass="lbtnView" ImageUrl="~/Image/b_drop.png" Height="22px" Width="22px"
                                        ToolTip="Inactive" />
                                   
                                    <asp:ImageButton ID="imgbtnDInActivateDP" runat="server" Font-Underline="false" OnClick="imgbtnD_ActivateDP_Click"
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


                                        </td></tr>
                               </table>

                         
                                     
                            </div>
                        </center>
                    </asp:Panel>
            <%--End--%> 

            </center>
     
</asp:Content>


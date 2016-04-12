<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ClientAddress.aspx.cs" Inherits="ClientAddress" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <asp:Panel ID="Panel1" runat="server">
                <h2>
                    Client Address
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
                            Address Type :
                        </td>
                        <td align="left" width="25%" valign="top">
                            <asp:DropDownList ID="ddlAddress" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                                <asp:ListItem Value="Select">Select</asp:ListItem>
                                <asp:ListItem Value="Residence">Residence</asp:ListItem>
                                <asp:ListItem Value="Office">Office</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv1" runat="server" ErrorMessage="Select" ForeColor="Red"
                                Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Save" ValueToCompare="Select"
                                ControlToValidate="ddlAddress"></asp:CompareValidator>
                        </td>
                        <td align="right" width="25%" valign="top">
                            Address :
                        </td>
                        <td align="left" valign="top">
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="TxtBox" Height="40px" TextMode="MultiLine"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfv" runat="server" ControlToValidate="txtAddress"
                                ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="Save"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="25%">
                            Country :
                        </td>
                        <td align="left" width="25%">
                            <asp:DropDownList ID="ddlCountry" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                CssClass="DropDown" OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv2" runat="server" ControlToValidate="ddlCountry" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" Type="Integer" ValidationGroup="Save"
                                ValueToCompare="0"></asp:CompareValidator>
                        </td>
                        <td align="right" width="25%">
                            State :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlState" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                                CssClass="DropDown" OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv4" runat="server" ControlToValidate="ddlState" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" Type="Integer" ValidationGroup="Save"
                                ValueToCompare="0"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="25%">
                            City :
                        </td>
                        <td align="left" width="25%">
                            <asp:DropDownList ID="ddlCity" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv3" runat="server" ControlToValidate="ddlCity" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" Type="Integer" ValidationGroup="Save"
                                ValueToCompare="0"></asp:CompareValidator>
                        </td>
                        <td align="right" width="25%">
                            Pincode :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtPincode" runat="server" CssClass="TxtBox"></asp:TextBox>
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
                    Client Address List
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
                            <asp:Button ID="btnNew" runat="server" Text="New Address" CssClass="btnNew" OnClick="btnNew_Click" />
                        </td>
                        <td align="right">
                            <asp:LinkButton ID="lbBack" runat="server" CssClass="lblHistory" OnClick="lbBack_Click">Back</asp:LinkButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <asp:GridView ID="gdvAddress" runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                                Width="100%" AllowPaging="True" OnPageIndexChanging="gdvAddress_PageIndexChanging"
                                OnRowCancelingEdit="gdvAddress_RowCancelingEdit" OnRowDataBound="gdvAddress_RowDataBound"
                                OnRowEditing="gdvAddress_RowEditing" OnRowUpdating="gdvAddress_RowUpdating" EmptyDataText="No Record Found."
                                DataKeyNames="Address_Id">
                                <AlternatingRowStyle CssClass="alt" />
                                <EmptyDataRowStyle HorizontalAlign="Center" />
                                <FooterStyle CssClass="footer" />
                                <Columns>
                                    <asp:TemplateField HeaderText="Id" Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Address_Id")%>'></asp:Label>
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEId" runat="server" Text='<%#Eval("Address_Id")%>'></asp:Label>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S.No.">
                                        <ItemTemplate>
                                            <%#Container.DataItemIndex+1 %>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address Type">
                                        <ItemTemplate>
                                            <asp:Label ID="lblType" runat="server" Text='<%#Eval("Address_Type")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEType" runat="server" Text='<%#Eval("Address_Type")%>' Visible="false"></asp:Label>
                                            <asp:DropDownList ID="ddlEAddress" runat="server" CssClass="DropDown" Width="120px">
                                                <asp:ListItem Value="Select">Select</asp:ListItem>
                                                <asp:ListItem Value="Residence">Residence</asp:ListItem>
                                                <asp:ListItem Value="Office">Office</asp:ListItem>
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Address">
                                        <ItemTemplate>
                                            <asp:Label ID="lblAddress" runat="server" Text='<%#Eval("Address")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtAddress" runat="server" Text='<%#Bind("Address")%>' CssClass="TxtBox"
                                                Width="120px" TextMode="MultiLine" Height="30px"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Country">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCountry" runat="server" Text='<%#Eval("Cntry_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblECountryId" runat="server" Text='<%#Eval("Cntry_Id")%>' Visible="false"></asp:Label>
                                            <asp:DropDownList ID="ddlECountry" runat="server" CssClass="DropDown" OnSelectedIndexChanged="ddlECountry_SelectedIndexChanged"
                                                Width="120px" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="State">
                                        <ItemTemplate>
                                            <asp:Label ID="lblState" runat="server" Text='<%#Eval("State_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblEStateId" runat="server" Text='<%#Eval("State_Id")%>' Visible="false"></asp:Label>
                                            <asp:DropDownList ID="ddlEState" runat="server" CssClass="DropDown" OnSelectedIndexChanged="ddlEState_SelectedIndexChanged"
                                                Width="120px" AutoPostBack="true">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="City">
                                        <ItemTemplate>
                                            <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City_Name")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                            <asp:Label ID="lblECityId" runat="server" Text='<%#Eval("City_Id")%>' Visible="false"></asp:Label>
                                            <asp:DropDownList ID="ddlECity" runat="server" CssClass="DropDown" Width="120px">
                                            </asp:DropDownList>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="PinCode">
                                        <ItemTemplate>
                                            <asp:Label ID="lblPincode" runat="server" Text='<%#Eval("Pincode")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" />
                                        <EditItemTemplate>
                                            <asp:TextBox ID="txtEPincode" runat="server" Text='<%#Bind("Pincode")%>' CssClass="TxtBox"
                                                Width="120px"></asp:TextBox>
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <ItemTemplate>
                                            <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                        </ItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Center" />
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
                                                CssClass="lbtnUpdate" />
                                            &nbsp;
                                            <asp:LinkButton ID="lbtnCancel" runat="server" Font-Underline="false" Text="Cancel"
                                                CommandName="Cancel" CssClass="lbtnCancel" />
                                        </EditItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="2">
                            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </center>
</asp:Content>

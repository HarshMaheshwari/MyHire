<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CandidateForm.aspx.cs" Inherits="Recruitment_CandidateForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    
            <center>
                <div id="page">
                    <h2>
                        &nbsp;Candidate Form</h2>
                    <table width="80%" cellpadding="3" cellspacing="3">
                        <tr>
                            <td align="right" style="width: 20%">
                                Candidate Name :
                            </td>
                            <td align="left" style="width: 30%">
                                <asp:TextBox ID="txtName" runat="server" CssClass="TxtBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtName"
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" style="width: 20%">
                                Date Of Birth :
                            </td>
                            <td align="left" style="width: 30%">
                                <asp:TextBox ID="txtDob" runat="server" CssClass="TxtBox"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtDob" TargetControlID="txtDob" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Email Id :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="TxtBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" 
                                    ControlToValidate="txtEmail" ErrorMessage="*" ForeColor="Red" 
                                    ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                            <td align="right" rowspan="2" valign="top">
                                Address:
                            </td>
                            <td align="left" rowspan="2" valign="top">
                                <asp:TextBox ID="txtAddress" runat="server" Height="40px" TextMode="MultiLine" CssClass="TxtBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Mobile No :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMobile" runat="server" CssClass="TxtBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtMobile"
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        
                        <tr>
                            <td align="right">
                                Current Location :
                            </td>
                            <td align="left">
                             <%--   <asp:TextBox ID="txtCurrentLocation" runat="server" CssClass="TxtBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtCurrentLocation"
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                                        <asp:DropDownList ID="ddlLocation" runat="server" AppendDataBoundItems="True" CssClass="DropDown" width="192px">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv10" runat="server" ControlToValidate="ddlLocation" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                            </td>
                            <td align="right">
                                Current Designation :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDesg" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Current Employer :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmployer" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="right">
                                Previous Employer :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPreEmployer" runat="server" CssClass="TxtBox"></asp:TextBox>
                        </tr>
                        <tr>
                            <td align="right">
                                Current CTC :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSalary" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="right">
                                Work Experience :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtExperience" runat="server" CssClass="TxtBox"></asp:TextBox>
                                </td>
                        </tr>
                        <tr>
                            <td align="right">
                                UG Course :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUG" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="right">
                                PG Course :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPG" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                UG University/Inst. :</td>
                            <td align="left">
                                <asp:TextBox ID="txtUGInstitute" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="right">
                                PG University/Inst. :</td>
                            <td align="left">
                                <asp:TextBox ID="txtPGInstitute" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Post PG Course :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPost" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="right">
                                Candidate Source :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtcandidateSource" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr id="Tr1" runat="server" visible="false">
                            <td align="right">
                                PAN Card Number :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPanCard" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                            <td align="right">
                                Passport Number :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPasportNo" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                        </tr>
                       <tr id="Tr2" runat="server" visible="false">
                            <td align="right">
                                Issue Date :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtissueDate" runat="server" CssClass="TxtBox"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="txtissueDate" 
                                TargetControlID="txtissueDate" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td align="right">
                                Issue Location :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtIssueLocation" runat="server" CssClass="TxtBox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Industry :
                            </td>
                            <td align="left">
                            <%--    <asp:TextBox ID="txtIndustry" runat="server" CssClass="TxtBox"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtIndustry"
                                    ErrorMessage="*" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>--%>
                                      <asp:DropDownList ID="ddlIndustry" runat="server" AppendDataBoundItems="True" CssClass="DropDown" Width="192px">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CVddlIndustry" runat="server" ControlToValidate="ddlIndustry" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                            </td>
                            <td align="right">
                                Status :
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlStatus" runat="server" CssClass="DropDown">
                                    <asp:ListItem Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="2">Inactive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                            <td align="right">
                                Resume :
                            </td>
                            <td align="left">
                                <asp:FileUpload ID="fileUpload" runat="server" CssClass="TxtBox" />
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnSave" runat="server" CssClass="btnSave" OnClick="btnSave_Click"
                                    Text="Save" ValidationGroup="Save" />
                                &nbsp;
                                <asp:Button ID="btnBack" runat="server" CssClass="btnCancel" OnClick="btnBack_Click"
                                    Text="Back" />
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
   
  
</asp:Content>

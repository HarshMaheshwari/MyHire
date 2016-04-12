<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewCandidate.aspx.cs" Inherits="Candidate_NewCandidate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
    <div id="page">
    <h2>
    New Candidate
    </h2> 
    <table width="80%" cellpadding="3" cellspacing="3">
                        <tr>
                            <td align="right" style="width: 20%">
                                Candidate Name :
                            </td>
                            <td align="left" style="width: 30%">
                                <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" style="width: 20%">
                                Date Of Birth :
                            </td>
                            <td align="left" style="width: 30%">
                                <asp:TextBox ID="txtDob" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" PopupButtonID="txtDob" TargetControlID="txtDob" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>

                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Telephone No :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPhn" runat="server"></asp:TextBox>
                            </td>
                            <td align="right" rowspan="2" valign="top">
                                Address:
                            </td>
                            <td align="left" rowspan="2" valign="top">
                                <asp:TextBox ID="txtAddress" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Mobile No :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtMobile" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Email Id :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                Alt Email Id :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAltEmail" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Current Location :
                            </td>
                            <td align="left">
                               <%-- <asp:TextBox ID="txtCurrentLocation" runat="server"></asp:TextBox>--%>
                                 <asp:DropDownList ID="ddlLocation" runat="server" AppendDataBoundItems="True" CssClass="DropDown" width="175px">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv10" runat="server" ControlToValidate="ddlLocation" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                            </td>
                            <td align="right">
                                Preferred Location :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPreferred" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Current Employer :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmployer" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                Current Designation:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDesg" runat="server"></asp:TextBox>
                        </tr>
                        <tr>
                            <td align="right">
                                Current CTC :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSalary" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                Work Experience :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtExperience" runat="server"></asp:TextBox>
                        </tr>
                        <tr>
                            <td align="right">
                                UG Course :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUG" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                PG Course :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPG" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Post PG Course :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPost" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                Candidate Source :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtcandidateSource" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                PAN Card Number :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPanCard" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                Passport Number :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPasportNo" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Issue Date :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtissueDate" runat="server"></asp:TextBox>
                                   <asp:CalendarExtender ID="CalendarExtender2" runat="server" PopupButtonID="txtissueDate" 
                                TargetControlID="txtissueDate" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td align="right">
                                Issue Location :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtIssueLocation" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Adhar Card Number :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAdharCard" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                &nbsp;Industry :
                            </td>
                            <td align="left">
                               <%-- <asp:TextBox ID="txtIndustry" runat="server"></asp:TextBox>--%>
                                  <asp:DropDownList ID="ddlIndustry" runat="server" AppendDataBoundItems="True" CssClass="DropDown" Width="175px">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CVddlIndustry" runat="server" ControlToValidate="ddlIndustry" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                            </td>
                        </tr>
                      


                      <tr>
                            <td align="right">
                                Key Skills:
                            </td>
                            <td align="left" colspan="3">
                                <asp:TextBox ID="txtKey_Skills" runat="server" Width="650px"></asp:TextBox>
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
                                <asp:Button ID="btnUpdate" runat="server" CssClass="btnSave" 
                                    onclick="btnUpdate_Click" Text="Save" />
                                    
                                &nbsp;
                                <asp:Button ID="btnBack" runat="server" CssClass="btnCancel" OnClick="btnBack_Click"
                                    Text="Back" />
                            </td>
                        </tr>
                    </table>
    </div>
    </center>
</asp:Content>


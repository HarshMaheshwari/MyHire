<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CandidateAdditionalInformation.aspx.cs" Inherits="Candidate_CandidateAdditionalInformation" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 32px;
        }
        .auto-style2 {
            height: 31px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Candidate - Additional Information
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
                               Gender:
                            </td>
                            <td align="left">
                                 <asp:DropDownList class="chzn-select" ID="ddlGender" runat="server" AppendDataBoundItems="true" 
                                Width="160px">
                                 <asp:ListItem Text="Select Gender" Value="0"></asp:ListItem>
                                     <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                                     <asp:ListItem Text="Female" Value="2"></asp:ListItem>
                                 </asp:DropDownList>
                                  
                            </td>
                            <td align="right">
                                &nbsp;Age:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtAge" runat="server"></asp:TextBox>
                            </td>
                        </tr>
        <tr>
                            <td align="right">
                                Total Experience :
                            </td>
                            <td align="left">
                               <%-- <asp:TextBox ID="txtCurrentLocation" runat="server"></asp:TextBox>--%>
                                   <asp:TextBox ID="txtTotalExperience" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                Relevant Experience :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRelevantExperience" runat="server"></asp:TextBox>
                            </td>
                        </tr>               
        <tr><td align="right">Cell No :</td><td  align="left">
                                   <asp:TextBox ID="txtCellNo" runat="server"></asp:TextBox>
                            </td><td align="right">
                                Current Organisation :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmployer" runat="server"></asp:TextBox>
                            </td></tr>

        <tr><td align="right" class="auto-style2">
                                Last Organisation :
                            </td>
                            <td align="left" class="auto-style2">
                                <asp:TextBox ID="txtLastEmployer" runat="server"></asp:TextBox>
                            </td><td align="right" class="auto-style2">Highest Education :</td><td align="left" class="auto-style2">
                                <asp:TextBox ID="txtHighestEducation" runat="server"></asp:TextBox>
                            </td></tr>
         <tr><td align="right">Insitute Name :</td><td align="left">
                                <asp:TextBox ID="txtInsituteName" runat="server"></asp:TextBox>
                            </td><td align="right">Indutry :</td><td align="left">
                                <asp:TextBox ID="txtIndutry" runat="server"></asp:TextBox>
                            </td></tr>
         <tr><td align="right"><b>Team</b></td><td align="left">&nbsp;</td><td align="right"></td><td align="left"></td></tr>
         <tr><td align="right">&nbsp;Last Designation :</td><td align="left">
                                <asp:TextBox ID="txtLastDesignation" runat="server"></asp:TextBox>
                            </td><td align="right">Team Size Managed :</td><td align="left" style="font-weight: 700">
                                <asp:TextBox ID="txtTeamSizeManaged" runat="server"></asp:TextBox>
                            </td></tr>
                            <tr><td align="right">Current RM Designation :</td><td align="left">
                                <asp:TextBox ID="txtCurrentRMDesignation" runat="server"></asp:TextBox>
                                </td><td></td><td></td></tr>
        <tr><td><b>Current Compensation</b></td><td align="left">&nbsp;</td><td></td><td></td></tr>
        <tr><td align="right">CTC :</td><td align="left">
                                <asp:TextBox ID="txtCTC" runat="server"></asp:TextBox>
                            </td><td align="right">Fixed :</td><td align="left">
                                <asp:TextBox ID="txtFixed" runat="server"></asp:TextBox>
                            </td></tr>
        <tr><td align="right">Variable :</td><td align="left">
                                <asp:TextBox ID="txtVariable" runat="server"></asp:TextBox>
                            </td><td align="right">Other Benefits :</td><td align="left">
                                <asp:TextBox ID="txtOtherBenefits" runat="server"></asp:TextBox>
                            </td></tr>
        <tr><td align="right"><b>Expected</b></td><td></td><td></td><td align="left"></td></tr>
        <tr><td align="right">CTC :</td><td align="left">
                                <asp:TextBox ID="txtExpectedCTC" runat="server"></asp:TextBox>
                            </td><td align="right">Fixed :</td><td align="left">
                                <asp:TextBox ID="txtExpectedFixed" runat="server"></asp:TextBox>
                            </td></tr>
       
         <tr><td align="right">Variable :</td><td align="left">
                                <asp:TextBox ID="txtExpectedVariable" runat="server"></asp:TextBox>
                            </td><td></td><td align="left"></td></tr>
         <tr><td align="right">Notice Period :</td><td align="left">
                                <asp:TextBox ID="txtNoticePeriod" runat="server"></asp:TextBox>
                            </td><td align="right">Min Time to Join :</td><td align="left">
                                <asp:TextBox ID="txtMintimetojoin" runat="server" ></asp:TextBox>
                            </td></tr>
<tr>
                            <td align="right" class="auto-style1">
                                *Current Location :
                            
                            <td align="left" class="auto-style1">
                               <%-- <asp:TextBox ID="txtCurrentLocation" runat="server"></asp:TextBox>--%>
                                   <asp:DropDownList ID="ddlLocation" runat="server" AppendDataBoundItems="True" CssClass="DropDown" width="175px">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv10" runat="server" ControlToValidate="ddlLocation" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                            </td>
                            <td align="right" class="auto-style1">
                                Preferred Location :
                            </td>
                            <td align="left" class="auto-style1">
                                <asp:TextBox ID="txtPreferred" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            
                            <td align="right">
                                Reason for Leaving :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtReasonforLeaving" runat="server"></asp:TextBox>
                                
                            
                            <td align="right">
                                Interview Type :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtInterviewType" runat="server"></asp:TextBox>
                        </tr>
                      
                        <tr>
                            <td align="right">
                                Work Experience :</td>
                            <td align="left">
                                <asp:TextBox ID="txtExperience" runat="server"></asp:TextBox>
                            </td>
                             <td align="right">
                                Primary Skill:</td>
                            <td align="left">
                                <asp:TextBox ID="txtPrimarySkill" runat="server"></asp:TextBox>
                            </td>
                           </tr>
        <tr><td>Tentative Schedule Date :</td><td align="left"><asp:TextBox ID="txtTentativeScheduleDate" runat="server"></asp:TextBox>
             <asp:CalendarExtender ID="CETentativeScheduleDate" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtTentativeScheduleDate" TargetControlID="txtTentativeScheduleDate">
                                  </asp:CalendarExtender>
                                              </td><td>Tentative Schedule Time:</td><td align="left"><asp:TextBox ID="txtTentativeScheduleTime" runat="server"></asp:TextBox></td></tr>
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
                                UG Institute:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtUGInstitute" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                &nbsp;PG Institute:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtPGInstitute" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                          <tr>
                            <td align="right">
                                Specialization 1:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSpecialEducation1" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                Specialization 2:
                            </td>
                            <td align="left">
                                 <asp:TextBox ID="txtSpecialEducation2" runat="server"></asp:TextBox>
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
                                Resume Title :
                            </td>
                            <td align="left">
                                 <asp:TextBox ID="txtResumeTitle" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                &nbsp;Resume Path :
                            </td>
                            <td align="left">
                                <asp:FileUpload ID="fileUpload" runat="server" CssClass="TxtBox" />
                                <%-- <asp:Image ID="ImgResume"  runat="server"   width="130px" height="90px" />--%>
                            </td>
                        </tr>

                           <tr>
                            <td align="right">
                                Functional Area:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtFunctionalArea" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                &nbsp;Specialization Area :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSpecializationArea" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                         <tr>
                            <td align="right">
                                Last Activation Date :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtLastActivationDate" runat="server"></asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtender3" runat="server" PopupButtonID="txtLastActivationDate" 
                                TargetControlID="txtLastActivationDate" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                            
                            </td>
                            <td align="right">
                                &nbsp;Previous Employer:
                            </td>
                            <td align="left">
                              <asp:TextBox ID="txtPreviousEmployer" runat="server"></asp:TextBox>
                              
                            </td>
                        </tr>

                        
                          <tr>
                            <td align="right">
                                Employee Level:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtEmpLevel" runat="server"></asp:TextBox>
                            </td>
                            <td align="right">
                                &nbsp;Source:
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtSource" runat="server"></asp:TextBox>
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
                                    onclick="btnUpdate_Click" Text="Update" />
                                    
                                &nbsp;
                                <asp:Button ID="btnBack" runat="server" CssClass="btnCancel" OnClick="btnBack_Click"
                                    Text="Back" />
                            </td>
                        </tr>
                    </table>
    </div>
    </center>
</asp:Content>


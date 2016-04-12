<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="NewRRequest.aspx.cs" Inherits="RecMgmt_NewRRequest" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="page">
        <h2>
            <asp:Label ID="lblHdr" runat="server"></asp:Label>&nbsp; Recruitment Request
        </h2>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td colspan="4">
                            &nbsp;&nbsp;
                        </td>
                    </tr>
                     <tr runat="server" id="trRRNo" visible="false">
                        <td align="right" width="20%">
                            RR-Number :
                        </td>
                        <td width="30%">
                             <asp:Label ID="lblRRNo" runat="server"></asp:Label>
                        </td>
                        <td align="right" width="20%">
                           
                        </td>
                        <td width="30%">
                           
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="20%">
                            Client Name :
                        </td>
                        <td width="30%">
                            <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                OnSelectedIndexChanged="ddlClientName_SelectedIndexChanged" AutoPostBack="True">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv9" runat="server" ControlToValidate="ddlClientName" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                        </td>
                        <td align="right" width="20%">
                            &nbsp;Role / Job Profile :
                        </td>
                        <td align="left" width="30%">
                            <asp:TextBox ID="txtJobProfile" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="txtJobProfile"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Requisition By:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRequest" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv12" runat="server" ControlToValidate="ddlRequest" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                        </td>
                        <td align="right">
                            &nbsp;Total Positions :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtTotalPositions" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtTotalPositions"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="re5" runat="server" ControlToValidate="txtTotalPositions"
                                ErrorMessage="Number Only" Font-Size="Small" ForeColor="Red" ValidationExpression="^\d+$"
                                ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Team Lead :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlReportMngr" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv13" runat="server" ControlToValidate="ddlReportMngr"
                                ErrorMessage="Select" ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save"
                                ValueToCompare="0" Font-Size="Small"></asp:CompareValidator>
                        </td>
                        <td align="right">
                            Request Receive Date :
                        </td>
                        <td>
                            <asp:TextBox ID="txtReceiveDate" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:CalendarExtender ID="txtReceiveDate_CalendarExtender" runat="server" Format="dd-MMM-yyyy"
                                PopupButtonID="txtReceiveDate" TargetControlID="txtReceiveDate">
                            </asp:CalendarExtender>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ControlToValidate="txtReceiveDate"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="Rev4" runat="server" ControlToValidate="txtReceiveDate"
                                Display="Dynamic" ErrorMessage="Eg. 31-May-2013 " ForeColor="Red" SetFocusOnError="true"
                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                ValidationGroup="save" Font-Size="Small"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Target Closure Date :
                        </td>
                        <td>
                            <asp:TextBox ID="txtTargetClosureDate" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                PopupButtonID="txtTargetClosureDate" TargetControlID="txtTargetClosureDate">
                            </asp:CalendarExtender>
                            <asp:RegularExpressionValidator ID="Rev5" runat="server" ControlToValidate="txtTargetClosureDate"
                                Display="Dynamic" ErrorMessage="Eg. 31-May-2013 " ForeColor="Red" SetFocusOnError="true"
                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                ValidationGroup="save" Font-Size="Small"></asp:RegularExpressionValidator>
                        </td>
                        <td align="right">
                            Criticality :
                        </td>
                        <td align="left">
                            <asp:RadioButtonList ID="rbCriticality" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Text="High" Value="0" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Medium" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Low" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>

                      <tr>
                        <td align="right">
                           Min Qualification :
                        </td>
                        <td>
                            <asp:TextBox ID="txtMinQualification" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ControlToValidate="txtMinQualification"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                           
                        </td>
                        <td align="left">
                           
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Designation :
                        </td>
                        <td>
                            <asp:TextBox ID="txtDesignation" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDesignation"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                            Location :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlLocation" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv10" runat="server" ControlToValidate="ddlLocation" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Min Salary :
                        </td>
                        <td>
                            <asp:TextBox ID="txtMinSalary" runat="server" CssClass="TxtBox"></asp:TextBox>
                       
                                  <asp:FilteredTextBoxExtender ID="FTtxtMinSalary" runat="server" TargetControlID="txtMinSalary" 
                          ValidChars=".0123456789" ></asp:FilteredTextBoxExtender>
                        </td>
                        <td align="right">
                            Max Salary :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMaxSalary" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtMaxSalary"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                       
                                  <asp:FilteredTextBoxExtender ID="FTtxtMaxSalary" runat="server" TargetControlID="txtMaxSalary"
                          ValidChars=".0123456789" ></asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                            Min Experience(yrs) :
                        </td>
                        <td>
                            <asp:TextBox ID="txtMinExperience" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ControlToValidate="txtMinExperience"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="re2" runat="server" ControlToValidate="txtMinExperience"
                                ErrorMessage="Eg.  4.0 or 4" Font-Size="Small" ForeColor="Red" ValidationExpression="(?!^0*$)(?!^0*\.0*$)^\d{1,5}(\.\d{1,3})?$"
                                ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                 
                        </td>
                        <td align="right">
                            Max Experience(yrs) :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMaxExperience" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ControlToValidate="txtMaxExperience"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="re4" runat="server" ControlToValidate="txtMaxExperience"
                                ErrorMessage="Eg.  4.0 or 4" Font-Size="Small" ForeColor="Red" ValidationExpression="(?!^0*$)(?!^0*\.0*$)^\d{1,5}(\.\d{1,3})?$"
                                ValidationGroup="save" Display="Dynamic"></asp:RegularExpressionValidator>
                                
                        </td>
                    </tr>
                    <tr>
                        <td align="right">
                           Functional Area :
                        </td>
                        <td>
                    
                                    <asp:DropDownList ID="ddlFunctionalArea" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CVddlFunctionalArea" runat="server" ControlToValidate="ddlFunctionalArea" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>

                        </td>
                        <td align="right">
                            Preferred Industry :
                        </td>
                        <td align="left">
                       
                                    <asp:DropDownList ID="ddlPreferdIndustry" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CVddlPreferdIndustry" runat="server" ControlToValidate="ddlPreferdIndustry" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                        </td>
                    </tr>

                    

                    <tr>
                    <td align="right">Key Skills :</td>
                    <td><asp:TextBox ID="txtSkills" runat="server" CssClass="TxtBox" Width="485px" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvSkill" runat="server" ControlToValidate="txtSkills"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                 

                 
                                
                                </td>
                                   <td align="right">
                             Industry :
                        </td>
                        <td align="left">
                          <asp:DropDownList ID="ddlIndustry" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="CVddlIndustry" runat="server" ControlToValidate="ddlIndustry" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                        </td>
                    </tr>
                      <tr>
                        <td align="right">
                            Request Status :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRequestStatus" runat="server" AppendDataBoundItems="True"
                                CssClass="DropDown">
                                <asp:ListItem >Open</asp:ListItem>
                                <asp:ListItem>Partialy Closed</asp:ListItem>
                                <asp:ListItem>Closed</asp:ListItem>
                                 <asp:ListItem>Hold</asp:ListItem>
                                   <asp:ListItem>Mapping</asp:ListItem>
                                 <asp:ListItem>Submitted</asp:ListItem>
                                   <asp:ListItem>Not Planned</asp:ListItem>
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv11" runat="server" ControlToValidate="ddlRequestStatus"
                                ErrorMessage="*" ForeColor="Red" Operator="NotEqual" ValidationGroup="save" ValueToCompare="Select"
                                SetFocusOnError="True"></asp:CompareValidator>
                        </td>
                        <td align="right" id="JobprofileTd" runat="server">
                            Position Type :
                        </td> <td align="left" id="Td2" runat="server">
                             <asp:DropDownList ID="ddlPositionType" runat="server" AppendDataBoundItems="True"
                                CssClass="DropDown">
                                 <asp:ListItem Text="Select Position Type" Value="0"></asp:ListItem>
                              <asp:ListItem Text="IT" Value="1" Selected="True"></asp:ListItem>
                                <asp:ListItem Text="Non-IT" Value="2"></asp:ListItem>
                               </asp:DropDownList>
                                 <asp:CompareValidator ID="CddlPositionType" runat="server" ControlToValidate="ddlPositionType" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                        
                        </td>
                       
                    </tr>

                     <tr>
                        <td align="right">
                            Job Description:
                        </td>
                        <td>
                            <asp:TextBox ID="txtJobDescription" runat="server" CssClass="TxtBox" Width="485px" TextMode="MultiLine" Height="100px"></asp:TextBox>
                    <asp:HtmlEditorExtender ID="hee1" TargetControlID="txtJobDescription" runat="server"> </asp:HtmlEditorExtender>
               <asp:RequiredFieldValidator ID="RFVtxtJobDescription" runat="server" ControlToValidate="txtJobDescription"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
           <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtJobDescription" ID="REVtxtJobDescription" ValidationExpression = "^[\s\S]{50,6000000}$" runat="server" 
           ErrorMessage="Minimum 50 characters Requred." ForeColor="Red" ValidationGroup="save"></asp:RegularExpressionValidator>

                        </td>
                        <td align="right" id="Td1" runat="server">
                            Job Description File :
                        </td>
                        <td align="left" id="FileUploadTd" runat="server">
                            <asp:FileUpload ID="fileUpload" runat="server" CssClass="TxtBox" />
                        </td>
                    </tr>
               
                        <tr id="Publish" runat="server" visible="false">
                        <td align="right">
                           Publish:
                        </td>
                        <td>
                            <asp:CheckBox ID="chkPublish" runat="server" Checked="true" 
                                oncheckedchanged="chkPublish_CheckedChanged" AutoPostBack="true" />
                        </td>
                        <td align="right" id="Td3" runat="server">
                           Referrer Points :
                        </td>
                        <td align="left" id="Td4" runat="server">
                            <asp:TextBox ID="txtReferrerPts" runat="server" CssClass="TxtBox" ></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFtxtReferrerPts" runat="server" ControlToValidate="txtReferrerPts"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                  <asp:FilteredTextBoxExtender ID="FTBtxtReferrerPts" runat="server" TargetControlID="txtReferrerPts"
                         FilterType="Numbers" >
                    </asp:FilteredTextBoxExtender>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            <asp:Button ID="btnsave" runat="server" CssClass="btnSave" OnClick="btnsave_Click"
                                Text="Save" ValidationGroup="save"  />
                               
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btncncl" runat="server" CssClass="btnCancel" OnClick="btncncl_Click"
                                Text="Cancel" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>

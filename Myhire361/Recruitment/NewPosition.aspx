﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="NewPosition.aspx.cs" Inherits="NewPosition" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 20%;
        }
    </style>
     <script type = "text/javascript">
         var popUpObj;
         function showModalPopUp() {
             popUpObj = window.open("../UploadCvs.aspx",
             "ModalPopUp",
             "toolbar=no," +
             "scrollbars=no," +
             "location=no," +
             "statusbar=no," +
             "menubar=no," +
             "resizable=0," +
             "width=1100," +
             "height=500," +
             "left = 100," +
             "top=50"
             );
             popUpObj.focus();
             LoadModalDiv();
         }
</script>
   <script type="text/javascript">
       function Showalert() {
           alert('Call JavaScript function from codebehind');
       }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="page">
        <h2>
            <asp:Label ID="lblHdr" runat="server"></asp:Label>&nbsp; Position&nbsp; Request
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
                        <td align="right" class="auto-style1">
                           
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
                        <td align="right" class="auto-style1">
                            Hiring HR:
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlRequest" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv12" runat="server" ControlToValidate="ddlRequest" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        
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

                        <td align="right" class="auto-style1">
                            Hiring Manager :
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlHiringMngr" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv13" runat="server" ControlToValidate="ddlHiringMngr"
                                ErrorMessage="Select" ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save"
                                ValueToCompare="0" Font-Size="Small"></asp:CompareValidator>
                        </td>
                    </tr>
                    <tr>
                        
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
                         <td align="right">
                            Designation :
                        </td>
                        <td>
                            <asp:TextBox ID="txtDesignation" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtDesignation"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>

                    </tr>
                    <tr>
                        
                         <td align="right">
                            Min CTC :
                        </td>
                        <td>
                            <asp:TextBox ID="txtMinctc" runat="server" CssClass="TxtBox"></asp:TextBox>
                       
                                  <asp:FilteredTextBoxExtender ID="FTtxtMinSalary" runat="server" TargetControlID="txtMinctc" 
                          ValidChars=".0123456789" ></asp:FilteredTextBoxExtender>
                        </td>
                        <td align="right" class="auto-style1">
                            Max CTC :
                        </td>
                        <td align="left">
                            <asp:TextBox ID="txtMaxctc" runat="server" CssClass="TxtBox"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ControlToValidate="txtMaxctc"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save"></asp:RequiredFieldValidator>
                       
                                  <asp:FilteredTextBoxExtender ID="FTtxtMaxSalary" runat="server" TargetControlID="txtMaxctc"
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

                         <td align="right" class="auto-style1">
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
                        
                        <td align="right" class="auto-style1">
                            Functional Sub Area :
                        </td>
                        <td>
                    
                                    <asp:DropDownList ID="ddlFunctionalSubArea" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cvf" runat="server" ControlToValidate="ddlFunctionalSubArea" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>

                        </td>
                    </tr>
                    <tr>
                       

                         <td align="right" class="auto-style1">
                            Location :
                        </td>
                        <td align="left">
                            <asp:DropDownList ID="ddlLocation" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                            </asp:DropDownList>
                            <asp:CompareValidator ID="cv10" runat="server" ControlToValidate="ddlLocation" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                        </td>
                         <td align="right" id="Td1" runat="server">
                            Job Description File :
                        </td>
                        <td align="left" id="FileUploadTd" runat="server">
                            <asp:FileUpload ID="fileUpload" runat="server" CssClass="TxtBox" />
                        </td>
                        
                        
                    </tr>
                     <tr>
                            <td align="right">Key Skills :</td>
                            <td colspan="2">
                                <asp:TextBox ID="txtSkills" runat="server" CssClass="TxtBox" Width="543px"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="rfvSkill" runat="server" ControlToValidate="txtSkills" ErrorMessage="*" ForeColor="Red" SetFocusOnError="True" ValidationGroup="save"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                    </tr>
                   
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnSkils" runat="server" CssClass="btnSave" OnClientClick="showModalPopUp()" Text="Skills" ValidationGroup="save" Visible="False" />
                                &nbsp;
                                <asp:Button ID="btnJdlink" runat="server" CssClass="btnSave" Text="JD Link" Visible="False" />
                                &nbsp;
                                <asp:Button ID="btnAddcv" runat="server" CssClass="btnSave" Text="Add CV" Visible="False" OnClientClick="showModalPopUp()" />
                                &nbsp;
                                <asp:Button ID="btnAddCmpnyVideo" runat="server" CssClass="btnSave" Text="Add Company Video" Visible="False" />
                                &nbsp;
                                <asp:Button ID="btnaddjdvideo" runat="server" CssClass="btnSave" Text="Add JD Video" Visible="False" />
                                &nbsp;
                                <asp:Button ID="btnViewCv" runat="server" CssClass="btnSave" Text=" View CVs" Visible="False" />
                                &nbsp;
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnsave" runat="server" CssClass="btnSave" OnClick="btnsave_Click" Text="Save" ValidationGroup="save" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btnsavenext" runat="server" CssClass="btnSave" OnClick="btnsavenext_Click" Text="Save &amp; Next" ValidationGroup="save" Width="99px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:Button ID="btncncl" runat="server" CssClass="btnCancel" OnClick="btncncl_Click" Text="Cancel" />
                            </td>
                        </tr>
                        <caption style="height: 5px">
                            <br>
                            <br></br>
                            <br>
                            <br></br>
                            </br>
                            </br>
                       
                    </caption>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
</asp:Content>


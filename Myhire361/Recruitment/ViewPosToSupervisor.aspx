<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ViewPosToSupervisor.aspx.cs" Inherits="Recruitment_ViewPosToSupervisor" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
 <link rel="Stylesheet" href="../Styles/Popup.css" type="text/css" />
  <style type="text/css">
        .style1
        {
            width: 100%;
        }
        .style2
        {
            height: 20px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
            <div id="page">
                <h2>
                   Position to Supervisor
                </h2>
                <table width="100%">
                    <tr>
                        <td align="right" width="25%">
                            R R Number :
                        </td>
                        <td width="25%">
                            <asp:Label ID="lblRRNumber" runat="server"></asp:Label>
                        </td>
                        <td width="25%" align="right">
                            Job Profile :
                        </td>
                        <td align="left" rowspan="2" valign="top">
                            <asp:Label ID="txtJobProfile" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="25%">
                            Client Name :
                        </td>
                        <td width="25%">
                            <asp:Label ID="lblClient" runat="server"></asp:Label>
                        </td>
                        <td align="right" width="25%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" width="25%">
                            Approving Manager :</td>
                        <td width="25%">
                            <asp:Label ID="lblManager" runat="server"></asp:Label>
                        </td>
                        <td width="25%" align="right">
                            Total Positions :
                        </td>
                        <td align="left">
                            <asp:Label ID="txtTotalPositions" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="25%">
                            Requisition By:
                        </td>
                        <td width="25%">
                            <asp:Label ID="lblRequestBy" runat="server"></asp:Label>
                        </td>
                        <td width="25%" align="right">
                            Request Receive Date :
                        </td>
                        <td align="left">
                            <asp:Label ID="txtReceiveDate" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="25%">
                            Target Closure Date :
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtTargetClosureDate" runat="server"></asp:Label>
                        </td>
                        <td width="25%" align="right">
                            Criticality :
                        </td>
                        <td align="left">
                            <asp:Label ID="lblCricality" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="25%">
                            Designation :
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtDesignation" runat="server"></asp:Label>
                        </td>
                        <td width="25%" align="right">
                            Location :
                        </td>
                        <td align="left">
                            <asp:Label ID="lblLocation" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="25%">
                            Min Salary :
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtMinSalary" runat="server"></asp:Label>
                        </td>
                        <td width="25%" align="right">
                            Max Salary :
                        </td>
                        <td align="left">
                            <asp:Label ID="txtMaxSalary" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="25%">
                            Min Experience(yrs) :
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtMinExperience" runat="server"></asp:Label>
                        </td>
                        <td width="25%" align="right">
                            Max Experience(yrs) :
                        </td>
                        <td align="left">
                            <asp:Label ID="txtMaxExperience" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="25%">
                            Min Qualification :
                        </td>
                        <td width="25%">
                            <asp:Label ID="txtMinQualification" runat="server"></asp:Label>
                        </td>
                        <td width="25%" align="right">
                            Preferred Industry :
                        </td>
                        <td align="left">
                            <asp:Label ID="txtPreferredIndus" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" width="25%">
                            Request Status :
                        </td>
                        <td width="25%">
                            <asp:Label ID="lblRequestStatus" runat="server"></asp:Label>
                        </td>
                        <td width="25%" align="right">
                            &nbsp;Position Type:
                        </td>
                        <td align="left">
                            <asp:Label ID="lblPositionType" runat="server"></asp:Label>
                        </td>
                    </tr>

                     <tr>
                        <td align="right" width="25%">
                            Key Skills :
                        </td>
                        <td width="25%" colspan="3">
                            <asp:Label ID="lblSkills" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                     <tr>
                        <td align="right" width="25%">
                            Job Description :
                        </td>
                        <td width="25%">
                            <asp:Label ID="lblJobDesc" runat="server"></asp:Label>
                        </td>
                        <td width="25%" align="right">
                            &nbsp;Job Description file:
                        </td>
                        <td align="left">
                             <asp:LinkButton ID="lbView" runat="server" OnClick="lbView_Click">View Job Description</asp:LinkButton>
                        </td>
                    </tr>

                      <tr>
                        <td align="right" width="25%">
                           
                        </td>
                        <td width="25%" align="right">

                            <b> Referral Reward Points : </b>
                        </td>
                        <td width="25%" align="left">
                          <b> <asp:TextBox ID="txtReferrerPts" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="RFtxtReferrerPts" runat="server" ControlToValidate="txtReferrerPts"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                  <asp:FilteredTextBoxExtender ID="FTBtxtReferrerPts" runat="server" TargetControlID="txtReferrerPts"
                          ValidChars=".0123456789" >
                    </asp:FilteredTextBoxExtender>
                    </b>
                        </td>
                        <td align="left">
                            
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
                            &nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btncncl" runat="server" CssClass="btnCancel" OnClick="btncncl_Click"
                                Text="Back" />
                                 &nbsp;&nbsp;
                                  <asp:Button ID="btnView" runat="server" CssClass="btnSave" OnClick="btnView_Click"
                                Text="View" />
                              
                               &nbsp;&nbsp;
                                   <asp:Button ID="btnPublish" runat="server" CssClass="btnSave" OnClick="btnPublish_Click"
                                Text="Publish" />
                               &nbsp;&nbsp;
                                   <asp:Button ID="btnDNPublish" runat="server" CssClass="btnSave" OnClick="btnDNPublish_Click"
                                Text="Do Not Publish" Width="150px" />
                        </td>
                    </tr>
                </table>
            </div>

            <%--region for View --%>
              <asp:Button ID="btnPopupView" runat="server" Style="display: none" />
                  <asp:ModalPopupExtender ID="MPEView" runat="server" TargetControlID="btnPopupView"
                        PopupControlID="PnlView" CancelControlID="imgClose" BackgroundCssClass="mdlbgrgnd">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="PnlView" runat="server" Width="90%">
                        <center>
                            <div class="popup">
                                <h6>
                                  
                                    <asp:ImageButton ID="imgClose" runat="server" Height="40px" ToolTip="Close Popup"
                                        ValidationGroup="MClose" Width="40px" ImageUrl="~/Image/close-icon.png" /></h6>
                                       
                                <table width="70%" style="font-size:13px" >
                                    <tr>
                                        <td colspan="4" align="center">  <b style="font-size:26px">  Final Publish on IndiaHiring</b>     
              
                                      
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="left" >
                                          <table>
                                             <tr>
                        <th colspan="6" align="left">
                            <asp:Label ID="lblDesignation" runat="server" Font-Bold="True" Font-Italic="False" Font-Size="16px" ></asp:Label>
                        </th>
                    </tr>
                    <tr>
                    <td align="left" style="width:150px">
                            <asp:ImageButton ID="imgExp" runat="server" Height="15px"   Width="15px" ImageUrl="~/Image/sms.png" />
                            &nbsp; <asp:Label ID="lblExperience" runat="server"></asp:Label>
                            &nbsp;
                              <asp:ImageButton ID="ImgLoc" runat="server" Height="15px"   Width="15px" ImageUrl="~/Image/loc.png" />
                             &nbsp;<asp:Label ID="lblLoc" runat="server" Text="Noida"></asp:Label>
                        </td>
                        </td>
                     
                       
                        <td colspan="5">
                        
                       
                    </tr>
                   
                     <tr>
                    <td align="left" >
                               <asp:Button ID="btnApply" runat="server" CssClass="btnSave"  Text="Apply" />
                               &nbsp;&nbsp;  <asp:Button ID="btnRefer" runat="server" CssClass="btnSave"  Text="Refer" />
                          
                        </td>
                     
                        <td align="left" colspan="5">
                          &nbsp;  &nbsp;<asp:Label ID="lblRefPointstxt" runat="server" Text="Referral Reward Points : "></asp:Label><asp:Label ID="lblrefPoints" runat="server" ></asp:Label> pts.
                        </td>
                       
                    </tr>

 <tr>
                    <td align="left">
                            <asp:ImageButton ID="ImgIndustry" runat="server" Height="15px"   Width="15px" ImageUrl="~/Image/star.png" />
                            &nbsp; <asp:Label ID="lblIndusttxt" runat="server" Text="Industry - "></asp:Label> <asp:Label ID="lblIndust" runat="server" Text="Dot Com"></asp:Label>

                           
                        </td>
                     
                        <td align="left" colspan="5">
                           
                             <asp:ImageButton ID="Imgpacakge" runat="server" Height="12px"   Width="12px" ImageUrl="~/Image/Rs.png" />
                             - &nbsp;INR&nbsp;<asp:Label ID="lblPackagefm" runat="server" Text=" INR 8,00,000 to 12,00,000 P.A"></asp:Label>
                             &nbsp;to&nbsp;<asp:Label ID="lblPackageto" runat="server" ></asp:Label>&nbsp;P.A.
                               &nbsp;&nbsp;<asp:Label ID="lblOpeningtxt" runat="server" Text="Opening(s) -"></asp:Label>
                               <asp:Label ID="lblOpening" runat="server" Text="1"></asp:Label>
                        </td>
                      
                       
                    </tr>

                      <tr> <td align="left" colspan="6" style="height:30px"> </td></tr>

                     <tr>
                    <td align="left" colspan="6">
                    <asp:Label ID="lblJobDesctxt" runat="server" Text="Job Description " Font-Size="14px"></asp:Label> 
                     <hr />
                     </td></tr>
                      
                        <tr>
                    <td align="left" colspan="6">
                           <asp:Label ID="lblJobdecs" runat="server" Width="650px"></asp:Label> 
                        </td>  </tr>
                         
                             <tr> <td align="left" style="width:200px">
                          Salary
                        </td> 
                        <td style="width:5px">: </td>
                        <td colspan="4">
                         INR&nbsp;<asp:Label ID="lblSalaryfm" runat="server" Text="INR 8,00,000 to 12,00,000 "></asp:Label> 
                         &nbsp;to&nbsp;<asp:Label ID="lblSalaryto" runat="server"></asp:Label> 
                        </td>
                         </tr>
                              <tr> <td align="left">
                         Industry
                        </td> 
                        <td style="width:5px">: </td>
                        <td colspan="4">
                         <asp:Label ID="lblIndustry" runat="server" Text="Dot Com"></asp:Label> 
                        </td>
                         </tr>
                              <tr> <td align="left">
                         Functional Area
                        </td> 
                        <td style="width:5px">: </td>
                        <td colspan="4">
                         <asp:Label ID="lblFunArea" runat="server" ></asp:Label> 
                        </td>
                         </tr>
                          <tr> <td align="left">
                         Role
                        </td> 
                        <td style="width:5px">: </td>
                        <td colspan="4">
                         <asp:Label ID="lblRole" runat="server" Text="Digital Marketing"></asp:Label> 
                        </td>
                         </tr>

                              <tr> <td align="left">
                          Key Skills
                        </td> 
                        <td style="width:5px">: </td>
                        <td colspan="4">
                         <asp:Label ID="lblKeySkill" runat="server" Text="Digital Marketing, Social Media Campaigns"></asp:Label> 
                        </td>
                         </tr>
                             
                                           </table>
                                       
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </center>
                    </asp:Panel>


            <%--End--%> 

        </ContentTemplate>
    </asp:UpdatePanel>

     
</asp:Content>



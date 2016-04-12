<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CandidateFormR.aspx.cs" Inherits="CandidateFormR" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Recruiter/EmpMenu.ascx" TagName="uctrlMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
      <link rel="Stylesheet" href="../Styles/Popup.css" type="text/css" />
     <link rel="Stylesheet" href="../Styles/BlueMaster.css" type="text/css" />

         <script type="text/javascript">

             
     
             
    </script>
    <style type="text/css">

.headingh2
{
    margin: 0px;
    text-align: center;
    padding: 5px 10px 5px 10px;
    font-family: calibri;
 } 
        .pnltop
        {
            width: 100%;
            height: auto;
        }
        
        /*CSS for Grid View*/
        .mGridDash
        {
            width: 100%;
            background-color: #CA1A21;
            margin: 5px 0 10px 0;
            border: 1px solid #FECBD3;
            border-collapse: collapse;
        }
        .mGridDash th
        {
            background: #CA1A21 url('../../Image/redmenu.jpg') repeat-x left center;
            color: #FFFFFF;
            font-family: Lucida Sans Unicode;
            font-size: 13px;
            height: 20px;
            vertical-align: middle;
            word-spacing: 5px;
            }
        .mGridDash td
        {
            border: 1px solid #FECBD3;
            color: #232323;
            font-family: "Lucida Sans Unicode";
            text-align: left;
            padding-left: 10px;
            font-size: 11px;
            vertical-align: middle;
        }
        
        .mGridDash .alt
        {
            background: #F9FCFF top;
        }
        
        .mGrid tbody tr:hover, .GridView tbody tr:hover td, .GridView tbody tr.hover, .GridView tbody tr.hover td
        {
            background: #F5FAFC;
            color: #000000;
        }
        .lbtnFView
        {
            font-family: "Lucida Sans Unicode";
            font-size: 14px;
            color: #0D203F;
            font-weight: 300;
        }
        .lbtnFolloup
        {
            font-family: "Lucida Sans Unicode";
            font-size: 14px;
            color: #008080;
        }

        .style3
        {
            font-weight: normal;
        }
        .auto-style1 {
            width: 25%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
    <%--<div id="page" style="height:600px;margin-top: 26px;">--%>
       <div id="page">
        <center>
            <table width="100%" >
                <tr>
                    <td align="left" valign="top" colspan="3">
                         <asp:Button runat="server" ID="btnFollowUp" Text="DashBoard" CssClass="btnCancel" Width="100px"/>
                        <asp:Button runat="server" ID="BtnJD" Text="JD" CssClass="btnCancel" Width="120px" OnClick="BtnJD_Click"/>
                        <asp:Button runat="server" ID="btnCandidate" Text="Candidate" CssClass="btnCancel" Width="100px" OnClick="btnCandidate_Click" />
                        <asp:Button runat="server" ID="btnFollowUpRecruiter" Text="Follow Ups" CssClass="btnCancel" Width="100px" OnClick="btnFollowUpRecruiter_Click" />
                        <asp:Button runat="server" ID="Button4" Text="CV Shared" CssClass="btnCancel" Width="100px" />
                        <asp:Button runat="server" ID="Button1" Text="Interview" CssClass="btnCancel" Width="100px" />
                        <asp:Button runat="server" ID="Button5" Text="Selected" CssClass="btnCancel" Width="100px" />
                    
                        <h2></h2>
                          
                             
                      
                       
                    </td>
                 
                 
                </tr>
                <tr>
                     
                    <td style="width:12%" valign="top">
                        <asp:Panel ID="PnlgdvJD" runat="server" Width="90%" ScrollBars="Vertical" Height="400px">
                     <asp:GridView ID="gdvFolloup" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvFolloup_RowCommand"
                                        GridLines="Vertical" 
                                        EmptyDataText="No Found JD." 
                                         PageSize="5"  HeaderStyle-ForeColor="White"  AllowSorting="true" CssClass="mGridDash" CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                                        <AlternatingRowStyle CssClass="alt" />
                                        <FooterStyle CssClass="footer" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Request_Id")%>'></asp:Label>
                                             </ItemTemplate>
                                            </asp:TemplateField>
                                         
           

                                   <asp:TemplateField HeaderText="JD">
                                    <ItemTemplate>
                                         <asp:Label ID="lblClientName" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label>/
                                         <asp:Label ID="lblJobProfile" runat="server" Text='<%#Eval("Job_Profile")%>'></asp:Label>
                                        <asp:LinkButton ID="LBRRNumber" runat="server" CommandName="View" Text='<%#Eval("RRNumber") %>' Font-Size="Small" Font-Bold="true"></asp:LinkButton>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CommandName="View12" Text='<%#Eval("RRNumber") %>' Font-Size="Small" Font-Bold="true" Visible="false"></asp:LinkButton>
                                   

                                        

                                        
                                        
                                        
                                    </ItemTemplate>
                                           <ItemStyle HorizontalAlign="Center" />
                                </asp:TemplateField>
                                       
                                        </Columns>
                                    </asp:GridView>
                            </asp:Panel>
                    </td>
                 
               <td valign="top" width="38%">
            
               
              <asp:Panel ID="PnlLink" runat="server" Width="90%" Height="50px" >
                    <table style="width:90%">
                 <tr>

                     <td valign="top" style="width: 20%">
                    <uc1:uctrlMenu ID="uctrlLogin1" runat="server" />
                   </td>
            
                </tr>

                        <tr>
                            <td valign="top">
                                <table>
                                    <tr>
                                        <td align="center" style="width:50%" valign="top">
                                            <asp:Label ID="lblHClientName" runat="server"></asp:Label>
                                        </td>
                                        <td align="center" style="width:20%" valign="top">
                                            <asp:Label ID="lblHjobprofile" runat="server"></asp:Label>
                                        </td>
                                        <td align="right" style="width:20%" valign="top">
                                            <asp:Label ID="lblrr" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                              
                                </table>
                            </td>
                        </tr>
                      
                 
                 </table>
               </asp:Panel>
               
              <asp:Panel ID="PnlJd" runat="server" Width="90%" Visible="false">
                <table width="100%">
                      <tr>
                          <td valign="top">
                     <fieldset >
                        <legend ><b>Job Description</b> </legend>
                       <table width="100%">
                    <tr>
                        <td align="right" class="auto-style1">
                            R R Number :
                        </td>
                        <td width="25%">
                            <asp:Label ID="lblRRNumber" runat="server"></asp:Label>
                            <asp:Label ID="lblRid" runat="server" Visible="false"></asp:Label>
                        </td>
                        <td width="25%" align="right">
                            Job Profile :
                        </td>
                        <td align="left" rowspan="2" valign="top">
                            <asp:Label ID="txtJobProfile" runat="server"></asp:Label>
                        </td>
                     
                       
                    </tr>
                    <tr>
                        <td align="right" class="auto-style1">
                            Client Name :
                        </td>
                        <td width="25%">
                            <asp:Label ID="lblClient" runat="server"></asp:Label>
                        </td>
                        <td align="right" width="25%">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="right" class="auto-style1">
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
                        <td align="right" class="auto-style1">
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
                        <td align="right" class="auto-style1">
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
                        <td align="right" class="auto-style1">
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
                        <td align="right" class="auto-style1">
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
                        <td align="right" class="auto-style1">
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
                        <td align="right" class="auto-style1">
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
                        <td align="right" class="auto-style1">
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
                        <td align="right" class="auto-style1">
                            Key Skills :
                        </td>
                        <td width="25%" colspan="3">
                            <asp:Label ID="lblSkills" runat="server"></asp:Label>
                        </td>
                        
                    </tr>
                     <tr>
                        <td align="right" class="auto-style1">
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
                  
                </table>
                          </fieldset>
                              </td>
                          </tr>
                    </table>
                    </asp:Panel>      
             
              <asp:Panel ID="PnlCandidate" runat="server" Width="100%">
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
                                <asp:Label ID="Label1" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnSave" runat="server" CssClass="btnSave" OnClick="btnSave_Click"
                                    Text="Save" ValidationGroup="Save" />
                                &nbsp;
                               <%-- <asp:Button ID="btnBack" runat="server" CssClass="btnCancel" OnClick="btnBack_Click"
                                    Text="Back" />--%>
                            </td>
                        </tr>
                    </table>
                     
                    </asp:Panel>
             
                    </td>
                
                   
                </tr>
               <tr>
                   <td>

                   </td>
                    <td valign="top" width="60%" >
                   
                </td>
               </tr>
              <tr>
                  <td>
                      
                  </td>
                  <td>
                      
                  </td>
              </tr>
            </table>
        </center>
    </div>


         </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="CandidateForJD.aspx.cs" Inherits="CandidateForJD" %>
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
                        <asp:Button runat="server" ID="btnFollowUp" Text="Dashboard" CssClass="btnCancel" Width="100px" />
                        <asp:Button runat="server" ID="BtnJD" Text="JD" CssClass="btnCancel" Width="120px" OnClick="BtnJD_Click1"/>
                        <asp:Button runat="server" ID="btnCandidate" Text="Candidate" CssClass="btnCancel" Width="100px"  OnClick="btnCandidate_Click"/>
                        <asp:Button runat="server" ID="btnFollowUpRecruiter" Text="Follow Ups" CssClass="btnCancel" Width="100px"  OnClick="btnFollowUpRecruiter_Click"/>
                        <asp:Button runat="server" ID="btnCVShared" Text="CV Shared" CssClass="btnCancel" Width="100px" OnClick="btnCVShared_Click" />
                        <asp:Button runat="server" ID="btnInterView" Text="Interview" CssClass="btnCancel" Width="100px"  OnClick="btnInterView_Click"/>
                        <asp:Button runat="server" ID="btnSelected" Text="Selected" CssClass="btnCancel" Width="100px" OnClick="btnSelected_Click" />
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
                                Candidates
                               </h2>
                    <table style="width:100%">
                        
                       
                        <tr>
                            <td>
                                  <asp:GridView ID="gdvCandidate" runat="server" AutoGenerateColumns="False" OnPageIndexChanging="gdvCandidate_PageIndexChanging" AllowPaging="true" PageSize="10"
                                    Width="100%" OnRowCommand="gdvCandidate_RowCommand"
                                    CssClass="mGrid" EmptyDataText="Sorry! No record found." DataKeyNames="Candidate_Id">
                                    
                                    <AlternatingRowStyle CssClass="alt" />
                                    <FooterStyle CssClass="footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCId" runat="server" Text='<%#Eval("Candidate_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="S.No.">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center"  Width="10px"/>
                                        </asp:TemplateField>
                                     
                                        <asp:TemplateField HeaderText="Client Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClntName" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left"  Width="160px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RR-No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRRno" runat="server" Text='<%#Eval("RRNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="70px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                              <%--  <asp:Label ID="lblName" runat="server" Text='<%#Eval("Candidate_Name")%>' Font-Bold="true"></asp:Label>--%>
                                              
                                                <asp:LinkButton ID="lblName" runat="server" CommandName="View12" Text='<%#Eval("Candidate_Name") %>' Font-Size="Small"></asp:LinkButton>
                                                 <asp:Label ID="lblRRCId" runat="server" Text='<%#Eval("RRCandidate_Id")%>' Visible="false"></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="120" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Current Employer">
                                            <ItemTemplate>
                                                <%#Eval("Current_Employer")%>  <br />
                                              <i>  <%#Eval("Current_Designation")%></i>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="250px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile_No")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left"  Width="90px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CTC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCTC" runat="server" Text='<%#Eval("Annual_Salary")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="50px"/>
                                        </asp:TemplateField>
                                        <%--<asp:TemplateField HeaderText="Recruiter Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecStatus" runat="server" Text='<%#Eval("Recruiter_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Approver Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblApproveStatus" runat="server" Text='<%#Eval("Supervisor_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>--%>
                                        <asp:TemplateField HeaderText="Work Exp">
                                            <ItemTemplate>
                                                <asp:Label ID="lblWorkExp" runat="server" Text='<%#Eval("WorkExp")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ConsultantID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsultantId" runat="server" Text='<%#Eval("Consultant_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                 
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        </table>
                     
                    </asp:Panel>


                   <asp:Panel ID="pnlHistory" runat="server" Width="100%" Visible="false">
              
                       <table style="width: 100%">


                           <tr>


                               <td>

                                   <td valign="top" style="width:50%">
                                       <fieldset style="height:430px">
                                           <legend><b>Candidate Profile</b>

                                           </legend>
                                           <table width="100%">
                                               <tr>
                                                   <td style="width: 18%" class="style4">Name
                                                   </td>
                                                   <td style="width: 29%">:
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                     <asp:Label ID="lblCid" runat="server" Visible="false"></asp:Label>
                                                   </td>
                                                   <td style="width: 16%">
                                                       <strong>CTC</strong>
                                                   </td>
                                                   <td style="width: 28%">:
                                    <asp:Label ID="lblCTC" runat="server"></asp:Label>
                                                   </td>
                                               </tr>
                                               <tr>
                                                   <td class="style4">Resume Title
                                                   </td>
                                                   <td colspan="3">:
                                    <asp:Label ID="lblResumeTittle" runat="server"></asp:Label>
                                                   </td>
                                               </tr>
                                               <tr>
                                                   <td class="style4">Company
                                                   </td>
                                                   <td colspan="3">:
                                    <asp:Label ID="lblCompny" runat="server"></asp:Label>
                                                   </td>
                                               </tr>
                                               <tr>
                                                   <td class="style4">Qualification
                                                   </td>
                                                   <td colspan="3">:
                                    <asp:Label ID="lblQualification" runat="server"></asp:Label>
                                                   </td>
                                               </tr>
                                               <tr>
                                                   <td class="style4">Designation
                                                   </td>
                                                   <td>:
                                    <asp:Label ID="lblCDesignation" runat="server"></asp:Label>
                                                   </td>
                                                   <td>
                                                       <strong>Experience </strong>
                                                   </td>
                                                   <td>:
                                    <asp:Label ID="lblExperience" runat="server"></asp:Label>
                                                   </td>
                                               </tr>
                                               <tr>
                                                   <td class="style4">Contact No.
                                                   </td>
                                                   <td>:
                                    <asp:Label ID="lblContact" runat="server"></asp:Label>
                                                   </td>
                                                   <td>
                                                       <strong>Location</strong>
                                                   </td>
                                                   <td>:
                                    <asp:Label ID="lblCLocation" runat="server"></asp:Label>
                                                   </td>
                                               </tr>
                                               <tr>
                                                   <td>
                                                       <b>Email Id</b>
                                                   </td>
                                                   <td colspan="3">:
                                    <asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                                   </td>
                                               </tr>
                                               <tr>
                                                   <td class="style4">Last Act. Date :
                                                   </td>
                                                   <td colspan="2">:
                                    <asp:Label ID="lblLastActiveDate" runat="server"></asp:Label>
                                                   </td>
                                                   <td>&nbsp;<asp:Label ID="lblPortalResume" runat="server" Visible="false"></asp:Label>
                                                   </td>
                                               </tr>
                                               <tr runat="server">
                                                   <td colspan="1" class="style4">Resume&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                   </td>
                                                   <td colspan="3">:
                                    <asp:LinkButton ID="lbtnResume" runat="server" OnClick="lbtnResume_Click">View Resume</asp:LinkButton>
                                                   </td>
                                               </tr>
                                               <tr runat="server">
                                                   <td colspan="1" class="style4">Upload Resume
                                                   </td>
                                                   <td colspan="2">:
                                    <asp:FileUpload ID="fileUpload" runat="server" />
                                                   </td>
                                                   <td>
                                                       <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
                                                   </td>
                                               </tr>
                                           </table>
                                       </fieldset>
                                   </td>
                                  <td valign="top" style="width:50%">
                         <fieldset style="height:430px">
                        <legend><b> FollowUp</b> </legend>
                          <table width="100%">
                                    <tr>
                                        <td style="width: 30%">
                                         Next FollowUp Type
                                        </td>
                                        <td style="width: 30%">
                                           <asp:DropDownList ID="ddlFolowType" runat="server" CssClass="DropDown">
                                                <asp:ListItem Selected="True">Call</asp:ListItem>
                                                <asp:ListItem>Meeting</asp:ListItem>
                                                <asp:ListItem>Email</asp:ListItem>
                                                <asp:ListItem>Interview</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                   
                                      
                                    </tr>
                                    <tr>
                                        <td>
                                        Next FollowUp Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFollowDate" runat="server" CssClass="TxtBox"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtFollowDate_CalendarExtender" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtFollowDate" TargetControlID="txtFollowDate">
                                            </asp:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="Rev4" runat="server" ControlToValidate="txtFollowDate"
                                                Display="Dynamic" ErrorMessage="Wrong Date" ForeColor="Red" SetFocusOnError="true"
                                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                                ValidationGroup="Save"></asp:RegularExpressionValidator>
                                        </td>
                                    
                                    </tr>
                                    <tr>
                                        <td>
                                            Candidate Status
                                        </td>
                                        <td valign="top">
                                            <asp:DropDownList ID="ddlCandStatus" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                               >
                                            </asp:DropDownList>
                                        </td>
                                    
                                    </tr>
                                
                                    <tr>
                                   
                                        <td>Remarks </td>
                                        <td>
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="TxtBox" Height="40px" TextMode="MultiLine" Width="300px"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtRemarks"
                                              ErrorMessage="*" ForeColor="Red" ValidationGroup="Save"></asp:RequiredFieldValidator>
                                        </td>
                                        
                                        
                                    </tr>


                                        </td>
                                
                                    </tr>
                                  <tr>
                                        <td colspan="2" align="center">
                                            &nbsp;
                                       
                                              <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>

                                        </td>
                                        
                                    </tr>
                                    
                                    <tr>
                                        <td colspan="3" align="center">
                                            &nbsp;
                                            <asp:Button ID="btnSave" runat="server" CssClass="btnSave" Text="Save" ValidationGroup="Save" OnClick="btnSave_Click"/>
                                        </td>
                                        
                                    </tr>
                           <tr>
                               <td colspan="2" style="width:100%">
                                 
                                   <asp:Panel ID="pnlFollowHisty" runat="server" Height="150px" ScrollBars="Vertical" Width="100%">
                                       <asp:GridView ID="gdvFollowuphis" runat="server" AutoGenerateColumns="False" DataKeyNames="FollowUp_Id" EmptyDataText="Sorry! No record found." CssClass="mGrid" OnPageIndexChanging="gdvFollowuphis_PageIndexChanging" PageSize="3" Width="100%">
                                           <AlternatingRowStyle CssClass="alt" />
                                           <FooterStyle CssClass="footer" />
                                           <Columns>
                                               <asp:TemplateField HeaderText="FollowUp Id" Visible="false">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblFId" runat="server" Text='<%#Eval("FollowUp_Id")%>'></asp:Label>
                                                   </ItemTemplate>
                                               </asp:TemplateField>
                                               <asp:TemplateField HeaderText="FollowUp History">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblType" runat="server" Text='<%#Eval("FollowUp_Type")%>'></asp:Label>/
                                                          <asp:Label ID="lblDate" runat="server" Text='<%#Eval("FollowUp_Date")%>'></asp:Label>/
                                                         <asp:Label ID="lblCandStatus" runat="server" Text='<%#Eval("Candidate_Status")%>'></asp:Label>/
                                                         <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("FollowUp_Remarks")%>'></asp:Label>
                                                   </ItemTemplate>
                                                   <HeaderStyle HorizontalAlign="Center" />
                                                   <ItemStyle HorizontalAlign="Left" />
                                               </asp:TemplateField>
                                             
                                           </Columns>
                                       </asp:GridView>
                                   </asp:Panel>
                                     
                               </td>
                           </tr>
                   
                                </table>
                    </fieldset>
                                   </td>
                                  
                               </td>
                           </tr>

                           

                         
                       </table>
                      </fieldset>
                 
                     
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

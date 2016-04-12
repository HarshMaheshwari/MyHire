<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RecruiterDashboard.aspx.cs" Inherits="RecruiterDashboard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<%@ Register Src="~/Recruiter/EmpMenu.ascx" TagName="uctrlMenu" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
      <link rel="Stylesheet" href="../Styles/Popup.css" type="text/css" />
     <link rel="Stylesheet" href="../Styles/BlueMaster.css" type="text/css" />

         <script type="text/javascript">

             
     
             
    </script>
    <style type="text/css">
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
                        <asp:Button runat="server" ID="btnFollowUp" Text="DashBoard" CssClass="btnCancel" Width="100px" />
                        <asp:Button runat="server" ID="BtnJD" Text="JD" CssClass="btnCancel" Width="120px"  OnClick="BtnJD_Click"/>
                        <asp:Button runat="server" ID="btnCandidate" Text="Candidate" CssClass="btnCancel" Width="100px" OnClick="btnCandidate_Click" />
                        <asp:Button runat="server" ID="btnFollowUpRecruiter" Text="Follow Ups" CssClass="btnCancel" Width="100px" OnClick="btnFollowUpRecruiter_Click" />
                        <asp:Button runat="server" ID="btnCVShared" Text="CV Shared" CssClass="btnCancel" Width="100px" OnClick="btnCVShared_Click" />
                        <asp:Button runat="server" ID="btnInterView" Text="Interview" CssClass="btnCancel" Width="100px" OnClick="btnInterView_Click" />
                        <asp:Button runat="server" ID="btnSelected" Text="Selected" CssClass="btnCancel" Width="100px" OnClick="btnSelected_Click" />
                        <h2></h2>

                          
                             
                      
                       
                    </td>
                 
                 
                </tr>
                <tr>
                     
                    <td style="width:12%" valign="top">
                        <asp:Panel ID="PnlgdvJD" runat="server" Width="90%" ScrollBars="Vertical" Height="400px">
                     <asp:GridView ID="gdvFolloup" runat="server" AutoGenerateColumns="False" OnRowCommand="gdvFolloup_RowCommand" OnSelectedIndexChanging="gdvFolloup_SelectedIndexChanging"
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
               

                <asp:Panel ID="PnlLink" runat="server" Width="90%">
                    <table style="width:90%">
                 <tr>

                     <td valign="top" style="width: 20%">
                    <uc1:uctrlMenu ID="uctrlLogin1" runat="server" />
                   </td>
              

                       
                </tr>
                    


                 <tr>
                <td>
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
                        
                     
                 
                            </tr>
                 
               </table>    
                 
                 </table>
               </asp:Panel>
                      
                <asp:Panel ID="PnlJd" runat="server" Width="90%" Visible="false">
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
                    
                    </asp:Panel>
                <asp:Panel ID="PnlCandidate" runat="server" Width="90%">
                    <table>
                        <tr>
                            <td>
                                  <asp:GridView ID="gdvCandidate" runat="server" AutoGenerateColumns="False"
                                    AllowPaging="True" Width="100%" OnRowCommand="gdvCandidate_RowCommand"
                                    GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                                    >
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
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RRID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRRId" runat="server" Text='<%#Eval("RRCandidate_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClntName" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RR-No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRRno" runat="server" Text='<%#Eval("RRNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="6%" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name">
                                            <ItemTemplate>
                                              <%--  <asp:Label ID="lblName" runat="server" Text='<%#Eval("Candidate_Name")%>' Font-Bold="true"></asp:Label>--%>
                                                <asp:LinkButton ID="lblName" runat="server" CommandName="View12" Text='<%#Eval("Candidate_Name") %>' Font-Size="Small"></asp:LinkButton>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Current Employer">
                                            <ItemTemplate>
                                                <%#Eval("Current_Employer")%>  <br />
                                              <i>  <%#Eval("Current_Designation")%></i>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Mobile No.">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile_No")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="CTC">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCTC" runat="server" Text='<%#Eval("Annual_Salary")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Recruiter Status">
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
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Candidate Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCandStatus" runat="server" Text='<%#Eval("Candidate_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ConsultantID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsultantId" runat="server" Text='<%#Eval("Consultant_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    <%--    <asp:TemplateField HeaderText="Action">
                                            <ItemTemplate>
                                                <asp:ImageButton ID="FollowUp" CommandName="FollowUp" runat="server" ImageUrl="~/Image/Followup.png"
                                                    ToolTip="FollowUp" Height="22px" Width="22px" />
                                                <asp:ImageButton ID="lbtnRRHistory" CommandName="RRHistory" ImageUrl="~/Image/RRHistory.png"
                                                    runat="server" ToolTip="RRHistory" Height="22px" Width="22px" />
                                                <asp:ImageButton ID="History" CommandName="History" runat="server" ImageUrl="~/Image/History.jpg"
                                                    ToolTip="History" Height="22px" Width="22px" />
                                                <asp:ImageButton ID="imgbtnVideo" runat="server" CommandName="Video" ImageUrl="~/Image/VideoIcon.png"
                                                    ToolTip="Send Video Link" Height="25px" Width="25px" />
                                                <asp:ImageButton ID="imgbtnViewVideo" runat="server" CommandName="ViewVideo" ImageUrl="~/Image/Video.png"
                                                    ToolTip="View Candidate Video" Height="22px" Width="22px" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" Width="13%"/>
                                        </asp:TemplateField>--%>
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        </table>
                     
                    </asp:Panel>
               <%-- <asp:Panel ID="PnlHistory" runat="server" Width="90%">
                    <table>
                        <tr>
                            <td>
                                
                            </td>
                        </tr>
                        </table>
                     
                    </asp:Panel>--%>
                <asp:Panel ID="PnlCVShared" runat="server" Width="90%">
                    <table>
                        <tr>
                            <td>
              <asp:GridView runat="server" AutoGenerateColumns="False" CssClass="mGrid"
                        ID="gdvCVShared" EmptyDataText="Sorry! No Record Found."
                         HeaderStyle-ForeColor="White">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." SortExpression="Candidate_Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"  Width="5%" />
                               <ItemStyle HorizontalAlign="Center"  Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id") %>'></asp:Label></ItemTemplate>
                                   
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Client Name " SortExpression="Client_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="12%" />
                                <ItemStyle HorizontalAlign="Left" Width="12%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RR Number" SortExpression="RRNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblRRNo" runat="server" Text='<%#Eval("RRNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="8%" />
                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                            </asp:TemplateField>
                         
                            <asp:TemplateField HeaderText="Job Profile" SortExpression="Job_Profile">
                                <ItemTemplate>
                                    <asp:Label ID="lblJob" runat="server" Text='<%#Eval("Job_Profile") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%"/>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Candidate Name" SortExpression="Candidate_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCandidate" runat="server" Text='<%#Eval("Candidate_Name") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="13%" />
                                <ItemStyle HorizontalAlign="Left"  Width="13%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email Id" SortExpression="Email" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone No" SortExpression="Mobile_No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Mobile_No") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                            </asp:TemplateField>
                          
                          <asp:TemplateField HeaderText="Approver" SortExpression="Approver">
                                <ItemTemplate>
                                    <asp:Label ID="lblApprover" runat="server" Text='<%#Eval("Approver") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                 <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Next FollowUp Date" SortExpression="FollowUp_Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblFollowUp_Date" runat="server" Text='<%#Eval("FollowUp_Date") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Overall Status" SortExpression="OverAllStatus">
                                <ItemTemplate>
                                    <asp:Label ID="lblOverAllStatus" runat="server" Text='<%#Eval("OverAllStatus") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                <ItemStyle HorizontalAlign="Left" Width="15%"/>
                            </asp:TemplateField>

                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                    </asp:GridView>
                            </td>
                        </tr>
                        </table>
                     
                    </asp:Panel>
                <asp:Panel ID="PnlFollowup" runat="server" Width="90%">
                    <table>
                        <tr>
                            <td>
                           <asp:GridView ID="gdvFollowup" runat="server" AutoGenerateColumns="False" DataKeyNames="Candidate_Id"
                                    AllowPaging="True" Width="100%"
                                    GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                                     HeaderStyle-ForeColor="White"  CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <FooterStyle CssClass="footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="S.No." SortExpression="Candidate_Id">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RRID" Visible="false"  SortExpression="Candidate_Id">
                                            <ItemTemplate>
                                              <%--  <asp:Label ID="lblRRId" runat="server" Text='<%#Eval("RRCandidate_Id")%>'></asp:Label>--%>
                                                 <asp:Label ID="lblRequest_Id" runat="server" Text='<%#Eval("Request_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client Name"  SortExpression="Candidate_Id">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClntName" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left"  Width="130px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RR-No" SortExpression="Candidate_Id">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRRno" runat="server" Text='<%#Eval("RRNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" SortExpression="Candidate_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Font-Bold="true" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Designation" SortExpression="Current_Designation">
                                            <ItemTemplate>
                                              <%--  <%#Eval("Current_Employer")%>  <br />--%>
                                                <%#Eval("Current_Designation")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left"  Width="250px"/>
                                        </asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="Mobile No." Visible="false" SortExpression="Mobile_No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile_No")%>' ></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                     <%--   <asp:TemplateField HeaderText="Next Follow Up "  SortExpression="FollowUp_Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNxtFollowUp" runat="server" Text='<%#Eval("FollowUp_Date")%>' ></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px"/>
                                        </asp:TemplateField>--%>
                                         

                                      <%--  <asp:TemplateField HeaderText="Recruiter Status" SortExpression="Recruiter_Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecStatus" runat="server" Text='<%#Eval("Recruiter_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px"/>
                                        </asp:TemplateField>--%>
                                      
                                        <asp:TemplateField HeaderText="Candidate Status" SortExpression="Overall_Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCandStatus" runat="server" Text='<%#Eval("Overall_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                         <%-- <asp:TemplateField HeaderText="Remarks" SortExpression="FollowUp_Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("FollowUp_Remarks")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="180px" />
                                        </asp:TemplateField>--%>
                                        
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        </table>
                     
                    </asp:Panel>
                <asp:Panel ID="pnlInterviewpndg" runat="server" Width="90%">
                    <table>
                        <tr>
                            <td>
                           <asp:GridView runat="server" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Candidate_Id"
                        ID="gdvInterviewPndng" AllowPaging="True" EmptyDataText="Sorry! No Record Found."
                         HeaderStyle-ForeColor="White" CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." SortExpression="Candidate_Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"  Width="5%" />
                               <ItemStyle HorizontalAlign="Center"  Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id") %>'></asp:Label></ItemTemplate>
                                   
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Client Name " SortExpression="Client_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="12%" />
                                <ItemStyle HorizontalAlign="Left" Width="12%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RR Number" SortExpression="RRNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblRRNo" runat="server" Text='<%#Eval("RRNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="8%" />
                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                            </asp:TemplateField>
                         
                            <asp:TemplateField HeaderText="Job Profile" SortExpression="Job_Profile">
                                <ItemTemplate>
                                    <asp:Label ID="lblJob" runat="server" Text='<%#Eval("Job_Profile") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%"/>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Candidate Name" SortExpression="Candidate_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCandidate" runat="server" Text='<%#Eval("Candidate_Name") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="13%" />
                                <ItemStyle HorizontalAlign="Left"  Width="13%"/>
                            </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="Phone No" SortExpression="Mobile_No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Mobile_No") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                            </asp:TemplateField>
                          
                         <%-- <asp:TemplateField HeaderText="Approver" SortExpression="Approver">
                                <ItemTemplate>
                                    <asp:Label ID="lblApprover" runat="server" Text='<%#Eval("Approver") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                 <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>--%>
   <%--                         <asp:TemplateField HeaderText="Next FollowUp Date" SortExpression="FollowUp_Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblFollowUp_Date" runat="server" Text='<%#Eval("FollowUp_Date") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Overall Status" SortExpression="Overall_Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblOverAllStatus" runat="server" Text='<%#Eval("Overall_Status") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                <ItemStyle HorizontalAlign="Left" Width="15%"/>
                            </asp:TemplateField>

                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                    </asp:GridView>
                            </td>
                        </tr>
                        </table>
                     
                    </asp:Panel>
                <asp:Panel ID="PnlInterviewDone" runat="server" Width="90%">
                    <table>
                        <tr>
                            <td>
                           <asp:GridView runat="server" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Candidate_Id"
                        ID="gdvInterviewDone" AllowPaging="True" EmptyDataText="Sorry! No Record Found."
                         HeaderStyle-ForeColor="White" CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." SortExpression="Candidate_Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"  Width="5%" />
                               <ItemStyle HorizontalAlign="Center"  Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id") %>'></asp:Label></ItemTemplate>
                                   
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Client Name " SortExpression="Client_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="12%" />
                                <ItemStyle HorizontalAlign="Left" Width="12%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RR Number" SortExpression="RRNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblRRNo" runat="server" Text='<%#Eval("RRNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="8%" />
                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Consultants" SortExpression="ConsultantName">
                                <ItemTemplate>
                                    <asp:Label ID="lblConsultants" runat="server" Text='<%#Eval("ConsultantName") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Job Profile" SortExpression="Job_Profile">
                                <ItemTemplate>
                                    <asp:Label ID="lblJob" runat="server" Text='<%#Eval("Job_Profile") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%"/>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Candidate Name" SortExpression="Candidate_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCandidate" runat="server" Text='<%#Eval("Candidate_Name") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="13%" />
                                <ItemStyle HorizontalAlign="Left"  Width="13%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email Id" SortExpression="Email" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone No" SortExpression="Mobile_No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Mobile_No") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                            </asp:TemplateField>
                          
                          <asp:TemplateField HeaderText="Approver" SortExpression="Approver">
                                <ItemTemplate>
                                    <asp:Label ID="lblApprover" runat="server" Text='<%#Eval("Approver") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                 <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Next FollowUp Date" SortExpression="FollowUp_Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblFollowUp_Date" runat="server" Text='<%#Eval("FollowUp_Date") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Overall Status" SortExpression="OverAllStatus">
                                <ItemTemplate>
                                    <asp:Label ID="lblOverAllStatus" runat="server" Text='<%#Eval("OverAllStatus") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                <ItemStyle HorizontalAlign="Left" Width="15%"/>
                            </asp:TemplateField>

                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                    </asp:GridView>
                            </td>
                        </tr>
                        </table>
                     
                    </asp:Panel>
                <asp:Panel ID="pnlOffred" runat="server" Width="90%">
                    <table>
                        <tr>
                            <td>
                           <asp:GridView runat="server" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Candidate_Id"
                        ID="gdvOffered" AllowPaging="True" EmptyDataText="Sorry! No Record Found."
                         HeaderStyle-ForeColor="White" CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." SortExpression="Candidate_Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"  Width="5%" />
                               <ItemStyle HorizontalAlign="Center"  Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id") %>'></asp:Label></ItemTemplate>
                                   
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Client Name " SortExpression="Client_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="12%" />
                                <ItemStyle HorizontalAlign="Left" Width="12%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RR Number" SortExpression="RRNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblRRNo" runat="server" Text='<%#Eval("RRNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="8%" />
                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Consultants" SortExpression="ConsultantName">
                                <ItemTemplate>
                                    <asp:Label ID="lblConsultants" runat="server" Text='<%#Eval("ConsultantName") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Job Profile" SortExpression="Job_Profile">
                                <ItemTemplate>
                                    <asp:Label ID="lblJob" runat="server" Text='<%#Eval("Job_Profile") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%"/>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Candidate Name" SortExpression="Candidate_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCandidate" runat="server" Text='<%#Eval("Candidate_Name") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="13%" />
                                <ItemStyle HorizontalAlign="Left"  Width="13%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email Id" SortExpression="Email" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone No" SortExpression="Mobile_No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Mobile_No") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                            </asp:TemplateField>
                          
                          <asp:TemplateField HeaderText="Approver" SortExpression="Approver">
                                <ItemTemplate>
                                    <asp:Label ID="lblApprover" runat="server" Text='<%#Eval("Approver") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                 <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Next FollowUp Date" SortExpression="FollowUp_Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblFollowUp_Date" runat="server" Text='<%#Eval("FollowUp_Date") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Overall Status" SortExpression="OverAllStatus">
                                <ItemTemplate>
                                    <asp:Label ID="lblOverAllStatus" runat="server" Text='<%#Eval("OverAllStatus") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                <ItemStyle HorizontalAlign="Left" Width="15%"/>
                            </asp:TemplateField>

                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                    </asp:GridView>
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
                                       
                                <table width="80%" cellpadding="3" cellspacing="3">
                                        <tr>
                                        <td colspan="4" align="center">  <b style="font-size:26px">Candidate Profile</b>     
              
                                      
                                        </td>
                                    </tr>
                        <tr>
                            <td align="right" style="width: 20%">
                                Candidate Name :
                            </td>
                            <td align="left" style="width: 30%">
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                            </td>
                            <td align="right" style="width: 20%">
                                Date Of Birth :
                            </td>
                            <td align="left" style="width: 30%">
                                <asp:Label ID="lblDob" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Telephone No :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblPhn" runat="server"></asp:Label>
                            </td>
                            <td align="right" rowspan="2" valign="top">
                                Address:
                            </td>
                            <td align="left" rowspan="2" valign="top">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Mobile No :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblMobile" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Email Id :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                Alt Email Id :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAltEmail" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Current Location :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblCurrentLocation" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                Preferred Location :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblPreferred" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Current Employer :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblEmployer" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                Current Designation:
                            </td>
                            <td align="left">
                                <asp:Label ID="lblDesg" runat="server"></asp:Label>
                        </tr>
                        <tr>
                            <td align="right">
                                Current CTC :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblSalary" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                Work Experience :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblExperience" runat="server"></asp:Label>
                        </tr>
                        <tr>
                            <td align="right">
                                UG Course :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblUG" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                PG Course :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblPG" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Post PG Course :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblPost" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                Candidate Source :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblcandidateSource" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                PAN Card Number :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblPanCard" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                Passport Number :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblPasportNo" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Issue Date :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblissueDate" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                Issue Location :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblIssueLocation" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                Adhar Card Number :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblAdharCard" runat="server"></asp:Label>
                            </td>
                            <td align="right">
                                Industry :
                            </td>
                            <td align="left">
                                <asp:Label ID="lblIndustry" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                            <td align="right">
                                &nbsp;</td>
                            <td align="left">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                &nbsp;
                              <%--  <asp:Button ID="btnBack" runat="server" CssClass="btnCancel"
                                    Text="Back" />--%>
                            </td>
                        </tr>
                    </table>
                                       
                                        </td>
                                    </tr>
                                </table>
                            </div>
                        </center>
                    </asp:Panel>

         </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

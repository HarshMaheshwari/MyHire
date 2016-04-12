<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewRRequest.aspx.cs" Inherits="Recruitment_ViweRRequest" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
            <div id="page">
                <h2>
                    View Recruitment Request
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
                        <td align="center" colspan="4">
                            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td align="center" colspan="4">
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                            <asp:Button ID="btncncl" runat="server" CssClass="btnCancel" OnClick="btncncl_Click"
                                Text="Back" />
                        </td>
                    </tr>
                </table>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

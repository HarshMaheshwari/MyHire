<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewCandidate.aspx.cs" Inherits="Recruitment_ViewCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                                <asp:Button ID="btnBack" runat="server" CssClass="btnCancel" OnClick="btnBack_Click"
                                    Text="Back" />
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

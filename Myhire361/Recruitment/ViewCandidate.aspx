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
                        View Candidate
                    </h2>
                    <table width="70%">
                        <tr>
                            <td align="right" width="25%">
                                Name :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblName" runat="server"></asp:Label>
                            </td>
                            <td align="right" width="25%">
                                &nbsp;
                            </td>
                            <td align="left" width="25%">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                         <td align="right" width="25%">
                                Mobile No :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblMobile" runat="server"></asp:Label>
                            </td>
                            <td align="right" width="25%">
                                Telephone No :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblPhn" runat="server"></asp:Label>
                            </td>
                           
                        </tr>
                        <tr>
                            <td align="right" width="25%">
                                Date Of Birth :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblDob" runat="server"></asp:Label>
                            </td>
                            <td align="right" width="25%">
                                Email Id :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="25%">
                                Work Experience :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblExp" runat="server">
                                </asp:Label>
                            </td>
                            <td align="right" width="25%">
                                Current Location :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblCurrent" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="25%">
                                Preferred Location :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblPreferred" runat="server"></asp:Label>
                            </td>
                            <td align="right" width="25%">
                                Current Employer :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblEmp" runat="server">
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="25%">
                                Current Designation:
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblDesg" runat="server">
                   
                                </asp:Label>
                            </td>
                            <td align="right" width="25%">
                                Annual Salary :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblSalary" runat="server">
                  
                                </asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="25%">
                                UG Course :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblUG" runat="server"></asp:Label>
                            </td>
                            <td align="right" width="25%">
                                PG Course :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblPG" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="25%">
                                Post PG Course :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblPost" runat="server"></asp:Label>
                            </td>
                            <td align="right" width="25%">
                                Last Activation Date :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblDate" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="25%">
                                Address :
                            </td>
                            <td align="left" colspan="3" style="width: 50%">
                                <asp:Label ID="lblAddress" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="4">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td align="center" colspan="4">
                                <asp:Button ID="btnBack" runat="server" CssClass="btnCancel" OnClick="btnBack_Click"
                                    Text="Back" />
                                &nbsp;
                            </td>
                        </tr>
                    </table>
                </div>
            </center>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

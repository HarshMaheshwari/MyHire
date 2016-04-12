<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ViewClient.aspx.cs" Inherits="ViewClient" %>

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
                        View Client
                    </h2>
                    <table width="70%">
                        <tr>
                            <td align="right" width="25%">
                                Client Code :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblCode" runat="server"></asp:Label>
                            </td>
                            <td align="right" width="25%">
                                Client Name :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblClient" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="25%">
                                Contact Name :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblcntct" runat="server"></asp:Label>
                            </td>
                            <td align="right" width="25%">
                                Contact Email Id :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
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
                                Contact Phone :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblPhn" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="25%">
                                Consultant Assigned :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblConsultant" runat="server">
                                </asp:Label>
                            </td>
                            <td align="right" width="25%">
                                Date Of Anniversary :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblDoa" runat="server"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td align="right" width="25%">
                                Website :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblWebsite" runat="server"></asp:Label>
                            </td>
                            <td align="right" width="25%">
                                Location :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblLocation" runat="server">
                                </asp:Label>
                            </td>
                        </tr>


                        <tr>
                            <td align="right" width="25%">
                                Email Alert :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblEmailAlert" runat="server">
                   
                                </asp:Label>
                            </td>
                            <td align="right" width="25%">
                                SMS Alert :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblSMS" runat="server">
                  
                                </asp:Label>
                            </td>
                        </tr>

                         <tr>
                            <td align="right" width="25%">
                                Client Source :
                            </td>
                            <td align="left" width="25%">
                                <asp:Label ID="lblClientSource" runat="server">
                   
                                </asp:Label>
                            </td>
                            <td align="right" width="25%">
                               
                            </td>
                            <td align="left" width="25%">
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

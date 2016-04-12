<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>RR Tracker</title>
    <link rel="Stylesheet" href="Styles/Login.css" type="text/css" />
     <link rel="Stylesheet" href="Styles/Popup.css"  type="text/css" />
    <style type="text/css">
        .auto-style1 {
            width: 191px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <center>
        <div id="main">
            <div id="mhead">
                 <asp:Image ID="imgClientLogo" runat="server" CssClass="logocss" 
                        ImageUrl="~/Image/logo.png" Height="100px" Width="180px" />
            </div>
            <div id="middle">
                <div id="mleft">
                          
                    <h2>
                        Login</h2>
                    <div class="mlgn" align="center">
                        <table style="height: 100px">
                            <tr>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtUsrName" runat="server" CssClass="txtbx"></asp:TextBox>
                                    <asp:TextBoxWatermarkExtender ID="TWE1" runat="server" TargetControlID="txtUsrName"
                                        WatermarkText="Username" WatermarkCssClass="watermark">
                                    </asp:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    <asp:TextBox ID="txtPsswrd" runat="server" CssClass="txtbx" TextMode="Password"></asp:TextBox>
                                    <asp:TextBoxWatermarkExtender ID="TWE2" runat="server" TargetControlID="txtPsswrd"
                                        WatermarkText="Password" WatermarkCssClass="watermark">
                                    </asp:TextBoxWatermarkExtender>
                                </td>
                            </tr>
                            <tr>
                                <td class="auto-style1">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                
                                <td align="center" class="auto-style1">
                                    <asp:Button ID="btnLogin" runat="server" Text="Submit" CssClass="loginbtn" OnClick="btnLogin_Click" />
                                </td>
                            </tr>
                             
                            <tr>
                                <td align="center" class="auto-style1">
                                    <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                                </td>
                            </tr>
                        </table>
                         
                    </div>
                    <td align="left" valign="bottom" >

                                     <asp:ImageButton ID="imgbtnSignin"  src="../Image/signIn.Jpg" runat="server" Height="18" Width="60" OnClick="imgbtnSignin_Click" Visible="false" >
                                     </asp:ImageButton></td>
                     <td align="left" valign="top">
             <asp:LinkButton ID="lbtnCreateNew" runat="server" Font-Size="13px" CssClass="btn-link" OnClick="lbtnCreateNew_Click" Visible="false">Create New Account</asp:LinkButton></td>
                    
                </div>
                <div id="mright">
                    <img src="Image/LoginBnr.jpg" width="695" height="300" alt="" />
                </div>
            </div>
            <table id="bottom">
                <tr>
                   
                    <td class="lbottom" align="center" width="33%">
                        <p>
                            <a href="#">Knowledge</a></p>
                    </td>
                    <td class="lbottom" align="center" width="33%">
                        <p>
                            <a href="#">Forgot Password</a></p>
                    </td>
                    <td class="lbottom" align="center" width="33%">
                        <p>
                            <a href="#">Contact Us</a></p>
                    </td>
                </tr>
                <tr>
                    
                    <td class="lrbottom" align="center" width="33%">
                        <asp:ImageButton ID="ImgKnowldg" runat="server" Height="105px" Width="105px" 
                            ImageUrl="~/Image/Knowldg.png" />
                    </td>
                    <td class="lrbottom" align="center" width="33%">
                        <asp:ImageButton ID="ImgFrgtPswrd" runat="server" ImageUrl="~/Image/FrgtPswrd.png"
                            Height="105px" Width="105px"  />
                    </td>
                    <td class="lrbottom" align="center" width="33%">
                        <asp:ImageButton ID="ImgContact" runat="server" ImageUrl="~/Image/Contact.png" Height="105px"
                            Width="105px" />
                    </td>
                </tr>
            </table>
            <div id="footer">
                <p class="hr">
                </p>
                <table width="100%">
                    <tr>
                        <td style="width: 50%">
                            <p>
                                Copyright© 2013 - SKOPE Buisness Ventures Pvt. Ltd. All rights reserved.</p>
                        </td>
                        <td align="right">
                            <%--<p>
                                Powered By : Saral Technomart Pvt Ltd.
                            </p>--%>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </center>

     <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
   
    <asp:Panel ID="pnlpop" runat="server" Width="450px">
    <div class="popup">
    <h6>
        <asp:ImageButton ID="imgClose" runat="server" Height="40px" 
             ToolTip="Close Popup" Width="40px" ImageUrl="~/Image/close-icon.png" /></h6>
            <table>
            <tr>
            <td></td>
            <td align="center"><h2>Forgot Password</h2></td></tr>
            <tr>
             <td></td>
            <td>
             <asp:TextBox ID="txtEmailID" runat="server" CssClass="txtLgn" Width="250px" ValidationGroup="fpswrd" 
                                          ></asp:TextBox>
                                           <asp:TextBoxWatermarkExtender ID="twm3" runat="server" TargetControlID="txtEmailID"
                                        WatermarkText="Email Id" WatermarkCssClass="watermark">
                                    </asp:TextBoxWatermarkExtender>
                <asp:RequiredFieldValidator ID="rfv3" runat="server" 
                    ControlToValidate="txtEmailID" Display="Dynamic" ErrorMessage="*" 
                    ForeColor="Red" SetFocusOnError="True" ValidationGroup="fpswrd"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="rev" runat="server" 
                    ControlToValidate="txtEmailID" Display="Dynamic" 
                    ErrorMessage="Invalid Email Id" Font-Size="Small" ForeColor="Red" 
                    ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" 
                    ValidationGroup="fpswrd"></asp:RegularExpressionValidator>
            </td>
            </tr>
            <tr>
            <td></td>
            </tr>
           <tr>
            <td></td>
           <td valign="top">  
               <asp:Button ID="btlFSubmit" runat="server" CssClass="btnpopup" Text="Submit"  
                   ValidationGroup="fpswrd" onclick="btlFSubmit_Click"
                                            /></td>
           </tr>
            </table>
    </div>
    </asp:Panel>

    </ContentTemplate>
    <Triggers>
 <asp:AsyncPostBackTrigger ControlID="ImgFrgtPswrd" EventName="Click" />
 </Triggers>
     </asp:UpdatePanel>
 
     <asp:ModalPopupExtender ID="mpefp" runat="server" TargetControlID="ImgFrgtPswrd" PopupControlID="pnlpop" CancelControlID="imgClose" BackgroundCssClass="mdlbgrgnd">
    </asp:ModalPopupExtender>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ForgotPassword.aspx.cs" Inherits="ForgotPassword" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Forgot Password</title>
    
     <style type="text/css">
     #main
{
	width:1000px;
	height:500px;
	margin-left:auto;
	margin-right:auto;
	margin-top:auto;
	margin-bottom:auto;	
}
#mhead
{
    width: 100%;
    height: 105px;
    border-bottom-color: #900;
    border-bottom-style: solid;
    border-bottom-width: 6px;
    text-align:right;
  
}
 #mhead h2
{
    
    color: #900;
    font-size: 40px;
    font-weight: bold;
    font-family: 'Lucida Sans Unicode';
}
 #mhead h2 sup
 {
     font: Tahoma, Geneva, sans-serif;
    color: #900;
    font-size: 20px;
    font-weight: bold;
    font-family: optima;	 
}
#middle
{
	margin-top:10px;
	margin-left:auto;
	margin-right:auto;
	margin-bottom:0px;
	height:300px;
	width:100%;	
}

#middle h2
{
    margin: 0px;
    color: #900;
    padding-top: 10px;
    margin-bottom: 10px;
    font-family: Arial, Helvetica, sans-serif;
}
.tbox
{
    
    background-color: #E7E6E0;
   
}
.hr
{
    margin: 0px;
    border-top-style: solid;
    border-top-width: 4px;
    border-top-color: #900;
}
.loginbtn
{
    width: 80px;
    height: 28px;
    font: Arial, Helvetica, sans-serif;
    background-color: #B70F20;
    color: #fff;
    font-size: 13px;
    padding-top: 4px;
    padding-bottom: 5px;
    font-family: arial, Helvetica, sans-serif;
}
.loginbtn:hover
{
 
    background-color:#FFB7B7;
    color:#B40E1F; 	
}
.watermark
{
    color: #909090;
    border: thin solid #999;
    height: 23px;
    width: 190px;
}
#footer
{
    margin-top:30px;
	margin-left:auto;
	margin-right:auto;
	margin-bottom:auto;	
	width:1000px;
	
}
#footer p
{
    margin: 0px;
    padding-left: 10px;
    padding-top: 8px;
    padding-bottom: 10px;
    font-size: 12px;
    color: #333;
    font-family: 'Lucida Sans Unicode';
}
     .txtbx
{
    border: thin solid #D4D4D4;
    height: 24px;
    width: 190px;
}
     </style>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <div id="main">
            <div id="mhead">
                 <asp:Image ID="imgClientLogo" runat="server" CssClass="logocss" 
                        ImageUrl="~/Image/logo.png" Height="100px" Width="180px" />
            </div>
            <div id="middle">
            <br /><br />
               <table width="50%" class="tbox">
               <tr>
               <td colspan="2" >
               <h2>Forgot Password</h2>
               </td>
               </tr>
               <tr>
               <td colspan="2" >
                                    <asp:TextBox ID="txtEMail" runat="server" CssClass="txtbx" 
                       Width="300px" Height="30px" ValidationGroup="save"></asp:TextBox>
                 
                                    <asp:TextBoxWatermarkExtender ID="TWE1" runat="server" TargetControlID="txtEmailID"
                                        WatermarkText="Enter Email Id" WatermarkCssClass="watermark"></asp:TextBoxWatermarkExtender>
                                        <br />
                   <asp:RegularExpressionValidator ID="rev1" runat="server" ErrorMessage="Enter Correct Email Id" 
                                        Font-Names="Lucida Sans Unicode" Font-Size="Small" ForeColor="Red" 
                                        ValidationGroup="save"></asp:RegularExpressionValidator>
                                </td>
               
               </tr>

               <tr>
               <td colspan="2" >
                   <asp:Button ID="btnForgot" runat="server" Text="Submit" CssClass="loginbtn" 
                       onclick="btnForgot_Click" ValidationGroup="save" />
                       <br />
                   <br />
               </td>
               </tr>
               </table>
            </div>
           
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
                            <p>
                                Powered By : Aranya Consulting Pvt. Ltd.
                            </p>
                        </td>
                    </tr>
                </table>
            </div>
        </div>
    </center>
    </form>
</body>
</html>

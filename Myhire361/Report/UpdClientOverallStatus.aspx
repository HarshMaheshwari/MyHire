<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdClientOverallStatus.aspx.cs" Inherits="Report_UpdClientOverallStatus" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 347px;
        }
        .auto-style2 {
            width: 171px;
        }
        .auto-style3 {
            width: 221px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Update Client Overall Status</h2>
            <table>
                <tr align="center">
                 
                      <td  style="width:200px;">  
                           <asp:Label ID="lblmsg" runat="server"  Font-Bold="true" ></asp:Label>
                         <asp:Button ID="btnSave" runat="server" Text="Save" OnClick="btnSave_OnClick" ValidationGroup="save" CssClass="btnSave"/>
                    </td>
                    
                </tr>

            </table>
        </div>
    </center>
</asp:Content>



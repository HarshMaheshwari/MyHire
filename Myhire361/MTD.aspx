<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="MTD.aspx.cs" Inherits="HomeCopy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    
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
            background: url('../Image/redmenu.jpg') repeat-x left center;
            color: #FFFFFF;
            font-family: Lucida Sans Unicode;
            font-size: 13px;
            height: 20px;
            vertical-align: middle;
            word-spacing: 5px;
            background-color: #CA1A21;
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
              background-color: white;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="page" style="height:600px;margin-top: 26px;">
        <center>
            <table width="100%" >
           
                <tr >
                <td align="Right"> <asp:ImageButton ID="lbtnDownload" runat="server" Height="30px" ImageUrl="~/Image/ExcelDownload.jpg" OnClick="lbtnDownload_Click" ToolTip="Download in Excel" Width="40px" /></td>
                    </tr>
                <tr>
                    <td align="Center" valign="top" >
                       
                        
                        <asp:Panel ID="Admin0" runat="server" CssClass="pnltop" ScrollBars="Auto">
                            <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                <ContentTemplate>
                                    <h2>MTD</h2>
                                    <asp:GridView ID="gdvMDT" runat="server"   EmptyDataText="No Monthly Status"  AutoGenerateColumns="true" 
                                        onrowcreated="gdvMDT_RowCreated" onrowdatabound="gdvMDT_RowDataBound"  CssClass="mGridDash" >
                            <%--  OnPreRender="gdv_PreRender"--%>
                                    </asp:GridView>
                   
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvMDT" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                       
                        
                    </td>

                    
                </tr>
            <tr>
                <td colspan="4" align="left" style="font-weight: 700">&nbsp;</td>
                </tr>
            </table>
        </center>
    </div>
</asp:Content>

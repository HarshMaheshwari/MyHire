<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="Reports.aspx.cs" Inherits="Reports" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style type="text/css">
        .pnltop {
            width: 100%;
            height: auto;
        }

        /*CSS for Grid View*/
        .mGridDash {
            width: 100%;
            background-color: #CA1A21;
            margin: 5px 0 10px 0;
            border: 1px solid #FECBD3;
            border-collapse: collapse;
        }

            .mGridDash th {
                background: url('../Image/redmenu.jpg') repeat-x left center;
                color: #FFFFFF;
                font-family: Lucida Sans Unicode;
                font-size: 13px;
                height: 20px;
                vertical-align: middle;
                word-spacing: 5px;
                background-color: #CA1A21;
            }

            .mGridDash td {
                border: 1px solid #FECBD3;
                color: #232323;
                font-family: "Lucida Sans Unicode";
                text-align: left;
                padding-left: 10px;
                font-size: 11px;
                vertical-align: middle;
                background-color: white;
            }

            .mGridDash .alt {
                background: #F9FCFF top;
            }

        .mGrid tbody tr:hover, .GridView tbody tr:hover td, .GridView tbody tr.hover, .GridView tbody tr.hover td {
            background: #F5FAFC;
            color: #000000;
        }

        .lbtnFView {
            font-family: "Lucida Sans Unicode";
            font-size: 14px;
            color: #0D203F;
            font-weight: 300;
        }

        .lbtnFolloup {
            font-family: "Lucida Sans Unicode";
            font-size: 14px;
            color: #008080;
        }

        .style3 {
            font-weight: normal;
        }
    .TxtBox
{
    border: 1px solid #999999;
     font-family: "Lucida Sans Unicode";
    width: 190px;
    height: 22px;
    font-size: 13px;
}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="page" style="height: 600px; margin-top: 26px;">
        <center>
            <table width="100%" >
                <tr>
                    <td>From Date</td>
                    <td>To Date</td>
                    <td></td>
                </tr>
                <tr>
                    <td>
                                <asp:TextBox ID="txtfrom" runat="server" CssClass="TxtBox" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfrom"
                                    PopupButtonID="txtfrom" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                                <br />
                                <br />
                            </td>
                    <td>
                                <asp:TextBox ID="txtTo" runat="server" CssClass="TxtBox" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtTo"
                                    PopupButtonID="txtTo" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                                <br />
                                <br />
                            </td>
                    <td></td>
                </tr>
                <tr ><td>RR Candidate </td>
                    <td>Follow Up</td>
                     <td> Recuriment </td>
               </tr>
               <tr>
                   <td> <asp:ImageButton ID="lbtnDownloadRRCandidate" runat="server" Height="30px" ImageUrl="~/Image/ExcelDownload.jpg"  ToolTip="Download in Excel" Width="40px" OnClick="lbtnDownloadRRCandidate_Click" /></td>
                   <td> <asp:ImageButton ID="lbtnDownloadFollowUp" runat="server" Height="30px" ImageUrl="~/Image/ExcelDownload.jpg" ToolTip="Download in Excel" Width="40px" OnClick="lbtnDownloadFollowUp_Click" /></td>
                   <td> <asp:ImageButton ID="lbtnDownloadRecuritment" runat="server" Height="30px" ImageUrl="~/Image/ExcelDownload.jpg"  ToolTip="Download in Excel" Width="40px" OnClick="lbtnDownloadRecuritment_Click" /></td>

               </tr>
                  <tr ><td>Consultant</td>
                    <td>Client</td>
                     <td> Location </td>
               </tr>
               <tr>
                   <td> <asp:ImageButton ID="lbtnDownloadConsultant" runat="server" Height="30px" ImageUrl="~/Image/ExcelDownload.jpg"  ToolTip="Download in Excel" Width="40px" OnClick="lbtnDownloadConsultant_Click"  /></td>
                   <td> <asp:ImageButton ID="lbtnDownloadClient" runat="server" Height="30px" ImageUrl="~/Image/ExcelDownload.jpg" ToolTip="Download in Excel" Width="40px" OnClick="lbtnDownloadClient_Click" /></td>
                   <td> <asp:ImageButton ID="lbtnDownloadLocation" runat="server" Height="30px" ImageUrl="~/Image/ExcelDownload.jpg"  ToolTip="Download in Excel" Width="40px" OnClick="lbtnDownloadLocation_Click" /></td>

               </tr>
            <tr ><td>Candidate </td>
                    <td></td>
                     <td></td>
               </tr>
                <tr>
                   <td> <asp:ImageButton ID="lbtnDownloadCandidate" runat="server" Height="30px" ImageUrl="~/Image/ExcelDownload.jpg"  ToolTip="Download in Excel" Width="40px" OnClick="lbtnDownloadCandidate_Click"  /></td>
                   <td> </td>
                   <td></td>

               </tr>
            </table>
        </center>
    </div>
</asp:Content>

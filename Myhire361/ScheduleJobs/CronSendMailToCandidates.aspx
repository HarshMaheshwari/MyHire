<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CronSendMailToCandidates.aspx.cs" Inherits="ScheduleJobs_CronSendMailToCandidates" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style type="text/css">
        .auto-style1 {
            height: 23px;
        }
    </style>

</head>
<body>

    <form id="form1" runat="server">

      <table width ="100%"><tr><td colspan="2" align="Center" class="auto-style1">Candidate Mailler</td></tr>
          <tr><td align="Right">RR-Number</td><td>
              <asp:DropDownList ID="ddlFromRRNumber" runat="server" AppendDataBoundItems="True" AutoPostBack="true" CssClass="DropDown" OnSelectedIndexChanged="ddlFromRRNumber_SelectedIndexChanged" Width="170px">
              </asp:DropDownList>
              </td></tr>
          <tr><td align="right" >Subject</td><td align="left">
              <asp:TextBox ID="txtSubject" runat="server" CssClass="TxtBox" Visible="false"></asp:TextBox>
              </td></tr>
          <tr><td align="right">Text</td><td align="left">
              <asp:TextBox ID="txtText" runat="server" CssClass="TxtBox" TextMode="MultiLine" Visible="false"></asp:TextBox>
              </td></tr>
          <tr><td colspan="2" align="center"><asp:Button ID="btnsend" runat="server" CssClass="btnSave" OnClick="btnsend_Click"
                                    Text="Send" ValidationGroup="Save" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                               <%--<asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg" Height="30px" Width="40px" OnClick="lbtnDownload_Click" 
                    ToolTip="Download in Excel"/>--%>
                            </td></tr>
      </table>

    </form>
</body>
</html>

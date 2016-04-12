<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Video.aspx.cs" Inherits="Video" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table cellpadding="8" align="center">
        <tr >
            <td>Q 1: Describe yourself    ?</td> 
            <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
            <td><asp:Button ID="btnFileUpld1" runat="server" Text="Upload" CssClass="btnCancel" OnClick="btnFileUpld1_Click" />
             <asp:Label ID="lblf1" runat="server" Text="Label" Visible="False" ForeColor="green"></asp:Label>

            </td>
        </tr>
        <tr>
            <td>Q2: Why do you think you are suitable for this position ?</td>
            <td><asp:FileUpload ID="FileUpload2" runat="server" /></td>
            <td>
                <asp:Button ID="btnFileUpld2" runat="server" Text="Upload" CssClass="btnCancel" OnClick="btnFileUpld2_Click" />
                     <asp:Label ID="lblf2" runat="server" Text="Label"  ForeColor="green" Visible="false"></asp:Label>
            </td>
       
        </tr>
        <tr>
            <td>Q3: Please explain your career journey so far  ?</td>
            <td><asp:FileUpload ID="FileUpload3" runat="server" /></td>
            <td>
                <asp:Button ID="btnFileUpld3" runat="server" Text="Upload" CssClass="btnCancel" OnClick="btnFileUpld3_Click" />
                 <asp:Label ID="lblf0" runat="server"  Text="Label" ForeColor="green" Visible="false"></asp:Label>

            </td>
           
        </tr>
        <tr>
            <td>Q4: Where do you yourself after 5 years  ?</td>
            <td><asp:FileUpload ID="FileUpload4" runat="server" /></td>
            <td><asp:Button ID="ButtbtnFileUpld4" runat="server" CssClass="btnCancel" Text="Upload" OnClick="btnFileUpld4_Click" />
                 <asp:Label ID="lblf4" runat="server"  ForeColor="green" Text="Label" Visible="false"></asp:Label>
            </td>
           
        </tr>
        <tr>
           
            <td></td>
            <td></td>
             </tr  >
        <tr>
            <td valign="bottom" align="right"><asp:Button ID="buttonUpload" CssClass="btnCancel" runat="server" Text="Submit" OnClick="btnUpload_Click" /></td>
        </tr>
    </table>
    
    

    <asp:Label ID="lblmsg" runat="server" Text="Label" Visible="false"></asp:Label>
    <hr />
    <asp:DataList ID="DataList1" Visible="true" runat="server" AutoGenerateColumns="false"
        RepeatColumns="2" CellSpacing="5">
        <ItemTemplate>
            <u>
                <%# Eval("VideoFile_Name") %></u>
            <hr />
            <a class="player" style="height: 300px; width: 300px; display: block" href='<%# Eval("Video_Id", "FileCS.ashx?Video_Id={0}") %>'></a>
        </ItemTemplate>
    </asp:DataList>
    <script src="FlowPlayer/flowplayer-3.2.12.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        flowplayer("a.player", "FlowPlayer/flowplayer-3.2.16.swf", {
            plugins: {
                pseudo: { url: "FlowPlayer/flowplayer.pseudostreaming-3.2.12.swf" }
            },
            clip: { provider: 'pseudo', autoPlay: false },
        });
    </script>
</asp:Content>


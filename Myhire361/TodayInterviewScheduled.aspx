<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage2.master" AutoEventWireup="true"
    CodeFile="TodayInterviewScheduled.aspx.cs" Inherits="HomeCopy" %>

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
                      <td valign="top" align="center">
                     <h2>
                         Today Interview Scheduled </h2>
                        <asp:Panel ID="pnlInterviewSchedule" runat="server" CssClass="pnltop" ScrollBars="Auto">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                    <asp:GridView ID="gdvInterview" runat="server" AutoGenerateColumns="False" 
                                      GridLines="Vertical" CssClass="mGridDash"
                                        EmptyDataText="No interview is scheduled for today." 
                                        OnRowCommand="gdvInterview_RowCommand"  HeaderStyle-ForeColor="White" onsorting="gdvInterview_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="RRNumber">
                                        <AlternatingRowStyle CssClass="alt" />
                                        <FooterStyle CssClass="footer" />
                                        <Columns>
                                            <asp:TemplateField HeaderText="ID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="RRID" Visible="false">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRRId" runat="server" Text='<%#Eval("RRCandidate_Id")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Client Name" SortExpression="Client_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblClntName" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Consultant" SortExpression="USR_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblUSR_Name" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                                <asp:TemplateField HeaderText="HR Name" SortExpression="Person_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblPerson_Name" runat="server" Text='<%#Eval("Person_Name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="RR-No" SortExpression="RRNumber">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblRRNo" runat="server" Text='<%#Eval("RRNumber")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Role" SortExpression="Job_Profile">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblJob_Profile" runat="server" Text='<%#Eval("Job_Profile")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Name" SortExpression="Candidate_Name">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblName" runat="server" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Mobile No." SortExpression="Mobile_No">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile_No")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                  
                                            <asp:TemplateField HeaderText="Candidate Status" SortExpression="Candidate_Status">
                                                <ItemTemplate>
                                                    <asp:Label ID="lblCandStatus" runat="server" Text='<%#Eval("Candidate_Status")%>'></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                   
                                            <asp:TemplateField HeaderText="Action"  Visible="false" >
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="ViewButton" CommandName="View" runat="server" Text="View" CssClass="lbtnFView" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvInterview" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </td>
                </tr>
          
            </table>
        </center>
    </div>
</asp:Content>

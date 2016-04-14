<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Admin_newDashboard.aspx.cs" Inherits="admin_new_Admin_newDashboard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <link rel="Stylesheet" href="../Styles/Popup.css" type="text/css" />
     <link rel="Stylesheet" href="../Styles/BlueMaster.css" type="text/css" />

         <script type="text/javascript">

             
     
             
    </script>
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
            background: #CA1A21 url('../../Image/redmenu.jpg') repeat-x left center;
            color: #FFFFFF;
            font-family: Lucida Sans Unicode;
            font-size: 13px;
            height: 20px;
            vertical-align: middle;
            word-spacing: 5px;
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
        .auto-style1 {
            width: 25%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
     <asp:UpdatePanel ID="upnl" runat="server">
        <ContentTemplate>
    <%--<div id="page" style="height:600px;margin-top: 26px;">--%>
       <div id="page">
        <center>
            
            <table width="100%" >
                <tr>
                    <td align="left" valign="top" colspan="3">
                        <asp:Button runat="server" ID="btnDashboard" Text="DashBoard" CssClass="btnCancel" Width="100px" />
                        <asp:Button runat="server" ID="btnClient" Text="Client" CssClass="btnCancel" Width="100px" OnClick="btnClient_Click" />
                        <asp:Button runat="server" ID="BtnJD" Text="JD" CssClass="btnCancel" Width="120px"  OnClick="btnJD_Click"/>
                        <asp:Button runat="server" ID="btnTeam" Text="Team" CssClass="btnCancel" Width="100px" OnClick="btnTeam_Click" />
                        <asp:Button runat="server" ID="btnCandidate" Text="Candidate" CssClass="btnCancel" Width="100px" OnClick="btnCandidate_Click" />
                        <asp:Button runat="server" ID="btnCV" Text="CV " CssClass="btnCancel" Width="100px" OnClick="btnCV_Click" />
                        <asp:Button runat="server" ID="btnInterView" Text="Interview" CssClass="btnCancel" Width="100px" OnClick="btnInterView_Click" />
                        <asp:Button runat="server" ID="btnSelected" Text="Selected" CssClass="btnCancel" Width="100px" OnClick="btnSelected_Click" />
                        <asp:Button runat="server" ID="btnJoined" Text="Joined" CssClass="btnCancel" Width="100px" OnClick="btnJoined_Click" />
                        <h2></h2>
                        <asp:Panel ID="pnlClient" runat="server">
                           <table>
                               <tr>
                                   <td>
                                       <asp:GridView ID="gdvClientList" runat="server" OnRowDataBound="gdvClientList_RowDataBound">
                                           <Columns>
                                                 <asp:TemplateField HeaderText="S.No." SortExpression="Client_Id" ItemStyle-Width="10">
                                                    <ItemTemplate>
                                                        <%#Container.DataItemIndex+1 %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField Visible="false">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblClientID" runat="server" Text='<%#Eval("Client_Id")%>'  />
                                                   </ItemTemplate>
                                               </asp:TemplateField>

                                               <asp:TemplateField >
                                                   <ItemTemplate>
                                                       <asp:LinkButton ID="lnkClientName" runat="server" Text='<%#Eval("Client_Name")%>'  />
                                                   </ItemTemplate>
                                               </asp:TemplateField>
                                               
                                              

                                               <asp:TemplateField Visible="false">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblClientCode" runat="server" Text='<%#Eval("Client_Code")%>'/>
                                                   </ItemTemplate>
                                               </asp:TemplateField >

                                               <asp:TemplateField Visible="false">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblClientCity" runat="server" Text='<%#Eval("Client_City") %>'/>
                                                   </ItemTemplate>
                                               </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Assigned To" Visible="false" SortExpression="USR_Name" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblAssigendTo" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contact Name" SortExpression="Person_Name" visible="false" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblContact" runat="server" Text='<%#Eval("Person_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Email Id" SortExpression="Person_Email" Visible="false" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Person_Email")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Contact No" SortExpression="Person_Contact" Visible="false" >
                                            <ItemTemplate>
                                                <asp:Label ID="lblPhnNo" runat="server" Text='<%#Eval("Person_Contact")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           </Columns>
                                           
                                       </asp:GridView>
                                   </td>
                                   <td>
                                       <asp:GridView ID="GridView2" runat="server" >
                                           <Columns>
                                                     
                                               <asp:TemplateField Visible="true">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblClientID" runat="server" Text='<%#Eval("Client_Id")%>'  />
                                                   </ItemTemplate>
                                               </asp:TemplateField>

                                               <asp:TemplateField >
                                                   <ItemTemplate>
                                                       <asp:Label ID="lnkClientName" runat="server" Text='<%#Eval("Client_Name")%>'  />
                                                   </ItemTemplate>
                                               </asp:TemplateField>
                                               
                                              

                                               <asp:TemplateField Visible="true">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblClientCode" runat="server" Text='<%#Eval("Client_Code")%>'/>
                                                   </ItemTemplate>
                                               </asp:TemplateField >

                                               <asp:TemplateField Visible="true">
                                                   <ItemTemplate>
                                                       <asp:Label ID="lblClientCity" runat="server" Text='<%#Eval("Client_City") %>'/>
                                                   </ItemTemplate>
                                               </asp:TemplateField>
                                           </Columns>
                                       </asp:GridView>
                                   </td>
                               </tr>
                           </table>
                        </asp:Panel>
                        <asp:Panel ID="pnlJD" runat="server"></asp:Panel>
                        <asp:Panel ID="pnlTeam" runat="server"></asp:Panel>
                        <asp:Panel ID="pnlCandidate" runat="server"></asp:Panel>
                        <asp:Panel ID="pnlCV" runat="server"></asp:Panel>
                        <asp:Panel ID="pnlInterview" runat="server"></asp:Panel>
                        <asp:Panel ID="pnlSelected" runat="server"></asp:Panel>
                        <asp:Panel ID="pnlJoined" runat="server"></asp:Panel>
                      </td>
                    </tr>
               
                 </table>
        </center>
       </div>


         </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>


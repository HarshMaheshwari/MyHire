<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ClientResumeTracker.aspx.cs" Inherits="Report_ClientResumeTracker" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
 <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                 Client Resume Tracker</h2>
            
                   
                <table>
                  <tr>
                   
                    <td width="25%" align="right" colspan="5">
                        <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg" Height="30px" Width="40px" OnClick="lbtnDownload_Click" 
                    ToolTip="Download in Excel"/>
                    </td>
                </tr>
                    <tr align="center">
                    <td align="right">Client :</td><td align="center">
                           <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="170px">
                                </asp:DropDownList>
                           
                                    </td>
                         <td align="right">Consultant :</td><td align="center">
                         <asp:DropDownList ID="ddlConsultant" runat="server" AppendDataBoundItems="True" CssClass="DropDown"  Width="170px">
                            </asp:DropDownList>
                           
                                    </td>
                       
                      <td align="left">  
                           
                          <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_OnClick" ValidationGroup="Search" CssClass="btnSave"/>
                    </td>
                     
                  </tr>
              
                </table>

           
            <table width="100%">
                <tr><td>
                   <asp:Panel ID="pnlUpload" runat="server" Width="1194px" ScrollBars="Auto" Height="800px">
                          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

                 <asp:GridView ID="gdvDWS" runat="server" CssClass="mRprtGrid" AutoGenerateColumns="false"
                             AllowPaging="True" PageSize="20" EmptyDataText="Sorry! No Record Found." OnPageIndexChanging="gdvDWS_PageIndexChanging"
                         HeaderStyle-ForeColor="White" onsorting="gdvDWS_Sorting" AllowSorting="true">
                            <HeaderStyle BackColor="#CC0000" />
                            <Columns>
                                  <asp:TemplateField HeaderText="S.No." SortExpression="Candidate_Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                            </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Date" SortExpression="Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("Date") %>'></asp:Label></ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                <ItemStyle HorizontalAlign="Left"  Width="130px"/>
                          
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Source" SortExpression="Source">
                                <ItemTemplate>
                                    <asp:Label ID="lblSource" runat="server" Text='<%#Eval("Source") %>'></asp:Label></ItemTemplate>
                               <HeaderStyle HorizontalAlign="Center" Width="180px" />
                                <ItemStyle HorizontalAlign="Left"  Width="180px"/>
                            </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Candidate Name" SortExpression="[Candidate Name]">
                                <ItemTemplate>
                                    <asp:Label ID="lblCandidateName" runat="server" Text='<%#Eval("[Candidate Name]") %>'></asp:Label></ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                <ItemStyle HorizontalAlign="Left"  Width="130px"/>
                          
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Cell No" SortExpression="[Cell No]">
                                <ItemTemplate>
                                    <asp:Label ID="lblMobileNo" runat="server" Text='<%#Eval("[Cell No]") %>'></asp:Label></ItemTemplate>
                               <HeaderStyle HorizontalAlign="Center" Width="180px" />
                                <ItemStyle HorizontalAlign="Left"  Width="180px"/>
                            </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Current Company" SortExpression="[Current Company]">
                                <ItemTemplate>
                                    <asp:Label ID="lblCurrentComp" runat="server" Text='<%#Eval("[Current Company]") %>'></asp:Label></ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                <ItemStyle HorizontalAlign="Left"  Width="130px"/>
                           </asp:TemplateField>
                         <asp:TemplateField HeaderText="Total Experience" SortExpression="[Total Experience]">
                                <ItemTemplate>
                                    <asp:Label ID="lblCurrentExp" runat="server" Text='<%#Eval("[Total Experience]") %>'></asp:Label></ItemTemplate>
                               <HeaderStyle HorizontalAlign="Center" Width="180px" />
                                <ItemStyle HorizontalAlign="Left"  Width="180px"/>
                            </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Client" SortExpression="Client_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name") %>'></asp:Label></ItemTemplate>
                               <HeaderStyle HorizontalAlign="Center" Width="180px" />
                                <ItemStyle HorizontalAlign="Left"  Width="180px"/>
                            </asp:TemplateField>
                               <asp:TemplateField HeaderText="Consultant" SortExpression="Consultant">
                                <ItemTemplate>
                                    <asp:Label ID="lblConsultants" runat="server" Text='<%#Eval("Consultant") %>'></asp:Label></ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                <ItemStyle HorizontalAlign="Left"  Width="130px"/>
                          
                            </asp:TemplateField>
                         
                            </Columns>
                        </asp:GridView> 
                 </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvDWS" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                        </asp:Panel>
                </td></tr>
            </table>
        </div>
    </center>
</asp:Content>

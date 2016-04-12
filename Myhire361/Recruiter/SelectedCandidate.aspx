<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="SelectedCandidate.aspx.cs" Inherits="SelectedCandidate" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
    <div id="page">
        <%--<h2>
            Candidate Status List</h2>--%>
        <table width="100%" align="center">
             <tr>
                    <td align="left" valign="top" colspan="3">
                        <asp:Button runat="server" ID="btnFollowUp" Text="DashBoard" CssClass="btnCancel" Width="100px"/>
                        <asp:Button runat="server" ID="BtnJD" Text="JD" CssClass="btnCancel" Width="120px" OnClick="BtnJD_Click"/>
                        <asp:Button runat="server" ID="btnCandidate" Text="Candidate" CssClass="btnCancel" Width="100px" OnClick="btnCandidate_Click" />
                        <asp:Button runat="server" ID="btnFollowUpRecruiter" Text="Follow Ups" CssClass="btnCancel" Width="100px" OnClick="btnFollowUpRecruiter_Click" />
                        <asp:Button runat="server" ID="btnCVShared" Text="CV Shared" CssClass="btnCancel" Width="100px" OnClick="btnCVShared_Click" />
                        <asp:Button runat="server" ID="btnInterView" Text="Interview" CssClass="btnCancel" Width="100px" OnClick="btnInterView_Click" />
                          <asp:Button runat="server" ID="btnSelected" Text="Selected" CssClass="btnCancel" Width="100px" OnClick="btnSelected_Click" />
                    
                        <h2>Selected</h2>
                          
                         
                      
                       
                    </td>
                 
                 
                </tr>
            <tr>
                <td colspan="2">
                    <table width="100%">
                    
                       

                         <%--<tr>
                           <td align="center" width="20%">
                              Client Name
                            </td>

                            <td align="center" width="20%">
                                Recruiter Status
                            </td>
                              <td align="center" width="20%">
                                  Supervisor Status 
                            </td>
                            <td align="center" width="20%">
                               Candidate Status
                            </td>
                          
                          
                          
                            <td align="center">
                            <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg"
                        Height="30px" Width="40px" OnClick="lbtnDownload_Click" ToolTip="Download" />
                            </td>

                        </tr>--%>
                       <%--  <tr>
                          <td align="center" width="20%">
                               <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td align="center" width="20%">
                                 <asp:DropDownList ID="ddlRecStatus" runat="server" CssClass="DropDown" 
                                    AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                              <td align="center" width="20%">
                                  <asp:DropDownList ID="ddlSupStatus" runat="server" CssClass="DropDown" 
                                    AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                            <td align="center" width="20%">
                                 <asp:DropDownList ID="ddlCandStatus" runat="server" CssClass="DropDown" 
                                    AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                            <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search" 
                                    onclick="btnSearch_Click" />
                            </td>

                        </tr>--%>


                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
                 <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                    <asp:GridView runat="server" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Candidate_Id"
                        ID="gdvCandidate" AllowPaging="True" EmptyDataText="Sorry! No Record Found."
                        OnPageIndexChanging="gdvRequest_PageIndexChanging" PageSize="20" HeaderStyle-ForeColor="White" onsorting="gdvCandidate_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." SortExpression="Candidate_Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"  Width="5%" />
                               <ItemStyle HorizontalAlign="Center"  Width="5%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id") %>'></asp:Label></ItemTemplate>
                                   
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Client Name " SortExpression="Client_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="12%" />
                                <ItemStyle HorizontalAlign="Left" Width="12%" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RR Number" SortExpression="RRNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblRRNo" runat="server" Text='<%#Eval("RRNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="8%" />
                                <ItemStyle HorizontalAlign="Left" Width="8%" />
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Job Profile" SortExpression="Job_Profile">
                                <ItemTemplate>
                                    <asp:Label ID="lblJob" runat="server" Text='<%#Eval("Job_Profile") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%"/>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Candidate Name" SortExpression="Candidate_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCandidate" runat="server" Text='<%#Eval("Candidate_Name") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="13%" />
                                <ItemStyle HorizontalAlign="Left"  Width="13%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email Id" SortExpression="Email" Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblEmail" runat="server" Text='<%#Eval("Email") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Phone No" SortExpression="Mobile_No">
                                <ItemTemplate>
                                    <asp:Label ID="lblPhone" runat="server" Text='<%#Eval("Mobile_No") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="7%" />
                                <ItemStyle HorizontalAlign="Left" Width="7%" />
                            </asp:TemplateField>
                          
                        
                            <%--<asp:TemplateField HeaderText="Next FollowUp Date" SortExpression="FollowUp_Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblFollowUp_Date" runat="server" Text='<%#Eval("FollowUp_Date") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="10%" />
                                <ItemStyle HorizontalAlign="Left" Width="10%" />
                            </asp:TemplateField>--%>
                            <asp:TemplateField HeaderText="Candidate Status" SortExpression="Overall_Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblOverAllStatus" runat="server" Text='<%#Eval("Overall_Status") %>'></asp:Label></ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="15%" />
                                <ItemStyle HorizontalAlign="Left" Width="15%"/>
                            </asp:TemplateField>

                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                    </asp:GridView>

                       </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvCandidate" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

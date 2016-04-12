<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RFollowUpList.aspx.cs" Inherits="RFollowUpList" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
      <center>
                <div id="page">
                  <%--  <h2>
                        Follow Ups</h2>  --%>
                        <table width="100%">
                            <tr>
                    <td align="left" valign="top" colspan="3">
                        <asp:Button runat="server" ID="btnFollowUp" Text="DashBoard" CssClass="btnCancel" Width="100px"/>
                        <asp:Button runat="server" ID="BtnJD" Text="JD" CssClass="btnCancel" Width="120px" OnClick="BtnJD_Click"/>
                        <asp:Button runat="server" ID="btnCandidate" Text="Candidate" CssClass="btnCancel" Width="100px"  OnClick="btnCandidate_Click"/>
                        <asp:Button runat="server" ID="btnFollowUpRecruiter" Text="Follow Ups" CssClass="btnCancel" Width="100px" OnClick="btnFollowUpRecruiter_Click"/>
                        <asp:Button runat="server" ID="btnCVShared" Text="CV Shared" CssClass="btnCancel" Width="100px" OnClick="btnCVShared_Click" />
                          <asp:Button runat="server" ID="btnInterView" Text="Interview" CssClass="btnCancel" Width="100px" OnClick="btnInterView_Click" />
                        <asp:Button runat="server" ID="Button5" Text="Selected" CssClass="btnCancel" Width="100px" />
                    
                     <%--   <h2></h2>--%>
                          
                         
                         <h2>
                        Follow Ups</h2> 
                       
                    </td>
                 
                 
                </tr>
                            <tr>
                                <td align="right"> <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg"
                        Height="30px" Width="40px" OnClick="lbtnDownload_Click" ToolTip="Download" Visible="false" /> 

                                </td>

                            </tr>

                        </table>
        
                   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
                    <table width="100%" align="center">
                 <%--   <tr  valign="middle" >
                    <td align="right">Client Name :</td>
                     <td align="left">

                         <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" 
                             CssClass="DropDown" Width="250px">
                         </asp:DropDownList>
                        </td>
                      <td align="right" id="lblCon" visible="false" runat="server">Consultant :</td>
                       <td align="left" id="ddlCon" visible="false" runat="server">
                           <asp:DropDownList ID="ddlConsultant" runat="server" AppendDataBoundItems="True" 
                               CssClass="DropDown">
                           </asp:DropDownList>
                        </td>
                         <td align="right">Date :</td>
                       <td align="left">
                       <asp:TextBox ID="txtDate" runat="server" CssClass="TxtBox"></asp:TextBox>
                           <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate"
                        PopupButtonID="txtDate" Format="dd-MMM-yyyy"></asp:CalendarExtender>
                   
                       </td>


                        <td>
                             
                        </td>
                    </tr>

                       <tr  valign="middle" >
                    <td align="right">Recruiter Status :</td>
                     <td align="left">
                         <asp:DropDownList ID="ddlRecStatus" runat="server" AppendDataBoundItems="True" 
                             CssClass="DropDown" Width="250px">
                         </asp:DropDownList>
                        </td>
                      <td align="right" id="Td1" runat="server">Approver Status :</td>
                       <td align="left" id="Td2" runat="server">
                           <asp:DropDownList ID="ddlSupStatus" runat="server" AppendDataBoundItems="True" 
                               CssClass="DropDown">
                           </asp:DropDownList>
                        </td>
                         <td align="right">Candidate Status :</td>
                       <td align="left">
                       <asp:DropDownList ID="ddlCandStatus" runat="server" AppendDataBoundItems="True" 
                               CssClass="DropDown">
                           </asp:DropDownList>
                   
                       </td>
                          

                        <td>
                          <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" 
                                OnClick="btnSearch_Click" Text="Search" />
                        </td>
                    </tr>

                        <tr style="width: 90%">
                            <td align="center" valign="middle" colspan="7">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>--%>
                        <tr>
                            <td colspan="7">
                            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:GridView ID="gdvCandidate" runat="server" AutoGenerateColumns="False" DataKeyNames="Candidate_Id"
                                    AllowPaging="True" Width="100%" OnPageIndexChanging="gdvCandidate_PageIndexChanging"
                                    GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                                     PageSize="15" HeaderStyle-ForeColor="White" onsorting="gdvCandidate_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                                    <AlternatingRowStyle CssClass="alt" />
                                    <FooterStyle CssClass="footer" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Candidate_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="S.No." SortExpression="Candidate_Id">
                                            <ItemTemplate>
                                                <%#Container.DataItemIndex+1%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RRID" Visible="false"  SortExpression="Candidate_Id">
                                            <ItemTemplate>
                                               <%-- <asp:Label ID="lblRRId" runat="server" Text='<%#Eval("RRCandidate_Id")%>'></asp:Label>--%>
                                                 <asp:Label ID="lblRequest_Id" runat="server" Text='<%#Eval("Request_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client Name"  SortExpression="Candidate_Id">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClntName" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left"  Width="130px"/>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="RR-No" SortExpression="Candidate_Id">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRRno" runat="server" Text='<%#Eval("RRNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Name" SortExpression="Candidate_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Font-Bold="true" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Current Employer" SortExpression="Current_Employer">
                                            <ItemTemplate>
                                                <%#Eval("Current_Employer")%>  <br />
                                                <%#Eval("Current_Designation")%>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left"  Width="250px"/>
                                        </asp:TemplateField>
                                        
                                         <asp:TemplateField HeaderText="Mobile No." Visible="false" SortExpression="Mobile_No">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMobile" runat="server" Text='<%#Eval("Mobile_No")%>' ></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Next Follow Up "  SortExpression="FollowUp_Date">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNxtFollowUp" runat="server" Text='<%#Eval("FollowUp_Date")%>' ></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="100px"/>
                                        </asp:TemplateField>
                                         

                                        <asp:TemplateField HeaderText="Candidate Status" SortExpression="Overall_Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCandStatus" runat="server" Text='<%#Eval("Overall_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="80px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Remarks" SortExpression="FollowUp_Remarks">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRemarks" runat="server" Text='<%#Eval("FollowUp_Remarks")%>'></asp:Label>
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Left" Width="180px" />
                                        </asp:TemplateField>
                                  
                                    </Columns>
                                </asp:GridView>

                                 </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvCandidate" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>

                      </ContentTemplate>
    </asp:UpdatePanel>
                </div>
            </center>
      
</asp:Content>

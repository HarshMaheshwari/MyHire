<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CandidateOffered.aspx.cs" Inherits="Report_CandidateOffered" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Candidates Offered</h2>
         <%--   <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>--%>
                    <table width="100%">
                        <tr>
                            <td align="center" width="20%">
                                Client
                            </td>
                            <td align="center" width="20%">
                               Consultant 
                            </td>
                          <%--    <td align="center" width="20%">
                                Next FollowUp Date
                            </td>--%>
                            <td align="center" width="20%">
                                Offered Date
                            </td>
                            <td align="center" width="20%">
                                Planned DOJ
                            </td>
                            <td align="center" width="20%">
                                Actual DOJ
                            </td>
                             <td align="center" width="20%">
                               Candidate Status
                            </td>
                            <td align="center">
                               <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg" Height="30px" Width="40px" OnClick="lbtnDownload_Click" 
                    ToolTip="Download in Excel"/>
                            </td>
                        </tr>
                        <tr>
                            <td align="center">
                                <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td align="center">
                                 <asp:DropDownList ID="ddlConsultant" runat="server" AppendDataBoundItems="True" CssClass="DropDown"  Width="170px">
                            </asp:DropDownList>
                            </td>
                            <%-- <td align="center">
                                 <asp:TextBox ID="txtNextFollowup" runat="server" CssClass="TxtBox"  Width="90px"></asp:TextBox>
                                 <asp:CalendarExtender ID="CEtxtNextFollowup" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtNextFollowup" TargetControlID="txtNextFollowup">
                                  </asp:CalendarExtender>
                            </td>--%>
                            <td align="center">
                                 <asp:TextBox ID="txtOfferedDate" runat="server" CssClass="TxtBox"  Width="90px"></asp:TextBox>
                                 <asp:CalendarExtender ID="CEtxtOfferedDate" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtOfferedDate" TargetControlID="txtOfferedDate">
                                  </asp:CalendarExtender>
                            </td>
                            <td align="center">
                                <asp:TextBox ID="txtPlannedDate" runat="server" CssClass="TxtBox"  Width="90px"></asp:TextBox>
                                 <asp:CalendarExtender ID="CEtxtPlannedDate" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtPlannedDate" TargetControlID="txtPlannedDate">
                                  </asp:CalendarExtender>
                            </td>
                             <td align="center">
                                <asp:TextBox ID="txtActualDoj" runat="server" CssClass="TxtBox"  Width="90px"></asp:TextBox>
                                 <asp:CalendarExtender ID="CEtxtActualDoj" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtActualDoj" TargetControlID="txtActualDoj">
                                  </asp:CalendarExtender>
                            </td>
                              <td align="center" width="20%">
                             
                             <asp:DropDownList CssClass="DropDown" ID="ddlCandStatus" runat="server">
                                   <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                   <asp:ListItem Text="Offered" Value="Offered"></asp:ListItem>
                                   <asp:ListItem Text="Offer Accepted" Value="Offer Accepted"></asp:ListItem>
                                   <asp:ListItem Text="Offered Drop Out" Value="Offered Drop Out"></asp:ListItem>
                                    <%--   <asp:ListItem Text="Completed 3 Months" Value="Completed 3 Months"></asp:ListItem>
                                  <asp:ListItem Text="Joined" Value="Joined"></asp:ListItem>
                                  <asp:ListItem Text="Left Before 3 Months" Value="Left Before 3 Months"></asp:ListItem>--%>
                              
                               
                             </asp:DropDownList>
                                     <%--<asp:DropDownList ID="ddlCandStatus" runat="server" CssClass="DropDown" 
                                    AppendDataBoundItems="True">
                                </asp:DropDownList>--%>
                            </td>
                            <td align="center">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                         <tr>
                        <td colspan="8" align="center">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                        <tr>
                            <td colspan="8">
                            <%--   <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>--%>
                                <asp:GridView ID="gdvCanOfferd" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                    OnPageIndexChanging="gdvCanOfferd_PageIndexChanging" GridLines="Both" CssClass="mRprtGrid"
                                    EmptyDataText="No Data to Dispaly." PageSize="50" Width="100%" OnRowDataBound="gdvCanOfferd_RowDataBound"  HeaderStyle-ForeColor="White" onsorting="gdvCanOfferd_Sorting" AllowSorting="true" 
                                     CurrentSortDirection="Desc" CurrentSortField="Client_Name" OnRowCancelingEdit="gdvCanOfferd_RowCancelingEdit"
                                     OnRowEditing="gdvCanOfferd_RowEditing" OnRowUpdating="gdvCanOfferd_RowUpdating">
                                    <Columns>
                                     <asp:TemplateField HeaderText="S.No." SortExpression="Client_Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRRCandidate_Id" runat="server" Text='<%#Eval("RRCandidate_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                              <EditItemTemplate>
                                             <asp:Label ID="lblERRCandidate_Id" runat="server" Text='<%#Eval("RRCandidate_Id") %>' Visible="false"></asp:Label>
                                                
                                             </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client Name" SortExpression="Client_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="RR Number" SortExpression="RRNumber">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRRNumber" runat="server" Text='<%#Eval("RRNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Role/Job_Profile" SortExpression="Job_Profile">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRole" runat="server" Text='<%#Eval("Job_Profile")%>'></asp:Label>
                                            </ItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Consultant" SortExpression="Consultant">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsultant" runat="server" Text='<%#Eval("Consultant")%>'></asp:Label>
                                            </ItemTemplate>
                                                  <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                              <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Candidate Name" SortExpression="Candidate_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblName" runat="server" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                              <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Candidate Status" SortExpression="Overall_Status">
                                            <ItemTemplate>
                                             
                                                <asp:Label ID="lblCandStatus" runat="server" Text='<%#Eval("Overall_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                            <%--   <EditItemTemplate>
                                                      <asp:Label ID="lblECandidateSts" runat="server" Width="80px" Text='<%#Eval("Overall_Status")%>'
                                                Visible="false"></asp:Label>
                                            <asp:DropDownList ID="ddlECandStatus" Width="80px" runat="server">
                                               <asp:ListItem Text="Offered" Value="Offered"></asp:ListItem>
                                               <asp:ListItem Text="Offer Accepted" Value="Offer Accepted"></asp:ListItem>
                                              <asp:ListItem Text="Completed 3 Months" Value="Completed 3 Months"></asp:ListItem>
                                              <asp:ListItem Text="Joined" Value="Joined"></asp:ListItem>
                                              <asp:ListItem Text="Left Before 3 Months" Value="Left Before 3 Months"></asp:ListItem>
                                              <asp:ListItem Text="Offered Drop Out" Value="Offered Drop Out"></asp:ListItem>
                                            </asp:DropDownList>

                                              <%-- <asp:Label ID="lblECandidateSts" runat="server" Text='<%#Eval("Candidate_Status") %>' Visible="false"></asp:Label>
                                                    <asp:DropDownList ID="ddlECandStatus" runat="server" AppendDataBoundItems="True" CssClass="DropDown" Width="120px" ValidationGroup="Update"> 
                                                    </asp:DropDownList>
                                                     </EditItemTemplate>--%>
                                              <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Offered Date" SortExpression="OfferDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfferdDate" runat="server" Text='<%#Eval("OfferDate")%>'></asp:Label>
                                            </ItemTemplate>
                                                <EditItemTemplate>
                                           <asp:TextBox ID="txtEOfferedDate" runat="server" CssClass="TxtBox" Text='<%#Eval("OfferDate")%>'  Width="90px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CEtxtEOfferedDate" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtEOfferedDate" TargetControlID="txtEOfferedDate">
                                            </asp:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="REtxtEOfferedDate" runat="server" ControlToValidate="txtEOfferedDate"
                                                Display="Dynamic" ErrorMessage="Wrong Date" ForeColor="Red" SetFocusOnError="true"
                                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$" ValidationGroup="Update"
                                                ></asp:RegularExpressionValidator>
                                                       </EditItemTemplate>
                                               <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                              <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Offered Price" SortExpression="OfferPrice">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfferPrice" runat="server" Text='<%#Eval("OfferPrice")%>'></asp:Label>
                                            </ItemTemplate>
                                               <EditItemTemplate>
                                           <asp:TextBox ID="txtEOfferdPrice" runat="server" CssClass="TxtBox" Text='<%#Eval("OfferPrice")%>' Width="90px"></asp:TextBox>
                                              <asp:FilteredTextBoxExtender ID="FTBtxtEOfferdPrice" runat="server" TargetControlID="txtEOfferdPrice"
                                                    ValidChars=".0123456789"> </asp:FilteredTextBoxExtender>
                                              </EditItemTemplate>
                                               <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                              <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Planned DOJ" SortExpression="PlannedDOJ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPlannedDoj" runat="server" Text='<%#Eval("PlannedDOJ")%>'></asp:Label>
                                            </ItemTemplate>
                                               <EditItemTemplate>
                                            <asp:TextBox ID="txtEPlannedDOJ" runat="server" CssClass="TxtBox" Text='<%#Eval("OfferDate")%>' Width="90px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CEtxtEPlannedDOJ" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtEPlannedDOJ" TargetControlID="txtEPlannedDOJ">
                                            </asp:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="REtxtEPlannedDOJ" runat="server" ControlToValidate="txtEPlannedDOJ"
                                                Display="Dynamic" ErrorMessage="Wrong Date" ForeColor="Red" SetFocusOnError="true"
                                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$" ValidationGroup="Update"
                                                ></asp:RegularExpressionValidator>

                                        </EditItemTemplate>
                                               <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                              <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Actual DOJ" SortExpression="ActualDoJ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActualDoJ" runat="server" Text='<%#Eval("ActualDoJ")%>'></asp:Label>
                                            </ItemTemplate>
                                               <EditItemTemplate>
                                           <asp:TextBox ID="txtEActualDoJ" runat="server" CssClass="TxtBox" Text='<%#Eval("OfferDate")%>' Width="90px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CEtxtEActualDoJ" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtEActualDoJ" TargetControlID="txtEActualDoJ">
                                            </asp:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="REtxtEActualDoJ" runat="server" ControlToValidate="txtEActualDoJ"
                                                Display="Dynamic" ErrorMessage="Wrong Date" ForeColor="Red" SetFocusOnError="true"
                                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$" ValidationGroup="Update"
                                                ></asp:RegularExpressionValidator>
                                              </EditItemTemplate>
                                               <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                              <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>

                            
                                          <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="EditButton" CommandName="Edit" runat="server" ToolTip="Edit"
                                                ImageUrl="~/Image/b_edit.png" Width="22px" Height="22px" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="UpdateButton" CommandName="Update" runat="server" Text="Update"
                                                CssClass="lbtnUpdate" ValidationGroup="Update"></asp:LinkButton>
                                            &nbsp;
                                            <asp:LinkButton ID="CancelUpdateButton" CommandName="Cancel" runat="server" Text="Cancel"
                                                CssClass="lbtnCancel" />
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Left" Width="110px" />
                                    </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                <%--    </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvCanOfferd" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
                                
                            </td>
                        </tr>
                    </table>
               <%-- </ContentTemplate>
            </asp:UpdatePanel>--%>
        </div>
    </center>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="RprtCandidateRelation.aspx.cs" Inherits="Report_RprtCandidateRelation" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript">
        //variable that will store the id of the last clicked row
        var previousRow;
        function ChangeRowColor(row) {

            if (previousRow == row)
                return; //do nothing

            else if (previousRow != null)

                document.getElementById(previousRow).style.backgroundColor = "red";

            document.getElementById(row).style.backgroundColor = "#ffffff";

            previousRow = row;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Selected Candidates</h2>
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="center" width="10%">
                                Client
                            </td>
                            <td align="center" width="15%">
                                <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td align="center" width="15%">
                               Consultant 
                            </td> 
                            <td align="center" width="15%">
                                <asp:DropDownList ID="ddlConsultantName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            
                            <td align="center" width="15%">
                               Candidate Status</td>
                            <td align="center">
                                <asp:DropDownList CssClass="DropDown" ID="ddlCandidateStatus" runat="server">
                              <asp:ListItem Text="All" Value="All"></asp:ListItem>
                                <asp:ListItem Text="2nd Interview Selected" Value="11"></asp:ListItem>
                                <asp:ListItem Text="Shortlisted" Value="12"></asp:ListItem>
                                <asp:ListItem Text="Offered" Value="13"></asp:ListItem>
                                <asp:ListItem Text="Offer Accepted" Value="14"></asp:ListItem>
                                <asp:ListItem Text="Completed 3 Months" Value="18"></asp:ListItem>
                                <asp:ListItem Text="Joined" Value="15"></asp:ListItem>
                                <asp:ListItem Text="Left Before 3 Months" Value="17"></asp:ListItem>
                                <asp:ListItem Text="Offered Drop Out" Value="24"></asp:ListItem>

                            </asp:DropDownList>
                                <%--<asp:DropDownList ID="ddlCandidateStatus" runat="server" AppendDataBoundItems="True" CssClass="DropDown" Width="200px">
                                </asp:DropDownList>--%>
                            </td>
                        </tr>
                        <tr><td align="center" width="10%">
                            </td>
                            <td align="center" width="15%">
                                Offer Date</td>
                            <td align="center" width="15%">
                                Plan DOJ</td>
                             <td align="center" width="15%">
                                 Actual DOJ</td>
                             <td align="center" width="20%" colspan="2">
                                </td>
                        </tr>
                        <tr>
                            
                           
                            <td align="center" width="10%">
                                From </td>
                            <td align="center" width="15%">
                                <asp:TextBox ID="txtOfferfrom" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtOfferfrom"
                                    PopupButtonID="txtOfferfrom" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td align="center" width="15%">
                                <asp:TextBox ID="txtPlanfrom" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender2" runat="server" TargetControlID="txtPlanfrom"
                                    PopupButtonID="txtPlanfrom" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td align="center" width="15%">
                                <asp:TextBox ID="txtActualfrom" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender3" runat="server" TargetControlID="txtActualfrom"
                                    PopupButtonID="txtActualfrom" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td colspan="2" rowspan="2" align="right">
                                <asp:ImageButton ID="lbtnDownload" runat="server" Height="30px" ImageUrl="~/Image/ExcelDownload.jpg" OnClick="lbtnDownload_Click" ToolTip="Download in Excel" Width="40px" />
                            </td>
                          
                        </tr>
                                <tr>
                            
                           
                            <td align="center" width="10%">
                                To </td>
                            <td align="center" width="15%">
                                <asp:TextBox ID="txtOfferTo" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtOfferTo"
                                    PopupButtonID="txtOfferTo" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                            </td>
                            <td align="center" width="15%">
                                <asp:TextBox ID="txtPlanto" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender5" runat="server" TargetControlID="txtPlanto"
                                    PopupButtonID="txtPlanto" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                                 </td>
                                <td align="center" width="15%">
                                <asp:TextBox ID="txtActualTo" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender6" runat="server" TargetControlID="txtActualTo"
                                    PopupButtonID="txtActualTo" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                           
                           </td>
                        </tr>
                                <tr>
                            
                           
                            <td align="center" colspan="6">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search" OnClick="btnSearch_Click" /></td>
                          
                           
                        </tr>
                     
                        <tr>
                            <td colspan="6">
                               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:GridView ID="gdvInterview" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                    OnPageIndexChanging="gdvInterview_PageIndexChanging" GridLines="Both" CssClass="mRprtGrid"
                                    EmptyDataText="No Data to Dispaly." PageSize="50" Width="100%" OnRowDataBound="gdvInterview_RowDataBound"  HeaderStyle-ForeColor="White" onsorting="gdvInterview_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                                    <Columns>
                                        <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Client_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="RR Number" SortExpression="RRNumber">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRRNumber" runat="server" Text='<%#Eval("RRNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Consultant" SortExpression="Consultant">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsultant" runat="server" Text='<%#Eval("Consultant")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client Name" SortExpression="Client">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Candidate Name" SortExpression="Candidate_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCandidate_Name" runat="server" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Offer Date" SortExpression="OfferDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfferDate" runat="server" Text='<%#Eval("OfferDate")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Offer Price" SortExpression="OfferPrice">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPrice" runat="server" Text='<%#Eval("OfferPrice")%>'></asp:Label>
                                            </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:TemplateField>
                                       
                                        <asp:TemplateField HeaderText="Plan DOJ" SortExpression="PlannedDOJ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPlannedDOJ" runat="server" Text='<%#Eval("PlannedDOJ")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Actual DOJ" SortExpression="ActualDOJ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActualDOJ" runat="server" Text='<%#Eval("ActualDOJ")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Status" SortExpression="SelectedCandidate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOverall_Status" runat="server" Text='<%#Eval("SelectedCandidate")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                    </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvInterview" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                                
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
         <%--   </asp:UpdatePanel>--%>
        </div>
    </center>
</asp:Content>

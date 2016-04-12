<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="ConsultantActivities.aspx.cs" Inherits="Recruitment_ConsultantActivities" %>

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
                Consultant Activities</h2>
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td align="center" width="10%">
                                Client
                            </td>
                            <td align="center" width="15%">
                               Consultant 
                            </td>
                            <td align="center" width="15%">
                                From Date</td> 
                            <td align="center" width="15%">
                                To 
                            </td>
                            
                            <td align="center" width="15%">
                               Candidate Status</td>
                            <td align="center">
                                <%--<asp:DropDownList ID="ddlCandidateStatus" runat="server" AppendDataBoundItems="True" CssClass="DropDown" Width="200px">
                                </asp:DropDownList>--%>
                                <asp:ImageButton ID="lbtnDownload" runat="server" Height="30px" ImageUrl="~/Image/ExcelDownload.jpg" OnClick="lbtnDownload_Click" ToolTip="Download in Excel" Width="40px" />
                            </td>
                        </tr>
                        <tr><td align="center" width="10%">
                                <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td align="center" width="15%">
                                <asp:DropDownList ID="ddlConsultantName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="200px">
                                </asp:DropDownList>
                            </td>
                            <td align="center" width="8%">
                                <asp:TextBox ID="txtfrom" runat="server" CssClass="TxtBox" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtfrom"
                                    PopupButtonID="txtfrom" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                            </td>
                             <td align="center" width="8%">
                                <asp:TextBox ID="txtTo" runat="server" CssClass="TxtBox" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="CalendarExtender4" runat="server" TargetControlID="txtTo"
                                    PopupButtonID="txtTo" Format="dd-MMM-yyyy">
                                </asp:CalendarExtender>
                            </td>
                             <td align="center" width="20%" >
                           <%--     <asp:DropDownList CssClass="DropDown" ID="ddlCandidateStatus" runat="server">
                             
                                <asp:ListItem Text="2nd Interview Selected" Value="11"></asp:ListItem>
                                <asp:ListItem Text="Shortlisted" Value="12"></asp:ListItem>
                                <asp:ListItem Text="Offered" Value="13"></asp:ListItem>
                                <asp:ListItem Text="Completed 3 Months" Value="18"></asp:ListItem>
                                <asp:ListItem Text="Joined" Value="15"></asp:ListItem>
                                <asp:ListItem Text="Left Before 3 Months" Value="17"></asp:ListItem>
                                <asp:ListItem Text="Offered Drop Out" Value="24"></asp:ListItem>
                            </asp:DropDownList>--%>
                                   <asp:DropDownList ID="ddlCandidateStatus" runat="server" CssClass="DropDown" 
                                    AppendDataBoundItems="True">
                                </asp:DropDownList>
                                </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search" OnClick="btnSearch_Click" /></td>
                        </tr>
                        
                                <tr>
                            
                           
                            <td align="center" colspan="6">
                                &nbsp;</td>
                          
                           
                        </tr>
                     
                        <tr>
                            <td colspan="6">
                               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:GridView ID="gdvInterview" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                    OnPageIndexChanging="gdvInterview_PageIndexChanging" GridLines="Both" CssClass="mRprtGrid"
                                    EmptyDataText="No Data to Dispaly." PageSize="50" Width="100%" OnRowDataBound="gdvInterview_RowDataBound"  HeaderStyle-ForeColor="White" onsorting="gdvInterview_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="Client_Name">
                                    <Columns>
                                     <%--   <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Client_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                           <asp:TemplateField HeaderText="Client" SortExpression="Client_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClient_Name" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="RR Number" SortExpression="RRNumber">
                                            <ItemTemplate>
                                                <asp:Label ID="RRNumber" runat="server" Text='<%#Eval("RRNumber")%>'></asp:Label>
                                            </ItemTemplate>
                                                   <HeaderStyle HorizontalAlign="Center" Width="70px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="70px" />
                                        </asp:TemplateField>
                                       <asp:TemplateField HeaderText="Role" SortExpression="Role">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRole" runat="server" Text='<%#Eval("Role")%>'></asp:Label>
                                            </ItemTemplate>
                                                   <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Consultant" SortExpression="Consultant">
                                            <ItemTemplate>
                                                <asp:Label ID="lblUSR_Name" runat="server" Text='<%#Eval("Consultant")%>'></asp:Label>
                                            </ItemTemplate>
                                                  <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="Candidate" SortExpression="Candidate_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCandidate_Name" runat="server" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                                  <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="150px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="RRCandidate Id" SortExpression="RRCandidate_Id">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRRCandidate_Id" runat="server" Text='<%#Eval("RRCandidate_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                                  <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="FollowUp Id" SortExpression="FollowUp_Id">
                                            <ItemTemplate>
                                                <asp:Label ID="lblFollowUp_Id" runat="server" Text='<%#Eval("FollowUp_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                                  <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Creation Date" SortExpression="CreationDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCreationDate" runat="server" Text='<%#Eval("CreationDate")%>'></asp:Label>
                                            </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Candidate Status" SortExpression="Candidate_Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCandidate_Status" runat="server" Text='<%#Eval("Candidate_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="150px" />
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

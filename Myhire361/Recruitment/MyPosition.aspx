<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="MyPosition.aspx.cs" Inherits="Recruitment_MyPosition" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <div id="page">
        <h2>
            My Positions</h2>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>

<table width="100%">
 <tr><td>Client Name</td><td>RR Number</td><td>Designation</td><td>Location</td><td>Position</td><td>Request Status </td><td></td>
                            </tr>

                             <tr><td>   <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="200px">
                                </asp:DropDownList></td>
                                <td>  <asp:TextBox ID="txtRRNumber" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox></td>
                                 <td>  <asp:TextBox ID="txtDesignation" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox></td>
                                 <td>  <asp:TextBox ID="txtLocation" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox></td>
                                <td>  <asp:TextBox ID="txtPosition" runat="server" CssClass="TxtBox" Width="140px"></asp:TextBox></td>
                               
                                <td> <asp:DropDownList ID="ddlRequestStatus" runat="server" AppendDataBoundItems="True"
                                CssClass="DropDown" Width="200px">
                                 <asp:ListItem Text="All" Value="0"></asp:ListItem>
                               <asp:ListItem Text="Open" Value="Open"></asp:ListItem>
                                 <asp:ListItem Text="Partialy Closed" Value="Partialy Closed"></asp:ListItem>
                               <%--    <asp:ListItem Text="Closed" Value="Closed"></asp:ListItem>
                                     <asp:ListItem Text="Hold" Value="Hold"></asp:ListItem>
                                      <asp:ListItem Text="Mapping" Value="Mapping"></asp:ListItem>--%>
                                     <asp:ListItem Text="Submitted" Value="Submitted"></asp:ListItem>
                                    <%--  <asp:ListItem Text="Not Planned" Value="Not Planned"></asp:ListItem>--%>
                              </asp:DropDownList></td>
                              
                              <td>  <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search"  OnClick="btnSearch_Click"/></td>
                            </tr>
                             <tr>
                               
                                <td colspan="7">

        <asp:GridView runat="server" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Request_Id"
            ID="gdvRequest" AllowPaging="True" EmptyDataText="Sorry! No Record Found." OnPageIndexChanging="gdvRequest_PageIndexChanging"
            OnRowCommand="gdvRequest_RowCommand" PageSize="20" 
            onrowdatabound="gdvRequest_RowDataBound" HeaderStyle-ForeColor="White" onsorting="gdvRequest_Sorting" AllowSorting="true"  CurrentSortDirection="Asc" CurrentSortField="Client_Name">
            <Columns>
                <asp:TemplateField HeaderText="S.No." SortExpression="Request_Id">
                    <ItemTemplate>
                        <%#Container.DataItemIndex+1%>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Id" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblId" runat="server" Text='<%#Eval("Request_Id") %>'></asp:Label></ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="RR Number" SortExpression="RRNumber">
                    <ItemTemplate>
                        <asp:Label ID="lblRRNo" runat="server" Text='<%#Eval("RRNumber") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Client" SortExpression="Client_Name">
                    <ItemTemplate>
                        <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name") %>' Font-Bold="true"></asp:Label></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Designation" SortExpression="Designation">
                    <ItemTemplate>
                        <asp:Label ID="lblDesig" runat="server" Text='<%#Eval("Designation") %>' Font-Bold="true"></asp:Label></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" width="150px" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Location" SortExpression="City_Name">
                    <ItemTemplate>
                        <asp:Label ID="lbllocation" runat="server" Text='<%#Eval("City_Name") %>'></asp:Label></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" width="80px"/>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Criticality" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="lblCriticality" runat="server" Text='<%#Eval("Criticality") %>'></asp:Label></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText=" Position" SortExpression="Total_Position">
                    <ItemTemplate>
                        <asp:Label ID="lblTotalPosition" runat="server" Text='<%#Eval("Total_Position") %>'></asp:Label></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Recieve Date" SortExpression="Recieve_Date">
                    <ItemTemplate>
                        <asp:Label ID="lblReciveDate" runat="server" Text='<%#Eval("Recieve_Date") %>'></asp:Label></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Left"  width="110px"/>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Target Closure Date" Visible="false" >
                    <ItemTemplate>
                        <asp:Label ID="lblTtlClosureDate" runat="server" Text='<%#Eval("Closer_Date") %>'></asp:Label></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                 <asp:TemplateField HeaderText="Request Status" SortExpression="Request_Status">
                    <ItemTemplate>
                        <asp:Label ID="lblRequestStatus" runat="server" Text='<%#Eval("Request_Status") %>'></asp:Label></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" width="100px" />
                </asp:TemplateField>

                   <asp:TemplateField HeaderText="Identified" SortExpression="Identified">
                    <ItemTemplate>
                        <asp:Label ID="lblIdentified" runat="server" Text='<%#Eval("Identified") %>'></asp:Label></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" width="60px" />
                </asp:TemplateField>
                 

                <asp:TemplateField HeaderText="Status" SortExpression="Status" Visible="false">
                    <ItemTemplate>
                        <asp:Label ID="lblStatus" runat="server" Text='<%#Eval("Status") %>'></asp:Label></ItemTemplate>
                    <HeaderStyle HorizontalAlign="Center" />
                    <ItemStyle HorizontalAlign="Center" />
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Action" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:ImageButton ID="lbtnView" runat="server" ImageUrl="~/Image/view.png" Height="22px"
                            Width="22px" CssClass="lbtnEdit" ToolTip="View" CommandName="View" />
                        &nbsp;
                        <asp:ImageButton ID="lbtnEdit" runat="server" ImageUrl="~/Image/b_edit.png" Height="22px"
                            Width="22px" CssClass="lbtnEdit" ToolTip="Edit" Visible="false" CommandName="Edit" />
                        &nbsp;
                        <asp:ImageButton ID="lbtnCandidate" runat="server" CssClass="lbtnCancel" CommandName="Candidate"
                            ToolTip="Candidate" ImageUrl="~/Image/candidate.gif"></asp:ImageButton>
                        &nbsp;<asp:LinkButton ID="lbtnConsultant" runat="server" CssClass="lbtnCancel" Visible="false"
                            CommandName="Consultant">Consultant</asp:LinkButton>
                        &nbsp;
                        <asp:ImageButton ID="lbtnUpload" runat="server" CssClass="lbtnCancel" CommandName="Upload"
                            ToolTip="Upload" ImageUrl="~/Image/Upload.jpg"></asp:ImageButton>
                            <asp:ImageButton ID="imgbtnAssign" runat="server" CssClass="lbtnCancel" CommandName="Assign"
                            ToolTip="Search Candidates" ImageUrl="~/Image/Icon_Assign.png" Height="22px"
                            Width="22px"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="New">
                    <ItemTemplate>
                        <asp:ImageButton ID="lbtnNewCandidate" runat="server" CssClass="lbtnUpdate" CommandName="New"
                            ToolTip="New Candidate" ImageUrl="~/Image/candidate.gif"></asp:ImageButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataRowStyle ForeColor="Red" />
        </asp:GridView>


        </td></tr>
</table>

          </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvRequest" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
    </div>
</asp:Content>

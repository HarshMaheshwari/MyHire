<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="HRDashboardq.aspx.cs" Inherits="Recruitment_HRDashboard" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style2
        {
            width: 53px;
        }
    </style>
   
       <script type = "text/javascript">
           var popUpObj;
           function showModalPopUp() {
               popUpObj = window.open("../UploadCvs.aspx",
               "ModalPopUp",
               "toolbar=no," +
               "scrollbars=no," +
               "location=no," +
               "statusbar=no," +
               "menubar=no," +
               "resizable=0," +
               "width=1100," +
               "height=500," +
               "left = 100," +
               "top=50"
               );
               popUpObj.focus();
               LoadModalDiv();
           }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
<div id="page">
        <h2>
            Recruitment Request Management</h2>
            <table width="100%"> <tr>
                <td align="left">
                    <asp:Button ID="btnNew" runat="server" CssClass="btnNew" OnClick="btnNew_Click" Text="New" />
                </td>
                <td align="right">
                    <asp:ImageButton ID="lbtnDownload" runat="server" ImageUrl="~/Image/ExcelDownload.jpg"
                        Height="30px" Width="40px" OnClick="lbtnDownload_Click" ToolTip="Download" />
                </td>
            </tr></table>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
        <table width="100%" align="center">
           
            <tr>
                <td colspan="2">
                    <table width="100%">
                        <tr>
                            <td align="right">
                                Client :
                            </td>
                            <td align="left" class="style2">
                                <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="180px">
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                RR-Number :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtRRNo" runat="server" Width="100px"></asp:TextBox>
                            </td>
                            <td align="right">
                                Role / Job_Profile :
                            </td>
                            <td align="left">
                                <asp:TextBox ID="txtDesigntn" runat="server" Width="180px"></asp:TextBox>
                            </td>
                            <td align="right">Request Status:</td>
                            <td align="left">
                            <asp:DropDownList ID="ddlRequestStatus" runat="server" AppendDataBoundItems="True"
                                CssClass="DropDown" Width="180px">
                                 <asp:ListItem Text="All" Value="0"></asp:ListItem>
                               <asp:ListItem Text="Open" Value="Open"></asp:ListItem>
                                 <asp:ListItem Text="Partialy Closed" Value="Partialy Closed"></asp:ListItem>
                                   <asp:ListItem Text="Closed" Value="Closed"></asp:ListItem>
                                     <asp:ListItem Text="Hold" Value="Hold"></asp:ListItem>
                                      <asp:ListItem Text="Mapping" Value="Mapping"></asp:ListItem>
                                       <asp:ListItem Text="Submitted" Value="Submitted"></asp:ListItem>
                                 <asp:ListItem Text="Not Planned" Value="Not Planned"></asp:ListItem>
                              </asp:DropDownList>
                            </td>
                            <td>
                                <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search" OnClick="btnSearch_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td align="right" colspan="3">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" colspan="4">
                                Status :
                                <asp:DropDownList ID="ddlRecordStatus" runat="server" AutoPostBack="True" CssClass="DropDown"
                                    OnSelectedIndexChanged="ddlRecordStatus_SelectedIndexChanged" Width="100px">
                                    <asp:ListItem Selected="True" Value="1">Active</asp:ListItem>
                                    <asp:ListItem Value="0">Inactive</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
               
                    <asp:GridView runat="server" AutoGenerateColumns="false" CssClass="mGrid" DataKeyNames="Request_Id"
                        ID="gdvRequest" AllowPaging="True" EmptyDataText="Sorry! No Record Found." OnPageIndexChanging="gdvRequest_PageIndexChanging"
                         OnRowCommand="gdvRequest_RowCommand"
                        PageSize="20"  HeaderStyle-ForeColor="White"  >
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." SortExpression="Request_Id">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Request_Id") %>'></asp:Label></ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RR Number" SortExpression="RRNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblRRNo" runat="server" Text='<%#Eval("RRNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                <ItemStyle HorizontalAlign="Left"  Width="80px"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Client" SortExpression="Client_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name") %>'></asp:Label></ItemTemplate>
                               <HeaderStyle HorizontalAlign="Center" Width="230px" />
                                <ItemStyle HorizontalAlign="Left"  Width="230px"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Designation" SortExpression="Designation">
                                <ItemTemplate>
                                    <asp:Label ID="lblDesig" runat="server" Text='<%#Eval("Designation") %>'></asp:Label></ItemTemplate>
                              <HeaderStyle HorizontalAlign="Center" Width="150px" />
                                <ItemStyle HorizontalAlign="Left"  Width="150px"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="HR Manager" SortExpression="HR Manager">
                                <ItemTemplate>
                                    <asp:Label ID="lblrequestby" runat="server" Text='<%#Eval("Request_By") %>'></asp:Label></ItemTemplate>
                               <HeaderStyle HorizontalAlign="Center" Width="90px" />
                                <ItemStyle HorizontalAlign="Left"  Width="90px"/>
                            </asp:TemplateField>
                            <%--<asp:TemplateField HeaderText="Hiring Manager" SortExpression="Hiring Manager">
                                <ItemTemplate>
                                    <asp:Label ID="lblTotalPosition" runat="server" Text='<%#Eval("Total_Position") %>'></asp:Label></ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                <ItemStyle HorizontalAlign="Left"  Width="50px"/>
                    
                            </asp:TemplateField>--%>
                            <%--<asp:TemplateField HeaderText="CVs Shared" Visible="false" SortExpression="CVs Shared">
                                <ItemTemplate>
                                    <asp:Label ID="lblCVsShared" runat="server" Text='<%#Eval("Criticality") %>'></asp:Label></ItemTemplate>
                              <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                <ItemStyle HorizontalAlign="Left"  Width="60px"/>
                            </asp:TemplateField>--%>
                            
                          
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>

                                          
                                    <asp:ImageButton ID="imgbtnOpen" runat="server" Font-Underline="false"  CommandName="edit"
                                        CssClass="lbtnView" ImageUrl="~/Image/b_edit.png" Height="22px" Width="22px"  
                                        ToolTip="View" />
                                    &nbsp;
                                    <asp:ImageButton ID="lbtnSkils" runat="server" CssClass="lbtnCancel" CommandName="skills"
                                        ImageUrl="~/Image/skills.jpg" Height="22px" Width="22px" ToolTip="skills" />
                                         &nbsp;
                                    <asp:ImageButton ID="lbtnCandidate" runat="server"  ToolTip="Candidate" 
                                       CommandName="Candidate"      ImageUrl="~/Image/candidate.gif"></asp:ImageButton>
                                    &nbsp;
                                    <asp:ImageButton ID="lbtnDownload" runat="server"  CommandName="excelupload" ImageUrl="~/Image/ExcelDownload.jpg"
                        Height="20px" Width="20px" ToolTip="Excel upload" />
                                      
                                    &nbsp;
                                    <asp:ImageButton ID="lbtnView" runat="server" ImageUrl="~/Image/cv.jpg" Height="22px"  OnClientClick="showModalPopUp()"
                                        Width="22px" CssClass="lbtnEdit" ToolTip="CVs Upload" />
                                   
                                    &nbsp;
                                    
                                     <asp:ImageButton ID="imgbtnViewVideo" runat="server"  ImageUrl="~/Image/Video.png"
                                                    ToolTip=" Video" Height="22px" Width="22px"></asp:ImageButton>

                                    &nbsp;
                                    <asp:ImageButton ID="imgbtnActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                        CssClass="lbtnView" ImageUrl="~/Image/b_drop.png" Height="22px" Width="22px"  Visible="false"
                                        ToolTip="Inactive" />
                                    &nbsp;
                                 
                                    <asp:ImageButton ID="imgbtnInActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click"
                                        CssClass="lbtnView" ImageUrl="~/Image/Checked.png" Height="22px" Width="22px" Visible="false"
                                        ToolTip="Active" />
                                    &nbsp;
                                    <asp:LinkButton ID="lbtnUpload" runat="server" CssClass="lbtnCancel" CommandName="Upload"
                                        Visible="false">Upload</asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"  Width="190px"/>
                                <ItemStyle HorizontalAlign="Center" Width="190px"/>
                            </asp:TemplateField>
                          <%--  <asp:TemplateField HeaderText="New">
                                <ItemTemplate>
                                    <asp:ImageButton ID="lbtnNewCandidate" runat="server" CommandName="New" ToolTip="New Candidate"
                                        ImageUrl="~/Image/candidate.gif"></asp:ImageButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"  Width="30px"/>
                                <ItemStyle HorizontalAlign="Center"  Width="30px"/>
                            </asp:TemplateField>--%>
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                    </asp:GridView>

                  
                </td>
            </tr>
        </table>

         </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvRequest" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
    </div>


</asp:Content>


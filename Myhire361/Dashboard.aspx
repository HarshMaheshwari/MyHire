<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Dashboard.aspx.cs" Inherits="Dashboard" MasterPageFile="~/MasterPage.master" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
<!DOCTYPE html>
 <style type="text/css">
        .style2
        {
            width: 53px;
        }
           .mGrid {
            }
            .modal-backdrop {
           background-color: rgba(0, 0, 0, 0.61);
           position: absolute;
           top: 0;
           bottom: 0;
           left: 0;
           right: 0;
           display: none;
       }
       .modal {
           width: 800px;
           height:500px;
           position: absolute;
           top: 30%;
           left:5%;
           z-index: 1020;
           background-color: #FFF;
           border-radius: 6px;
           display: none;
       }
       .modal-header {
           background-color: #333;
           color: #FFF;
           border-top-right-radius: 5px;
           border-top-left-radius: 5px;
        
       }
       .modal-header h3 {
           margin: 0;
           padding: 0 10px 0 10px;
           line-height: 40px;
         
       }
       .modal-header h3 .close-modal {
           float: left;
           text-decoration: none;
           color: #FFF;
         
       }
       .modal-footer {
           background-color: #F1F1F1;
           padding: 0 10px 0 10px;
           line-height: 40px;
           text-align: right;
           height:0px;
           border-bottom-right-radius: 5px;
           border-bottom-left-radius: 5px;
           border-top: solid 1px #CCC;
           left:5%;
       }
       .modal-body {
       
           padding: 10px 10px 10px 10px;
       }

    </style>
    
  <script src="//ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script>
        $(function () {
            modalPosition();
            $(window).resize(function () {
                modalPosition();
            });
            $('.openModal').click(function (e) {
                $('.modal, .modal-backdrop').fadeIn('fast');
                e.preventDefault();
            });
            $('.close-modal').click(function (e) {
                $('.modal, .modal-backdrop').fadeOut('fast');
            });
        });
        function modalPosition() {
            var width = $('.modal').width();
            var pageWidth = $(window).width();
            var x = (pageWidth / 2) - (width / 2);
            $('.modal').css({ left: x + "px" });
        }
    </script>



        
    
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


     <script type = "text/javascript">
         var popUpObj;
         function showModalPopUp2() {
             popUpObj = window.open("VintroVideo.aspx",
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
     <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ToolkitScriptManager>
  
     <div>
         <div class="modal">
    <div class="modal-header" style="width: 780px">
        <center><h3>Question Details <a class="close-modal" href="#">&times;</a></h3></center>
    </div>
    <div class="modal-body">
            <asp:GridView runat="server" AutoGenerateColumns="false" CssClass="mGrid" DataKeyNames="Que_Id"
                ID="gdvVideoQue" AllowPaging="True" EmptyDataText="Sorry! No Record Found."
                HeaderStyle-ForeColor="White" Width="755px">
                <Columns>
                    <asp:TemplateField HeaderText="Ques.No." SortExpression="Que_Id">
                        <ItemTemplate>
                            <%#Container.DataItemIndex+1%>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="40px" />
                        <ItemStyle HorizontalAlign="Center" Width="40px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Id" Visible="false">
                        <ItemTemplate>
                            <asp:Label ID="lblId" runat="server" Text='<%#Eval("Que_Id") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Question" SortExpression="Que_Type">
                        <ItemTemplate>
                            <asp:Label ID="lblques" runat="server" Text='<%#Eval("Que_Type") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="80px" />
                        <ItemStyle HorizontalAlign="Left" Width="80px" />
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Question Site" SortExpression="Que_Site">
                        <ItemTemplate>
                            <asp:Label ID="lblQueSite" runat="server" Text='<%#Eval("Que_Site") %>'></asp:Label>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>

                    <%-- <asp:TemplateField HeaderText="Question Site" SortExpression="Que_Site">
                        <ItemTemplate>
                           <asp:Button ID="Button1" CssClass="btnCancel" runat="server" Text="Send" /></td>
                        </ItemTemplate>
                        <HeaderStyle HorizontalAlign="Center" Width="30px" />
                        <ItemStyle HorizontalAlign="Center" Width="30px" />
                    </asp:TemplateField>--%>
                </Columns>
                <EmptyDataRowStyle ForeColor="Red" />
            </asp:GridView>
        <table align="center" >
            <tr align="center">
                <td>
          <asp:Button ID="btn_close" runat="server" Text="Send" CssClass="modalOK close-modal" 
           Width="50" Height="30" BackColor="Black" ForeColor="Red" />
    </td>
</tr>                </table>    
         </div>
</div>
</div>
    <div id="page" style="top: -100px">
        <h2>
          My  Dashboard</h2>
            <table width="100%"> <tr>
                <td align="left">
                    <asp:Button ID="btnNew" runat="server" CssClass="btnNew" OnClick="btnNew_Click" Text="New" Visible="false"/>
                </td>
                 <td align="left">
                    <asp:Button ID="btnEditProfile" runat="server" CssClass="btnNew" OnClick="btnEditProfile_Click" Text="Edit Profile" />
                </td>
                <td align="right">
                    <asp:ImageButton ID="lbtnDownload" Visible="false" runat="server" ImageUrl="~/Image/ExcelDownload.jpg"
                        Height="30px" Width="40px" OnClick="lbtnDownload_Click" ToolTip="Download" />
                </td>
            </tr></table>

                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
        <table width="100%" align="center">
           
            <tr style="visibility: hidden">
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
                          <%--  //<asp:Label ID="'<%# Eval("Request_Id") %>'" runat="server" Text="Label" Visible="false"></asp:Label>--%>
                        </tr>
                    </table>
                </td>
            </tr>
            <tr>
                <td colspan="2">
               <%-- <asp:GridView runat="server" AutoGenerateColumns="false" CssClass="mGrid" DataKeyNames="Request_Id"
                        ID="GridView1" AllowPaging="True" EmptyDataText="Sorry! No Record Found." OnPageIndexChanging="gdvRequest_PageIndexChanging"
                         OnRowCommand="gdvRequest_RowCommand"
                        PageSize="20"  HeaderStyle-ForeColor="White"  >--%>
                    <asp:GridView runat="server" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Request_Id"
                        ID="gdvRequest" AllowPaging="True" EmptyDataText="Sorry! No Record Found." OnPageIndexChanging="gdvRequest_PageIndexChanging"
                         OnRowCommand="gdvRequest_RowCommand"
                        PageSize="20"  HeaderStyle-ForeColor="White">
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
                           <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                      <asp:ImageButton ID="lbtnView" runat="server" Visible="false" ImageUrl="~/Image/view.png" Height="22px"
                                        Width="22px" CssClass="lbtnEdit" ToolTip="View" CommandName="View" />
                                          
                                    <asp:ImageButton ID="imgbtnOpen" runat="server" Visible="false" Font-Underline="false"  CommandName="edit"
                                        CssClass="lbtnView" ImageUrl="~/Image/b_edit.png" Height="22px" Width="22px"  
                                        ToolTip="Edit" />
                                    &nbsp;
                                    <asp:ImageButton ID="lbtnSkils" runat="server" Visible="false" CssClass="lbtnCancel" CommandName="skills"
                                        ImageUrl="~/Image/skills.jpg" Height="22px" Width="22px" ToolTip="skills" />
                                         &nbsp;
                                    <asp:ImageButton ID="lbtnCandidate" runat="server" Visible="false" ToolTip="Candidate" 
                                       CommandName="Candidate"      ImageUrl="~/Image/candidate.gif"></asp:ImageButton>
                                    &nbsp;
                                    <asp:ImageButton ID="lbtnDownload" runat="server"  CommandName="Upload" ImageUrl="~/Image/ExcelDownload.jpg"
                        Height="20px" Width="20px" ToolTip="Excel upload" />
                                      
                                    &nbsp;
                                    <asp:ImageButton ID="lbtCVs" runat="server" ImageUrl="~/Image/cv.jpg" Height="22px"  OnClientClick="showModalPopUp()"
                                        Width="22px" CssClass="lbtnEdit" ToolTip="CVs Upload" />
                                   
                                    &nbsp;
                                    
                                     <asp:ImageButton ID="ImageButton1" runat="server"  ImageUrl="~/Image/Video.png" Visible="false"
                                          CssClass="openModal"   ToolTip=" Question" Height="22px" Width="22px"></asp:ImageButton>
                                    &nbsp;
                                     <%--<asp:ImageButton ID="imgbtnViewVideo" runat="server"  ImageUrl="~/Image/Video.png"
                                            CommandName="Video"    ToolTip=" Video" Height="22px" Width="22px"></asp:ImageButton>--%>

                                    &nbsp;
                                    <asp:ImageButton ID="imgbtnActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click" Visible="false"
                                        CssClass="lbtnView" ImageUrl="~/Image/b_drop.png" Height="22px" Width="22px"  
                                        ToolTip="Inactive" />
                                    &nbsp;
                                 
                                    <asp:ImageButton ID="imgbtnInActivate" runat="server" Font-Underline="false" OnClick="imgbtn_Activate_Click" Visible="false"
                                        CssClass="lbtnView" ImageUrl="~/Image/Checked.png" Height="22px" Width="22px" 
                                        ToolTip="Active" />
                                    &nbsp;
                                    <asp:LinkButton ID="lbtnUpload" runat="server" CssClass="lbtnCancel" CommandName="Upload"
                                        Visible="false">Upload</asp:LinkButton>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center"  Width="190px"/>
                                <ItemStyle HorizontalAlign="Center" Width="190px"/>
                            </asp:TemplateField>
                          
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


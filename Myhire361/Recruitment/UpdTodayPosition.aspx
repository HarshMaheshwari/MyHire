<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UpdTodayPosition.aspx.cs" Inherits="Recruitment_UpdTodayPosition" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            width: 53px;
        }
    </style>


    <script type = "text/javascript">
        function Check_Click(objRef) {
            //Get the Row based on checkbox
            var row = objRef.parentNode.parentNode;
            if (objRef.checked) {
                //If checked change color to Aqua
                row.style.backgroundColor = "PaleTurquoise";
            }
            else {
                //If not checked change back to original color
                if (row.rowIndex % 2 == 0) {
                    //Alternating Row Color
                    row.style.backgroundColor = "#C2D69B";
                }
                else {
                    row.style.backgroundColor = "white";
                }
            }

            //Get the reference of GridView
            var GridView = row.parentNode;

            //Get all input elements in Gridview
            var inputList = GridView.getElementsByTagName("input");

            for (var i = 0; i < inputList.length; i++) {
                //The First element is the Header Checkbox
                var headerCheckBox = inputList[0];

                //Based on all or none checkboxes
                //are checked check/uncheck Header Checkbox
                var checked = true;
                if (inputList[i].type == "checkbox" && inputList[i] != headerCheckBox) {
                    if (!inputList[i].checked) {
                        checked = false;
                        break;
                    }
                }
            }
            headerCheckBox.checked = checked;

        }
</script>



    <script type="text/javascript">
        function checkAll2(objRef) {
            var GridView = objRef.parentNode.parentNode.parentNode;
            var inputList = GridView.getElementsByTagName("input");
            for (var i = 0; i < inputList.length; i++) {
                //Get the Cell To find out ColumnIndex
                var row = inputList[i].parentNode.parentNode;
                if (inputList[i].type == "checkbox" && objRef != inputList[i]) {
                    if (objRef.checked) {
                        inputList[i].checked = true;
                    }
                    else {

                        inputList[i].checked = false;
                    }
                }
            }
        }
    </script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server" EnablePartialRendering="true">
    </asp:ToolkitScriptManager>
  

    <div id="page">
        <h2>
            Update Today Positions </h2>
         

               <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
        <table width="100%" align="center">
           
            <tr>
                <td colspan="2">
                    <table width="100%">
                        <tr>
                            <td align="right">
                                Client:
                            </td>
                            <td align="left" class="style2">
                                <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Width="170px">
                                </asp:DropDownList>
                            </td>
                            <td align="right">
                                Consultant:
                            </td>
                            <td align="left">
                                  <asp:DropDownList ID="ddlConsultant" runat="server" AppendDataBoundItems="True" CssClass="DropDown"  Width="170px">
                            </asp:DropDownList>
                           
                            </td>
                              <td align="right">
                                Assign Date:
                            </td>
                            <td align="left">
                                 <asp:TextBox ID="txtAssigndt" runat="server" CssClass="TxtBox" Width="100px"></asp:TextBox>
                                  <asp:CalendarExtender ID="CEtxtAssigndt" runat="server" Format="dd-MMM-yyyy"
                                PopupButtonID="txtAssigndt" TargetControlID="txtAssigndt">
                            </asp:CalendarExtender>
                          
                            </td>
                            <td align="right">Request Status:</td>
                            <td align="left">
                            <asp:DropDownList ID="ddlRequestStatus" runat="server" AppendDataBoundItems="True"
                                CssClass="DropDown" Width="90px">
                                 <asp:ListItem Text="All" Value="0"></asp:ListItem>
                               <asp:ListItem Text="Open" Value="Open" Selected="True"></asp:ListItem>
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
                            <td align="right" colspan="5">
                                <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" colspan="4">
                                Status:
                                <asp:DropDownList ID="ddlRecordStatus" runat="server" AutoPostBack="True" CssClass="DropDown"
                                    OnSelectedIndexChanged="ddlRecordStatus_SelectedIndexChanged" Width="90px">
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
                

                    <asp:GridView runat="server" AutoGenerateColumns="False" CssClass="mGrid" DataKeyNames="Request_Id"
                        ID="gdvData" AllowPaging="True" PageSize="20" EmptyDataText="Sorry! No Record Found." OnPageIndexChanging="gdvData_PageIndexChanging"
                         HeaderStyle-ForeColor="White" onsorting="gdvData_Sorting" AllowSorting="true" OnRowDataBound="gdvData_RowDataBound">
                        <Columns>
                            <asp:TemplateField HeaderText="S.No." SortExpression="Request_Id" Visible="false">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="40px" />
                                <ItemStyle HorizontalAlign="Center" Width="40px" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("Request_Id") %>'></asp:Label>
                                 <asp:Label ID="lblRelation_Id" runat="server" Text='<%#Eval("Relation_Id") %>'></asp:Label></ItemTemplate>
                                 </asp:TemplateField>
                 
                            <asp:TemplateField HeaderText="Today Position">
                        <HeaderTemplate>
                          <asp:CheckBox ID="checkAll" runat="server" onclick = "checkAll2(this);" Text="Today Position"  />
                        </HeaderTemplate>
                       <ItemTemplate>
                         <asp:CheckBox ID="ChkIsTodayPos" runat="server" onclick = "Check_Click(this)" />
                            <asp:Label ID="lblChkIsTodayPos" runat="server" Text='<%#Eval("TodayPosition") %>' Visible="false"></asp:Label>

                       </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                <ItemStyle HorizontalAlign="left"  Width="100px"/>
                    </asp:TemplateField>

                             <asp:TemplateField HeaderText="Consultant" SortExpression="Consultants">
                                <ItemTemplate>
                                    <asp:Label ID="lblConsultants" runat="server" Text='<%#Eval("Consultants") %>'></asp:Label></ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                <ItemStyle HorizontalAlign="Left"  Width="130px"/>
                          
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Client" SortExpression="Client_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name") %>'></asp:Label></ItemTemplate>
                               <HeaderStyle HorizontalAlign="Center" Width="180px" />
                                <ItemStyle HorizontalAlign="Left"  Width="180px"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="RR Number" SortExpression="RRNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblRRNo" runat="server" Text='<%#Eval("RRNumber") %>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                <ItemStyle HorizontalAlign="Left"  Width="80px"/>
                            </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="Role/Job Profile" SortExpression="Role">
                                <ItemTemplate>
                                    <asp:Label ID="lblRole" runat="server" Text='<%#Eval("Role") %>'></asp:Label></ItemTemplate>
                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                <ItemStyle HorizontalAlign="Left"  Width="130px"/>
                            </asp:TemplateField>
                           <asp:TemplateField HeaderText="Location" SortExpression="City_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCity" runat="server" Text='<%#Eval("City_Name") %>'></asp:Label></ItemTemplate>
                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                <ItemStyle HorizontalAlign="Left"  Width="130px"/>
                            </asp:TemplateField>
                           
                             <asp:TemplateField HeaderText="Assign Date" SortExpression="Assign_Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblAssign_Date" runat="server" Text='<%#Eval("Assign_Date") %>'></asp:Label></ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                <ItemStyle HorizontalAlign="Left"  Width="100px"/>
                           </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="Request Status" SortExpression="Request_Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblRequest_Status" runat="server" Text='<%#Eval("Request_Status") %>'></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                <ItemStyle HorizontalAlign="Left"  Width="100px"/>
                            </asp:TemplateField>
                           
                           
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                    </asp:GridView>
                 <asp:HiddenField ID="hdnFldSelectedValues" runat="server" />

                  
                </td>
            </tr>

              <tr><td align="center" colspan="2">
                
                     <asp:Button ID="btnSave" runat="server" CssClass="btnSave" Text="Save" ValidationGroup="PSave" OnClick="btnSave_Click"  />&nbsp;
                    
                    </td></tr>
        </table>

        <%-- </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvData" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
    </div>
      
</asp:Content>


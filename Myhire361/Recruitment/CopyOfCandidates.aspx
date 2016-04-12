<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CopyOfCandidates.aspx.cs" Inherits="Recruitment_CopyOfCandidates" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style2
        {
            width: 53px;
        }
    </style>

   <script type="text/javascript">
       function Check_Click(objRef) {
           //Get the Row based on checkbox
           var row = objRef.parentNode.parentNode;
           var GridView = row.parentNode;
           var inputList = GridView.getElementsByTagName("input");
           for (var i = 0; i < inputList.length; i++) {
               var headerCheckBox = inputList[0];
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
        function checkAll(objRef) {
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
            Copy Of Candidates </h2>
         

               <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>--%>
        <table width="100%" align="center">
           
            <tr>
                <td colspan="2">
                    <table width="100%">
                        <tr>
                            <td align="right">
                               From Client:
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlfromClient" runat="server" AppendDataBoundItems="True" CssClass="DropDown" AutoPostBack="true"
                                    Width="170px" OnSelectedIndexChanged="ddlfromClient_SelectedIndexChanged" >
                                </asp:DropDownList>
                                  <asp:CompareValidator ID="CVddlfromClient" runat="server" ControlToValidate="ddlfromClient" ErrorMessage="*"
                                                ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="PSave"
                                                Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td align="right">
                               From RR-Number:
                            </td>
                             <td align="left">
                                <asp:DropDownList ID="ddlFromRRNumber" runat="server" AppendDataBoundItems="True" AutoPostBack="true" CssClass="DropDown"  Width="170px"
                                    OnSelectedIndexChanged="ddlFromRRNumber_SelectedIndexChanged" >
                            </asp:DropDownList>
                                  <asp:CompareValidator ID="CVddlFromRRNumber" runat="server" ControlToValidate="ddlFromRRNumber" ErrorMessage="*"
                                                ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="PSave"
                                                Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                           
                             
                              <td align="right">
                               From Consultant:
                            </td>
                            <td align="left">
                                  <asp:DropDownList ID="ddlFromConsultant" runat="server" AppendDataBoundItems="True" AutoPostBack="true" CssClass="DropDown"  Width="170px"
                                    OnSelectedIndexChanged="ddlFromConsultant_SelectedIndexChanged" >
                            </asp:DropDownList>
                                 <asp:CompareValidator ID="CVddlFromConsultant" runat="server" ControlToValidate="ddlFromConsultant" ErrorMessage="*"
                                                ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="PSave"
                                                Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                           
                            </td>
                           
                        </tr>
                        <tr>
                            <td align="right">
                               To Client:
                            </td>
                            <td align="left">
                                <asp:DropDownList ID="ddlToClient" runat="server" AppendDataBoundItems="True" CssClass="DropDown" AutoPostBack="true"
                                    Width="170px" OnSelectedIndexChanged="ddlToClient_SelectedIndexChanged" >
                                </asp:DropDownList>
                                  <asp:CompareValidator ID="CVddlToClient" runat="server" ControlToValidate="ddlToClient" ErrorMessage="*"
                                                ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="PSave"
                                                Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td align="right">
                               To RR-Number:
                            </td>
                             <td align="left">
                                <asp:DropDownList ID="ddlToRRNumber" runat="server" AppendDataBoundItems="True" AutoPostBack="true" CssClass="DropDown"  Width="170px"
                                    OnSelectedIndexChanged="ddlToRRNumber_SelectedIndexChanged" >
                            </asp:DropDownList>
                                  <asp:CompareValidator ID="CVddlToRRNumber" runat="server" ControlToValidate="ddlToRRNumber" ErrorMessage="*"
                                                ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="PSave"
                                                Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                            </td>


                            <td align="right">
                               To Consultant:
                            </td>
                            <td align="left">
                                  <asp:DropDownList ID="ddlToConsultant" runat="server" AppendDataBoundItems="True"   CssClass="DropDown"  Width="170px"
                                    >
                            </asp:DropDownList>
                                 <asp:CompareValidator ID="CVddlToConsultant" runat="server" ControlToValidate="ddlToConsultant" ErrorMessage="*"
                                                ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="PSave"
                                                Type="Integer" ValueToCompare="0"></asp:CompareValidator>
                           
                            </td>
                             
                             
                            <td>

                                <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search" OnClick="btnSearch_Click" Visible="false" />
                            </td>
                        </tr>

                        <tr runat="server">
                            <td align="right" colspan="5">
                               <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                            </td>
                            <td align="right" colspan="4" runat="server" visible="false">
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
                               

                                </ItemTemplate>
                                 </asp:TemplateField>
                 
                            <asp:TemplateField HeaderText="Action">
                           <HeaderTemplate>
                          <asp:CheckBox ID="checkAll" runat="server" onclick = "checkAll(this);" Text="Check All"  />
                        </HeaderTemplate>
                       <ItemTemplate>
                         <asp:CheckBox ID="ChkTRansfer" runat="server" onclick = "Check_Click(this)" />
                          
                         </ItemTemplate>
                                  <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                <ItemStyle HorizontalAlign="left"  Width="100px"/>
                    </asp:TemplateField>
                           
                              <asp:TemplateField HeaderText="Candidate Name" SortExpression="Candidate_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblCandidate_Name" runat="server" Text='<%#Eval("Candidate_Name") %>'></asp:Label>
                                      <asp:Label ID="lblCandidate_Id" runat="server" Text='<%#Eval("Candidate_Id") %>' Visible="false"></asp:Label>
                                    
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                <ItemStyle HorizontalAlign="Left"  Width="100px"/>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="Mobile No" SortExpression="Mobile_No">
                                <ItemTemplate>
                                    <asp:Label ID="lblMobile_No" runat="server" Text='<%#Eval("Mobile_No") %>'></asp:Label>
                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                <ItemStyle HorizontalAlign="Left"  Width="100px"/>
                            </asp:TemplateField>

                             <asp:TemplateField HeaderText="From Consultant" SortExpression="Consultants">
                                <ItemTemplate>
                                    <asp:Label ID="lblConsultants" runat="server" Text='<%#Eval("Consultants") %>'></asp:Label>


                                </ItemTemplate>
                                 <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                <ItemStyle HorizontalAlign="Left"  Width="130px"/>
                          
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="From Client" SortExpression="Client_Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name") %>'></asp:Label></ItemTemplate>
                               <HeaderStyle HorizontalAlign="Center" Width="180px" />
                                <ItemStyle HorizontalAlign="Left"  Width="180px"/>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="From RR Number" SortExpression="RRNumber">
                                <ItemTemplate>
                                    <asp:Label ID="lblRRNo" runat="server" Text='<%#Eval("RRNumber") %>'></asp:Label>
                                     <asp:Label ID="lblRRCandidate_Id" runat="server" Text='<%#Eval("RRCandidate_Id") %>' Visible="false"></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                <ItemStyle HorizontalAlign="Left"  Width="80px"/>
                            </asp:TemplateField>
                          
                            <asp:TemplateField HeaderText="Role / Job Profile" SortExpression="Role">
                                <ItemTemplate>
                                    <asp:Label ID="lblRole" runat="server" Text='<%#Eval("Role") %>'></asp:Label></ItemTemplate>
                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                <ItemStyle HorizontalAlign="Left"  Width="130px"/>
                            </asp:TemplateField>
                           
                           
                           
                           
                        </Columns>
                        <EmptyDataRowStyle ForeColor="Red" />
                    </asp:GridView>
               
                </td>
            </tr>

              <tr><td align="center" colspan="2">
                
                     <asp:Button ID="btnSave" runat="server" CssClass="btnSave" Text="Copy" ValidationGroup="PSave" OnClick="btnSave_Click" Visible="false"  />&nbsp;
                  
                    
                    </td></tr>
        </table>

        <%-- </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvData" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>--%>
    </div>
      
</asp:Content>


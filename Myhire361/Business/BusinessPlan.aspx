<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="BusinessPlan.aspx.cs" Inherits="Business_BusinessPlan" %>



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

     <script type="text/javascript">
         function setCurrentTime(cntrl) {
             var date = new Date();
             var hour = date.getHours();
             var min = date.getMinutes();
             document.getElementById('ContentPlaceHolder1_' + cntrl).value = hour + ":" + min;// document.getElementById('ContentPlaceHolder1_currentDatetime').value;
         }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                Business Plan</h2>
    
                    <table width="100%">
                        <tr>
                            <td align="right" width="15%">
                                Client :
                            </td>
                            <td align="left" width="15%">
                                <asp:DropDownList ID="ddlClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                    Height="25px" Width="150px">
                                </asp:DropDownList>
                                <asp:CompareValidator ID="CVddlClientName" runat="server" ControlToValidate="ddlClientName" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                            </td>
                            <td align="right" width="15%">
                               Month :
                            </td>
                              <td align="left" width="12%">
                              <asp:DropDownList ID="ddlMonth" runat="server" Height="25px" Width="100px">
                                      <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                      <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                      <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                      <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                      <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                      <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                                      <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                      <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                      <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                      <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                      <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                      <asp:ListItem Text="Dec" Value="12"></asp:ListItem>
                                     </asp:DropDownList>
                                    <asp:CompareValidator ID="CVddlMonth" runat="server" ControlToValidate="ddlMonth" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="String" ValidationGroup="save" ValueToCompare="Select"
                                Font-Size="Small"></asp:CompareValidator>
                            </td>
                              <td align="right" width="15%">
                                Year :
                            </td>
                             <td align="left" width="12%">
                                  <asp:DropDownList ID="ddlYear" runat="server" Height="25px" Width="100px">
                                      <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                      <asp:ListItem Text="2010" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="2011" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="2012" Value="2"></asp:ListItem>
                                      <asp:ListItem Text="2013" Value="3"></asp:ListItem>
                                      <asp:ListItem Text="2014" Value="4"></asp:ListItem>
                                      <asp:ListItem Text="2015" Value="5"></asp:ListItem>
                                      <asp:ListItem Text="2016" Value="6"></asp:ListItem>
                                      <asp:ListItem Text="2017" Value="7"></asp:ListItem>
                                      <asp:ListItem Text="2018" Value="8"></asp:ListItem>
                                      <asp:ListItem Text="2019" Value="9"></asp:ListItem>
                                      <asp:ListItem Text="2020" Value="10"></asp:ListItem>
                                      <asp:ListItem Text="2021" Value="11"></asp:ListItem>
                                      <asp:ListItem Text="2022" Value="12"></asp:ListItem>
                                      <asp:ListItem Text="2023" Value="13"></asp:ListItem>
                                      <asp:ListItem Text="2024" Value="14"></asp:ListItem>
                                      <asp:ListItem Text="2025" Value="15"></asp:ListItem>
                                     </asp:DropDownList>
                                   <asp:CompareValidator ID="CVddlYear" runat="server" ControlToValidate="ddlYear" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                            </td>
                               <td align="center" width="15%">
                               Consultant: 
                            </td>
                             <td align="left" width="11%" valign="middle">
                                 <asp:DropDownList ID="ddlConsltants"  AppendDataBoundItems="True" CssClass="DropDown" runat="server" >
                                    
                                 </asp:DropDownList>
                                  <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlConsltants" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                            </td>
                             <td align="center" width="5%">
                              
                            </td>
                              <td align="center" width="15%">
                               <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search" OnClick="btnSearch_Click" />
                            </td>
                             
                           
                         
                        </tr>
                        <tr>
                             <td align="right" width="15%">
                                Offers # :
                            </td>
                             <td align="left" width="15%">
                                 <asp:TextBox ID="txtOffersNo" runat="server" CssClass="TxtBox" Width="150px"></asp:TextBox>
                                      <asp:FilteredTextBoxExtender ID="FTtxtOffersNo" runat="server" TargetControlID="txtOffersNo" 
                           FilterType="Numbers" ></asp:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RFtxtOffersNo" runat="server" ControlToValidate="txtOffersNo"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>
                             <td align="right" width="15%">
                                Offers Value :
                            </td>
                            <td align="left" width="15%">
                                <asp:TextBox ID="txtOffersValue" runat="server" CssClass="TxtBox" Width="100px"></asp:TextBox>
                                     <asp:FilteredTextBoxExtender ID="FTtxtOffersValue" runat="server" TargetControlID="txtOffersValue" 
                          FilterType="Numbers" ></asp:FilteredTextBoxExtender>
                                   <asp:RequiredFieldValidator ID="RFtxtOffersValue" runat="server" ControlToValidate="txtOffersValue"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                            </td>

                            <td align="right" width="15%">
                               Joining # :

                            </td>
                             <td align="left" width="15%">
                                <asp:TextBox ID="txtJoiningNo" runat="server" CssClass="TxtBox" Width="100px"></asp:TextBox>
                                      <asp:FilteredTextBoxExtender ID="FTtxtJoiningNo" runat="server" TargetControlID="txtJoiningNo" 
                          FilterType="Numbers" ></asp:FilteredTextBoxExtender>
                                    <asp:RequiredFieldValidator ID="RFtxtJoiningNo" runat="server" ControlToValidate="txtJoiningNo"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>

                            </td>
                            
                            <td align="right" width="15%">
                               Billing :

                            </td>
                             <td align="left" width="12%" valign="bottom">
                              <asp:TextBox ID="txtBilling" runat="server" CssClass="TxtBox" Width="80px"></asp:TextBox>
                                      <asp:FilteredTextBoxExtender ID="FTtxtBilling" runat="server" TargetControlID="txtBilling" 
                          FilterType="Numbers" ></asp:FilteredTextBoxExtender>
                                  <asp:RequiredFieldValidator ID="RFtxtBilling" runat="server" ControlToValidate="txtBilling"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>

                            </td>
                             <td align="center" width="5%">
                              
                            </td>
                           <td align="center">
                               
                                 <asp:Button ID="btnSave" runat="server" CssClass="btnSave" Text="Save" ValidationGroup="save"
                                                OnClick="btnSave_Click" />
                                               
                            </td>
                        </tr>
                         <tr>
                        <td colspan="10" align="center">
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                        <tr>
                            <td colspan="10">
                               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:GridView ID="gdvBusiness" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                    OnPageIndexChanging="gdvBusiness_PageIndexChanging" GridLines="Both" CssClass="mRprtGrid"
                                    EmptyDataText="No Data to Dispaly." PageSize="50" Width="100%" OnRowDataBound="gdvBusiness_RowDataBound"  HeaderStyle-ForeColor="White" onsorting="gdvBusiness_Sorting" AllowSorting="true" 
                                     CurrentSortDirection="Desc" CurrentSortField="Client_Name" OnRowCancelingEdit="gdvBusiness_RowCancelingEdit"
                                     OnRowEditing="gdvBusiness_RowEditing" OnRowUpdating="gdvBusiness_RowUpdating">
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
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("BusinessPlanId")%>'></asp:Label>
                                            </ItemTemplate>
                                              <EditItemTemplate>
                                            <asp:Label ID="lblEId" runat="server" Text='<%#Eval("BusinessPlanId")%>'></asp:Label>
                                               </EditItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Client Name" SortExpression="Client_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                             <EditItemTemplate>
                                                  <asp:Label ID="lblEClientId" runat="server" Text='<%#Eval("Client_Id")%>' Visible="false"></asp:Label>
                                              <asp:DropDownList ID="ddlEClientName" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                              Height="25px" Width="150px"> </asp:DropDownList>
                                <asp:CompareValidator ID="CVddlEClientName" runat="server" ControlToValidate="ddlEClientName" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="Update" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                                          </EditItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                            <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Month" SortExpression="BMonth">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMonth" runat="server" Text='<%#Eval("BMonth")%>'></asp:Label>
                                            </ItemTemplate>
                                             <EditItemTemplate>
                                                  <asp:Label ID="lblEMonth" runat="server" Text='<%#Eval("BMonth")%>' Visible="false"></asp:Label>
                                              <asp:DropDownList ID="ddlEMonth" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                              Height="25px" Width="80px">
                                              <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                      <asp:ListItem Text="Jan" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="Feb" Value="2"></asp:ListItem>
                                      <asp:ListItem Text="Mar" Value="3"></asp:ListItem>
                                      <asp:ListItem Text="Apr" Value="4"></asp:ListItem>
                                      <asp:ListItem Text="May" Value="5"></asp:ListItem>
                                      <asp:ListItem Text="Jun" Value="6"></asp:ListItem>
                                      <asp:ListItem Text="Jul" Value="7"></asp:ListItem>
                                      <asp:ListItem Text="Aug" Value="8"></asp:ListItem>
                                      <asp:ListItem Text="Sep" Value="9"></asp:ListItem>
                                      <asp:ListItem Text="Oct" Value="10"></asp:ListItem>
                                      <asp:ListItem Text="Nov" Value="11"></asp:ListItem>
                                      <asp:ListItem Text="Dec" Value="12"></asp:ListItem>

                                              </asp:DropDownList>
                                <asp:CompareValidator ID="CVddlEMonth" runat="server" ControlToValidate="ddlEMonth" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="String" ValidationGroup="Update" ValueToCompare="Select"
                                Font-Size="Small"></asp:CompareValidator>
                                          </EditItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:TemplateField>

                                         <asp:TemplateField HeaderText="Year" SortExpression="BYear">
                                            <ItemTemplate>
                                                <asp:Label ID="lblYear" runat="server" Text='<%#Eval("BYear")%>'></asp:Label>
                                            </ItemTemplate>
                                             <EditItemTemplate>
                                                  <asp:Label ID="lblEYear" runat="server" Text='<%#Eval("BYear")%>' Visible="false"></asp:Label>
                                              <asp:DropDownList ID="ddlEYear" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                              Height="25px" Width="80px">
                                                   <asp:ListItem Text="Select" Value="0"></asp:ListItem>
                                      <asp:ListItem Text="2010" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="2011" Value="1"></asp:ListItem>
                                      <asp:ListItem Text="2012" Value="2"></asp:ListItem>
                                      <asp:ListItem Text="2013" Value="3"></asp:ListItem>
                                      <asp:ListItem Text="2014" Value="4"></asp:ListItem>
                                      <asp:ListItem Text="2015" Value="1" Selected="True"></asp:ListItem>
                                      <asp:ListItem Text="2016" Value="2"></asp:ListItem>
                                      <asp:ListItem Text="2017" Value="3"></asp:ListItem>
                                      <asp:ListItem Text="2018" Value="4"></asp:ListItem>
                                      <asp:ListItem Text="2019" Value="5"></asp:ListItem>
                                      <asp:ListItem Text="2020" Value="6"></asp:ListItem>
                                      <asp:ListItem Text="2021" Value="7"></asp:ListItem>
                                      <asp:ListItem Text="2022" Value="8"></asp:ListItem>
                                      <asp:ListItem Text="2023" Value="9"></asp:ListItem>
                                      <asp:ListItem Text="2024" Value="10"></asp:ListItem>
                                      <asp:ListItem Text="2025" Value="11"></asp:ListItem>

                                              </asp:DropDownList>
                                <asp:CompareValidator ID="CVddlEYear" runat="server" ControlToValidate="ddlEYear" ErrorMessage="Select"
                                ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="Update" ValueToCompare="0"
                                Font-Size="Small"></asp:CompareValidator>
                                          </EditItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:TemplateField>

                                          <asp:TemplateField HeaderText="Consultant" SortExpression="ConsultantNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsultantNo" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                             <EditItemTemplate>
                                                  <asp:TextBox ID="txtEConsultantNo" runat="server" CssClass="TxtBox"  Width="80px" Text='<%#Eval("ConsultantNo") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFtxtEConsultantNo" runat="server" ControlToValidate="txtEConsultantNo"
                                                      ErrorMessage="*" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                   <asp:FilteredTextBoxExtender ID="FTtxtEConsultantNo" runat="server" TargetControlID="txtEConsultantNo" 
                                                   ValidChars=".0123456789" ></asp:FilteredTextBoxExtender>
                                          </EditItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Offers #" SortExpression="OffersNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOffersNo" runat="server" Text='<%#Eval("OffersNo")%>'></asp:Label>
                                            </ItemTemplate>
                                             <EditItemTemplate>
                                                  <asp:TextBox ID="txtEOffersNo" runat="server" CssClass="TxtBox"  Width="80px" Text='<%#Eval("OffersNo") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFtxtEOffersNo" runat="server" ControlToValidate="txtEOffersNo"
                                                      ErrorMessage="*" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                   <asp:FilteredTextBoxExtender ID="FTtxtEOffersNo" runat="server" TargetControlID="txtEOffersNo" 
                                                 FilterType="Numbers" ></asp:FilteredTextBoxExtender>
                                          </EditItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Offer Value" SortExpression="OfferValue">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfferValue" runat="server" Text='<%#Eval("OfferValue")%>'></asp:Label>
                                            </ItemTemplate>
                                             <EditItemTemplate>
                                                  <asp:TextBox ID="txtEOfferValue" runat="server" CssClass="TxtBox"  Width="80px" Text='<%#Eval("OfferValue") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFEOfferValue" runat="server" ControlToValidate="txtEOfferValue"
                                                      ErrorMessage="*" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                   <asp:FilteredTextBoxExtender ID="FTtxtEOfferValue" runat="server" TargetControlID="txtEOfferValue" 
                                           FilterType="Numbers" ></asp:FilteredTextBoxExtender>
                                          </EditItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Joining#" SortExpression="JoiningNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJoiningNo" runat="server" Text='<%#Eval("JoiningNo")%>'></asp:Label>
                                            </ItemTemplate>
                                             <EditItemTemplate>
                                                  <asp:TextBox ID="txtEJoiningNo" runat="server" CssClass="TxtBox"  Width="80px" Text='<%#Eval("JoiningNo") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFtxtEJoiningNo" runat="server" ControlToValidate="txtEJoiningNo"
                                                      ErrorMessage="*" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                   <asp:FilteredTextBoxExtender ID="FTtxtEJoiningNo" runat="server" TargetControlID="txtEJoiningNo" 
                                                    FilterType="Numbers" ></asp:FilteredTextBoxExtender>
                                          </EditItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Billing" SortExpression="Billing">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBilling" runat="server" Text='<%#Eval("Billing")%>'></asp:Label>
                                            </ItemTemplate>
                                             <EditItemTemplate>
                                                  <asp:TextBox ID="txtEBilling" runat="server" CssClass="TxtBox"  Width="80px" Text='<%#Eval("Billing") %>'></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RFtxtEBilling" runat="server" ControlToValidate="txtEBilling"
                                                      ErrorMessage="*" ForeColor="Red" ValidationGroup="Update"></asp:RequiredFieldValidator>
                                                   <asp:FilteredTextBoxExtender ID="FTtxtEBilling" runat="server" TargetControlID="txtEBilling" 
                                                   FilterType="Numbers" ></asp:FilteredTextBoxExtender>
                                          </EditItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
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

                                    </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="gdvBusiness" EventName="RowCommand" />
                                </Triggers>
                            </asp:UpdatePanel>
                                
                            </td>
                        </tr>
                    </table>
           
        </div>
    </center>
</asp:Content>


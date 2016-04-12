<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PositionsBilled.aspx.cs" Inherits="Report_PositionsBilled" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
              Positions Billed</h2>
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
                              
                            <td align="center" width="20%">
                                From Billing Date</td>
                            <td align="center" width="20%">
                                To Billing Date</td>
                            <td align="center" width="20%">
                                From Payment Due Date</td>
                            <td align="center" width="20%">
                                To Payment Due Date</td>
                             <td align="center" width="20%">
                                 Payment Status
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
                             
                            <td align="center">
                                <asp:TextBox ID="txtfromBillingDate" runat="server" CssClass="TxtBox"  Width="90px"></asp:TextBox>
                                 <asp:CalendarExtender ID="CEtxtfromBillingDate" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtfromBillingDate" TargetControlID="txtfromBillingDate">
                                  </asp:CalendarExtender>
                            </td>
                             <td align="center">
                                <asp:TextBox ID="txtToBillingDate" runat="server" CssClass="TxtBox"  Width="90px"></asp:TextBox>
                                 <asp:CalendarExtender ID="CEToBillingDate" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtToBillingDate" TargetControlID="txtToBillingDate">
                                  </asp:CalendarExtender>
                            </td>
                              <td align="center">
                                <asp:TextBox ID="txtFromPaymentDueDate" runat="server" CssClass="TxtBox"  Width="90px"></asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtender1" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtFromPaymentDueDate" TargetControlID="txtFromPaymentDueDate">
                                  </asp:CalendarExtender>
                            </td>
                             <td align="center">
                                <asp:TextBox ID="txtToPaymentDueDate" runat="server" CssClass="TxtBox"  Width="90px"></asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtender2" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtToPaymentDueDate" TargetControlID="txtToPaymentDueDate">
                                  </asp:CalendarExtender>
                            </td>
                              <td align="center" width="20%">
                                  <asp:DropDownList ID="ddlPaymentStatus" runat="server" CssClass="DropDown" 
                                    AppendDataBoundItems="True">
                                </asp:DropDownList>
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
                        <%--       <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>--%>
                                <asp:GridView ID="gdvCanOfferd" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                    OnPageIndexChanging="gdvCanOfferd_PageIndexChanging" GridLines="Both" CssClass="mRprtGrid"
                                    EmptyDataText="No Data to Dispaly." PageSize="50" Width="100%" OnRowDataBound="gdvCanOfferd_RowDataBound" 
                                     HeaderStyle-ForeColor="White" onsorting="gdvCanOfferd_Sorting" AllowSorting="true" 
                                     CurrentSortDirection="Desc" CurrentSortField="Client" OnRowCancelingEdit="gdvCanOfferd_RowCancelingEdit"
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
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("RRCandidate_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                              <EditItemTemplate>
                                             <asp:Label ID="lblEId" runat="server" Text='<%#Eval("RRCandidate_Id") %>' Visible="false"></asp:Label>
                                             </EditItemTemplate>
                                        </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Client Name" SortExpression="Client">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClient" runat="server" Text='<%#Eval("Client")%>'></asp:Label>
                                            </ItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                              <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Consultant" SortExpression="Consultant">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsultant" runat="server" Text='<%#Eval("Consultant")%>'></asp:Label>
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
                                   <asp:TemplateField HeaderText="Role" SortExpression="Job_Profile">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRole" runat="server" Text='<%#Eval("Job_Profile")%>'></asp:Label>
                                            </ItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                            <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                         <asp:TemplateField HeaderText="Candidate" SortExpression="Candidate_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblCandidate_Name" runat="server" Text='<%#Eval("Candidate_Name")%>'></asp:Label>
                                            </ItemTemplate>
                                               <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                              <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Candidate Status" SortExpression="Overall_Status">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOverall_Status" runat="server" Text='<%#Eval("Overall_Status")%>'></asp:Label>
                                            </ItemTemplate>
                                               <HeaderStyle HorizontalAlign="Center" Width="120px" />
                                              <ItemStyle HorizontalAlign="Center" Width="120px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Actual DOJ" SortExpression="ActualDOJ">
                                            <ItemTemplate>
                                                <asp:Label ID="lblActualDOJ" runat="server" Text='<%#Eval("ActualDOJ")%>'></asp:Label>
                                            </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                              <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                              <asp:TemplateField HeaderText="Billed Date" SortExpression="BillingDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBillingDate" runat="server" Text='<%#Eval("BillingDate")%>'></asp:Label>
                                            </ItemTemplate>
                                                <EditItemTemplate>
                                           <asp:TextBox ID="txtEBillingDate" runat="server" CssClass="TxtBox" Text='<%#Eval("BillingDate")%>'  Width="90px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CEtxtEBillingDate" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtEBillingDate" TargetControlID="txtEBillingDate">
                                            </asp:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="REtxtEBillingDate" runat="server" ControlToValidate="txtEBillingDate"
                                                Display="Dynamic" ErrorMessage="Wrong Date" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Update"
                                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$" 
                                                ></asp:RegularExpressionValidator>
                                                       </EditItemTemplate>
                                               <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                              <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Billed Amount" SortExpression="BillingAmount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBillingAmount" runat="server" Text='<%#Eval("BillingAmount")%>'></asp:Label>
                                            </ItemTemplate>
                                               <EditItemTemplate>
                                           <asp:TextBox ID="txtEBillingAmount" runat="server" CssClass="TxtBox" Text='<%#Eval("BillingAmount")%>' Width="60px"></asp:TextBox>
                                              <asp:FilteredTextBoxExtender ID="FTBtxtEBillingAmount" runat="server" TargetControlID="txtEBillingAmount"
                                                    ValidChars=".0123456789"> </asp:FilteredTextBoxExtender>
                                              </EditItemTemplate>
                                               <HeaderStyle HorizontalAlign="Center" Width="65px" />
                                             <ItemStyle HorizontalAlign="Center" Width="65px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="S Tax" SortExpression="ServiceTax">
                                            <ItemTemplate>
                                                <asp:Label ID="lblServiceTax" runat="server" Text='<%#Eval("ServiceTax")%>'></asp:Label>
                                            </ItemTemplate>
                                               <EditItemTemplate>
                                           <asp:TextBox ID="txtEServiceTax" runat="server" CssClass="TxtBox" Text='<%#Eval("ServiceTax")%>' Width="45px"></asp:TextBox>
                                              <asp:FilteredTextBoxExtender ID="FTBtxtEServiceTax" runat="server" TargetControlID="txtEServiceTax"
                                                    ValidChars=".0123456789"> </asp:FilteredTextBoxExtender>
                                              </EditItemTemplate>
                                               <HeaderStyle HorizontalAlign="Center" Width="50px" />
                                             <ItemStyle HorizontalAlign="Center" Width="50px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Billing Status" SortExpression="BillStatus">
                                            <ItemTemplate>
                                         
                                                  <asp:Label ID="lblBillStatus" runat="server" Text='<%#Eval("BillStatus")%>'></asp:Label>
                                            </ItemTemplate>
                                               <EditItemTemplate>
                                               <asp:Label ID="lblEBillStatusId" runat="server" Text='<%#Eval("BillStatusId") %>' Visible="false"></asp:Label>
                                                    <asp:DropDownList ID="ddlEBillStatus" runat="server" AppendDataBoundItems="True" CssClass="DropDown" Width="79px" > 
                                                    </asp:DropDownList>
                                                     </EditItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Payment Status" SortExpression="PaymentStatus">
                                            <ItemTemplate>
                                           
                                                  <asp:Label ID="lblPaymentStatus" runat="server" Text='<%#Eval("PaymentStatus")%>'></asp:Label>
                                            </ItemTemplate>
                                               <EditItemTemplate>
                                               <asp:Label ID="lblEPaymentStatusId" runat="server" Text='<%#Eval("PaymentStatusId") %>' Visible="false"></asp:Label>
                                                    <asp:DropDownList ID="ddlEPaymentStatus" runat="server" AppendDataBoundItems="True" CssClass="DropDown" Width="79px" > 
                                                    </asp:DropDownList>
                                                     </EditItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                            <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Payment Due Date" SortExpression="PaymentDueDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPaymentDueDate" runat="server" Text='<%#Eval("PaymentDueDate")%>'></asp:Label>
                                            </ItemTemplate>
                                                <EditItemTemplate>
                                           <asp:TextBox ID="txtEPaymentDueDate" runat="server" CssClass="TxtBox" Text='<%#Eval("PaymentDueDate")%>'  Width="90px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CEtxtEPaymentDueDate" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtEPaymentDueDate" TargetControlID="txtEPaymentDueDate">
                                            </asp:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="REtxtEPaymentDueDate" runat="server" ControlToValidate="txtEPaymentDueDate"
                                                Display="Dynamic" ErrorMessage="Wrong Date" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Update"
                                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$" 
                                                ></asp:RegularExpressionValidator>
                                                       </EditItemTemplate>
                                               <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                              <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Recevied Date" SortExpression="ReceviedDate">
                                            <ItemTemplate>
                                                <asp:Label ID="lblReceviedDate" runat="server" Text='<%#Eval("ReceviedDate")%>'></asp:Label>
                                            </ItemTemplate>
                                                <EditItemTemplate>
                                           <asp:TextBox ID="txtEReceviedDate" runat="server" CssClass="TxtBox" Text='<%#Eval("ReceviedDate")%>'  Width="90px"></asp:TextBox>
                                                <asp:CalendarExtender ID="CEtxtEReceviedDate" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtEReceviedDate" TargetControlID="txtEReceviedDate">
                                            </asp:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="REtxtEReceviedDate" runat="server" ControlToValidate="txtEReceviedDate"
                                                Display="Dynamic" ErrorMessage="Wrong Date" ForeColor="Red" SetFocusOnError="true" ValidationGroup="Update"
                                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$" 
                                                ></asp:RegularExpressionValidator>
                                                       </EditItemTemplate>
                                               <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                              <ItemStyle HorizontalAlign="Center" Width="100px" />
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Amount Received" SortExpression="Amount Received">
                                            <ItemTemplate>
                                                <asp:Label ID="lblAmountReceived" runat="server" Text='<%#Eval("ReceviedAmount")%>'></asp:Label>
                                            </ItemTemplate>
                                               <EditItemTemplate>
                                           <asp:TextBox ID="txtEAmountReceived" runat="server" CssClass="TxtBox" Text='<%#Eval("ReceviedAmount")%>' Width="60px"></asp:TextBox>
                                              <asp:FilteredTextBoxExtender ID="FTBtxtEAmountReceived" runat="server" TargetControlID="txtEAmountReceived"
                                                    ValidChars=".0123456789"> </asp:FilteredTextBoxExtender>
                                              </EditItemTemplate>
                                               <HeaderStyle HorizontalAlign="Center" Width="65px" />
                                             <ItemStyle HorizontalAlign="Center" Width="65px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <asp:ImageButton ID="EditButton" CommandName="Edit" runat="server" ToolTip="Edit"
                                                ImageUrl="~/Image/b_edit.png" Width="22px" Height="22px" />
                                        </ItemTemplate>
                                        <EditItemTemplate>
                                            <asp:LinkButton ID="UpdateButton" CommandName="Update" runat="server" Text="Update" ValidationGroup="Update"
                                                CssClass="lbtnUpdate" ></asp:LinkButton>
                                            &nbsp;
                                            <asp:LinkButton ID="CancelUpdateButton" CommandName="Cancel" runat="server" Text="Cancel"
                                                CssClass="lbtnCancel" />
                                        </EditItemTemplate>
                                        <HeaderStyle HorizontalAlign="Center" Width="100px" />
                                        <ItemStyle HorizontalAlign="Left" Width="110px" />
                                    </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>

                                  <%--  </ContentTemplate>
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


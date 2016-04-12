<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FinancialDetails.aspx.cs" Inherits="Report_FinancialDetails" %>

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

          function opneNewWindow(url) {

              window.open(url, "_blank", "toolbar=yes, width=1200, height=500,scrollbars=yes, resizable=no");

          }

    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
               Financial Details</h2>
            <%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">--%>
                <ContentTemplate>
                    <table width="100%">
                
<%--                        <tr>
                            
                           
                            <td align="right" width="10%">
                                &nbsp;</td>
                            <td align="left" width="15%" style="width: 0%">
                                Month</td>
                            <td align="left" width="15%" style="width: 7%">
                                Year</td>
                            <td align="right" width="15%">
                                &nbsp;</td>
                            <td align="left" width="15%" style="width: 0%">
                                Month</td>
                            <td align="left" width="15%" style="width: 7%">
                                Year</td>
                            <td  align="center">
                                RR Type</td>
                          
                            <td  align="center">
                                &nbsp;</td>
                          
                            <td  align="right">
                                &nbsp;</td>
                          
                        </tr>
                              
                        <tr>
                            
                           
                            <td align="right" width="10%">
                                From : </td>
                            <td align="left" width="15%" style="width: 0%">
                                    <asp:DropDownList CssClass="DropDown" ID="ddlFromMonth" runat="server">
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
                                <asp:CompareValidator ID="cv2" runat="server" ControlToValidate="ddlFromMonth" ErrorMessage="*" ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td align="left" width="15%" style="width: 7%">
                                  <asp:DropDownList CssClass="DropDown" ID="ddlFroearmY" runat="server">
                                   <asp:ListItem Text="2014" Value="2014"></asp:ListItem>
                                   <asp:ListItem Text="2015" Value="2015"></asp:ListItem>
                                   <asp:ListItem Text="2016" Value="2016"></asp:ListItem>
                                   <asp:ListItem Text="2017" Value="2017"></asp:ListItem>
                                   <asp:ListItem Text="2018" Value="2018"></asp:ListItem>
                                   <asp:ListItem Text="2019" Value="2019"></asp:ListItem>
                                   <asp:ListItem Text="2020" Value="2020"></asp:ListItem>
                                   
                                        </asp:DropDownList>
                                <asp:CompareValidator ID="cv3" runat="server" ControlToValidate="ddl_city" ErrorMessage="*" ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td align="right" width="15%">
                                To : </td>
                            <td align="left" width="15%" style="width: 0%">
                                <asp:DropDownList ID="ddlToMonth" runat="server" AppendDataBoundItems="True" AutoPostBack="True" CssClass="DropDown" Height="34px" OnSelectedIndexChanged="ddl_state_SelectedIndexChanged" Width="60px">
                                </asp:DropDownList>
                                <asp:CompareValidator ID="cv4" runat="server" ControlToValidate="ddl_state" ErrorMessage="*" ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td align="left" width="15%" style="width: 7%">
                                <asp:DropDownList ID="ddlToYear" runat="server" AppendDataBoundItems="True" CssClass="DropDown">
                                </asp:DropDownList>
                                <asp:CompareValidator ID="cv5" runat="server" ControlToValidate="ddl_city" ErrorMessage="*" ForeColor="Red" Operator="NotEqual" Type="Integer" ValidationGroup="save" ValueToCompare="0"></asp:CompareValidator>
                            </td>
                            <td  align="center">
                                &nbsp;</td>
                          
                            <td  align="center">
                                <asp:Button ID="btnSearch" runat="server" CssClass="btnCancel" Text="Search" OnClick="btnSearch_Click" />
                            </td>
                          
                            <td  align="right">
                                <asp:ImageButton ID="lbtnDownload" runat="server" Height="30px" ImageUrl="~/Image/ExcelDownload.jpg" OnClick="lbtnDownload_Click" ToolTip="Download in Excel" Width="40px" />
                            </td>
                          
                        </tr>
                              
                                <tr>
                            
                           
                            <td align="center" colspan="9">
                                &nbsp;</td>
                          
                           
                        </tr>--%>
                     
                        <tr>
                            <td colspan="9">
                               <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                <ContentTemplate>
                                <asp:GridView ID="gdvInterview" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                    OnPageIndexChanging="gdvInterview_PageIndexChanging" GridLines="Both" CssClass="mRprtGrid"
                                    EmptyDataText="No Data to Dispaly." PageSize="50" Width="100%" OnRowDataBound="gdvInterview_RowDataBound"  HeaderStyle-ForeColor="White" onsorting="gdvInterview_Sorting" AllowSorting="true"  CurrentSortDirection="Desc" CurrentSortField="NoOfOffers">
                                    <Columns>
                                     <%--   <asp:TemplateField HeaderText="ID" Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblId" runat="server" Text='<%#Eval("Consultant_Id")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>--%>
                                      
                                           <asp:TemplateField HeaderText="Month/Year"  SortExpression="MonthYear">
                                            <ItemTemplate>
                                                <asp:Label ID="lblMonthYear" runat="server" Text='<%#Eval("MonthYear")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Offered #" SortExpression="OfferedNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfferedNo" runat="server" Text='<%#Eval("OfferedNo")%>'></asp:Label>
                                            </ItemTemplate>
                                                <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:TemplateField>
                                           <asp:TemplateField HeaderText="Offered Value" SortExpression="OfferedValue">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfferedValue" runat="server" Text='<%#Eval("OfferedValue")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         
                                        <asp:TemplateField HeaderText="Planned Joining #" SortExpression="PlannedJoiningNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPlannedJoiningNo" runat="server" Text='<%#Eval("PlannedJoiningNo")%>'></asp:Label>
                                            </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Joined #" SortExpression="JoinedNo">
                                            <ItemTemplate>
                                                <asp:Label ID="lblJoinedNo" runat="server" Text='<%#Eval("JoinedNo")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Joined Value" SortExpression="joinedValue">
                                            <ItemTemplate>
                                                <asp:Label ID="lbljoinedValue" runat="server" Text='<%#Eval("joinedValue")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                         
                                     
                                      <asp:TemplateField HeaderText="Planned Billing" SortExpression="PlannedBilling">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPlannedBilling" runat="server" Text='<%#Eval("PlannedBilling")%>'></asp:Label>
                                            </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Center" Width="60px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="60px" />
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Billed Amount" SortExpression="BilledAmount">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBillingAmount" runat="server" Text='<%#Eval("BilledAmount")%>'></asp:Label>
                                            </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Center" Width="80px" />
                                                 <ItemStyle HorizontalAlign="Center" Width="80px" />
                                        </asp:TemplateField>
                                        
                                          <asp:TemplateField HeaderText="Planned Collection" SortExpression="PlannedCollection">
                                            <ItemTemplate>
                                                <asp:Label ID="lblPlannedCollection" runat="server" Text='<%#Eval("PlannedCollection")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Amount Received" SortExpression="PaymentReceived">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRecevingAmount" runat="server" Text='<%#Eval("PaymentReceived")%>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                      
                                        
                                     <%--     <asp:TemplateField HeaderText="Action">
                                                    <ItemTemplate>
                                                       
                                                          <img width="20px" style="cursor:pointer;" height="20px" src="../Image/candidate.gif" title="Client" onclick="opneNewWindow('<%#"FinancialDetailforConsultant.aspx?Id="+Eval("OfferDate") %>')" />
                                                        &nbsp;
                                                       <img width="20px" style="cursor:pointer;" height="20px" src="../Image/Consultant.png" title="Consultant" onclick="opneNewWindow('<%#"FinanicalDetailForClient.aspx?Id="+Eval("OfferDate") %>')" />
                                                         
                                                         </ItemTemplate>
                                                    <ItemStyle Width="80px" HorizontalAlign="Center" />
                                                </asp:TemplateField>--%>
                                       
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

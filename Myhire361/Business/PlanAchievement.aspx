<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="PlanAchievement.aspx.cs" Inherits="Business_PlanAchievement" %>



<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
   <link rel="Stylesheet" href="../Styles/PopupP.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <center>
        <div id="page">
            <h2>
                 Plan Achievement-Monthly</h2>
   
                    <table width="100%">
                           <tr>
                   
                    <td width="25%" align="right" colspan="3">
                    
                    </td>
                </tr>

                <tr align="center">
                 
                    <td align="right">Month :</td><td  align="center">
                         <asp:TextBox ID="txtMonth" runat="server" CssClass="TxtBox" Width="100px"></asp:TextBox>
                            <asp:CalendarExtender ID="CltxtMonth" runat="server" Format="MMM-yyyy"
                                PopupButtonID="txtMonth" TargetControlID="txtMonth" DefaultView="Months">
                            </asp:CalendarExtender>
                            <asp:RegularExpressionValidator ID="Rev4" runat="server" ControlToValidate="txtMonth"
                                Display="Dynamic" ErrorMessage="Eg. May-2015 " ForeColor="Red" SetFocusOnError="true"
                                ValidationExpression="(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                ValidationGroup="save" Font-Size="Small"></asp:RegularExpressionValidator>
                         <asp:RequiredFieldValidator ID="RFVtxtMonth" runat="server" ControlToValidate="txtMonth"
                                ErrorMessage="*" ForeColor="Red" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                                    </td>
                    
                      <td align="left">  
                           
                          <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="btnSearch_OnClick" ValidationGroup="Search" CssClass="btnSave"/>
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
                                    EmptyDataText="No Data to Dispaly." PageSize="15" Width="100%" OnRowCommand="gdvBusiness_RowCommand"  HeaderStyle-ForeColor="White" onsorting="gdvBusiness_Sorting" AllowSorting="true" 
                                     >
                                    <Columns>
                                     <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                               
                                             <asp:TemplateField HeaderText="Offers #<hr>Planned / Actual" SortExpression="NoOfOffereP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOffersNoP" runat="server" Text='<%#Eval("NoOfOffereP")%>'></asp:Label> /
                                                 <asp:Label ID="lblOffersNoA" runat="server" Text='<%#Eval("NoOfOfferedA")%>'></asp:Label>
                                            </ItemTemplate>
                                            
                                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Offer Value<hr>Planned / Actual" SortExpression="OfferValueP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfferValueP" runat="server" Text='<%#Eval("OfferValueP")%>'></asp:Label> /
                                                 <asp:Label ID="lblOfferValueA" runat="server" Text='<%#Eval("OfferValueA")%>'></asp:Label>
                                            </ItemTemplate>
                                           
                                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Joining #<hr>Planned / Actual" SortExpression="NoOfJoinedP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoOfJoinedP" runat="server" Text='<%#Eval("NoOfJoinedP")%>'></asp:Label> /
                                                 <asp:Label ID="lblNoOfJoinedA" runat="server" Text='<%#Eval("NoOfJoinedA")%>'></asp:Label>
                                           
                                                 </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Billing<hr>Planned / Actual" SortExpression="BillingP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBillingP" runat="server" Text='<%#Eval("BillingP")%>'></asp:Label> /
                                                 <asp:Label ID="lblBillingA" runat="server" Text='<%#Eval("BillingA")%>'></asp:Label>
                                            </ItemTemplate>
                                            
                                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                                          <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                          <asp:ImageButton ID="imgClient" CommandName="Client" runat="server" ImageUrl="~/Image/clientp.png" ToolTip="Client Wise Achievement"
                                                    Height="30px" Width="30px" />&nbsp;&nbsp;
                                            <asp:ImageButton ID="imgConsultant" CommandName="Consultant" runat="server" ImageUrl="~/Image/Consultant.png" ToolTip="Consultant Wise Achievement"
                                                    Height="30px" Width="30px" />
                                            
                                        </ItemTemplate>
                                       
                                        <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                        <ItemStyle HorizontalAlign="Left" Width="130px" />
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

             <%--region for ClientWisePoup --%>
               <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
              <asp:Button ID="btnPopupC" runat="server" Style="display: none" />
                  <asp:ModalPopupExtender ID="MPEbtnPopupC" runat="server" TargetControlID="btnPopupC"
                        PopupControlID="PnlPopupC" CancelControlID="imgClose" BackgroundCssClass="mdlbgrgnd">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="PnlPopupC" runat="server" Width="80%" Height="650px" ScrollBars="Auto">
                        <center>
                            <div class="popup">
                                <h6>
                                   <asp:ImageButton ID="imgClose" runat="server" Height="40px" ToolTip="Close Popup"
                                        ValidationGroup="MClose" Width="40px" ImageUrl="~/Image/close-icon.png" /></h6>
                                       
                                <table >
                                    <tr>
                                        <td colspan="4" align="center">  <b style="font-size:26px">Plan Achievement by Client - Monthly</b>     
              
                                      
                                        </td>
                                    </tr>
                                  <tr><td align="center" colspan="4">
                                      
                                      <asp:GridView ID="gdvBusiness2" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                    OnPageIndexChanging="gdvBusiness2_PageIndexChanging" GridLines="Both" CssClass="mRprtGrid"
                                    EmptyDataText="No Data to Dispaly." PageSize="15" Width="100%"  HeaderStyle-ForeColor="White" onsorting="gdvBusiness2_Sorting" AllowSorting="true" 
                                     >
                                    <Columns>
                                     <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Client" SortExpression="Client_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClient_Name" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label> 
                                                
                                            </ItemTemplate>
                                            
                                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                               
                                             <asp:TemplateField HeaderText="Offers #<hr>Planned / Actual" SortExpression="NoOfOffereP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOffersNoP2" runat="server" Text='<%#Eval("NoOfOffereP")%>'></asp:Label> /
                                                 <asp:Label ID="lblOffersNoA2" runat="server" Text='<%#Eval("NoOfOfferedA")%>'></asp:Label>
                                            </ItemTemplate>
                                            
                                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Offer Value<hr>Planned / Actual" SortExpression="OfferValueP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfferValueP2" runat="server" Text='<%#Eval("OfferValueP")%>'></asp:Label> /
                                                 <asp:Label ID="lblOfferValueA2" runat="server" Text='<%#Eval("OfferValueA")%>'></asp:Label>
                                            </ItemTemplate>
                                           
                                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Joining #<hr>Planned / Actual" SortExpression="NoOfJoinedP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoOfJoinedP2" runat="server" Text='<%#Eval("NoOfJoinedP")%>'></asp:Label> /
                                                 <asp:Label ID="lblNoOfJoinedA2" runat="server" Text='<%#Eval("NoOfJoinedA")%>'></asp:Label>
                                           
                                                 </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Billing<hr>Planned / Actual" SortExpression="BillingP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBillingP2" runat="server" Text='<%#Eval("BillingP")%>'></asp:Label> /
                                                 <asp:Label ID="lblBillingA2" runat="server" Text='<%#Eval("BillingA")%>'></asp:Label>
                                            </ItemTemplate>
                                            
                                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>          

                                   
                                

                                        </td></tr>
                               </table>

                         
                                     
                            </div>
                        </center>
                    </asp:Panel>
                             </ContentTemplate></asp:UpdatePanel>
            <%--End--%> 


                <%--region for ConsultantWisePoup --%>
               <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                <ContentTemplate>
              <asp:Button ID="btnPoupCons" runat="server" Style="display: none" />
                  <asp:ModalPopupExtender ID="MpePopupCns" runat="server" TargetControlID="btnPoupCons"
                        PopupControlID="PnlMpePopupCns" CancelControlID="imgClose3" BackgroundCssClass="mdlbgrgnd">
                    </asp:ModalPopupExtender>
                    <asp:Panel ID="PnlMpePopupCns" runat="server" Width="80%" Height="650px" ScrollBars="Auto">
                        <center>
                            <div class="popup">
                                <h6>
                                   <asp:ImageButton ID="imgClose3" runat="server" Height="40px" ToolTip="Close Popup"
                                        ValidationGroup="MClose" Width="40px" ImageUrl="~/Image/close-icon.png" /></h6>
                                       
                                <table >
                                    <tr>
                                        <td colspan="4" align="center">  <b style="font-size:26px">Plan Achievement by Consultant-Monthly</b>     
              
                                      
                                        </td>
                                    </tr>
                                  <tr><td align="center" colspan="4">
                                      
                                      <asp:GridView ID="gdvBusiness3" runat="server" AutoGenerateColumns="False" AllowPaging="True"
                                    OnPageIndexChanging="gdvBusiness3_PageIndexChanging" GridLines="Both" CssClass="mRprtGrid"
                                    EmptyDataText="No Data to Dispaly." PageSize="15" Width="100%"  HeaderStyle-ForeColor="White" onsorting="gdvBusiness3_Sorting" AllowSorting="true" 
                                     >
                                    <Columns>
                                     <asp:TemplateField HeaderText="S.No.">
                                <ItemTemplate>
                                    <%#Container.DataItemIndex+1%>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" Width="20px" />
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Client" SortExpression="Client_Name">
                                            <ItemTemplate>
                                                <asp:Label ID="lblClient_Name" runat="server" Text='<%#Eval("Client_Name")%>'></asp:Label> 
                                              </ItemTemplate>
                                             <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                                        <%--  <asp:TemplateField HeaderText="RRNumber" SortExpression="RRNumber">
                                            <ItemTemplate>
                                                <asp:Label ID="lblRRNumber" runat="server" Text='<%#Eval("RRNumber")%>'></asp:Label> 
                                                 </ItemTemplate>
                                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>--%>
                                          <asp:TemplateField HeaderText="Consultant" SortExpression="ConsultantName">
                                            <ItemTemplate>
                                                <asp:Label ID="lblConsultantName" runat="server" Text='<%#Eval("ConsultantName")%>'></asp:Label> 
                                                
                                            </ItemTemplate>
                                            
                                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                               
                                             <asp:TemplateField HeaderText="Offers #<hr>Planned / Actual" SortExpression="NoOfOffereP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOffersNoP2" runat="server" Text='<%#Eval("NoOfOffereP")%>'></asp:Label> /
                                                 <asp:Label ID="lblOffersNoA2" runat="server" Text='<%#Eval("NoOfOfferedA")%>'></asp:Label>
                                            </ItemTemplate>
                                            
                                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Offer Value<hr>Planned / Actual" SortExpression="OfferValueP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblOfferValueP2" runat="server" Text='<%#Eval("OfferValueP")%>'></asp:Label> /
                                                 <asp:Label ID="lblOfferValueA2" runat="server" Text='<%#Eval("OfferValueA")%>'></asp:Label>
                                            </ItemTemplate>
                                           
                                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Joining #<hr>Planned / Actual" SortExpression="NoOfJoinedP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblNoOfJoinedP2" runat="server" Text='<%#Eval("NoOfJoinedP")%>'></asp:Label> /
                                                 <asp:Label ID="lblNoOfJoinedA2" runat="server" Text='<%#Eval("NoOfJoinedA")%>'></asp:Label>
                                           
                                                 </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                                             <asp:TemplateField HeaderText="Billing<hr>Planned / Actual" SortExpression="BillingP">
                                            <ItemTemplate>
                                                <asp:Label ID="lblBillingP2" runat="server" Text='<%#Eval("BillingP")%>'></asp:Label> /
                                                 <asp:Label ID="lblBillingA2" runat="server" Text='<%#Eval("BillingA")%>'></asp:Label>
                                            </ItemTemplate>
                                            
                                              <HeaderStyle HorizontalAlign="Center" Width="130px" />
                                            <ItemStyle HorizontalAlign="Center" Width="130px" />
                                        </asp:TemplateField>
                                        
                                    </Columns>
                                </asp:GridView>          

                                   
                                

                                        </td></tr>
                               </table>

                         
                                     
                            </div>
                        </center>
                    </asp:Panel>
                             </ContentTemplate></asp:UpdatePanel>
            <%--End--%> 
           
        </div>
    </center>
</asp:Content>


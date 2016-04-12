<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true"
    CodeFile="FollowUp.aspx.cs" Inherits="Recruitment_FollowUp" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .style3
        {
            width: 5%;
            font-weight: bold;
        }
        .style4
        {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>
        <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                        <ContentTemplate>
    <div id="page">
        <h2>
            Follow Up</h2>
        
        <table width="100%">
         <tr>
                <td align="right" colspan="2">
                    <asp:LinkButton ID="lbBack" runat="server" CssClass="lblHistory" OnClick="lbBack_Click">Back</asp:LinkButton>
                </td>
            </tr>
            <tr>

                <td valign="top" width="38%">
                    <fieldset>
                        <legend><b>Job Description</b> </legend>
                        <table width="100%">
                            <tr>
                                <td class="style3">
                                    Client Name
                                </td>
                                <td style="width: 25%" colspan="3">
                                    :
                                    <asp:Label ID="lblClient" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    Designation&nbsp;
                                </td>
                                <td style="width: 25%" colspan="3">
                                    :
                                    <asp:Label ID="lblRrNo" runat="server" Visible="false"></asp:Label>
                                    <asp:Label ID="lblDesig" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    Min Salary
                                </td>
                                <td>
                                    :
                                    <asp:Label ID="lblMinSalary" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Max Salary </b>
                                </td>
                                <td>
                                    :
                                    <asp:Label ID="lblMaxSalary" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    Location
                                </td>
                                <td colspan="3">
                                    :
                                    <asp:Label ID="lblLocation" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style3">
                                    Recieve Date
                                </td>
                                <td>
                                    :
                                    <asp:Label ID="lblRecieveDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Target Date </b>
                                </td>
                                <td>
                                    :
                                    <asp:Label ID="lblTargetDate" runat="server"></asp:Label>
                                </td>
                            </tr>
                        
                            <tr id="Vjob" runat="server">
                                <td colspan="1" class="style3">
                                    Description&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td colspan="3">
                                    :
                                    <asp:LinkButton ID="lbView" runat="server" OnClick="lbView_Click">View Job Description</asp:LinkButton>
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
                <td valign="top" width="60%">
                    <fieldset>
                        <legend><b>Candidate Profile</b></legend>
                        <table width="100%">
                            <tr>
                                <td style="width: 18%" class="style4">
                                    Name
                                </td>
                                <td style="width: 29%">
                                    :
                                    <asp:Label ID="lblName" runat="server"></asp:Label>
                                </td>
                                <td style="width: 16%">
                                    <strong>CTC</strong>
                                </td>
                                <td style="width: 28%">
                                    :
                                    <asp:Label ID="lblCTC" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Resume Title
                                </td>
                                <td colspan="3">
                                    :
                                    <asp:Label ID="lblResumeTittle" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Company
                                </td>
                                <td colspan="3">
                                    :
                                    <asp:Label ID="lblCompny" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Qualification
                                </td>
                                <td colspan="3">
                                    :
                                    <asp:Label ID="lblQualification" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Designation
                                </td>
                                <td>
                                    :
                                    <asp:Label ID="lblCDesignation" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <strong>Experience </strong>
                                </td>
                                <td>
                                    :
                                    <asp:Label ID="lblExperience" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Contact No.
                                </td>
                                <td>
                                    :
                                    <asp:Label ID="lblContact" runat="server"></asp:Label>
                                </td>
                                <td>
                                    <strong>Location</strong>
                                </td>
                                <td>
                                    :
                                    <asp:Label ID="lblCLocation" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <b>Email Id</b>
                                </td>
                                <td colspan="3">
                                    :
                                    <asp:Label ID="lblEmailId" runat="server"></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style4">
                                    Last Act. Date :
                                </td>
                                <td colspan="2">
                                    :
                                    <asp:Label ID="lblLastActiveDate" runat="server"></asp:Label>
                                </td>
                                <td>
                                    &nbsp;<asp:Label ID="lblPortalResume" runat="server" Visible="false"></asp:Label>
                                </td>
                            </tr>
                            <tr id="trView" runat="server">
                                <td colspan="1" class="style4">
                                    Resume&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                </td>
                                <td colspan="3">
                                    :
                                    <asp:LinkButton ID="lbtnResume" runat="server" OnClick="lbtnResume_Click">View Resume</asp:LinkButton>
                                </td>
                            </tr>
                            <tr id="trUpload" runat="server">
                                <td colspan="1" class="style4">
                                    Upload Resume
                                </td>
                                <td colspan="2">
                                    :
                                    <asp:FileUpload ID="fileUpload" runat="server" />
                                </td>
                                <td>
                                    <asp:Button ID="btnUpload" runat="server" OnClick="btnUpload_Click" Text="Upload" />
                                </td>
                            </tr>
                        </table>
                    </fieldset>
                </td>
            </t
            <tr>
                <td colspan="2">
                
                            <fieldset>
                                <legend><b>Create FollowUp</b></legend>
                                <table width="100%">
                                    <tr>
                                        <td style="width: 20%">
                                            Recruiter Status
                                        </td>
                                        <td style="width: 30%">
                                            <asp:DropDownList ID="ddlRecStatus" runat="server" CssClass="DropDown" AppendDataBoundItems="True"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlRecStatus_SelectedIndexChanged">
                                            </asp:DropDownList>
                                            <asp:CompareValidator ID="cv1" runat="server" ControlToValidate="ddlRecStatus" ErrorMessage="*"
                                                ForeColor="Red" Operator="NotEqual" SetFocusOnError="True" ValidationGroup="Save"
                                                Type="Integer" ValueToCompare="1"></asp:CompareValidator>
                                        </td>
                                        <td style="width: 15%">
                                            Next FollowUp Type
                                        </td>
                                        <td style="width: 35%">
                                            <asp:DropDownList ID="ddlFolowType" runat="server" CssClass="DropDown">
                                                <asp:ListItem Selected="True">Call</asp:ListItem>
                                                <asp:ListItem>Meeting</asp:ListItem>
                                                <asp:ListItem>Email</asp:ListItem>
                                                <asp:ListItem>Interview</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Supervisor Status
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlSupStatus" runat="server" CssClass="DropDown" AppendDataBoundItems="True"
                                                AutoPostBack="True" OnSelectedIndexChanged="ddlSupStatus_SelectedIndexChanged"
                                                Enabled="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            Next FollowUp Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtFollowDate" runat="server" CssClass="TxtBox"></asp:TextBox>
                                            <asp:CalendarExtender ID="txtFollowDate_CalendarExtender" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtFollowDate" TargetControlID="txtFollowDate">
                                            </asp:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="Rev4" runat="server" ControlToValidate="txtFollowDate"
                                                Display="Dynamic" ErrorMessage="Wrong Date" ForeColor="Red" SetFocusOnError="true"
                                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                                ValidationGroup="Save"></asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Candidate Status
                                        </td>
                                        <td valign="top">
                                            <asp:DropDownList ID="ddlCandStatus" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                                                Enabled="False">
                                            </asp:DropDownList>
                                        </td>
                                        <td>
                                            Next FollowUp Time
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlHH" runat="server" CssClass="DropDown" Width="50px">
                                                <asp:ListItem>00</asp:ListItem>
                                                <asp:ListItem>01</asp:ListItem>
                                                <asp:ListItem>02</asp:ListItem>
                                                <asp:ListItem>03</asp:ListItem>
                                                <asp:ListItem>04</asp:ListItem>
                                                <asp:ListItem>05</asp:ListItem>
                                                <asp:ListItem>05</asp:ListItem>
                                                <asp:ListItem>06</asp:ListItem>
                                                <asp:ListItem>07</asp:ListItem>
                                                <asp:ListItem>08</asp:ListItem>
                                                <asp:ListItem>09</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem Selected="True">11</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlMM" runat="server" CssClass="DropDown" Width="50px">
                                                <asp:ListItem Selected="True">00</asp:ListItem>
                                                <asp:ListItem>05</asp:ListItem>
                                                <asp:ListItem>10</asp:ListItem>
                                                <asp:ListItem>15</asp:ListItem>
                                                <asp:ListItem>20</asp:ListItem>
                                                <asp:ListItem>25</asp:ListItem>
                                                <asp:ListItem>30</asp:ListItem>
                                                <asp:ListItem>35</asp:ListItem>
                                                <asp:ListItem>40</asp:ListItem>
                                                <asp:ListItem>45</asp:ListItem>
                                                <asp:ListItem>50</asp:ListItem>
                                                <asp:ListItem>55</asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:DropDownList ID="ddlAMPM" runat="server" CssClass="DropDown" Width="60px">
                                                <asp:ListItem Selected="True">AM</asp:ListItem>
                                                <asp:ListItem>PM</asp:ListItem>
                                            </asp:DropDownList>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Next FollowUp By
                                        </td>
                                        <td>
                                            <asp:DropDownList ID="ddlFollowBy" runat="server" AppendDataBoundItems="True" 
                                                CssClass="DropDown" Enabled="False">
                                            </asp:DropDownList>

                                        </td>
                                        <td>
                                          
                                        </td>
                                        <td>
                                            

                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                           Offered Date
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOfferedDate" runat="server" CssClass="TxtBox" ></asp:TextBox>
                                                <asp:CalendarExtender ID="CEtxtOfferedDate" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtOfferedDate" TargetControlID="txtOfferedDate">
                                            </asp:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="REtxtOfferedDate" runat="server" ControlToValidate="txtOfferedDate"
                                                Display="Dynamic" ErrorMessage="Wrong Date" ForeColor="Red" SetFocusOnError="true"
                                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                                ></asp:RegularExpressionValidator>
                                        </td>
                                        <td>
                                           Offered Price
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtOfferdPrice" runat="server" CssClass="TxtBox"
                                                ></asp:TextBox>
                                              <asp:FilteredTextBoxExtender ID="FTBtxtOfferdPrice" runat="server" TargetControlID="txtOfferdPrice"
                         ValidChars=".0123456789">
                    </asp:FilteredTextBoxExtender>

                                           
                                        </td>
                                    </tr>


             <tr>
                                        <td>Planned DoJ 
                                           
                                        </td>
                                        <td>
                                            <asp:TextBox ID="txtPlannedDOJ" runat="server" CssClass="TxtBox"></asp:TextBox>
                                            <asp:CalendarExtender ID="CEtxtPlannedDOJ" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtPlannedDOJ" TargetControlID="txtPlannedDOJ">
                                            </asp:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="REVtxtPlannedDOJ" runat="server" ControlToValidate="txtPlannedDOJ"
                                                Display="Dynamic" ErrorMessage="Wrong Date" ForeColor="Red" SetFocusOnError="true"
                                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                                ></asp:RegularExpressionValidator>
                                        </td>
                                        <td> Actual DoJ
                                             
                                        </td>
                                        <td> <asp:TextBox ID="txtActualDoj" runat="server" CssClass="TxtBox"></asp:TextBox>
                                            <asp:CalendarExtender ID="CEtxtActualDoj" runat="server" Format="dd-MMM-yyyy"
                                                PopupButtonID="txtActualDoj" TargetControlID="txtActualDoj">
                                            </asp:CalendarExtender>
                                            <asp:RegularExpressionValidator ID="REtxtActualDoj" runat="server" ControlToValidate="txtActualDoj"
                                                Display="Dynamic" ErrorMessage="Wrong Date" ForeColor="Red" SetFocusOnError="true"
                                                ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                                                ></asp:RegularExpressionValidator>
                                           
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            Remarks
                                        </td>
                                        <td rowspan="2">
                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="TxtBox" Height="40px" TextMode="MultiLine"
                                                Width="300px"></asp:TextBox>
                                        </td>
                                        <td colspan="1">
                                           
                                        </td>
                                        <td>
                                           
                                        </td>
                                        </td>`
                                    </tr>
                                    <tr>
                                        <td valign="top">
                                            &nbsp;
                                        </td>
                                        <td>
                                            &nbsp;
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" align="center">
                                            &nbsp;
                                            <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:LinkButton ID="lbtnHistory" runat="server" CssClass="lblHistory" OnClick="lbtnHistory_Click">FollowUp History</asp:LinkButton>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="4" align="center">
                                            <asp:Button ID="btnSave" runat="server" CssClass="btnSave" Text="Save" ValidationGroup="Save"
                                                OnClick="btnSave_Click" />
                                                 &nbsp;
                                              <asp:Button ID="btnPrevious" runat="server" CssClass="btnSave" Text="Previous" ValidationGroup="Previous"
                                                OnClick="btnPrevious_Click" Enabled="false" />
                                            &nbsp;
                                              <asp:Button ID="btnNext" runat="server" CssClass="btnSave" Text="Next" ValidationGroup="Next"
                                                OnClick="btnNext_Click" />
                                            &nbsp;
                                                <asp:Button ID="btnSaveNext" runat="server" CssClass="btnSave" Text="Save & Next" Width="130px" ValidationGroup="Save & Next"
                                                OnClick="btnSaveNext_Click" />
                                            &nbsp;
                                        </td>
                                    </tr>
                                </table>
                            </fieldset>
            
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server" AssociatedUpdatePanelID="UpdatePanel2">
                        <ProgressTemplate>
                            <div class="modalbackground">
                                Please Wait
                            </div>
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                </td>
            </tr>
        </table>
 
                <asp:Panel ID="pnlHistory" runat="server" Width="90%" CssClass="pnlpopup">
                    <h2>
                        Follow Up History
                    </h2>
                    <asp:GridView ID="gdvFollowup" runat="server" AutoGenerateColumns="False" DataKeyNames="FollowUp_Id"
                        Width="100%" GridLines="Vertical" CssClass="mGrid" EmptyDataText="Sorry! No record found."
                        PageSize="20">
                        <AlternatingRowStyle CssClass="alt" />
                        <FooterStyle CssClass="footer" />
                        <Columns>
                            <asp:TemplateField HeaderText="FollowUp Id" Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%#Eval("FollowUp_Id")%>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FollowUp Type">
                                <ItemTemplate>
                                    <asp:Label ID="lblType" runat="server" Text='<%#Eval("FollowUp_Type")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FollowUp Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblDate" runat="server" Text='<%#Eval("FollowUp_Date")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="FollowUp By">
                                <ItemTemplate>
                                    <asp:Label ID="lblBy" runat="server" Text='<%#Eval("USR_Name")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Recruiter Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblRecStatus" runat="server" Text='<%#Eval("Recruiter_Status")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Supervisor Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblSupStatus" runat="server" Text='<%#Eval("Supervisor_Status")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Candidate Status">
                                <ItemTemplate>
                                    <asp:Label ID="lblCandStatus" runat="server" Text='<%#Eval("Candidate_Status")%>'></asp:Label>
                                </ItemTemplate>
                                <HeaderStyle HorizontalAlign="Center" />
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                    <center>
                        <br />
                        <asp:Button ID="btnBack" runat="server" CssClass="btnCancel" Text="Ok" /></center>
                </asp:Panel>
                <asp:ModalPopupExtender ID="mpe" runat="server" PopupControlID="pnlHistory" TargetControlID="btn1dump"
                    CancelControlID="btnBack" BackgroundCssClass="modalbackground">
                </asp:ModalPopupExtender>
                <asp:Button ID="btn1dump" runat="server" Style="visibility: hidden" />
                </div>
             
    </div>
     </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>

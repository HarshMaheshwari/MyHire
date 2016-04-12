<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="CandidtateProfile.aspx.cs" Inherits="CandidtateProfile" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
     <style type="text/css">
        body
        {
        }
        .Error
        {
            border: solid 1px Red;
            font-family: verdana;
            width: 200px;
            height: 23px;
        }
         .auto-style1 {
             width: 9%;
         }
    </style>
    <script type="text/javascript">
        function WebForm_OnSubmit() {
            if (typeof (ValidatorOnSubmit) == "function" && ValidatorOnSubmit() == false) {
                for (var i in Page_Validators) {
                    try {
                        var control = document.getElementById(Page_Validators[i].controltovalidate);
                        if (!Page_Validators[i].isvalid) {
                            control.className = "Error";
                        }
                        else {
                            control.className = "TxtBox";
                        }
                    }
                    catch (e) { }
                }
                return false;
            }
            return true;
        }
    </script>
    <script type="text/javascript" language="javascript">
        function onCalendarShown() {
            var cal = $find("calendar1");
            cal._switchMode("years", true);
            if (cal._yearsBody) {
                for (var i = 0; i < cal._yearsBody.rows.length; i++) {
                    var row = cal._yearsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
                    }
                }
            }
        }
        function call(eventElement) {
            var target = eventElement.target;
            switch (target.mode) {
                case "year":
                    var cal = $find("calendar1");
                    cal.set_selectedDate(target.date);
                    cal._blur.post(true);
                    cal.raiseDateSelectionChanged(); break;
            }
        }


        function onCalendarShown1() {
            var cal = $find("calendar2");
            cal._switchMode("years", true);
            if (cal._yearsBody) {
                for (var i = 0; i < cal._yearsBody.rows.length; i++) {
                    var row = cal._yearsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call1);
                    }
                }
            }
        }
        function call1(eventElement) {
            var target = eventElement.target;
            switch (target.mode) {
                case "year":
                    var cal = $find("calendar2");
                    cal.set_selectedDate(target.date);
                    cal._blur.post(true);
                    cal.raiseDateSelectionChanged(); break;
            }
        }


        function onCalendarShown2() {
            var cal = $find("calendar3");
            cal._switchMode("years", true);
            if (cal._yearsBody) {
                for (var i = 0; i < cal._yearsBody.rows.length; i++) {
                    var row = cal._yearsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call2);
                    }
                }
            }
        }
        function call2(eventElement) {
            var target = eventElement.target;
            switch (target.mode) {
                case "year":
                    var cal = $find("calendar3");
                    cal.set_selectedDate(target.date);
                    cal._blur.post(true);
                    cal.raiseDateSelectionChanged(); break;
            }
        }


        function onCalendarShown3() {
            var cal = $find("calendar4");
            cal._switchMode("years", true);
            if (cal._yearsBody) {
                for (var i = 0; i < cal._yearsBody.rows.length; i++) {
                    var row = cal._yearsBody.rows[i];
                    for (var j = 0; j < row.cells.length; j++) {
                        Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call3);
                    }
                }
            }
        }
        function call3(eventElement) {
            var target = eventElement.target;
            switch (target.mode) {
                case "year":
                    var cal = $find("calendar4");
                    cal.set_selectedDate(target.date);
                    cal._blur.post(true);
                    cal.raiseDateSelectionChanged(); break;
            }
        }
       

    </script>
     <script>
         function getfoc() {
             window.open('AddCompany.aspx', 'popUpWindow', 'height=200,width=290,left=900,top=160,resizable=Yes,scrollbars=Yes,toolbar=no,menubar=no,location=no,directories=no, status=No')

         }
</script>

    <script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<link href="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/css/bootstrap.min.css"
    rel="stylesheet" type="text/css" />
<script type="text/javascript" src="http://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/3.0.3/js/bootstrap.min.js"></script>
<link href="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/css/bootstrap-multiselect.css" rel="stylesheet" type="text/css" />
<script src="http://cdn.rawgit.com/davidstutz/bootstrap-multiselect/master/dist/js/bootstrap-multiselect.js" type="text/javascript"></script>
<script type="text/javascript">
    $(function () {
        $('[id*=lstFruits]').multiselect({
            includeSelectAllOption: true
        });
    });
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
      <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
    </asp:ToolkitScriptManager>

     <center>
        <table width="70%" class="tblbg" cellpadding="3" cellspacing="3">
            <thead>
                <tr>
                    <td align="center" style="color: #000000">
                       Employment Details
                    </td>
                </tr>
            </thead>
        </table>
        <table width="80%" class="tblbg">
            <tbody>
                <tr>
                    <td align="right" colspan="4">
                        <asp:LinkButton ID="lbBack" runat="server" CssClass="LinkBtn" >Back</asp:LinkButton>
                    </td>
                </tr>
            </tbody>
        </table>
        <table width="80%" class="tblbg" cellpadding="10">
            <tr>
                <td colspan="4" id="cssmenu" align="left">
                      Employment  Detail
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 10%">
                  First   Name :
                </td>
                <td align="left" style="width: 30%">
                    <asp:TextBox ID="txtFName" runat="server" CssClass="TxtBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv2" runat="server" ControlToValidate="txtFName"
                        ErrorMessage="*" ValidationGroup="save" SetFocusOnError="True" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
                 <td align="right" style="width: 10%">
                    Last  Name :
                </td>
                <td align="left" class="auto-style1">
                    <asp:TextBox ID="txtLName" runat="server" CssClass="TxtBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLName" ForeColor="Red"
                        ErrorMessage="*" ValidationGroup="save" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                 <td align="right" style="width: 10%">
                    Mobile No.:
                </td>
                <td align="left">
                    <asp:TextBox ID="txtMobile" runat="server" Style="height: 22px" CssClass="TxtBox"
                        MaxLength="10"></asp:TextBox>
                    <asp:FilteredTextBoxExtender ID="FilteredTextBoxExtender3" runat="server" TargetControlID="txtMobile"
                        FilterType="Numbers">
                    </asp:FilteredTextBoxExtender>
                </td>
                <td align="right" style="width: 10%">
                   Current Industry:
                </td>
                <td align="left" class="auto-style1">
                    <asp:DropDownList ID="ddlCindustry" runat="server" AppendDataBoundItems="True"
               ForeColor="Red"         ValidationGroup="Save" CssClass="DropDown">
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cv2" runat="server" ErrorMessage="*" ControlToValidate="ddlCindustry"
                        Operator="NotEqual" ValueToCompare="0" ValidationGroup="save" Type="Integer"
                        SetFocusOnError="True"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right" style="width: 10%" >
            Current Company:
                </td>
                <td align="left" style="width: 30%">
                    <asp:DropDownList ID="ddlCcompany" runat="server" AppendDataBoundItems="True" AutoPostBack="True"
                        CssClass="DropDown">
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cv3" runat="server" ControlToValidate="ddlCcompany" ErrorMessage="*" ForeColor="Red"
                        Operator="NotEqual" ValueToCompare="0" Type="Integer" ValidationGroup="save"
                        SetFocusOnError="True"></asp:CompareValidator>
                </td>
                <td align="right" style="width: 10%">
                   previous Company:
                </td>
                <td align="left" class="auto-style1">
                    <asp:DropDownList ID="ddlPCompany" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                        AutoPostBack="True" >
                        <asp:ListItem Text="Select"></asp:ListItem>

                    </asp:DropDownList>
                    
                      <%--   <asp:ImageButton ID="imgbtnAdpCompny" src="Image/add.png"  ToolTip="Add More Company" runat="server" Width="20px" OnClick="imgbtnAdpCompny_Click" />
 
                    <asp:TextBox ID="txtAddPcompany" runat="server" Visible="false"></asp:TextBox>--%>
                    <asp:CompareValidator ID="cv4" runat="server" ControlToValidate="ddlPCompany" ErrorMessage="*" ForeColor="Red"
                        Operator="NotEqual" ValueToCompare="0" SetFocusOnError="True" Type="Integer"
                        ValidationGroup="save"></asp:CompareValidator>
                </td>
               <%-- <td align="right" style="width: 10%">
                    
                </td>--%>

            </tr>
            <tr>

                <td align="right" style="width: 10%">
                    Current designation:
                </td>
                <td align="left">
                    <asp:TextBox ID="txtCrntDegnition" runat="server" CssClass="TxtBox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="txtCrntDegnition"
                        ErrorMessage="*" ValidationGroup="save" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                  <td align="right" style="width: 10%">
                   Total Work experience:
                </td>
                <td align="left" class="auto-style1">
                    <asp:DropDownList ID="ddlTWrkExper" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                        AutoPostBack="True" >
                        <asp:ListItem Text="Select Year">---Select in Year---</asp:ListItem>
                        <asp:ListItem Text="Select Year">Fresher</asp:ListItem>
                        <asp:ListItem Text="Select Year">0 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">1 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">2 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">3 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">4 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">5 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">6 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">7 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">8 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">9 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">10 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">11 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">12 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">13 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">14 Year</asp:ListItem>
                        <asp:ListItem Text="Select Year">15 Year</asp:ListItem>

                    </asp:DropDownList>
                    <asp:DropDownList ID="ddlTWrkExpermonth" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                        AutoPostBack="True" >
                         <asp:ListItem Text="Select Year">---Select in Months---</asp:ListItem>
                        <asp:ListItem Text="Select Year">0 Month</asp:ListItem>
                        <asp:ListItem Text="Select Year">1 Months</asp:ListItem>
                        <asp:ListItem Text="Select Year">2 Months</asp:ListItem>
                        <asp:ListItem Text="Select Year">3 Months</asp:ListItem>
                        <asp:ListItem Text="Select Year">4 Months</asp:ListItem>
                        <asp:ListItem Text="Select Year">5 Months</asp:ListItem>
                        <asp:ListItem Text="Select Year">6 Months</asp:ListItem>
                        <asp:ListItem Text="Select Year">7 Months</asp:ListItem>
                        <asp:ListItem Text="Select Year">8 Months</asp:ListItem>
                        <asp:ListItem Text="Select Year">9 Months</asp:ListItem>
                        <asp:ListItem Text="Select Year">10 Months</asp:ListItem>
                        <asp:ListItem Text="Select Year">11 Months</asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToValidate="ddlTWrkExper" ErrorMessage="*"
                        Operator="NotEqual" ValueToCompare="0" ForeColor="Red" SetFocusOnError="True" Type="Integer"
                        ValidationGroup="save"></asp:CompareValidator>
                    </td>
                  
                   
                
               <%-- <td align="right">
                    Admission Date:
                </td>--%>
               <%-- <td align="left">
                    <asp:TextBox ID="txtAddmsnDate" runat="server" CssClass="TxtBox"></asp:TextBox>
                    <asp:CalendarExtender ID="ce1" runat="server" TargetControlID="txtAddmsnDate" PopupButtonID="txtAddmsnDate"
                        Format="dd-MMM-yyyy">
                    </asp:CalendarExtender>
                    <asp:RegularExpressionValidator ID="rev1" runat="server" ErrorMessage="Wrong" SetFocusOnError="true"
                        ValidationExpression="^\d\d-(Jan|Feb|Mar|Apr|May|Jun|Jul|Aug|Sep|Oct|Nov|Dec)(-\d{4})?$"
                        ControlToValidate="txtAddmsnDate" ValidationGroup="save"></asp:RegularExpressionValidator>
                </td>--%>
                
            </tr>
            <tr>
                  <td align="right" style="width: 10%">
                   Functional Area:
                </td>
                <td align="left" style="width: 30%">
                    <asp:DropDownList ID="ddlFarea" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                        AutoPostBack="True" >
                        <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ControlToValidate="ddlFarea" ForeColor="Red" ErrorMessage="*"
                        Operator="NotEqual" ValueToCompare="0" SetFocusOnError="True" Type="Integer"
                        ValidationGroup="save"></asp:CompareValidator>
                </td>
                 <td align="right" valign="top"  >
                    Sub Functional Area :
                </td>
                <td align="left" class="auto-style1">
                     <asp:ListBox ID="lstFruits" runat="server" SelectionMode="Multiple">


                     <asp:ListItem Text="Asp.net" Value="1" />
                      <asp:ListItem Text="C#" Value="2" />
                      <asp:ListItem Text="SQL SERVER" Value="3" />
                      <asp:ListItem Text="HTML" Value="4" />
                  <asp:ListItem Text="JQUERY" Value="5" />
                </asp:ListBox>
            
                  
                </td>
               <%-- <td align="right">
                    &nbsp;Upload Photo:
                </td>
                <td align="left">
                    <asp:FileUpload ID="imgUpload" runat="server" BackColor="White" BorderColor="Black"
                        Font-Bold="True" Font-Size="11pt" ForeColor="Black" Height="23px" />
                </td>--%>
            </tr>
            <tr>
                <td align="left" >
                    Notice Period :
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlNoticeperiod" runat="server" AppendDataBoundItems="True"
                        ValidationGroup="Save" CssClass="DropDown">
                      
                         <asp:ListItem Text="Select Year">---Select Notice  time---</asp:ListItem>
                        <asp:ListItem Text="Select Year">Immediate Joining</asp:ListItem>
                        <asp:ListItem Text="Select Year">10 days</asp:ListItem>
                        <asp:ListItem Text="Select Year">15 days</asp:ListItem>
                        <asp:ListItem Text="Select Year">20 days</asp:ListItem>
                        <asp:ListItem Text="Select Year">30 days</asp:ListItem>
                      
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cv10" runat="server" ErrorMessage="*" ControlToValidate="ddlNoticeperiod" ForeColor="Red"
                        Operator="NotEqual" ValueToCompare="0" ValidationGroup="save" Type="Integer"
                        SetFocusOnError="True"></asp:CompareValidator>
                </td>
                 
                <td align="right"  valign="top" >
                    Focus Area / Key Skills:
                </td>
                <td align="left" style="width: 30%">
                     <asp:ListBox ID="ListBox1" runat="server" SelectionMode="Multiple">


                     <asp:ListItem Text="Asp.net" Value="1" />
                      <asp:ListItem Text="C#" Value="2" />
                      <asp:ListItem Text="SQL SERVER" Value="3" />
                      <asp:ListItem Text="HTML" Value="4" />
                  <asp:ListItem Text="JQUERY" Value="5" />
                </asp:ListBox>
            
                  
                </td>
                 
                
               <%-- <td align="right">
                    Mother Name:
                </td>
                <td align="left">
                    <asp:TextBox ID="txtMName" runat="server" CssClass="TxtBox"></asp:TextBox>
                </td>--%>
            </tr>
            <tr>
                 <td align="right" style="width: 10%">
                   Current Location:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlClocation" runat="server" CssClass="DropDown" AppendDataBoundItems="true">
                        
                         <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator4" runat="server" ControlToValidate="ddlClocation" ForeColor="Red" ErrorMessage="*"
                        Operator="NotEqual" ValidationGroup="save" ValueToCompare="0" SetFocusOnError="True"
                        Type="Integer"></asp:CompareValidator>
                </td>
                <td align="right" class="auto-style1">
                    Preferred Location:
                </td>
                <td align="left">
                    
                    <asp:ListBox ID="lsbPrefLocation" runat="server" SelectionMode="Multiple" Height="50px">
                        <asp:ListItem>Anywhere North In India </asp:ListItem>
                        <asp:ListItem>Anywhere South In India</asp:ListItem>
                        <asp:ListItem>Anywhere East In India</asp:ListItem>
                        <asp:ListItem>Anywhere West In India</asp:ListItem>
                        <asp:ListItem>----Top metropolitan Cities----</asp:ListItem>
                        <asp:ListItem>Delhi-NCR</asp:ListItem>
                        <asp:ListItem>Gurgaon</asp:ListItem>
                        <asp:ListItem>Noida</asp:ListItem>
                        <asp:ListItem>Pune</asp:ListItem>
                        <asp:ListItem>Banlore</asp:ListItem>
                        <asp:ListItem>Chandigarh</asp:ListItem>
                        <asp:ListItem>chennai</asp:ListItem>
                        <asp:ListItem>Hyderabad</asp:ListItem>
                        <asp:ListItem>Kolkata</asp:ListItem>
                    </asp:ListBox><pre>Select upto 3 locations that you would prefer most to work in.</pre>
                    </td>
                   <%-- <asp:DropDownList ID="ddlPreLocation" runat="server" CssClass="DropDown" AppendDataBoundItems="true"
                        AutoPostBack="true">
                        <asp:ListItem Value="0" Text="Select"></asp:ListItem>
                        <%--<asp:ListItem Value="1" Text="General"></asp:ListItem>
                        <asp:ListItem Value="2" Text="OBC"></asp:ListItem>
                        <asp:ListItem Value="3">SC</asp:ListItem>
                        <asp:ListItem Value="4">ST</asp:ListItem>--%>
                  <%--  </asp:DropDownList>
                    <asp:CompareValidator ID="cv9" runat="server" ControlToValidate="ddlPreLocation" ForeColor="Red" ErrorMessage="*"
                        Operator="NotEqual" ValidationGroup="save" ValueToCompare="0" SetFocusOnError="True"
                        Type="Integer"></asp:CompareValidator>
                --%>
               <%-- <td style="width: 20%" align="right">
                    Community :
                </td>
                <td align="left" style="width: 30%">
                    <asp:DropDownList ID="ddlCommunity" runat="server" CssClass="DropDown" AppendDataBoundItems="true"
                        AutoPostBack="true">
                    </asp:DropDownList>
                </td>--%>
            </tr>
            <tr>
              <td align="right" style="width: 10%">
                    Annual Salary:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlAnSalry" runat="server" CssClass="DropDown" AppendDataBoundItems="true">
                        <asp:ListItem Text="IN Lakhs"></asp:ListItem>
                        <asp:ListItem>1 Lakh </asp:ListItem>
                       <asp:ListItem>2 Lakh </asp:ListItem>
                         <asp:ListItem>3 Lakh </asp:ListItem>
                         <asp:ListItem>4 Lakh </asp:ListItem>
                         <asp:ListItem>5 Lakh </asp:ListItem>
                         <asp:ListItem>6 Lakh </asp:ListItem>
                         <asp:ListItem>7 Lakh </asp:ListItem>
                         <asp:ListItem>8 Lakh </asp:ListItem>
                         <asp:ListItem>9 Lakh </asp:ListItem>
                         <asp:ListItem>10 Lakh </asp:ListItem>
                         <asp:ListItem>11 Lakh </asp:ListItem>
                         <asp:ListItem>12 Lakh </asp:ListItem>

                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator3" runat="server" ControlToValidate="ddlAnSalry" ForeColor="Red" ErrorMessage="*"
                        Operator="NotEqual" ValidationGroup="save" ValueToCompare="0" SetFocusOnError="True"
                        Type="Integer"></asp:CompareValidator>
                </td>
                <td align="left" style="width: 2%; "></br>
                     <asp:DropDownList ID="ddlAnSalrythousan" runat="server" AppendDataBoundItems="True" CssClass="DropDown"
                        AutoPostBack="True" >
                        <asp:ListItem Text="IN Thousand"></asp:ListItem>
                          <asp:ListItem>10 Thousand </asp:ListItem>
                       <asp:ListItem>20 Thousand </asp:ListItem>
                         <asp:ListItem>30 Thousand </asp:ListItem>
                         <asp:ListItem>40 Thousand </asp:ListItem>
                         <asp:ListItem>50 Thousand </asp:ListItem>
                         <asp:ListItem>60 Thousand </asp:ListItem>
                         <asp:ListItem>70 Thousand </asp:ListItem>
                         <asp:ListItem>80 Thousand </asp:ListItem>
                         <asp:ListItem>90 Thousand </asp:ListItem>
                         
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator11" runat="server" ControlToValidate="ddlAnSalrythousan" ErrorMessage="*"
                        Operator="NotEqual" ValueToCompare="0" ForeColor="Red" SetFocusOnError="True" Type="Integer"
                        ValidationGroup="save"></asp:CompareValidator>
                </td>
               
               
            </tr>
           <%-- jkjhkl--%>
            <tr>
                <td colspan="4" id="cssmenu" align="left">
                    Education Detail
                </td>
            </tr>
            <tr>
                <td align="right" valign="top">
                    Bachelors Degree:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlBDegree" runat="server" AppendDataBoundItems="True"
                        ValidationGroup="Save" CssClass="DropDown">
                         <asp:ListItem Text="Select"></asp:ListItem>

                        <asp:ListItem Text="Select"> Bachelor of Science Education(B.S.E)</asp:ListItem>
                      <asp:ListItem Text="Select">   Bachelor of Science(B.S)</asp:ListItem>
                        <asp:ListItem Text="Select"> Bachelors of Technology(B.Tech)</asp:ListItem>


                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator5" runat="server" ErrorMessage="*" ControlToValidate="ddlBDegree" ForeColor="Red"
                        Operator="NotEqual" ValueToCompare="0" ValidationGroup="save" Type="Integer"
                        SetFocusOnError="True"></asp:CompareValidator>
                </td>
               <td align="right" valign="top">
                    Bachelors institute:
                </td>
                <td align="left" class="auto-style1">
                    <asp:DropDownList ID="ddlBInstute" runat="server" AppendDataBoundItems="True"
                        ValidationGroup="Save" CssClass="DropDown">
                         <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator6" runat="server" ErrorMessage="*" ControlToValidate="ddlBInstute" ForeColor="Red"
                        Operator="NotEqual" ValueToCompare="0" ValidationGroup="save" Type="Integer"
                        SetFocusOnError="True"></asp:CompareValidator>
                </td>
            </tr>
            <tr>

                 <td align="right">
                    Year Of Passing:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlYeayOfPasing" runat="server" CssClass="DropDown">
                        <%--<asp:ListItem>Select</asp:ListItem>
                        <asp:ListItem>Andhra Pradesh</asp:ListItem>
                        <asp:ListItem>Arunachal Pradesh</asp:ListItem>
                        <asp:ListItem>Himachal Pradesh</asp:ListItem>
                        <asp:ListItem>Punjab</asp:ListItem>
                        <asp:ListItem>Delhi</asp:ListItem>
                        <asp:ListItem>Haryana</asp:ListItem>
                        <asp:ListItem>Rajasthan</asp:ListItem>
                        <asp:ListItem>Gujrat</asp:ListItem>
                        <asp:ListItem>Uttar Pradesh</asp:ListItem>
                        <asp:ListItem>Uttaranchal</asp:ListItem>
                        <asp:ListItem>Bihar</asp:ListItem>
                        <asp:ListItem>West Bengal</asp:ListItem>
                        <asp:ListItem>Madhya Pradesh</asp:ListItem>
                        <asp:ListItem>Chattisgarh</asp:ListItem>
                        <asp:ListItem>Jharkhand</asp:ListItem>
                        <asp:ListItem>karnataka</asp:ListItem>
                        <asp:ListItem>Kerala</asp:ListItem>
                        <asp:ListItem>Maharashtra</asp:ListItem>
                        <asp:ListItem>Tamil Nadu</asp:ListItem>
                        <asp:ListItem>Jammu Kashmir</asp:ListItem>
                        <asp:ListItem>Goa</asp:ListItem>
                        <asp:ListItem>Assam</asp:ListItem>
                        <asp:ListItem>Mizoram</asp:ListItem>
                        <asp:ListItem>Orrisa</asp:ListItem>
                        <asp:ListItem>Sikkim</asp:ListItem>
                        <asp:ListItem>Tripura</asp:ListItem>
                        <asp:ListItem>Manipur</asp:ListItem>
                        <asp:ListItem>Others</asp:ListItem>--%>
                         <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cv6" runat="server" ControlToValidate="ddlYeayOfPasing" ErrorMessage="*" ForeColor="Red"
                        Operator="NotEqual" ValidationGroup="save" ValueToCompare="Select" SetFocusOnError="True"></asp:CompareValidator>
                </td>
               
                <td align="right">
              Post Graduate Institue:
                </td>
                <td align="left" class="auto-style1">
                    <asp:DropDownList ID="ddlPgratuteInst" runat="server" ValidationGroup="save" CssClass="DropDown">
                        <asp:ListItem Text="Select"></asp:ListItem>
                        <asp:ListItem Text="India"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="cv7" runat="server" ControlToValidate="ddlPgratuteInst" ErrorMessage="*" ForeColor="Red"
                        Operator="NotEqual" ValidationGroup="save" ValueToCompare="Select" SetFocusOnError="True"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
                    Year Of Passing:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlYrpgiPasng" runat="server" CssClass="DropDown">
                         <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator8" runat="server" ControlToValidate="ddlYrpgiPasng" ErrorMessage="*" ForeColor="Red"
                        Operator="NotEqual" ValidationGroup="save" ValueToCompare="Select" SetFocusOnError="True"></asp:CompareValidator>
                </td>
                <td align="right">
               Doctoral Institue:
                </td>
                <td align="left" class="auto-style1">
                    <asp:DropDownList ID="ddlDinst" runat="server" CssClass="DropDown">
                         <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator9" runat="server" ControlToValidate="ddlDinst" ErrorMessage="*" ForeColor="Red"
                        Operator="NotEqual" ValidationGroup="save" ValueToCompare="Select" SetFocusOnError="True"></asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td align="right">
              Year Of Passing:
                </td>
                <td align="left">
                    <asp:DropDownList ID="ddlDYrOfPasing" runat="server" CssClass="DropDown">
                         <asp:ListItem Text="Select"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:CompareValidator ID="CompareValidator10" runat="server" ControlToValidate="ddlDYrOfPasing" ErrorMessage="*" ForeColor="Red"
                        Operator="NotEqual" ValidationGroup="save" ValueToCompare="Select" SetFocusOnError="True"></asp:CompareValidator>
                </td>
               
            </tr>
          <tr>
                <td colspan="4" id="cssmenu" align="left">
                    Education Detail
                </td>
            </tr>
 <tr>
             <td align="right">
              Upload Resume:
                </td>
                 <td align="right">
                   <asp:FileUpload ID="FileUpload" runat="server" BackColor="White" BorderColor="Black"
                         Font-Bold="True" Font-Size="11pt" ForeColor="Black" Height="23px" />
                     </td>

     </tr>
        </table>
        <asp:Label ID="lblmsg" runat="server" Style="font-weight: 700; color: #FF0000; background-color: #FFFFFF"></asp:Label>
        <hr />
        <asp:Button ID="btnSave" runat="server" Text="Save" Width="75px" Font-Bold="False"
            ValidationGroup="save" CssClass="btnSave" OnClick="Submit" />
        <asp:Panel ID="pnlMultCollege" runat="server" Width="40%" BorderColor="Black" BorderStyle="Solid"
            BackColor="White">
            <table width="100%" class="tblbg">
                <thead>
                    <tr>
                        <td align="center" colspan="4">
                            Alert
                        </td>
                    </tr>
                </thead>
                <tbody>
                   
                    <tr>
                        <td colspan="4" align="center">
                            &nbsp;<asp:Button ID="btnOk" runat="server" Text="Ok" CssClass="btnCancel"  />
                        </td>
                    </tr>
                </tbody>
            </table>
        </asp:Panel>
        <asp:ModalPopupExtender ID="ModalPopupExtender1" runat="server" PopupControlID="pnlMultCollege"
            TargetControlID="btn1dump" CancelControlID="Button1" BackgroundCssClass="modalbackground">
        </asp:ModalPopupExtender>
        <asp:Button ID="btn1dump" runat="server" Style="visibility: hidden" />
        <asp:Button ID="Button1" runat="server" Style="visibility: hidden" />
    </center>


</asp:Content>


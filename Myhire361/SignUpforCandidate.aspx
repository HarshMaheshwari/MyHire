<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SignUpforCandidate.aspx.cs" 
     MasterPageFile="~/Site.master" Inherits="SignUpforCandidate" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <script type="text/javascript" src="js/PasswordValidation.js"></script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div class="midder">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 mid1">
                    <div class="col-lg-6">
                        <div class="midleft">
                            <h1>
                                Reference now is just a click away!</h1>
                            <div class="referm">
                                <a href="#">
                                    <%--<img src="Image/Refermore.jpg" />--%></a></div>
                            <h2>
                                To help a friend refer a friend!</h2>
                        </div>
                    </div>
                    <div class="col-lg-6">
                        <div class="midright">
                            <h1>
                                Save Time</h1>
                            <h2>
                                Sign in using social media accounts</h2>
                            <ul>

                                <li><a href="https://www.linkedin.com/company/india-hiring">
                                 <img alt="" src="Image/btnProfilewithLinkedIn.png" />
                                    </a></li>

                             <%--   <li><a href="#">
                                    <img src="images/signinlin.png" /></a></li>
                                <li><a href="#">
                                    <img src="images/signinfb.png" /></a></li>--%>
                            </ul>
                          <%--  <ul>
                                <li><a href="#">
                                    <img src="images/signingGplus.png" /></a></li>
                                <li><a href="#">
                                    <img src="images/signintw.png" /></a></li>
                            </ul>--%>
                            <img src="Image/or.png" />
                            <p>
                                Sign up, its free</p>
                            <div class="freesignup">
                                <div class="col-md-10 col-xs-offset-1 signupfree">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-md" 
                                        placeholder="Email address*" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtEmail" ForeColor="Red" ErrorMessage="* Please Enter the Email ID"></asp:RequiredFieldValidator>
                                </div>
                                <div class="col-md-10 col-xs-offset-1 signupfree">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control input-md" 
                                        placeholder="Password*" TextMode="Password" Width="200px"></asp:TextBox>
                                    </div>
                                <div class="col-md-10 col-xs-offset-1 signupfree">
                                    <asp:TextBox ID="txtReEnterPassword" runat="server" CssClass="form-control input-md"
                                        placeholder="Re-enter Password*" TextMode="Password" Width="200px"></asp:TextBox>
                                        <asp:CompareValidator ID="CompareValidator1" runat="server" 
                                        ControlToCompare="txtPassword" ControlToValidate="txtReEnterPassword" 
                                        ErrorMessage="CompareValidator" ForeColor="Red"></asp:CompareValidator>
                                </div>
                                <div class="col-md-10 col-xs-offset-1 signupfree">
                                    <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control input-md" 
                                        placeholder="Full Name*" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtFullName" ForeColor="Red" ErrorMessage="* Please Enter the Full Name"></asp:RequiredFieldValidator>
                               
                                </div>
                                <div class="col-md-10 col-xs-offset-1 signupfree">
                                    <asp:TextBox ID="txtMobileNo" runat="server" CssClass="form-control input-md" 
                                        placeholder="Mobile No.*" Width="200px"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtMobileNo" ForeColor="Red" ErrorMessage="* Please Enter the Mobile Number"></asp:RequiredFieldValidator>
                                </div>
                                <div class="BttnSignUp">
                                 <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                                    <asp:ImageButton runat="server" ID="btnSignUp" 
                                        ImageUrl="~/Image/bttn-signup.png" onclick="btnSignUp_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="clearfix space20">
    </div>
    <div class="container">
        <div class="col-lg-12 videosection">
            <img class="catchamagingvideo" src="Image/catchamaging.png" />
            <p>
                Just 2 more minutes to have a clear picture about IndiaHiring</p>
            <div class="col-lg-4 V1">
                <a href="#">
                    <img src="Image/v3.png" /></a>
                <p>
                    What's IndiaHiring?<span>28s</span></p>
            </div>
            <div class="col-lg-4 V1">
                <a href="#">
                    <img src="Image/v2.png" /></a>
                <p>
                    Referral Rewards<span>40s</span></p>
            </div>
            <div class="col-lg-4 V1">
                <a href="#">
                    <img src="Image/v1.png" /></a>
                <p>
                    When you can't change the boss, change the job ;)<span>18s</span></p>
            </div>
        </div>
    </div>
</asp:Content>
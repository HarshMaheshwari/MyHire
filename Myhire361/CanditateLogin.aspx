<%@ Page Title="" Language="C#"  MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="CanditateLogin.aspx.cs" Inherits="CanditateLogin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
      <script type="text/javascript" src="http://platform.linkedin.com/in.js">
       api_key: 759v2l3ulwn97u
       authorize: true
       onLoad: onLinkedInLoad
       scope: r_basicprofile r_emailaddress r_fullprofile
    </script>


    <script type="text/javascript">
        function onLinkedInLoad() {
            IN.Event.on(IN, "auth", onLinkedInAuth);
            $('a[id*=li_ui_li_gen_]').css({ marginBottom: '20px' })
   .html('<img src= "images/signinwithlink.png" width="250px" height="40px" />');
        }
        function onLinkedInAuth() {
            IN.API.Profile("me")
     .fields("firstName", "lastName", "industry", "location:(name)", "picture-url", "headline", "summary", "num-connections", "public-profile-url", "distance", "positions", "email-address", "educations", "date-of-birth")
     .result(displayProfiles)
     .error(displayProfilesErrors);
        }
        function displayProfiles(profiles) {
            member = profiles.values[0];

            $.ajax({
                type: "POST",
                url: "http://www.indiahiring.org/Websrvcs/Misc.asmx/LoginWithLinkedIn",
                data: '{Name: "' + (member.firstName + " " + member.lastName) + '",Email: "' + (member.emailAddress) + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: window.location.href = "Dashboard.aspx",
                failure: function (response) {
                    alert("Try again!!");
                }
            });
        }
</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <div class="midder">
        <div class="container">
            <div class="row">
                <div class="col-lg-12 mid1">
                    <div class="col-lg-6">
                        <div class="midleft midleft12">
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
                            <h4>
                                Sign in to your IndiaHiring
                                <br />
                                my account</h4>
                            <div class="freesignup">
                                <div class="col-md-10 col-xs-offset-1 signupfree">
                                    <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control input-md" placeholder="Email address*"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfv1" runat="server" ErrorMessage="" 
                                        ControlToValidate="txtEmail" SetFocusOnError="True" ValidationGroup="Password"></asp:RequiredFieldValidator>

                                                          <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="" 
                                        ControlToValidate="txtEmail" SetFocusOnError="True" ValidationGroup="Login"></asp:RequiredFieldValidator>


                                </div>
                                <div class="col-md-10 col-xs-offset-1 signupfree">
                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control input-md" placeholder="Password*" TextMode="Password"></asp:TextBox>
                                                           <asp:RequiredFieldValidator ID="rfv3" runat="server" ErrorMessage="" 
                                        ControlToValidate="txtPassword" SetFocusOnError="True" ValidationGroup="Login"></asp:RequiredFieldValidator>

                                </div>
                                <div class="col-xs-offset-1 col-lg-5 checkboxes121">
                                    <label class="checkbox-inline" for="checkboxes-0">
                                        <asp:CheckBox runat="server" ID="cbKeepmeSignIn"  Checked="true"/>
                                        Keep me signed in
                                    </label>
                                </div>
                                <div class="col-lg-6 ForgotPassword">
                                  <asp:LinkButton ID="lbtnForgotPassword" runat="server"  OnClick="lbtnForgotPassword_Click" ValidationGroup="Password">Forgot Password?</asp:LinkButton>
                                </div>
                                <div class="BttnSignUp">
                                       <asp:Label ID="lblmsg" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="BttnSignUp">
                                    <asp:ImageButton runat="server" ID="btnLogin" ImageUrl="~/Image/Login.png" OnClick="btnLogin_Click" ValidationGroup="Login" />
                             
                                </div>
                            </div>
                            <p class="accountur">
                                Not having IndiaHiring account?</p>
                            <div class="CreatingAcc">
                                <asp:LinkButton ID="lbtnCreateNew" runat="server" Font-Size="18px" CssClass="btn-link" OnClick="lbtnCreateNew_Click">Create New</asp:LinkButton>
                            </div>
                            <img src="Image/or.png" />
                            
                            <ul Style="text-align:center">


                                                                 <script type="in/Login"></script>

                                <%--<li ><a href="#">
                                 <img alt="" src="images/signinwithlink.png" width="250px" height="40px" align="middle" />
                                    </a></li>--%>
                               <%-- <li><a href="#">
                                    <img src="images/signinlin.png" /></a></li>
                                <li><a href="#">
                                    <img src="images/signinfb.png" /></a></li>--%>
                            </ul>
                            <%--<ul>
                                <li><a href="#">
                                    <img src="images/signingGplus.png" /></a></li>
                                <li><a href="#">
                                    <img src="images/signintw.png" /></a></li>
                            </ul>--%>
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
     <div class="clearfix space20">
    </div>
</asp:Content>


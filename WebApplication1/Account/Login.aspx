<%@ Page Title="Login" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Account.Login" %>

<asp:Content ID="Login" ContentPlaceHolderID="MainContent" runat="server">

    <!--
     -->

    <h2><%: Title %></h2>

    <div class="row">
        <div class="col-md-6 mx-auto">
            <section id="loginForm">
                <div class="form-horizontal">
                    <hr />

                    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
                        <p class="text-danger">
                            <asp:Literal runat="server" ID="FailureText" />
                        </p>
                    </asp:PlaceHolder>

                    <div class="form-group">
                        <div class="col-md-15 mx-auto">
                            <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-3 control-label">Email</asp:Label>
                            <div class="col-md mx-auto">
                                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                    CssClass="text-danger" ErrorMessage="The email field is required." />
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-20 mx-auto">
                            <asp:Label runat="server" AssociatedControlID="Password" CssClass="col-md-3 control-label">Password</asp:Label>
                            <div class="col-md mx-auto">
                                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="Password" CssClass="text-danger" ErrorMessage="The password field is required." />
                            </div>
                        </div>
                    </div>

                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <div class="checkbox">
                                <asp:CheckBox runat="server" ID="RememberMe" />
                                <asp:Label runat="server" AssociatedControlID="RememberMe">Remember me?</asp:Label>
                            </div>
                        </div>
                    </div>
                    
                    <!-- captcha -->
                    <div class="col-md-offset-1 col-md-10">
                        <asp:Button runat="server" OnClick="login_Click" Text="Log in" CssClass="btn btn-success btn-block" />
                        
                    </div>

                    <div class="col-md-offset-1 col-md-10">
                        <asp:Label ID="clicklabel" BackColor="Red" runat="server" Text=""></asp:Label>
                    </div>
                </div><br/><br/><br/>
                <div class="col-md-offset-2 col-md-10">
                    <p>
                        <asp:HyperLink runat="server" ID="RegisterHyperLink" NavigateUrl="~/Account/Registration.aspx" ViewStateMode="Enabled">Register as a new user</asp:HyperLink>
                    </p>
                    <p>
                        <%--Enable this once you have account confirmation enabled for password reset functionality --%>
                        <asp:HyperLink runat="server" ID="ForgotPasswordHyperLink" NavigateUrl="~/Account/Forgot_Password.aspx" ViewStateMode="Enabled">Forgot your password?</asp:HyperLink>
                    
                    </p>
                </div>
                
            </section>
        </div>
    </div>
</asp:Content>

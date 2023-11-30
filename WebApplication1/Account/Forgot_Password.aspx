<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Forgot_Password.aspx.cs" Inherits="WebApplication1.Account.Forgot_Password" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <h2><%: Title %></h2>
    <asp:MultiView runat="server" ID="multiview">
        <asp:View ID="View1" runat="server">

            <div class="row">
                <div class="col-md-8">
                    <section id="forgotpassword_s1">
                        <div class="form-horizontal">
                            <hr />

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="email" CssClass="col-md-2 control-label">Email</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="email" CssClass="form-control" TextMode="Email" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="email"
                                        CssClass="text-danger" ErrorMessage="The email field is required." />
                                    <asp:LinkButton runat="server" OnClick="sendotp">Send OTP </asp:LinkButton>
                                    <p><a onclick="sendotp">Send OTP</a></p>
                                </div>
                            </div>

                            <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="otp" CssClass="col-md-2 control-label">Enter OTP</asp:Label>
                                <div class="col-md-10">
                                    <asp:TextBox runat="server" ID="otp" CssClass="form-control" TextMode="Number" MaxLength="6" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="otp" CssClass="text-danger" ErrorMessage="The otp field is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <asp:Label runat="server" ID="label5"></asp:Label>
                            </div>

                           <%--  <div class="form-group">
                                <asp:Label runat="server" AssociatedControlID="captcha" CssClass="col-md-2 control-label">Enter Capchha</asp:Label>
                                <div class="col-md-10">
                                    <asp:Image ID="imgCaptcha" runat="server" ImageUrl="captcha.ashx" />
                                    <asp:TextBox runat="server" ID="captcha" CssClass="form-control" />
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="captcha"
                                        CssClass="text-danger" ErrorMessage="The Captcha field is required." />
                                </div>
                            </div>  --%>

                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Button runat="server" OnClick="submit" Text="Submit" CssClass="btn btn-default" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Label ID="Label1" BackColor="Red" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>

                    </section>
                </div>
            </div>

        </asp:View>


        <asp:View ID="View2" runat="server">

            <div class="row">
                <div class="col-md-8">
                    <section id="forgotpassword_s2">
                        <div class="form-horizontal">
                            <hr />
                            <div class="form-group">
                                <div class="col-md-10">
                                    <asp:Label runat="server" AssociatedControlID="password" CssClass="col-2 control-label" Text="Password: "></asp:Label>
                                    <asp:TextBox ID="password" CssClass="form-control" pattern="[A-Za-z0-9!@#$%^&*A-Za-z0-9]{8,}" runat="server" title="Ex. A4!|@|#|$|%|^|&|*a4" TextMode="Password" placeholder="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="password"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The Password field is required." />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-10">
                                    <asp:Label runat="server" AssociatedControlID="repassword" CssClass="col-2 control-label" Text="Confirm Password: "></asp:Label>
                                    <asp:TextBox ID="repassword" CssClass="form-control" pattern="[A-Za-z0-9!@#$%^&*A-Za-z0-9]{8,}" runat="server" title="Ex. A4!|@|#|$|%|^|&|*a4" 
                                        TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                                </div>
                                <div class="col-md-10">
                                    <asp:RequiredFieldValidator runat="server" ControlToValidate="repassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                                    <asp:CompareValidator runat="server" ControlToCompare="password" ControlToValidate="repassword"
                                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                                </div>
                            </div>
                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Button runat="server" OnClick="forgotpassword" Text="Submit" CssClass="btn btn-default" />
                                </div>
                            </div>

                            <div class="form-group">
                                <div class="col-md-offset-2 col-md-10">
                                    <asp:Label ID="Label2" BackColor="Red" runat="server" Text=""></asp:Label>
                                </div>
                            </div>
                        </div>
                        
                    </section>
                </div>
            </div>

        </asp:View>
    </asp:MultiView>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="WebApplication1.Account.Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:MultiView ID="multiview" runat="server">

        <asp:View ID="viewDefault" runat="server">
                
            <form class="signin-form" method="post">
                <div aria-orientation="vertical">
                    <h3>Choose your Account Type</h3>
                    <div aria-orientation="horizontal">
                        <asp:ImageButton ID="ImageButton1" runat="server" OnClick="school_Click" ImageUrl="~/Content/Image/Book.png" ForeColor="White" Height="150" Width="120" />
                        <asp:ImageButton ID="ImageButton2" runat="server" OnClick="user_Click" ImageUrl="~/Content/Image/User.png" Height="150" Width="120" />
                        <asp:ImageButton ID="ImageButton3" runat="server" OnClick="org_Click" ImageUrl="~/Content/Image/organizer.png" Height="150" Width="120" />
                    </div>
                </div>
            </form>
             
            <br/>
            <p>Already have an account? <a href="Login.aspx">Log in</a></p>
        
        </asp:View>
    
    <%-- View 1 User index 1 --%>

        <asp:View ID="users" runat="server">
            <form id="f1" class="signin-form" method="post" aria-orientation="horizontal">
                <h1>User Registration</h1>
                <div aria-orientation="vertical">
        
                    <div id="user_u" aria-orientation="vertical">
                    <br />
                    <asp:Label runat="server" AssociatedControlID="firstname" Text="First Name: "></asp:Label>
                    <asp:TextBox ID="firstname" runat="server" title="Firstname" placeholder="firstname"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="firstname" CssClass="text-danger" ErrorMessage="The First Name field is required." />
                    <br />
                    <br />
                    <asp:Label runat="server" AssociatedControlID="lastname" Text="Last Name: "></asp:Label>
                    <asp:TextBox ID="lastname" runat="server" title="Lastname" placeholder="lastname"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="lastname" CssClass="text-danger" ErrorMessage="The Last Name field is required." />
                    </div>
                    <br />
                    <asp:Label runat="server" AssociatedControlID="email_f1" Text="Email: "></asp:Label>
                    <asp:TextBox ID="email_f1" runat="server" title="Email" TextMode="Email" placeholder="&#9993; Email"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="email_f1" CssClass="text-danger" ErrorMessage="The Email field is required." />
                    <br /><br />
                    <asp:Label runat="server" AssociatedControlID="phone_f1" Text="Phone Number: "></asp:Label>
                    <asp:TextBox ID="phone_f1" MaxLength="10" runat="server" TextMode="Phone" title="Phone No" placeholder="&#128222; Phone Number"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="phone_f1" CssClass="text-danger" ErrorMessage="The Phone No field is required." />
                    <br /><br />
                    
                    <asp:Label runat="server" AssociatedControlID="male_f1" Text="Gender: "></asp:Label>
                    <div id="gender_u" aria-orientation="vertical">
                        <asp:RadioButton ID="male_f1" runat="server" Text="Male" GroupName="gender" />
                        <asp:RadioButton ID="female_f1" runat="server" Text="Female" GroupName="gender" />
                        <asp:RadioButton ID="other_f1" runat="server" Text="Other" GroupName="gender" />
                        <asp:Label runat="server" ID="gender_uu" Text=""></asp:Label>
                    </div>

                    <div id="dateofbirth_u" aria-orientation="vertical">
                        <asp:Label runat="server" AssociatedControlID="dateofbirth_f1">Date of Birth: </asp:Label>
                        <asp:TextBox ID="dateofbirth_f1" TextMode="Date" runat="server" title="Date of Birth"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="dateofbirth_f1" CssClass="text-danger" ErrorMessage="The Date of Birth field is required." />
                    </div>
                    <br />
                    <div id="address_u" aria-orientation="vertical">
                      <!--  <asp:Label runat="server" AssociatedControlID="country_f1" Text="Country: "></asp:Label>
                        <asp:DropDownList ID="country_f1" runat="server">
                            <asp:ListItem Text="-- Select a Country --" Value=""/>
                            <asp:ListItem Text="Option 1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Option 2" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="country_f1" CssClass="text-danger" ErrorMessage="The Country field is required." />
                        <br /><br />
                        -->
                        <asp:Label runat="server" AssociatedControlID="state_f1" Text="State: "></asp:Label>
                        <asp:DropDownList ID="state_f1" runat="server">
                            <asp:ListItem Text="-- Select a State --" Value="" />
                            <asp:ListItem Text="Option 1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Option 2" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="state_f1" CssClass="text-danger" ErrorMessage="The State field is required." />
                        <br /><br />
                        <asp:Label runat="server" AssociatedControlID="district_f1" Text="District: "></asp:Label>
                        <asp:TextBox ID="district_f1" runat="server" placeholder="District"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="district_f1" CssClass="text-danger" ErrorMessage="The District field is required." />
                        <br /><br />
                        <asp:Label runat="server" Text="City: " AssociatedControlID="city_f1"></asp:Label>
                        <asp:TextBox ID="city_f1" runat="server" placeholder="City"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="city_f1" CssClass="text-danger" ErrorMessage="The City field is required." />
                        <br />
                        <br />
                    </div>
                    <asp:Label runat="server" AssociatedControlID="pincode_f1" Text="Pincode: "></asp:Label>
                    <asp:TextBox runat="server" placeholder="Pincode" ID="pincode_f1" TextMode="Phone" title="pincode" MaxLength="6"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="pincode_f1" CssClass="text-danger" ErrorMessage="The Pincode field is required." />
                    <br />
                    <br />
                    <div aria-orientation="vertical">
                        <asp:Label runat="server" Text="Department: " AssociatedControlID="department_f1"></asp:Label>
                        <asp:DropDownList ID="department_f1" runat="server">
                            <asp:ListItem Text="-- Department --" Value="" />
                            <asp:ListItem Text="Option 1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Option 2" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="department_f1" CssClass="text-danger" ErrorMessage="The Department field is required." />
                    </div>
                    <br />
                    <asp:Label runat="server" AssociatedControlID="password_f1" Text="Password: "></asp:Label>
                    <asp:TextBox ID="password_f1" pattern="[A-Za-z0-9!@#$%^&*A-Za-z0-9]{8,}" runat="server" title="Ex. A4!|@|#|$|%|^|&|*a4" TextMode="Password" placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="password_f1"
                        CssClass="text-danger" Display="Dynamic" ErrorMessage="The Password field is required." />
                        
                    <br /><br />
                    <asp:Label runat="server" AssociatedControlID="repassword_f1" Text="Confirm Password: "></asp:Label>
                    <asp:TextBox ID="repassword_f1" pattern="[A-Za-z0-9!@#$%^&*A-Za-z0-9]{8,}" runat="server" title="Ex. A4!|@|#|$|%|^|&|*a4" TextMode="Password" placeholder="Confirm Password"></asp:TextBox>
                    <div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="repassword_f1"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                        <asp:CompareValidator runat="server" ControlToCompare="password_f1" ControlToValidate="repassword_f1"
                            CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                    </div>
                    <%-- <script src="District.js"></script> --%>
                    <br />
                    <br />
                    <asp:Button ID="Registration_f1" runat="server" Text="Registration" OnClick="RegistrationButton_u_click" />
                    <br />
                    <asp:Label runat="server" ID="u1" Text=""></asp:Label>
                    <br />
                    <p>Already have an account? <a href="Login.aspx">Login..</a></p>
                </div>
                
            </form>
        
        </asp:View>

        <%-- View 2 Organizer index 2 --%>
        
        <asp:View ID="organizer" runat="server">

            <form class="signin-form" id="f2" method="post">
                <div aria-orientation="vertical">
                    <h1>Organizer Registration</h1>
                    <asp:Label runat="server" AssociatedControlID="org_name_f2" Text="Organizer Name: "></asp:Label>
                    <asp:TextBox ID="org_name_f2" runat="server" title="Organizer Name" placeholder="Organizer Name"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="org_name_f2" CssClass="text-danger" ErrorMessage="The Organizer Name field is required." />
                    <br />
                    <br />
                    <asp:Label runat="server" AssociatedControlID="email_f2" Text="Email: "></asp:Label>
                    <asp:TextBox ID="email_f2" runat="server" title="Email" TextMode="Email" placeholder="&#9993; Email"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="email_f2" CssClass="text-danger" ErrorMessage="The Email field is required." />
                    <br />
                    <br />
                    <asp:Label runat="server" AssociatedControlID="phone_f2" Text="Phone Number: "></asp:Label>
                    <asp:TextBox ID="phone_f2" MaxLength="10" runat="server" TextMode="Phone" title="Phone" placeholder="&#128222; Phone Number"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="phone_f2" CssClass="text-danger" ErrorMessage="The Phone Number field is required." />
                    <br />
                    <br />
                    
                    <div id="address_o">
                     <!--   <asp:Label runat="server" AssociatedControlID="country_f2" Text="Country: "></asp:Label>
                        <asp:DropDownList ID="country_f2" runat="server">
                            <asp:ListItem Text="-- Select a Country --" Value="" />
                            <asp:ListItem Text="Option 1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Option 2" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="country_f2" CssClass="text-danger" ErrorMessage="The Country field is required." />
                        <br />
                        <br /> -->
                        <asp:Label runat="server" AssociatedControlID="state_f2" Text="State: "></asp:Label>
                        <asp:DropDownList ID="state_f2" runat="server">
                            <asp:ListItem Text="-- Select a State --" Value="" />
                            <asp:ListItem Text="Option 1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Option 2" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="state_f2" CssClass="text-danger" ErrorMessage="The State field is required." />
                        <br />
                        <br />
                        <asp:Label runat="server" AssociatedControlID="district_f2" Text="District: "></asp:Label>
                        <asp:TextBox ID="district_f2" runat="server" placeholder="District"></asp:TextBox>    
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="district_f2" CssClass="text-danger" ErrorMessage="The District field is required." />
                        <br />
                        <br />
                        <asp:Label runat="server" AssociatedControlID="city_f2" Text="City: "></asp:Label>
                        <asp:TextBox ID="city_f2" runat="server" placeholder="City"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="city_f2" CssClass="text-danger" ErrorMessage="The City field is required." />
                    </div>
                    <br />
                    <div id="full_address_o" aria-orientation="vertical">
                        <asp:label ID="label_address" AssociatedControlID="address_f2" runat="server" Text="Address"></asp:label>
                        <asp:TextBox ID="address_f2" runat="server" placeholder="Address" title="address"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="address_f2" CssClass="text-danger" ErrorMessage="The Address field is required." />
                    </div>
                    <br />
                    <asp:Label runat="server" AssociatedControlID="pincode_f2" Text="Pincode: "></asp:Label>
                    <asp:TextBox runat="server" placeholder="Pincode" ID="pincode_f2" TextMode="Phone" title="pincode" MaxLength="6"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="pincode_f2" CssClass="text-danger" ErrorMessage="The Pincode field is required." />
                    <br />
                    <br />
                    <asp:Label runat="server" AssociatedControlID="password_f2" Text="Password: "></asp:Label>
                    <asp:TextBox ID="password_f2" pattern="[A-Za-z0-9!@#$%^&*A-Za-z0-9]{8,}" runat="server" title="Ex. A4!|@|#|$|%|^|&|*a4" TextMode="Password" placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="password_f2" CssClass="text-danger" Display="Dynamic" ErrorMessage="The Password field is required." />
                    <br />
                    <br />
                    <asp:Label runat="server" AssociatedControlID="repassword_f2" Text="Confirm Password: "></asp:Label>
                    <asp:TextBox ID="repassword_f2" pattern="[A-Za-z0-9!@#$%^&*A-Za-z0-9]{8,}" runat="server" title="Ex. A4!|@|#|$|%|^|&|*a4" TextMode="Password" placeholder="Re-password"></asp:TextBox>
                    <div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="repassword_f2" CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                        <asp:CompareValidator runat="server" ControlToCompare="password_f2" ControlToValidate="repassword_f2" CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                    </div>
                    <br />
                    <br />
                    
                    <asp:Button ID="registration_f2" runat="server" Text="Registration" OnClick="RegistrationButton_o_click" />
                    <br />
                    <asp:Label runat="server" ID="o1" Text=""></asp:Label>
                    <br />
                    <p>Already have an account? <a href="Login.aspx">Login..</a></p>

                </div>
                
            </form>
        
        </asp:View>

        <%-- view 3 college index 3 --%>

        <asp:View ID="college" runat="server">
                
            <form class="signin-form" id="f3" method="post">
                <div aria-orientation="vertical">
                    <h1>College/School Registration</h1>
                    <asp:Label runat="server" AssociatedControlID="sname_f3" Text="College/School Name: "></asp:Label>
                    <asp:TextBox ID="sname_f3" runat="server" title="College/School Name" placeholder="College/School Name"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="sname_f3" CssClass="text-danger" ErrorMessage="The Pincode field is required." />
                    <br /><br />
                    <asp:Label runat="server" AssociatedControlID="email_f3" Text="Email: "></asp:Label>
                    <asp:TextBox ID="email_f3" runat="server" title="Email" TextMode="Email" placeholder="&#9993; Email"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="email_f3" CssClass="text-danger" ErrorMessage="The Email field is required." />
                    <br /><br />
                    <asp:Label runat="server" AssociatedControlID="phone_f3" Text="Phone Number: "></asp:Label>
                    <asp:TextBox ID="phone_f3" MaxLength="10" runat="server" TextMode="Phone" title="Phone" placeholder="&#128222; Phone Number"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="phone_f3" CssClass="text-danger" ErrorMessage="The Phone Number field is required." />
                    <br />
                    <br />
                    <div id="address_s" aria-orientation="vertical">
                       <!-- <asp:Label runat="server" AssociatedControlID="country_f3" Text="Country: "></asp:Label>
                        <asp:DropDownList ID="country_f3" runat="server">
                            <asp:ListItem Text="-- Select a Country --" Value=""/>
                            <asp:ListItem Text="Option 1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Option 2" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="country_f3" CssClass="text-danger" ErrorMessage="The Country field is required." />
                        <br /><br />
                        -->
                        <asp:Label runat="server" AssociatedControlID="state_f3" Text="State: "></asp:Label>
                        <asp:DropDownList ID="state_f3" runat="server">
                            <asp:ListItem Text="-- Select a State --" Value="" />
                            <asp:ListItem Text="Option 1" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Option 2" Value="2"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="state_f3" CssClass="text-danger" ErrorMessage="The State field is required." />
                        <br /><br />
                        <asp:Label runat="server" AssociatedControlID="district_f3" Text="District: "></asp:Label>
                        <asp:TextBox ID="district_f3" runat="server" placeholder="District"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="district_f3" CssClass="text-danger" ErrorMessage="The District field is required." />
                        <br /><br />
                        <asp:Label runat="server" Text="City: " AssociatedControlID="city_f3"></asp:Label>
                        <asp:TextBox runat="server" ID="city_f3" placeholder="City"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="city_f3" CssClass="text-danger" ErrorMessage="The City field is required." />
                        <br />
                        <br />
                    </div>
                    <div>
                        <asp:label AssociatedControlID="address_f3" runat="server" Text="Address: "></asp:label>
                        <asp:TextBox ID="address_f3" placeholder="Address" Wrap="true" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="address_f3" CssClass="text-danger" ErrorMessage="The Address field is required." />
                    </div>
                    <br />
                    <asp:Label runat="server" AssociatedControlID="pincode_f3" Text="Pincode: "></asp:Label>
                    <asp:TextBox runat="server" placeholder="Pincode" TextMode="Phone" ID="pincode_f3" title="pincode" MaxLength="6"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="pincode_f3" CssClass="text-danger" ErrorMessage="The Pincode field is required." />

                    <br /><br />
                    <asp:Label runat="server" AssociatedControlID="password_f3" Text="Password: "></asp:Label>
                    <asp:TextBox ID="password_f3" pattern="[A-Za-z0-9!@#$%^&*A-Za-z0-9]{8,}" runat="server" title="Ex. A4!|@|#|$|%|^|&|*a4" TextMode="Password" placeholder="Password"></asp:TextBox>
                    <asp:RequiredFieldValidator runat="server" ControlToValidate="password_f3" CssClass="text-danger" ErrorMessage="The Password field is required." />
                    <br /><br />
                    <asp:Label runat="server" AssociatedControlID="repassword_f3" Text="Confirm Password: "></asp:Label>
                    <asp:TextBox ID="repassword_f3" pattern="[A-Za-z0-9!@#$%^&*A-Za-z0-9]{8,}" runat="server" title="Ex. A4!|@|#|$|%|^|&|*a4" TextMode="Password" placeholder="Re-password"></asp:TextBox>
                    <div>
                        <asp:RequiredFieldValidator runat="server" ControlToValidate="repassword_f3" CssClass="text-danger" Display="Dynamic" ErrorMessage="The confirm password field is required." />
                        <asp:CompareValidator runat="server" ControlToCompare="password_f3" ControlToValidate="repassword_f3" CssClass="text-danger" Display="Dynamic" ErrorMessage="The password and confirmation password do not match." />
                    </div>

                    <br /><br />
                    <asp:Button ID="register_c" runat="server" Text="Registration" OnClick="RegistrationButton_s_click" />
                    
                    <br />
                    <asp:Label runat="server" ID="s1" Text=""></asp:Label>
                    <br />
                    <p>Already have an account? <a href="Login.aspx">Login..</a></p>

                </div>
            </form>
        </asp:View>
    </asp:MultiView>
</asp:Content>

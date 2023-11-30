<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebApplication1.Account.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin:50px 0px 0px 0px;">
        <asp:Label ID="error" runat="server" />
        <asp:Label ID="uid" runat="server" />
        <table class="nav-justified">
            <tr>
                <td style="vertical-align: top;">
                    <div id="d1" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" ID="label1" Text="First Name: " AssociatedControlID="TextBox1" />
                        <asp:TextBox runat="server" ID="TextBox1" />
                    </div>
                    <div id="d2" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" ID="label2" Text="Last Name: " AssociatedControlID="TextBox2" />
                        <asp:TextBox runat="server" ID="TextBox2" />                
                    </div>
                    <div id="d3" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" ID="label3" Text="Email: " AssociatedControlID="TextBox3" />
                        <asp:TextBox runat="server" ID="TextBox3" />
                    </div>
                    <div id="d4" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" ID="label4" Text="Email Status: " AssociatedControlID="TextBox4" />
                        <asp:Label runat="server" ID="TextBox4" /> &nbsp; &nbsp;
                        <asp:LinkButton runat="server" ID="link4" Text="Click" OnClick="emailstatus" />
                    </div>
                    <div id="d15" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" Text="OTP" AssociatedControlID="textbox15" />
                        <asp:TextBox runat="server" ID="textbox15" TextMode="Number" MaxLength="6" />
                        <asp:Button runat="server" OnClick="otp" />
                    </div>
                    <div id="d5" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" Text="Phone Number: " ID="label5" AssociatedControlID="TextBox5" />
                        <asp:TextBox runat="server" ID="TextBox5" />    
                    </div>
                    <div id="d6" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" Text="Gender: " ID="label6" AssociatedControlID="TextBox6" />
                        <asp:TextBox runat="server" ID="TextBox6" />
                    </div>
                    <div id="d7" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" Text="Date of Birth: " ID="label7" AssociatedControlID="TextBox7" />
                        <asp:TextBox runat="server" ID="TextBox7" />
                    </div>
                     <div id="d8" runat="server" style="margin:0px 0px 15px 0px">
                         <asp:Label runat="server" Text="Address: " ID="label8" AssociatedControlID="TextBox8" />
                        <asp:TextBox runat="server" ID="TextBox8" />
                    </div>
                    <div id="d9" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" ID="label9" Text="Department: " AssociatedControlID="TextBox9" />
                        <asp:TextBox runat="server" ID="TextBox9" />
                    </div>
                </td>
                <td style="vertical-align: top;">
                    <div id="d10" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" Text="Country: " ID="label10" AssociatedControlID="TextBox10" />
                        <asp:TextBox runat="server" ID="TextBox10" />
                    </div>
                    <div id="d11" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" Text="State: " ID="label11" AssociatedControlID="TextBox11" />
                        <asp:TextBox runat="server" ID="TextBox11" />
                    </div>
                    <div id="d12" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" Text="District: " ID="label12" AssociatedControlID="TextBox12" />
                        <asp:TextBox runat="server" ID="TextBox12" />
                    </div>
                    <div id="d13" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" Text="City: " ID="label13" AssociatedControlID="TextBox13" />
                        <asp:TextBox runat="server" ID="TextBox13" />
                    </div>
                    <div id="d14" runat="server" style="margin:0px 0px 15px 0px">
                        <asp:Label runat="server" Text="Pincode: " ID="label14" AssociatedControlID="TextBox14" />
                        <asp:TextBox runat="server" ID="TextBox14" />
                    </div>
                </td>
            </tr>
        </table>

        <div style="text-align:center; padding:30px 0px 0px 0px">
            <asp:Button runat="server" Text="Save" OnClick="save" />
        </div>

    </div>
    


</asp:Content>

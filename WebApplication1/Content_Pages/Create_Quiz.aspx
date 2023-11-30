<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Create_Quiz.aspx.cs" Inherits="WebApplication1.Content_Pages.Create_Quiz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <script type="text/javascript" src="../Scripts/Script_Page.js"></script>

    <h1 style="text-align:center; margin:20px, 0px, 20px, 0px">Create Quiz</h1>
    <asp:MultiView runat="server" ID="MultiView">
        
        <asp:View ID="View1" runat="server">

            <table class="nav-justified">
                    <tr>
                        <td>
                            <div runat="server" aria-orientation="vertical" style="margin:0px, 50px, 0px, 0px">

                                <div id="D1" runat="server" style="margin:0px 0px 15px 0px">
                                    <asp:Label runat="server" Text="Quiz Name: " AssociatedControlID="TextBox1" />
                                    <asp:TextBox runat="server" ID="TextBox1" />
                                </div>
                                <div id="D2" runat="server" style="margin:0px 0px 15px 0px">
                                    <asp:Label runat="server" Text="Subject Name: " AssociatedControlID="DropDownList1" />
                                    <asp:DropDownList runat="server" Width="15%" ID="DropDownList1">
                                        <asp:ListItem Text="1" />
                                        <asp:ListItem Text="2" />
                                    </asp:DropDownList>
                                </div>
                                <div id="D3" runat="server" style="margin:0px 0px 15px 0px">
                                    <asp:Label runat="server" Font-Bold="true" Text="Description: " />
                                    <asp:TextBox runat="server" TextMode="MultiLine" Width="100%" ID="TextBox2" />
                                </div>
                                <div id="D4" runat="server" style="margin:0px 0px 15px 0px">
                                    <asp:Label runat="server" Font-Bold="true" Text="Time For Quiz " />
                                    <asp:Label runat="server" AssociatedControlID="TextBox3" Text="Hour: " />
                                    <asp:TextBox runat="server" Text="00" TextMode="Number" MaxLength="2" ID="TextBox3" />
                                </div>
                                <div id="D5" runat="server" style="margin:0px 0px 15px 0px">
                                    <asp:Label runat="server" AssociatedControlID="TextBox4" Text="Minutes: " />
                                    <asp:TextBox runat="server" Text="00" MaxLength="2" TextMode="Number" ID="TextBox4" />
                                </div>
                                <div id="D6" runat="server" style="margin:0px 0px 15px 0px">
                                    <asp:Button Text="Next" Width="100" Height="30" OnClick="nextview" runat="server" /> &nbsp;
                                    <asp:Button Text="Cancel" Width="100" Height="30" runat="server" OnClick="Unnamed8_Click" />
                                </div>
                            </div>
                        </td>
                    </tr>
                </table>

        </asp:View>


        <asp:View ID="view2" runat="server">
            <table class="nav-justified">
                <tr>
                    <td>
                        <div id="D8" runat="server" style="margin:0px 0px 15px 0px">
                            <asp:Label runat="server" Text="Question Type: " AssociatedControlID="DropDownList2" />
                            <asp:DropDownList runat="server" Width="15%" AutoPostBack="true" ID="DropDownList2" OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged">
                                <asp:ListItem Value="-1" Text="" />
                                <asp:ListItem Value="1" Text="Text" />
                                <asp:ListItem Value="2" Text="Image" />
                                <asp:ListItem Value="3" Text="Audio" />
                                <asp:ListItem Value="4" Text="Video" />
                            </asp:DropDownList>                
                        </div>
                        <div id="D9" runat="server" visible="false" style="margin:0px 0px 15px 0px">
                            <asp:Label runat="server" Text="Qustion Name: " AssociatedControlID="TextBox5" />
                            <asp:TextBox runat="server" ID="TextBox5" />
                        </div>
                        <div id="D10" runat="server" visible="false" style="margin:0px 0px 15px 0px">
                            <asp:Label runat="server" Text="Qustion: " AssociatedControlID="TextBox6" />
                            <asp:TextBox runat="server" ID="TextBox6" />
                            <asp:FileUpload runat="server" ID="file1" />
                        </div>

                        <div id="D11" runat="server" visible="false" style="margin:0px 0px 15px 0px">
                            <asp:Label runat="server" Text="Option Number: " AssociatedControlID="DropDownList3" />
                            <asp:DropDownList runat="server" AutoPostBack="true" Width="15%" ID="DropDownList3" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged">
                                <asp:ListItem Selected="True" Text="" />
                                <asp:ListItem Value="o1" Text="2" />
                                <asp:ListItem Value="o2" Text="4" />
                                <asp:ListItem Value="o3" Text="5" />
                            </asp:DropDownList>                
                        </div>
                        <div id="D12" runat="server" visible="false" style="margin:0px 0px 15px 0px">
                            <asp:Label runat="server" Text="Option 1: " AssociatedControlID="TextBox7" />
                            <asp:TextBox runat="server" ID="TextBox7" /> &nbsp;  
                            <asp:CheckBox runat="server" Checked="false" ID="checkbox1" Text="A" ValidationGroup="check" />
                        </div>
                        <div id="D13" runat="server" visible="false" style="margin:0px 0px 15px 0px">
                            <asp:Label runat="server" Text="Option 2: " AssociatedControlID="TextBox8" />
                            <asp:TextBox runat="server" ID="TextBox8" />       &nbsp;  
                            <asp:CheckBox runat="server" Checked="false" ID="checkbox2" Text="B" ValidationGroup="check" />          
                        </div>
                        <div id="D14" runat="server" visible="false" style="margin:0px 0px 15px 0px">
                            <asp:Label runat="server" Text="Option 3: " AssociatedControlID="TextBox9" />
                            <asp:TextBox runat="server" ID="TextBox9" /> &nbsp;  
                            <asp:CheckBox runat="server" Checked="false" ID="checkbox3" Text="C" ValidationGroup="check" />           
                        </div>
                        <div id="D15" runat="server" visible="false" style="margin:0px 0px 15px 0px">
                            <asp:Label runat="server" Text="Option 4: " AssociatedControlID="TextBox10" />
                            <asp:TextBox runat="server" ID="TextBox10" /> &nbsp;  
                            <asp:CheckBox runat="server" Checked="false" ID="checkbox4" Text="D" ValidationGroup="check" />
                        </div>
                        <div id="D16" runat="server" visible="false" style="margin:0px 0px 15px 0px">
                            <asp:Label runat="server" Text="Option 5: " AssociatedControlID="TextBox11" />
                            <asp:TextBox runat="server" ID="TextBox11" />&nbsp;  
                            <asp:CheckBox runat="server" Checked="false" ID="checkbox5" Text="E" ValidationGroup="check" />
                        </div>
                        <div id="D17" runat="server" visible="false" style="margin:0px 0px 15px 0px">
                            <asp:Label runat="server" Text="Enter Correct Letter from options. ex. A, .., E" ID="anslabel" /> <br />
                            <asp:Label runat="server" Text="Answer: " AssociatedControlID="TextBox12" />
                            <asp:TextBox runat="server" ID="TextBox12" />                
                        </div>
                        <div id="D18" runat="server" visible="false" style="margin:0px 0px 15px 0px">
                            <asp:Button runat="server" Text="Add Question" ID="Addquestion" OnClick="Addquestion_Click" />&nbsp;
                            <asp:Button runat="server" Text="Save" ID="Save" OnClick="Save_Click" />
                        </div>

                    </td>
                </tr>
            </table>
        </asp:View>
    </asp:MultiView>
</asp:Content>

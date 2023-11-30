<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    
    <style>
        .repeater-item {
            border: 3px solid #ddd; /* Add your preferred border style here */
            padding: 5px; /* Adjust padding as needed */
            margin-bottom: 1px; /* Adjust margin as needed */
            
        }
    </style>
     
    <script type="text/javascript">
         function itemClick(id) {
             // You can perform additional client-side logic here if needed
             __doPostBack('', 'ItemClick;' + id); // Trigger server-side click event
             return false; // Prevent default anchor behavior
         }
    </script>

    <div runat="server" id="d_u" style="margin:25px 0px 0px 0px; border:1px solid gray;">
        <asp:LinkButton runat="server" Text="Create Quiz"></asp:LinkButton> | 
        <asp:LinkButton runat="server" Text="Attend Quiz" OnClick="attendquiz"></asp:LinkButton> | 
        <asp:LinkButton runat="server" Text="Manage Quiz"></asp:LinkButton> | 
        <asp:LinkButton runat="server" Text="Manage Quiz"></asp:LinkButton>
    </div>


    <div class="jumbotron" Height="90%" Width="90%">
        <div runat="server" style="align-content:center;" class="text-center"><p><asp:LinkButton runat="server" onclick="upcommingdata">Upcomming</asp:LinkButton> | <asp:LinkButton runat="server" onclick="currentdata">Running</asp:LinkButton> | <asp:LinkButton runat="server" onclick="pastdata">Past</asp:LinkButton></p></div>
        
            <asp:Repeater ID="Repeater1" runat="server" OnItemCommand="myRepeater_ItemCommand">
                <ItemTemplate>
                    <a href="#" class="repeater-item-link" onclick="return itemClick('<%# Eval("UserId") %>')">
                        <div class="repeater-item">
                            ID: <%# Eval("UserId") %><br />
                            Name: <%# Eval("Role") %><br />
                        </div>
                    </a>
                </ItemTemplate>
            </asp:Repeater>

           
        
       <!-- <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p> -->
    </div>

</asp:Content>

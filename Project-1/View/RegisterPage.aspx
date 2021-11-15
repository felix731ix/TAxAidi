<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="Project_1.View.RegisterPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style10 {
            width: 158px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Register Page</h2>
    <div>
        <table>
            <tr>
                <td class="auto-style10">Name</td>
                <td><asp:TextBox ID="txtName" runat="server" /></td>
                <td>
                    <asp:Label ID="errName" Text="" runat="server" ForeColor="Red"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Username</td>
                <td><asp:TextBox ID="txtUsername" runat="server" /></td>
                 <td>
                    <asp:Label ID="errUsername" Text="" runat="server" ForeColor="Red"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Password</td>
                <td class="auto-style3"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"/></td>
                 <td>
                    <asp:Label ID="errPassword" Text="" runat="server" ForeColor="Red"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Confirmation Password</td>
                <td><asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" /></td>
                 <td>
                    <asp:Label ID="errConfirmPassword" Text="" runat="server" ForeColor="Red"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Roles</td>
                <td>
                    <asp:DropDownList ID="txtRoles" runat="server" Height="16px" Width="74px">
                        <asp:ListItem Text="Seller" />
                        <asp:ListItem Text="Buyer" />
                    </asp:DropDownList></td>
            </tr>
        </table>
    </div>
    <div>
        <asp:Button ID="btnRegister" Text="Register" runat="server" OnClick="btnRegister_Click"/>
    </div>
    <br />
    <a href="LoginPage.aspx">Already have an account?</a>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="Project_1.View.LoginPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Login Page</h2>
    <div>
        <table>
            <tr>
                <td class="auto-style1">Username</td>
                <td><asp:TextBox ID="txtUsername" runat="server" /></td>
                <td><asp:Label ID="errUsername" Text="" runat="server" ForeColor="Red"/></td>
            </tr>
            <tr>
                <td class="auto-style1">Password</td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"/></td>
                <td><asp:Label ID="errPassword" Text="" runat="server" ForeColor="Red"/></td>
            </tr>
            <tr>
                <td class="auto-style1">
                    <asp:CheckBox ID="checkRememberMe" Text="Remember Me?" runat="server" />
                </td>
                <td>
                     <asp:Label ID="lblError" Text="" runat="server" ForeColor="Red" />
                </td>
            </tr>
        </table>
        <asp:Button ID="btnLogin" Text="Login" runat="server" OnClick="btnLogin_Click"/>
        <br />
        <br />
        <a href="RegisterPage.aspx">Don't have an account?</a>
    </div>
</asp:Content>

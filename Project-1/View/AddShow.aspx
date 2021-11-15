<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="AddShow.aspx.cs" Inherits="Project_1.View.AddShow" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style10 {
            width: 172px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Add Show</h2>
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
                <td class="auto-style10">URL</td>
                <td>
                    <asp:TextBox ID="txtUrl" runat="server" />
                </td>
                <td>
                     <asp:RegularExpressionValidator ID="RegularExpressionValidator1" ErrorMessage="Invalid URL" ControlToValidate="txtUrl" runat="server" ForeColor="Red" ValidationExpression="http(s)?://([\w-]+\.)+[\w-]+(/[\w- ./?%&amp;=]*)?" />
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Description</td>
                <td class="auto-style3"><asp:TextBox ID="txtDescription" runat="server"/></td>
                 <td>
                    <asp:Label ID="errDescription" Text="" runat="server" ForeColor="Red"/>
                </td>
            </tr>
            <tr>
                <td class="auto-style10">Price</td>
                <td><asp:TextBox ID="txtPrice" runat="server" TextMode="Number" Text="1000"/></td>
                 <td>
                    <asp:Label ID="errPrice" Text="" runat="server" ForeColor="Red"/>
                </td>
            </tr>
        </table>
        <asp:Label ID="lblSuccess" Text="" runat="server" ForeColor="Green"/>
    </div>
    <div>
        <asp:Button ID="btnAddShows" Text="Add Show" runat="server" OnClick="btnAddShows_Click"/>
    </div>
</asp:Content>

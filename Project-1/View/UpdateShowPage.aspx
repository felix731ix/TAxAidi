<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="UpdateShowPage.aspx.cs" Inherits="Project_1.View.UpdateShowPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Show</h2>
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
                <td><asp:TextBox ID="txtPrice" runat="server" TextMode="Number"/></td>
                 <td>
                    <asp:Label ID="errPrice" Text="" runat="server" ForeColor="Red"/>
                </td>
            </tr>
        </table>
        <asp:Label ID="lblSuccess" Text="" runat="server" ForeColor="Green"/>
    </div>
    <div>
        <asp:Button ID="btnUpdateShow" Text="Update" runat="server" OnClick="btnUpdateShow_Click"/>
    </div>
</asp:Content>

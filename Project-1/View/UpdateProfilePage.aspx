<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="UpdateProfilePage.aspx.cs" Inherits="Project_1.View.UpdateProfilePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style10 {
            width: 158px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <h2>Update Profile Page</h2>
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
                <td class="auto-style10">Old Password</td>
                <td class="auto-style3"><asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"/></td>
                 <td>
                    <asp:Label ID="errOldPassword" Text="" runat="server" ForeColor="Red"/>
                </td>
            </tr>

            <tr>
                <td class="auto-style10">New Password</td>
                <td class="auto-style3"><asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"/></td>
            </tr>
            <tr>
                <td class="auto-style10">Confirmation Password</td>
                <td><asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" /></td>
                 <td>
                    <asp:Label ID="errConfirmPassword" Text="" runat="server" ForeColor="Red"/>
                </td>
            </tr>
           
        </table>
    </div>
    <div>
        <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click"/>
    </div>
  
</asp:Content>

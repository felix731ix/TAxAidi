<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="RedeemToken.aspx.cs" Inherits="Project_1.View.RedeemToken" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        #main {
            margin-left: auto;
            margin-right: auto;
            margin-top:100px;
            width: 560px
        }
        .btnRedeem {
            background-color: rgb(38, 165, 154);
            height: 30px;
            margin-top :20px;
            border-radius: 4px;
            color: white;
            font-weight: bold;
            border: none;
            margin: 5px;
        }


    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />

    <div id="main">
        <asp:TextBox ID="txtToken" placeholder="Enter your token here" style="text-align: center; font-size: 32pt; font-weight :800" runat="server" />
        <asp:Button ID="btnRedeem" CssClass="btnRedeem" Text="Redeem Token" style="margin-left:260px; margin-top:20px;" runat="server" OnClick="btnRedeem_Click"/>
        <br />
        <br />

        <asp:Label ID="errToken" Text="" style="text-align: center; margin-left:172px; color:red" runat="server" />
    </div>

</asp:Content>

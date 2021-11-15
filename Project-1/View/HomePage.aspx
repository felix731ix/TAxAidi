<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="HomePage.aspx.cs" Inherits="Project_1.View.HomePage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Home Page</h2>
        
    <br />
    <br />
    <asp:Label ID="lblData" Text="" runat="server" />
    <br />
    <asp:GridView runat="server" ID="grdView" AutoGenerateColumns="False" OnRowCommand="grdView_RowCommand">
        <Columns>
            <asp:BoundField DataField="Title" HeaderText="Title">
            <ItemStyle HorizontalAlign="Center" Width="150px" />
            </asp:BoundField>
            <asp:BoundField DataField="Price" HeaderText="Price">
            <ItemStyle HorizontalAlign="Center" Width="100px" />
            </asp:BoundField>
            <asp:BoundField DataField="Name" HeaderText="Seller Name">
            <ItemStyle HorizontalAlign="Center" Width="200px" />
            </asp:BoundField>
            <asp:BoundField DataField="Description" HeaderText="Description">
            <ItemStyle HorizontalAlign="Justify" Width="800px" />
            </asp:BoundField>
            <asp:ButtonField ButtonType="Button" Text="Show Detail" CommandName="showDetail">
            <ItemStyle HorizontalAlign="Center" Width="150px" />
            </asp:ButtonField>
        </Columns>
    </asp:GridView>
</asp:Content>

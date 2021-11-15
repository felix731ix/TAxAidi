<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="TransactionsPage.aspx.cs" Inherits="Project_1.View.TransactionsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .grd:hover{
            background-color:dimgray;
            border-width: thick;
            font-weight:bolder;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <br />
    <br />
    <asp:GridView ID="grdView" AutoGenerateColumns="false"
        OnSelectedIndexChanged="grdView_SelectedIndexChanged" 
        OnRowDataBound="grdView_RowDataBound" runat="server"
        RowStyle-CssClass="grd">
        <Columns>

            <asp:BoundField DataField="HeaderId" HeaderText="Header ID">
                <ItemStyle HorizontalAlign="Center" Width="120px" />
            </asp:BoundField>

            <asp:BoundField DataField="CreatedAt" HeaderText="Payment Date">
                <ItemStyle HorizontalAlign="Center" Width="150px" />
            </asp:BoundField>

            <asp:BoundField DataField="ShowName" HeaderText="Show Name">
                <ItemStyle HorizontalAlign="Center" Width="150px" />
            </asp:BoundField>

            <asp:BoundField DataField="ShowTime" HeaderText="Show Time">
                <ItemStyle HorizontalAlign="Center" Width="150px" />
            </asp:BoundField>


            <asp:BoundField DataField="Quantity" HeaderText="Quantity">
                <ItemStyle HorizontalAlign="Center" Width="90px" />
            </asp:BoundField>

            <asp:BoundField DataField="TotalPrice" HeaderText="Total Price">
                <ItemStyle HorizontalAlign="Center" Width="130px" />
            </asp:BoundField>

        </Columns>
    </asp:GridView>
</asp:Content>

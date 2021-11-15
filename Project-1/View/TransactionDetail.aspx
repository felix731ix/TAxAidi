<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="Project_1.View.TransactionDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .btnCancel {
            background-color: rgb(245, 54, 73);
            height: 30px;
            width: 10%;
            border-radius: 4px;
            color: white;
            font-weight: bold;
            border: none;
            margin: 5px;
        }
    </style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h2>Transaction Detail Page</h2>

    <div>
        <table>
            <tr>
                <td class="auto-style9">Show Name</td>
                <td>
                    <asp:Label ID="showName" Text="" runat="server" />
                </td>
            </tr>
    
            <tr>
                <td class="auto-style9">Average Rating</td>
                <td>
                    <asp:Label ID="showAvg" Text="" runat="server" />
                </td>
            </tr>

            <tr>
                <td class="auto-style9">Description</td>
                <td>
                    <asp:Label ID="showDesc" Text="" runat="server" />
                </td>
            </tr>

        </table>
        <br />
        <br />
        <br />
        <asp:GridView ID="grdView" AutoGenerateColumns="false" runat="server">
        <Columns>

            <asp:BoundField DataField="Token" HeaderText="Token">
                <ItemStyle HorizontalAlign="Center" Width="150px" />
            </asp:BoundField>

            <asp:BoundField DataField="Status" HeaderText="Token Status">
                <ItemStyle HorizontalAlign="Center" Width="150px" />
            </asp:BoundField>

        </Columns>
    </asp:GridView>
        <br />
        <div>
            <asp:Button CssClass="btnCancel" ID="btnCancel" Text="Cancel" runat="server" OnClick="btnCancel_Click"/>
            <br />
            <asp:Label ID="errCancel" Text="" runat="server" Font-Bold="true" />
        </div>


    </div>
</asp:Content>

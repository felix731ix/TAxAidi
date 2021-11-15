<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="ShowDetailPage.aspx.cs" Inherits="Project_1.View.ShowDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Show Detail Page</h2>
    <div>
        <table>
            <tr>
                <td class="auto-style9">Name</td>
                <td>
                    <asp:Label ID="showName" Text="" runat="server" />
                </td>
            </tr>

            <tr>
                <td class="auto-style9">Price</td>
                <td>
                    <asp:Label ID="showPrice" Text="" runat="server" />
                </td>
            </tr>

            <tr>
                <td class="auto-style9">Seller Name</td>
                <td>
                    <asp:Label ID="showSeller" Text="" runat="server" />
                </td>
            </tr>

            <tr>
                <td class="auto-style9">Description</td>
                <td>
                    <asp:Label ID="showDesc" Text="" runat="server" />
                </td>
            </tr>

            <tr>
                <td class="auto-style9">Average Rating</td>
                <td>
                    <asp:Label ID="showAvg" Text="" runat="server" />
                </td>
            </tr>

        </table>

        <h3>Review</h3>
        <asp:GridView runat="server" ID="grdView" AutoGenerateColumns="False">
        <Columns>
            <asp:BoundField DataField="Description" HeaderText="Review Description">
            <ItemStyle HorizontalAlign="Center" Width="500px" />
            </asp:BoundField>

            <asp:BoundField DataField="Rating" HeaderText="Rating">
            <ItemStyle HorizontalAlign="Center" Width="50px" />
            </asp:BoundField>
        </Columns>
    </asp:GridView>
        <br />
        <div>
            <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click" Visible="false" />
            <asp:Button ID="btnOrder" Text="Order" runat="server" OnClick="btnOrder_Click" Visible="false" />
        </div>

    </div>



</asp:Content>

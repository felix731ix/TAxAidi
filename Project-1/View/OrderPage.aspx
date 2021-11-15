<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="OrderPage.aspx.cs" Inherits="Project_1.View.OrderPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .btnOrder {
            background-color: rgb(38, 165, 154);
            height: 30px;
            width: 90%;
            border-radius: 4px;
            color: white;
            font-weight: bold;
            border: none;
            margin: 5px;
        }

    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <h2>Order Page</h2>
    <div>

        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>

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

                    <tr>
                        <td class="auto-style10">Quantity</td>
                        <td>
                            <asp:TextBox ID="txtQty" TextMode="Number" runat="server" /></td>
                        <td>
                            <asp:Label ID="errQty" Text="" runat="server" ForeColor="Red" />
                        </td>
                    </tr>

                </table>

                <p>Choose Date</p>

                <asp:Calendar ID="DatePick" runat="server"></asp:Calendar>
                <br />
                <p>Available Show Time</p>
                <asp:GridView runat="server" ID="grdView" AutoGenerateColumns="False" OnRowCommand="grdView_RowCommand" OnRowDataBound="grdView_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="startShow" HeaderText="Show Time">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundField>

                        <%--<asp:TemplateField ShowHeader="false"> <ItemStyle HorizontalAlign="Center" Width="150px" />
                    <ItemTemplate>
                            <asp:Button CssClass="btnOrder" ID="btnOrder1" runat="server" Text="Order" CommandName="order" CommandArgument="<%# ((GridViewRow) Container).RowIndex %>"/>
        
                            <%--<asp:Button CssClass="btnUnavailable" ID="btnUnavailable1" runat="server" Text="Unavailable" Visible="false"/>--%>
                        <%--</ItemTemplate>
                </asp:TemplateField>--%>
                        <asp:ButtonField ControlStyle-CssClass="btnOrder" ButtonType="button" Text="Order" CommandName="order" ShowHeader="false" ItemStyle-BorderWidth="0px">
                            <ItemStyle HorizontalAlign="center" Width="150px" />
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>

        </asp:UpdatePanel>
    </div>
    <div>
        <asp:Label ID="lblSuccess" Text="" ForeColor="Green" runat="server" />
    </div>
</asp:Content>

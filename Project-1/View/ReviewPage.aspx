<%@ Page Title="" Language="C#" MasterPageFile="~/View/Main.Master" AutoEventWireup="true" CodeBehind="ReviewPage.aspx.cs" Inherits="Project_1.View.ReviewPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <table>
            <tr>
                <td class="auto-style9">Name</td>
                <td>
                    <asp:Label ID="showName" Text="" runat="server" />
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

        </table>
        
        <h2>Rate the show</h2>

        <table>
            
            <tr>
                <td class="auto-style9">Rating</td>
                <td class="auto-style9">
                    <asp:TextBox ID="txtRate" TextMode="Number" Text="" placeholder="Must be numeric and at least 1 and at most 5" runat="server" />
                </td>
                <td>
                    <asp:Label ID="errRate" Text="" runat="server" ForeColor="Red" />
                </td>
            </tr>



            <tr>
                <td class="auto-style9">Description</td>
                <td class="auto-style9">
                    <asp:TextBox runat="server" Text="" placeholder="Must be filled" ID="txtDescRate" TextMode="MultiLine" Rows="5" />
                </td>
                <td>
                    <asp:Label ID="errDescRate" Text="" runat="server" ForeColor="Red" />
                </td>
            </tr>

        </table>
            
        <br />
        <br />
        <asp:Button ID="btnRate" Text="Rate" runat="server" OnClick="btnRate_Click" Visible="false"/>
        <asp:Button ID="btnUpdate" Text="Update" runat="server" OnClick="btnUpdate_Click" Visible="false"/>
        <asp:Button ID="btnDelete" Text="Delete" runat="server" OnClick="btnDelete_Click" Visible="false"/>
        <br />
        <asp:Label ID="reviewConfirm" Text="" runat="server" ForeColor="Green"/>
    </div>
</asp:Content>

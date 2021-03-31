<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TicTacToe.aspx.cs" Inherits="TicTacToe.TicTacToe" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
     <asp:Panel ID="Alert" runat="server" Font-Size="Medium">You do not have access to this page.</asp:Panel>
    <asp:Panel ID="Board" runat="server">
        <p><asp:Label ID="Status" runat="server" Font-Size="Large"></asp:Label></p>
        <div class="bottom right">
            <asp:Button ID="Btn11" runat="server" OnClick="Btn11Click" />
            <asp:Image ID="Img11" runat="server" Visible="False" />
        </div>
        <div class="left bottom right">
            <asp:Button ID="Btn12" runat="server" OnClick="Btn12Click" />
            <asp:Image ID="Img12" runat="server" Visible="False" />
        </div>
        <div class="left bottom">
            <asp:Button ID="Btn13" runat="server" OnClick="Btn13Click" />
            <asp:Image ID="Img13" runat="server" Visible="False" />
        </div>

        <div class="top right bottom">
            <asp:Button ID="Btn21" runat="server" OnClick="Btn21Click" />
            <asp:Image ID="Img21" runat="server" Visible="False" />
        </div>
        <div class="top right bottom left">
            <asp:Button ID="Btn22" runat="server" OnClick="Btn22Click" />
            <asp:Image ID="Img22" runat="server" Visible="False" />
        </div>
        <div class="top left bottom">
            <asp:Button ID="Btn23" runat="server" OnClick="Btn23Click" />
            <asp:Image ID="Img23" runat="server" Visible="False" />
        </div>

        <div class="top right">
            <asp:Button ID="Btn31" runat="server" OnClick="Btn31Click" />
            <asp:Image ID="Img31" runat="server" Visible="False" />
        </div>
        <div class="left top right">
            <asp:Button ID="Btn32" runat="server" OnClick="Btn32Click" />
            <asp:Image ID="Img32" runat="server" Visible="False" />
        </div>
        <div class="top left">
            <asp:Button ID="Btn33" runat="server" OnClick="Btn33Click" />
            <asp:Image ID="Img33" runat="server" Visible="False" />
        </div>
    </asp:Panel>
   
</asp:Content>

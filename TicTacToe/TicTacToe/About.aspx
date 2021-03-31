<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TicTacToe.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   <h1>Rules of Tic-Tac-Toe</h1>
    <ul>
                        <li>The game is played on a grid that's 3 squares by 3 squares.</li>
                        <li>One player is X, and the other is O. Players take turns putting their marks in empty squares.</li>
                        <li>The first player to get 3 of her marks in a row (up, down, across, or diagonally) is the winner.</li>
                        <li>When all 9 squares are full, the game is over. If no player has 3 marks in a row, the game ends in a tie.</li>
                      
    </ul>
  
       <p>Click <a runat="server" href="~/TicTacToe.aspx">here</a> to play the game.</p>
</asp:Content>

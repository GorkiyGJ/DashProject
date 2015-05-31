<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register TagPrefix="dash" TagName="Player" Src="~/mod/Player.ascx" %> 

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
    
    <dash:Player runat="server"></dash:Player>   
   
</asp:Content>

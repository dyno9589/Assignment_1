<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="LoginForm.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:DropDownList ID="DropDownList1" runat="server" >
        <asp:ListItem>Choose any</asp:ListItem>
        <asp:ListItem>aa</asp:ListItem>
        <asp:ListItem>bb</asp:ListItem>
        <asp:ListItem>cc</asp:ListItem>
    </asp:DropDownList>
    <br/>

    <asp:Button ID="Button1" runat="server" Text="Button" OnClick="Button1_Click" />
    <br/>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    </asp:Content>

<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LoginForm._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1 class="">Login Page</h1>




    <form class="login form">
        <div class="form-group">
            <label for="emailInp">Email address</label>
            <input type="email" class="form-control" runat="server" id="emailInp" aria-describedby="emailHelp" placeholder="Enter email">
            <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
        </div>
        <div class="form-group">
            <label for="passinp">Password</label>
            <input type="password" class="form-control" runat="server" id="passInp" placeholder="Password">
        </div>
        <div class="form-check">
            <input type="checkbox" class="form-check-input" runat="server" id="chkbox">
            <label class="form-check-label" for="exampleCheck1">Remember me</label>
        </div>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
        <br />
        <br />

    <a runat="server" href="~/register">Not registered? Signup here.</a>



    </form>
    <asp:Label ID="lbl" runat="server">status</asp:Label>




</asp:Content>

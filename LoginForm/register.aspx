<%@ Page Title="Register" Language="C#" AutoEventWireup="true" MasterPageFile="~/Site.Master" CodeBehind="register.aspx.cs" Inherits="LoginForm.services" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <h1 runat="server">Register Page</h1>


    <form class="register form">
        <div class="form-group">
            <label for="regemailInp">Email address</label>
            <input type="email" class="form-control" runat="server" id="regemailInp" aria-describedby="emailHelp" placeholder="Enter email">
            <small id="emailHelp" class="form-text text-muted">We'll never share your email with anyone else.</small>
        </div>
        <div class="form-group">
            <label for="regpassinp">Set Password</label>
            <input type="password" class="form-control" runat="server" id="regpassInp" placeholder="Enter Password">
        </div>
        <div class="form-group">
            <label for="regcpassinp">Confirm Password</label>
            <input type="password" class="form-control" runat="server" id="regcpassinp" placeholder="Enter Password again">
        </div>

        <asp:Button ID="regbtn" runat="server" Text="Register" OnClick="regbtn_Click" Width="71px" />
    &nbsp;
        <a runat="server" href="~/"><asp:Button ID="regbtncan" runat="server" Text="Cancel" OnClick="regbtncan_Click" /></a>
        <br />
        <br />

        <a runat="server" href="~/">Already a user? Login here.</a>

    </form>

    <br /><br />
    <asp:Label ID="reglbl" runat="server" ForeColor="Green">status</asp:Label>


    </form>


</asp:Content>


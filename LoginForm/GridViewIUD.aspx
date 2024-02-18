<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="GridViewIUD.aspx.cs" Inherits="LoginForm.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
  
    <asp:GridView ID="gvEmployee" runat="server" AutoGenerateColumns="false" ShowFooter="true" DataKeyNames="Empid"
        ShowHeaderWhenEmpty="true"
        OnRowCommand="gvEmployee_RowCommand" OnRowEditing="gvEmployee_RowEditing" OnRowCancelingEdit="gvEmployee_RowCancelingEdit" OnRowUpdating="gvEmployee_RowUpdating" OnRowDeleting="gvEmployee_RowDeleting"

        BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3">
        <%-- Theme Properties--%>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />

        <Columns>
            <asp:TemplateField HeaderText="First Name">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("FirstName") %>' runat="server"  ></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtFirstName" Text='<%# Eval("FirstName") %>' runat="server" />          
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtFirstNameFooter"  runat="server" />          
                </FooterTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Last Name">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("LastName") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtLastName" Text='<%# Eval("LastName") %>' runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtLastNameFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Contact">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Contact") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtContact" Text='<%# Eval("Contact") %>' runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtContactFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>


            <asp:TemplateField HeaderText="Email">
                <ItemTemplate>
                    <asp:Label Text='<%# Eval("Email") %>' runat="server"></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="txtEmail" Text='<%# Eval("Email") %>' runat="server" />
                </EditItemTemplate>
                <FooterTemplate>
                    <asp:TextBox ID="txtEmailFooter" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>


            <asp:TemplateField>
                <ItemTemplate>
                    <asp:ImageButton ImageUrl="~/Icons/edit_icon.png" runat="server" CommandName="Edit" ToolTip="Edit" Width="20px" Height="20px" />
                    <asp:ImageButton ImageUrl="~/Icons/remove_icon.png" runat="server" CommandName="Delete" ToolTip="Delete" Width="20px" Height="20px" />

                </ItemTemplate>

                <EditItemTemplate>
                    <asp:ImageButton ImageUrl="~/Icons/save_icon.png" runat="server" CommandName="Update" ToolTip="Update" Width="20px" Height="20px" />
                    <asp:ImageButton ImageUrl="~/Icons/cancel_icon.png" runat="server" CommandName="Cancel" ToolTip="Cancel" Width="20px" Height="20px" />

                </EditItemTemplate>

                <FooterTemplate>
                    <asp:ImageButton ImageUrl="~/Icons/add_new.png" runat="server" CommandName="AddNew" ToolTip="Add New" Width="20px" Height="20px" />

                </FooterTemplate>

            </asp:TemplateField>
        </Columns>

    </asp:GridView>

    <br/>

    <asp:Label ID="lblSuccessMessage" Text="" runat="server" ForeColor="Green"/>
    
    <br />
    <asp:Label ID="lblErrorMessage" Text="" runat="server" ForeColor="Red"/>


  
    </asp:Content>

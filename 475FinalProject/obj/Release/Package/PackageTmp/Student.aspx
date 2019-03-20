<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="_475FinalProject.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>&nbsp;:SignUp</h2>
    <p>&nbsp;</p>
<p>Please enter the following information. Non-skippable information *.</p>
<p>&nbsp;</p>
<p>
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
</p>
<p>&nbsp;</p>
<p>Student ID*</p>
<p>
    <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
</p>
<p>&nbsp;</p>
<p>First Name*</p>
<p>
    <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
</p>
<p>&nbsp;</p>
<p>Middle Name</p>
<p>
    <asp:TextBox ID="TextBox3" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
</p>
<p>&nbsp;</p>
<p>Last Name*</p>
<p>
    <asp:TextBox ID="TextBox4" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
</p>
<p>&nbsp;</p>
<p>Email*</p>
<p>
    <asp:TextBox ID="TextBox5" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
</p>
<p>&nbsp;</p>
<p>Password*</p>
<p>
    <asp:TextBox ID="TextBox6" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
</p>
<p>&nbsp;</p>
<p>Confirm Password*</p>
<p>
    <asp:TextBox ID="TextBox7" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
</p>
<p>&nbsp;</p>
<p>&nbsp;</p>
<p>
    <asp:Button ID="Button1" runat="server" Text="Submit Information" OnClick="Button1_Click" />
</p>
</asp:Content>

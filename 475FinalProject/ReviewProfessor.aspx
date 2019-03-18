<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReviewProfessor.aspx.cs" Inherits="_475FinalProject.ReviewProfessor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button2" runat="server" Height="21px" OnClick="Button2_Click" Text="Home" Width="51px" />
            <br />
            <br />
            <asp:Label ID="Label2" runat="server" Text="Add a Completed Course:"></asp:Label>
            <br />
            <br />
            Department (e.g. CSS):<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Class Level (e.g. 475):<br />
            <asp:TextBox ID="TextBox3" runat="server" Height="16px" OnTextChanged="TextBox3_TextChanged"></asp:TextBox>
            <br />
            <br />
            Professor First Name:<br />
            <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
            <br />
            <br />
            Professor Last Name:<br />
            <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
            <br />
            <br />
            Style (See numbers below):<br />
            <asp:TextBox ID="TextBox6" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="StyleTable"></asp:Label>
            <br />
            <br />
            Teacher Score (0 - 100):<br />
            <asp:TextBox ID="TextBox7" runat="server"></asp:TextBox>
            <br />
            <br />
            Work Load (1-5):<br />
            <asp:TextBox ID="TextBox8" runat="server"></asp:TextBox>
            <br />
            <br />
            Grade Received (0 - 40):<br />
            <asp:TextBox ID="TextBox9" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Please Enter a Review Here (or enter &quot;NULL&quot; for no review) :"></asp:Label>
            <br />
        </div>
        <asp:TextBox ID="TextBox1" runat="server" Height="200px" Width="400px"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="SHOUTOUT TO JOHN"></asp:Label>
    </form>
</body>
</html>


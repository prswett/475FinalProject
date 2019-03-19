<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProfessorInfo.aspx.cs" Inherits="_475FinalProject.ProfessorInfo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Search by Professor: "></asp:Label>
        <br />
        <br />
        FirstName:<p>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            LastName:</p>
        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search" />
        <br />
        <asp:Label ID="Label2" runat="server" Text="TEAM SBD SHOUTOUT"></asp:Label>
    </form>
</body>
</html>

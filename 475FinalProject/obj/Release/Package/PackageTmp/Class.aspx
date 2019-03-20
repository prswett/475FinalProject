<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Class.aspx.cs" Inherits="_475FinalProject.Class" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        </div>
        <p>
            Department (CSS)&nbsp;&nbsp;&nbsp; Level (475, 422, etc)</p>
        <asp:TextBox ID="TextBox1" runat="server" OnTextChanged="TextBox1_TextChanged"></asp:TextBox>
        <asp:TextBox ID="TextBox2" runat="server" OnTextChanged="TextBox2_TextChanged"></asp:TextBox>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Search For Class" />
        </p>
        <p>
            <asp:Label ID="Label2" runat="server" Text="Results"></asp:Label>
        </p>
        <p style="margin-top: 21px">
            &nbsp;</p>
        <p style="margin-top: 21px">
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click1" Text="Back To Class Search" />
        </p>
    </form>
</body>
</html>


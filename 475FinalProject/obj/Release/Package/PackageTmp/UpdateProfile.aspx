<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateProfile.aspx.cs" Inherits="_475FinalProject.UpdateProfile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Audit Degree" />
            <br />
            <br />
            <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="Add Completed Course" />
            <br />
            <br />
            <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="Delete Account" />
            <br />
            <br />
            Department:<br />
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <br />
            <br />
            Level:<br />
            <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            <br />
            <br />
            <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Delete Completed Course" />
            <br />
            <br />
            Change Degree (Select From Below):<br />
            <asp:DropDownList ID="DropDownList1" runat="server">
                <asp:ListItem Value="1">1: Computer Science</asp:ListItem>
                <asp:ListItem Value="2">2: Physics</asp:ListItem>
                <asp:ListItem Value="3">3: Biology</asp:ListItem>
                <asp:ListItem Value="4">4: Psychology</asp:ListItem>
                <asp:ListItem Value="5">5: English</asp:ListItem>
                <asp:ListItem Value="6">6: Political Science</asp:ListItem>
                <asp:ListItem Value="7">7: Business</asp:ListItem>
            </asp:DropDownList>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Update Degree" />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
        </div>
    </form>
</body>
</html>

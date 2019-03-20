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
            Style (Select Below):<br />
            <asp:DropDownList ID="DropDownList1" runat="server" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Value="0">0: Tough Grader</asp:ListItem>
                <asp:ListItem Value="1">1: Amazing Lecturer</asp:ListItem>
                <asp:ListItem Value="2">2: Old-School</asp:ListItem>
                <asp:ListItem Value="3">3: Chill</asp:ListItem>
                <asp:ListItem Value="4">4: Lots of Reading</asp:ListItem>
                <asp:ListItem Value="5">5: Inspirational</asp:ListItem>
                <asp:ListItem Value="6">6: Leaves the Comfort Zone</asp:ListItem>
                <asp:ListItem Value="7">7: Assigns Busy-Work</asp:ListItem>
                <asp:ListItem Value="8">8: Promotes Participation</asp:ListItem>
                <asp:ListItem Value="9">9: Ambiguous Grader</asp:ListItem>
                <asp:ListItem Value="10">10: By The Book</asp:ListItem>
            </asp:DropDownList>
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
            <asp:Label ID="Label1" runat="server" Text="Please Enter a Review Here:"></asp:Label>
            <br />
        </div>
        <asp:TextBox ID="TextBox1" runat="server" Height="200px" Width="400px" Columns="10" Rows="10" TextMode="MultiLine"></asp:TextBox>
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


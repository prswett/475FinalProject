<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AuditDegree.aspx.cs" Inherits="_475FinalProject.AuditDegree" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <p>
                <strong>CSSE Degree Courses:</strong></p>
            <p>
                Required Courses:</p>
        </div>
        <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        Required Classifications:<br />
        <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        General CSS Courses:<br />
        <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        General Electives:<br />
        <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
        <br />
        <br />
        Total Credits for Graduation:<br />
        <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
        <br />
        ------------------------------------------------<p>
            <strong>Your Current Degree Progress:</strong></p>
        <p>
            Your Specific Classes Needed:</p>
        <p>
            <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            Your Current Classifications:</p>
        <p>
            <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
        </p>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="MessageClient._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        Choose a link<br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Sender.aspx">Sender</asp:HyperLink>
        <br />
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Receiver.aspx">Receiver</asp:HyperLink>
    </form>
</body>
</html>

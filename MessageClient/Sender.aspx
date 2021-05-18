<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sender.aspx.cs" Inherits="MessageClient.Sender" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Sender Page&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Receiver.aspx">Receiver</asp:HyperLink>
        </div>
        <p>
            Sender ID
            <asp:TextBox ID="SenderTB" runat="server"></asp:TextBox>
        </p>
        <p>
            ReceiverID
            <asp:TextBox ID="ReceiverTB" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            Message</p>
        <p>
&nbsp;<asp:TextBox ID="MessageTB" runat="server" Height="182px" Width="369px"></asp:TextBox>
        </p>
        <asp:Button ID="SendButton" runat="server" OnClick="SendButton_Click" Text="Send" Width="377px" />
    </form>
</body>
</html>

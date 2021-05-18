<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receiver.aspx.cs" Inherits="MessageClient.Receiver" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #TextArea1 {
            height: 171px;
            width: 377px;
        }
        #MessageTB {
            height: 168px;
            width: 390px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Receiver Page&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Sender.aspx">Sender</asp:HyperLink>
        </div>
        <p>
            Receiver ID
            <asp:TextBox ID="ReceiverTB" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="ReceiverButton" runat="server" Text="Receive" OnClick="ReceiverButton_Click" />
        </p>
        <p>
            <asp:CheckBox ID="PurgeCB" runat="server" Text="Purge" />
        </p>
    <p>
        Message:</p>
    <p>
        <asp:TextBox ID="MessageTB" runat="server" Height="241px" ReadOnly="True" TextMode="MultiLine" Width="425px"></asp:TextBox>
        </p>
    </form>
    </body>
</html>

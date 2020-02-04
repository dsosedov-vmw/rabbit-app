<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Receive.aspx.cs" Inherits="RMQApp.Web.Receive" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Receive | RabbitMQ App</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <h3>Receive</h3>
                <p>
                    <a href="/">Home</a> | <a href="Send.aspx">Send</a>
                </p>
                <p>
                    <asp:Button ID="btnReceive" runat="server" Text="Receive" OnClick="btnReceive_Click" />
                </p>
                <p>
                    <asp:Literal ID="litMessage" runat="server" />
                </p>
            </div>
        </form>
    </body>
</html>

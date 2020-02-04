<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="RMQApp.Web.Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>RabbitMQ App</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <h3>RabbitMQ App</h3>
                <p>
                    <a href="Send.aspx">Send</a> | <a href="Receive.aspx">Receive</a>
                </p>
                <p>
                    <asp:Literal ID="litMessage" runat="server" />
                </p>
            </div>
        </form>
    </body>
</html>

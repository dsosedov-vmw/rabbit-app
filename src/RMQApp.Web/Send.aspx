<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Send.aspx.cs" Inherits="RMQApp.Web.Send" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
        <title>Send | RabbitMQ App</title>
    </head>
    <body>
        <form id="form1" runat="server">
            <div>
                <h3>Send</h3>
                <p>
                    <a href="/">Home</a> | <a href="Receive.aspx">Receive</a>
                </p>
                <p>
                    <asp:TextBox ID="txtMessage" runat="server" />
                    <asp:Button ID="btnSend" runat="server" Text="Send" OnClick="btnSend_Click" />
                </p>
                <p>
                    <asp:Literal ID="litMessage" runat="server" />
                </p>
            </div>
        </form>
    </body>
</html>

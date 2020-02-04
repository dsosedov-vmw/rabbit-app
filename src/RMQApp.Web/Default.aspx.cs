using System;

namespace RMQApp.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    if (QueueConnector.Instance.IsOpen())
                    {
                        litMessage.Text = "Connection established successfully";
                    }
                    else
                    {
                        litMessage.Text = "Connection established successfully but it's closed";
                    }
                }
                catch (Exception ex)
                {
                    litMessage.Text = ex.Message;
                }
            }
        }
    }
}

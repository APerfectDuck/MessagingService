using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MessageClient
{
    public partial class Sender : System.Web.UI.Page
    {
        MessageReference.MessageServiceClient messRef = new MessageReference.MessageServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SendButton_Click(object sender, EventArgs e)
        {
            string senderID = SenderTB.Text;
            string receiverID = ReceiverTB.Text;
            string messageText = MessageTB.Text;

           messRef.sendMsg(senderID, receiverID, messageText);
        }
    }
}
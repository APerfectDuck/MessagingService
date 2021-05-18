using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MessageClient
{
    public partial class Receiver : System.Web.UI.Page
    {
        MessageReference.MessageServiceClient messRef = new MessageReference.MessageServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ReceiverButton_Click(object sender, EventArgs e)
        {
            MessageTB.Text = "";
            string[] responseText;

            string receiverID = ReceiverTB.Text;

            if (PurgeCB.Checked == true)
            {
                responseText = messRef.receiveMsg(receiverID, true);

            }
            else
                responseText = messRef.receiveMsg(receiverID, false);


            for (int i = 0; i < responseText.Length; i++)
            { 
            
                MessageTB.Text += responseText[i] + Environment.NewLine;

                if (i % 3 == 2)
                {
                    MessageTB.Text += Environment.NewLine;
                }
            }
        }
    }
}
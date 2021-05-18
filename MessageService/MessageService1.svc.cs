using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Xml.Linq;
using System.IO;
using System.Web;
using System.Xml;

namespace MessageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IMessageService
    {
        string XMLLocale = Path.Combine(HttpRuntime.AppDomainAppPath, @"App_Data\Messages.xml");
        public void sendMsg(string senderID, string receiverID, string msg)
        {
            XDocument xmlDocMsgs = new XDocument();
            XNamespace nameSpace = "http://example.com/Messages";
            try
            {
                xmlDocMsgs = XDocument.Load(XMLLocale);
                XElement xmlElement = new XElement(nameSpace + "Message",
                                new XElement(nameSpace + "SenderID", senderID),
                                new XElement(nameSpace + "ReceiverID", receiverID),
                                new XElement(nameSpace + "TS", DateTime.Now.ToString()),
                                new XElement(nameSpace + "MessageContents", msg),
                                new XElement(nameSpace + "Received", "false"));
                                
                xmlDocMsgs.Element(nameSpace + "Messages").Add(xmlElement);
                xmlDocMsgs.Save(XMLLocale);
            }
            catch (XmlException ex)
            {
                if (!(ex.Message.ToLower().Contains("root") && ex.Message.ToLower().Contains("element") && ex.Message.ToLower().Contains("not") && ex.Message.ToLower().Contains("found")))
                {
                    xmlDocMsgs = new XDocument(
                                       new XDeclaration("1.0", "UTF-8", "yes"),
                                       new XComment("CSE446 Messaging System Example"),
                                       new XElement(nameSpace + "Messages",
                                       new XElement(nameSpace + "Message",
                                       new XElement(nameSpace + "SenderID", senderID),
                                       new XElement(nameSpace + "ReceiverID", receiverID),
                                       new XElement(nameSpace + "TS", System.DateTime.Now.ToString()),
                                       new XElement(nameSpace + "MessageContents", msg),
                                       new XElement(nameSpace + "Received", "false"))));
                    xmlDocMsgs.Save(XMLLocale);

                }
            }
        }


        public string[] receiveMsg(string receiverID, bool purge)
        {
            string[] returnMsg;
            XDocument xmlDocMsgs = XDocument.Load(XMLLocale);
            XNamespace nameSpace = "http://example.com/Messages";
            IEnumerable<XElement> queryElementItems =
            from item in xmlDocMsgs.Root.Descendants(nameSpace + "Message")
            where item.Element(nameSpace + "ReceiverID").Value == receiverID
            orderby (DateTime)item.Element(nameSpace + "TS") descending
            select item;
            returnMsg = new string[queryElementItems.Count() * 3];
            
            
            int iter = 0;
            foreach (XElement item in queryElementItems)
            {
                if (purge == true)
                {
                    item.Element(nameSpace + "MessageContents").Value = "This message was purged.";
                }

                if (item.Element(nameSpace + "Received").Value == "false")
                {
                    item.Element(nameSpace + "Received").Value = "true";

                    returnMsg[iter++] = item.Element(nameSpace + "SenderID").Value;
                    returnMsg[iter++] = item.Element(nameSpace + "TS").Value;
                    returnMsg[iter++] = item.Element(nameSpace + "MessageContents").Value;
                }

            }

            xmlDocMsgs.Save(XMLLocale);

            return returnMsg;

        }

        public void purgeMsg(string receiverID)
        {

        }
    }
}

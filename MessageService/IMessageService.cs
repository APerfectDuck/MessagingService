using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace MessageService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IMessageService
    {
        [OperationContract]
        void sendMsg(string senderID, string receiverID, string msg);

        [OperationContract]
        string[] receiveMsg(string receiverID, bool purge);
    }


}

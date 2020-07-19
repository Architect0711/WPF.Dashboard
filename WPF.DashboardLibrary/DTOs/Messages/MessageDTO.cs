using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using WPF.DashboardLibrary.Enums;

namespace WPF.DashboardLibrary.DTOs.Messages
{
    [DataContract]
    public class MessageDTO
    {
        [DataMember]
        public string Message { get; private set; }

        [DataMember]
        public MessageType MessageType { get; private set; }

        public MessageDTO(string message,  MessageType messageType)
        {
            Message = message;
            MessageType = messageType;
        }
    }
}

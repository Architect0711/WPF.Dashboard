using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DashboardLibrary.DTOs.Messages;
using WPF.DashboardLibrary.Enums;

namespace WPF.DashboardLibrary.Models.Messages
{
    public class MessageModel
    {
        public string Message { get; private set; }

        public DateTime Timestamp { get; private set; }

        public MessageType MessageType { get; private set; }

        public MessageModel(string message, DateTime timestamp, MessageType messageType)
        {
            Message = message;
            Timestamp = timestamp;
            MessageType = messageType;
        }

        public MessageModel(MessageDTO dto)
        {
            Message = dto.Message;
            Timestamp = DateTime.Now;
            MessageType = dto.MessageType;
        }

        public override string ToString()
        {
            return string.Format("[{0}][{1}]{2}",
                Enum.GetName(typeof(MessageType), MessageType),
                Timestamp,
                Message);
        }
    }
}

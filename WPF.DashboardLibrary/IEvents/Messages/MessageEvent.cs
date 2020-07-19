using EventAggregator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPF.DashboardLibrary.Models.Messages;

namespace WPF.DashboardLibrary.IEvents.Messages
{
    public class MessageEvent : IEvent
    {
        public MessageModel Message { get; private set; }

        public MessageEvent(MessageModel message)
        {
            Message = message;
        }
    }
}

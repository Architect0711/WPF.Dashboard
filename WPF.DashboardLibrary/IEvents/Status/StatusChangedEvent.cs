using EventAggregator.Interfaces;
using System.Collections.Generic;
using WPF.DashboardLibrary.Models.Status;

namespace WPF.DashboardLibrary.Events.Status
{
    public class StatusChangedEvent : IEvent
    {
        public List<StatusModel> Statuses { get; private set; }

        public StatusChangedEvent(List<StatusModel> statuses)
        {
            Statuses = statuses;
        }

        public override string ToString()
        {
            return nameof(StatusChangedEvent);
        }
    }
}

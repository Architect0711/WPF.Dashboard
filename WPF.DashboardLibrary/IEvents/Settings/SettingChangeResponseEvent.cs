using EventAggregator.Interfaces;
using WPF.DashboardLibrary.DTOs.Settings;
using WPF.DashboardLibrary.Models.Settings;
using WPF.DashboardLibrary.RequestResponse.Settings;

namespace WPF.DashboardLibrary.Events.Settings
{
    public class SettingChangeResponseEvent : IEvent
    {
        public SettingChangeResponse Response { get; private set; }

        public SettingChangeResponseEvent(SettingChangeResponse response)
        {
            Response = response;
        }

        public override string ToString()
        {
            return string.Format("{0} => {1}",
                nameof(SettingChangeResponseEvent),
                Response.ToString());
        }
    }
}

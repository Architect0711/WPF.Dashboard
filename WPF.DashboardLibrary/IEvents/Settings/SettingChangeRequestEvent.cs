using EventAggregator.Interfaces;
using WPF.DashboardLibrary.Models.Settings;
using WPF.DashboardLibrary.RequestResponse.Settings;

namespace WPF.DashboardLibrary.Events.Settings
{
    /// <summary>
    /// This Event Occurs, when the User wants to change a Setting
    /// Subscribe to this Event to send it to the Backend and change that Setting
    /// To process the Answer from the Backend, raise a SettingChangeProcessedEvent with the Setting that was changed with its new Value
    /// </summary>
    public class SettingChangeRequestEvent : IEvent
    {
        public SettingChangeRequest Request { get; private set; }

        public SettingChangeRequestEvent(SettingChangeRequest request)
        {
            Request = request;
        }

        public override string ToString()
        {
            return string.Format("{0} => {1}",
                nameof(SettingChangeRequestEvent),
                Request.ToString());
        }
    }
}

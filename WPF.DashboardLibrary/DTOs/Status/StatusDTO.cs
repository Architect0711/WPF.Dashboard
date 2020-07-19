using System.Drawing;
using System.Runtime.Serialization;

namespace WPF.DashboardLibrary.DTOs.Status
{
    [DataContract]
    public class StatusDTO
    {
        [DataMember]
        public string StatusId { get; set; }

        [DataMember]
        public int Order { get; set; }

        [DataMember]
        public string TitleText { get; set; }

        [DataMember]
        public string HoverText { get; set; }

        [DataMember]
        public Color BackgroundColor { get; set; }

        public StatusDTO(
            string id, 
            int order, 
            string titleText, 
            string hoverText, 
            Color backgroundColor)
        {
            StatusId = id;
            Order = order;
            TitleText = titleText;
            HoverText = hoverText;
            BackgroundColor = backgroundColor;
        }
    }
}

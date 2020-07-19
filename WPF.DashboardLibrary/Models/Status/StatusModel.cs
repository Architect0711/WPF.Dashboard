using System.Collections.Generic;
using WPF.Basics.MVVM;
using WPF.DashboardLibrary.DTOs.Status;

namespace WPF.DashboardLibrary.Models.Status
{
    /// <summary>
    /// Data Model for the colored Status Items in the Sidebar
    /// </summary>
    public class StatusModel : ObservableObject
    {
        private string statusId;
        private int order;
        private string titleText;
        private string hoverText;
        private System.Drawing.Color color;

        /// <summary>
        /// Unique Id
        /// </summary>
        public string StatusId { get => statusId; private set => OnPropertyChanged(ref statusId, value); }

        /// <summary>
        /// StatusView orders the Status Item List by this Integer Key
        /// => 0 is the First!
        /// </summary>
        public int Order { get => order; private set => OnPropertyChanged(ref order, value); }

        /// <summary>
        /// This Text is shown in the Status Item
        /// </summary>
        public string TitleText { get => titleText; private set => OnPropertyChanged(ref titleText, value); }

        /// <summary>
        /// This Text is shown when the User hovers over the Status Item
        /// </summary>
        public string HoverText { get => hoverText; private set => OnPropertyChanged(ref hoverText, value); }

        /// <summary>
        /// Status determines the Color
        /// </summary>
        public System.Drawing.Color Color { get => color; private set => OnPropertyChanged(ref color, value); }

        public StatusModel(
            string id,
            int order,
            System.Drawing.Color color,
            string titleText,
            string hoverText)
        {
            StatusId = id;
            Order = order;
            TitleText = titleText;
            HoverText = hoverText;
            Color = color;
        }

        public StatusModel(StatusDTO dto)
        {
            StatusId = dto.StatusId;
            Order = dto.Order;
            TitleText = dto.TitleText;
            HoverText = dto.HoverText;
            Color = dto.BackgroundColor;
        }

        public void Update(StatusModel newStatus)
        {
            Order = newStatus.Order;
            TitleText = newStatus.TitleText;
            HoverText = newStatus.HoverText;
            Color = newStatus.Color;
        }

        public override bool Equals(object obj)
        {
            return obj is StatusModel model &&
                   StatusId == model.StatusId;
        }

        public override int GetHashCode()
        {
            return 1833075890 + EqualityComparer<string>.Default.GetHashCode(StatusId);
        }
    }
}

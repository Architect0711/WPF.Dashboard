using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPF.DashboardLibrary.Models.LaunchPrograms
{
    /// <summary>
    /// Holds Data about an external Program that can be launched by the Dashboard
    /// </summary>
    public class LaunchProgramModel
    {
        /// <summary>
        /// Unique Id
        /// </summary>
        public string LaunchProgramId { get; private set; }

        /// <summary>
        /// LaunchViewModel orders the Launch Item List by this Integer Key
        /// => 0 is the First!
        /// </summary>
        public int Order { get; private set; }

        /// <summary>
        /// Full Path to the Application
        /// </summary>
        public string Fullpath { get; private set; }

        /// <summary>
        /// Title for the Application, e.g. "Internet Explorer"
        /// </summary>
        public string Title { get; private set; }

        /// <summary>
        /// Descriptive Text for the User, e.g. "Browse the Network or Internet"
        /// </summary>
        public string Description { get; private set; }

        /// <summary>
        /// Holds the Icon of the Application
        /// </summary>
        public ImageSource Image { get; private set; }

        public LaunchProgramModel(int Index,
            string Fullpath,
            string Title,
            string Description)
        {
            this.Title = Title;
            this.Order = Index;
            this.Fullpath = Fullpath;
            this.Description = Description;

            try
            {
                // https://stackoverflow.com/questions/2969821/display-icon-in-wpf-image
                var icon = Icon.ExtractAssociatedIcon(Fullpath);

                using (Bitmap bmp = icon.ToBitmap())
                {
                    var stream = new MemoryStream();
                    bmp.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                    Image = BitmapFrame.Create(stream);
                }
            }
            catch (Exception)
            {

            }
        }

        public override bool Equals(object obj)
        {
            return obj is LaunchProgramModel model &&
                   LaunchProgramId == model.LaunchProgramId;
        }

        public override int GetHashCode()
        {
            return 2144961283 + EqualityComparer<string>.Default.GetHashCode(LaunchProgramId);
        }
    }
}

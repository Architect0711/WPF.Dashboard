using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.DashboardImpl.Configuration
{
    public class IndivPaths
    {
        public static readonly string _Folder = "Images";

        /// <summary>
        /// All Image Paths related to Icons
        /// </summary>
        public static readonly string _Icons = "Icons";
        public static readonly string _Black = "Black";
        public static readonly string _White = "White";
        public static readonly string _Color = _White;
        public static string _Directory = AppDomain.CurrentDomain.BaseDirectory;

        private static readonly string _TestsIcon = "icons8-test-passed-32.png";

        public static string TestsIcon
        {
            get { return Path.Combine(_Directory, _Folder, _Icons, _Color, _TestsIcon); }
        }
    }
}

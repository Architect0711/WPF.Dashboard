using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF.DashboardImpl.Configuration
{
    /// <summary>
    /// Enter the Password Guidelines into this Class
    /// </summary>
    public static class PasswordGuidelines
    {
        public static TimeSpan PasswordValidityPeriodDays
        {
            get { return TimeSpan.FromDays(365); }
        }

        public static int MinimumPasswordLength
        {
            get { return 12; }
        }

        public static int MinimumUsernameLength
        {
            get { return 1; }
        }

        public static bool NumbersRequired
        {
            get { return true; }
        }

        public static bool SpecialCharactersRequired
        {
            get { return true; }
        }

        public static bool LowercaseCharactersRequired
        {
            get { return true; }
        }

        public static bool UppercaseCharactersRequired
        {
            get { return true; }
        }

        private static bool ContainsUppercaseCharacters(this string str)
        {
            return !string.IsNullOrWhiteSpace(str) && str.Any(char.IsUpper);
        }

        private static bool ContainsLowercaseCharacters(this string str)
        {
            return !string.IsNullOrWhiteSpace(str) && str.Any(char.IsLower);
        }

        private static bool ContainsSpecialCharacters(this string str)
        {
            return !string.IsNullOrWhiteSpace(str) && !str.Any(char.IsLetterOrDigit);
        }

        private static bool ContainsNumbers(this string str)
        {
            return !string.IsNullOrWhiteSpace(str) && str.Any(char.IsDigit);
        }
    }
}

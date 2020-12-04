using System;
using System.Text.RegularExpressions;

namespace Assessment.Helpers
{
    public static class HelperFunctions
    {
        public static string GeTimeAgoString(DateTime date)
        {
            TimeSpan ts = DateTime.Now.ToUniversalTime().Subtract(date);
            int intMonths = ts.Days / 30;
            int intWeeks = ts.Days / 7;
            int intDays = ts.Days;
            int intHours = ts.Hours;
            int intMinutes = ts.Minutes;
            int intSeconds = ts.Seconds;


            if (intMonths > 0)
                return string.Format("{0} month", intMonths) + (intMonths > 1 ? "s" : "");

            if (intWeeks > 0)
                return string.Format("{0} week", intWeeks) + (intWeeks > 1 ? "s" : "");

            if (intDays > 0)
                return string.Format("{0} day", intDays) + (intDays > 1 ? "s" : "");

            if (intHours > 0)
                return string.Format("{0} hour", intHours) + (intHours > 1 ? "s" : "");

            if (intMinutes > 0)
                return string.Format("{0} minute", intMinutes) + (intMinutes > 1 ? "s" : "");

            if (intSeconds > 0)
                return string.Format("{0} second", intSeconds) + (intSeconds > 1 ? "s" : "");

            // let's handle future times..just in case
            if (intDays < 0)
                return string.Format("in {0} days", Math.Abs(intDays));

            if (intHours < 0)
                return string.Format("in {0} hours", Math.Abs(intHours));

            if (intMinutes < 0)
                return string.Format("in {0} minutes", Math.Abs(intMinutes));

            if (intSeconds < 0)
                return string.Format("in {0} seconds", Math.Abs(intSeconds));

            return "a bit";

        }

        public static bool HasSequence(string input)
        {
            for(int i = 0; i < input.Length - 1; i++) //length minus one because no sequence can start on last index
            {
                //look for next index of this char (should it exist)
                var secondIndexOfChar = input.IndexOf(input[i], i + 1);
                if (secondIndexOfChar > 0)
                {
                    //Char is found again in the string - analize the sequence
                    var lengthOfSequence = secondIndexOfChar - i;
                    if (lengthOfSequence + secondIndexOfChar > input.Length)
                    {
                        //Would need more chars to complete second sequence
                        continue;
                    }

                    var substring1 = input.Substring(i, secondIndexOfChar - i);
                    var substring2 = input.Substring(secondIndexOfChar, lengthOfSequence);
                    if (substring1.Equals(substring2))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static Tuple<bool, string> IsValidPassword(string password, string confirmationPassword)
        {
            bool validPassword = true;
            string errorMessage = string.Empty;

            //Validate confirmation matches password
            if (!password.Equals(confirmationPassword))
            {
                errorMessage = "Passwords do not match";
                return new Tuple<bool, string>(false, errorMessage);
            }

            //String must consist of a mixture of letters and numerical digits only, with at least one of each.
            //String must be between 5 and 12 characters in length.
            //String must not contain any sequence of characters immediately followed by the same sequence
            var hasLetterAndNumber = new Regex(@"(\w*[a-zA-Z]\w*)(\w*[0-9]\w*)");
            var isCorrectLength = password.Length > 5 && password.Length < 12;
            var hasSequence = HelperFunctions.HasSequence(password);

            if (!hasLetterAndNumber.IsMatch(password))
            {
                errorMessage += "The password must contain a letter and a number. ";
                validPassword = false;
            }

            if (!isCorrectLength)
            {
                errorMessage += "The password must be between 5 and 12 characters in length. ";
                validPassword = false;
            }

            if (hasSequence)
            {
                errorMessage += "The password must not contain any sequence of characters immediately followed by the same sequence. ";
                validPassword = false;
            }

            return new Tuple<bool, string>(validPassword, errorMessage);
        }
    }
}

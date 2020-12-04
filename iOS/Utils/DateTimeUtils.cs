using System;
using Foundation;

namespace Assessment.iOS.Utils
{
    public static class DateTimeUtils
    {
		public static NSDate DateTimeToNSDate(this Nullable<DateTime> date)
		{
			if (date == null)
			{
				return null;
			}
			else
			{
				DateTime reference = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(2001, 1, 1, 0, 0, 0));
				return NSDate.FromTimeIntervalSinceReferenceDate((date.GetValueOrDefault() - reference).TotalSeconds);
			}
		}
	}
}

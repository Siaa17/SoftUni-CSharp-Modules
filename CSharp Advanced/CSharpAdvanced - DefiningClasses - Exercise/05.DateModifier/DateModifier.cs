using System;

namespace _05.DateModifier
{
    public static class DateModifier
    {
        public static double GetDifferenceInDaysBetweenTwoDates(string firstDate, string secondDate)
        {
            DateTime startDate = DateTime.Parse(firstDate);
            DateTime endDate = DateTime.Parse(secondDate);

            double diff = (startDate - endDate).TotalDays;

            double absoluteValue = Math.Abs(diff);

            return absoluteValue;
        }
    }
}

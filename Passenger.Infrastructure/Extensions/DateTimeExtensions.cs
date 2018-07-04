using System;
using System.Collections.Generic;
using System.Text;

namespace Passenger.Infrastructure.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToTimeStamp(this DateTime dataTime)
        {
            var epoch = new DateTime(1970, 1, 1,0,0,0, DateTimeKind.Utc);
            var time = dataTime.Subtract(new TimeSpan(epoch.Ticks));
            return time.Ticks / 10000;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Instagram.Utils
{
    public static class DateTimeUtils
    {
        public static DateTime GetUtcNow()
        {
            return DateTime.UtcNow.AddHours(7);
        }
    }
}

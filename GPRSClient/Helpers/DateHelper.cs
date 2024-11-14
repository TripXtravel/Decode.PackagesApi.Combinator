using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPRSClient.Helpers
{
    public static class DateHelper
    {
        public static Cmp.Types.V1.Date ToDate(DateTime datetime)
        {
            var date = new Cmp.Types.V1.Date();
            date.Day = datetime.Day;
            date.Month = datetime.Month;
            date.Year = datetime.Year;
            return date;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UserProject
{
    public static class PersianConvertor
    {
        public static string ToShamsi(this DateTime? value)
        {
            System.Globalization.PersianCalendar pc = new System.Globalization.PersianCalendar();
            return pc.GetYear(value.Value) + "/" + pc.GetMonth(value.Value).ToString("00") + "/" + pc.GetDayOfMonth(value.Value).ToString("00") + " " + pc.GetHour(value.Value).ToString("00") + ":" + pc.GetMinute(value.Value).ToString("00");
        }
    }
}
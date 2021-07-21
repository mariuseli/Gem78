using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GemCalendarApi.Controllers
{
    public class CalendarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        #region Private methods

        private void GenerateRecurringEvent()
        {
            var now = DateTime.Now;
            var later = now.AddHours(1);

            //Repeat daily for 5 days
            var rrule = new RecurrencePattern(FrequencyType.Daily, 1) { Count = 5 };
            var e = new CalendarEvent
            {
                Start = new CalDateTime(now),
                End = new CalDateTime(later),
                RecurrenceRules = new List<RecurrencePattern> { rrule },
            };


            //Matinale
            DateTime matinaleStartDate = new DateTime(2021, 07, 19, 5, 0, 0);
            var matinaleRecurrence = new RecurrencePattern(FrequencyType.Daily, 1) { Count = 5 };
            var matinale = new CalendarEvent
            {
                Name = "Les Matinales de Prière",
                Location = "https://zoom.us/j/976062824?pwd=YjgweHdSNmNneGM5MlphQjY3Nlhndz09",
                Start = new CalDateTime(matinaleStartDate),
                End = new CalDateTime(matinaleStartDate.AddHours(1.0d)),
                RecurrenceRules = new List<RecurrencePattern> { matinaleRecurrence },
                Description = "👉 Les 𝕄𝕒𝕥𝕚𝕟𝕒𝕝𝕖𝕤 🇪🇺, tous les jours de 05h00 à 06h00 du matin"
            };

            //P7
            DateTime p7StartDate = new DateTime(2021, 07, 19, 12, 30, 0);
            var p7Recurrence = new RecurrencePattern(FrequencyType.Daily, 1) { Count = 5 };
            var p7 = new CalendarEvent
            {
                Name = "P7: 7 jours de prière",
                Location = "https://zoom.us/j/97478773681?pwd=N24zVmhVUE9DUmpIdU1xbmN0VWx3Zz09",
                Start = new CalDateTime(p7StartDate),
                End = new CalDateTime(p7StartDate.AddHours(1.0d)),
                RecurrenceRules = new List<RecurrencePattern> { p7Recurrence },
                Description = "👉 P7: 7 jours de prière de Lundi à Samedi de 12h30 à 13h30"
            };

            var tourDeGarde


            var calendar = new Calendar();
            calendar.Events.Add(e);

            var serializer = new CalendarSerializer();
            var serializedCalendar = serializer.SerializeToString(calendar);
        }

        #endregion
    }
}

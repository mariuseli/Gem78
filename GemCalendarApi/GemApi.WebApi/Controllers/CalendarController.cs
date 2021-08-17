using GemApi.Application.GemEvents.Commands;
using GemApi.Database.Persistence;
using GemApi.Domain;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Ical.Net.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace GemCalendarApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class CalendarController : ApiControllerBase
    {
        private GemEventsDatabaseContext _dbContext;
        private ILogger<CalendarController> _log;
        public CalendarController(GemEventsDatabaseContext dbContext, ILogger<CalendarController> logger)
        {
            _dbContext = dbContext;
            _log = logger;
        }

        [HttpGet] 
        public IActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult AddNewGemEvent(GemEvent newEvent)
        {
            try
            {
                CreateEventCommand createCommand = new CreateEventCommand()
                {
                    NewEvent = new GemApi.Application.Common.Models.GemEventDto
                    {
                        EndDate = newEvent.EndDate,
                        GemEventDescription = newEvent.GemEventDescription,
                        GemEventImage = newEvent.GemEventImage,
                        GemEventLocation = newEvent.GemEventLocation,
                        GemEventName = newEvent.GemEventName,
                        GemEventUrl = newEvent.GemEventUrl,
                        IsAllDayLong = newEvent.IsAllDayLong,
                        StartDate = newEvent.StartDate
                    }
                };

                int r = Mediator.Send(createCommand).GetAwaiter().GetResult();
                return new JsonResult(createCommand.NewEvent);
            }
            catch (Exception exception)
            {
                return new JsonResult(exception);
            }
        }


        #region Private methods

        private string GenerateRecurringEvent()
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

            var calendar = new Calendar();
            calendar.AddTimeZone(new VTimeZone("Europe/Paris"));

            //Matinale
            DateTime matinaleStartDate = new DateTime(2021, 07, 19, 5, 0, 0);
            var matinaleRecurrence = new RecurrencePattern(FrequencyType.Daily, 1) { Until = new DateTime(2021, 8, 31, 23, 59, 00) };
            var matinale = new CalendarEvent
            {
                Name = "Les Matinales de Prière",
                Location = "https://zoom.us/j/976062824?pwd=YjgweHdSNmNneGM5MlphQjY3Nlhndz09",
                Start = new CalDateTime(matinaleStartDate),
                End = new CalDateTime(matinaleStartDate.AddHours(1.0d)),
                RecurrenceRules = new List<RecurrencePattern> { matinaleRecurrence },
                Description = "👉 Les 𝕄𝕒𝕥𝕚𝕟𝕒𝕝𝕖𝕤 🇪🇺, tous les jours de 05h00 à 06h00 du matin"
            };
            calendar.Events.Add(matinale);

            //P7
            DateTime p7StartDate = new DateTime(2021, 07, 19, 12, 30, 0);
            var p7Recurrence = new RecurrencePattern(FrequencyType.Daily, 1) { Until = new DateTime(2021, 8, 31, 23, 59, 00) };
            var p7 = new CalendarEvent
            {
                Name = "P7: 7 jours de prière",
                Location = "https://zoom.us/j/97478773681?pwd=N24zVmhVUE9DUmpIdU1xbmN0VWx3Zz09",
                Start = new CalDateTime(p7StartDate),
                End = new CalDateTime(p7StartDate.AddHours(1.0d)),
                RecurrenceRules = new List<RecurrencePattern> { p7Recurrence },
                Description = "👉 P7: 7 jours de prière de Lundi à Samedi de 12h30 à 13h30"
            };
            calendar.Events.Add(p7);

            DateTime tourDeGardeStartDate = new DateTime(2021, 07, 19, 23, 00, 0);
            var listOfDays = new List<WeekDay>();
            listOfDays.Add(new WeekDay(DayOfWeek.Monday));
            listOfDays.Add(new WeekDay(DayOfWeek.Tuesday));
            listOfDays.Add(new WeekDay(DayOfWeek.Thursday));
            var tourDeGardeStartDateRecurrence = new RecurrencePattern(FrequencyType.Daily, 1) {ByDay = listOfDays, Until = new DateTime(2021, 8, 31, 23, 59, 00) } ;
            var tourdeGarde = new CalendarEvent
            {
                Name = "Tour de garde Europe-Priere24",
                Location = "https://us02web.zoom.us/j/82395571174",
                Start = new CalDateTime(tourDeGardeStartDate),
                End = new CalDateTime(tourDeGardeStartDate.AddHours(1.0d)),
                RecurrenceRules = new List<RecurrencePattern> { tourDeGardeStartDateRecurrence },
                Description = "👉𝕋𝕠𝕦𝕣 𝕕𝕖 𝕘𝕒𝕣𝕕𝕖 𝔼𝕦𝕣𝕠𝕡𝕖-Prière24 : Tous les lundis,mardis de 21h00 à 24h00 et jeudis de 23h00 à 24h00"
            };
            calendar.Events.Add(tourdeGarde);

            DateTime jeudiParole = new DateTime(2021, 07, 19, 21, 0, 0);
            var jeudiParoleDays = new List<WeekDay>();
            jeudiParoleDays.Add(new WeekDay(DayOfWeek.Tuesday));
            var jeudiParoleReccurring = new RecurrencePattern(FrequencyType.Weekly, 1) {ByDay = jeudiParoleDays, Until = new DateTime(2021, 8, 31, 23, 59, 00) } ;
            var jeudiParoleEvent = new CalendarEvent
            {
                Name = "Les Jeudis de la Parole",
                Start = new CalDateTime(jeudiParole),
                End = new CalDateTime(jeudiParole.AddHours(1.5d)),
                RecurrenceRules = new List<RecurrencePattern> { jeudiParoleReccurring},
                Location = "https://zoom.us/j/976062824?pwd=YjgweHdSNmNneGM5MlphQjY3Nlhndz09",
                Description = "👉 Le 𝕁𝕖𝕦𝕕𝕚 𝕕𝕖 𝕝𝕒 ℙ𝕒𝕣𝕠𝕝𝕖 à 21h00-22h00"
            };
            calendar.Events.Add(jeudiParoleEvent);

            DateTime nightFireTime = new DateTime(2021, 07, 19, 2, 0, 0);
            var nightFireTimeDays = new List<WeekDay>();
            jeudiParoleDays.Add(new WeekDay(DayOfWeek.Saturday));
            var nightFireReccurring = new RecurrencePattern(FrequencyType.Weekly, 1) { ByDay = nightFireTimeDays, Until = new DateTime(2021, 8, 31, 23, 59, 00) };
            var nightFireEvent = new CalendarEvent
            {
                Name = "ℕ𝕚𝕘𝕙𝕥 𝔽𝕚𝕣𝕖 🔥",
                Start = new CalDateTime(nightFireTime),
                End = new CalDateTime(nightFireTime.AddHours(3.0d)),
                RecurrenceRules = new List<RecurrencePattern> { nightFireReccurring },
                Location = "https://us02web.zoom.us/j/82395571174",
                Description = "👉 ℕ𝕚𝕘𝕙𝕥 𝔽𝕚𝕣𝕖 🔥dans la nuit de Vendredi à Samedi  à 02h00 du matin"
            };
            calendar.Events.Add(nightFireEvent);

            DateTime rassemblementGemTime = new DateTime(2021, 07, 19, 10, 0, 0);
            List<WeekDay> rassemblementListOfDays = new List<WeekDay> { new WeekDay(DayOfWeek.Sunday) };
            RecurrencePattern rassemblementRecur = new RecurrencePattern(FrequencyType.Weekly) { ByDay = rassemblementListOfDays, Until = new DateTime(2021, 8, 31, 23, 59, 00) };
            CalendarEvent rassemblementEvent = new CalendarEvent
            {
                Name= "ℝ𝕒𝕤𝕤𝕖𝕞𝕓𝕝𝕖𝕞𝕖𝕟𝕥 𝕕𝕖𝕤 𝔾𝔼𝕄",
                Start = new CalDateTime(rassemblementGemTime),
                End = new CalDateTime(rassemblementGemTime.AddHours(2.0d)),
                RecurrenceRules = new List<RecurrencePattern> { rassemblementRecur },
                Location = "https://us02web.zoom.us/j/85384927069?pwd=UHFqWTVHZUQ4SktxdEFhUHNpQ0tuZz09"
            };
            calendar.Events.Add(rassemblementEvent);

            DateTime rencontreHebdo = new DateTime(2021, 07, 19, 21, 0, 0);
            List<WeekDay> rencontreHebdoistOfDays = new List<WeekDay> { new WeekDay(DayOfWeek.Sunday) };
            RecurrencePattern rencontreHebdoRecur = new RecurrencePattern(FrequencyType.Weekly) { ByDay = rencontreHebdoistOfDays, Until = new DateTime(2021, 8, 31, 23, 59, 00) };
            CalendarEvent rencontreHebdoEvent = new CalendarEvent
            {
                Name = "ℝ𝕒𝕤𝕤𝕖𝕞𝕓𝕝𝕖𝕞𝕖𝕟𝕥 𝕕𝕖𝕤 𝔾𝔼𝕄",
                Start = new CalDateTime(rencontreHebdo),
                End = new CalDateTime(rencontreHebdo.AddHours(1.0d)),
                RecurrenceRules = new List<RecurrencePattern> { rencontreHebdoRecur }
            };
            calendar.Events.Add(rencontreHebdoEvent);

            var serializer = new CalendarSerializer();
            //var serializedCalendar = serializer.SerializeToString(calendar);
            return serializer.SerializeToString(calendar);
        }

        #endregion
    }
}

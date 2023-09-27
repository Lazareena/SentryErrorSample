using System;
using EventKit;
using Foundation;
using SentryErrorSampleApp.Models;

namespace SentryErrorSampleApp.Services
{
	public partial class CalendarService
	{
        private static EKEventStore _eventStore;
        private static EKEventStore EventStore
        {
            get
            {
                if (_eventStore == null)
                    _eventStore = new EKEventStore();
                return _eventStore;
            }
        }

        public partial async Task<List<CalendarEvent>> LoadEvents()
        {
            var permissionSuccess = await EventStore.RequestAccessAsync(EKEntityType.Event);
            if (!permissionSuccess.Item1)
                return new List<CalendarEvent>();

            var nsStartDate = (NSDate)new DateTime(2023, 12, 15, 0, 0, 0, DateTimeKind.Utc); ;
            var nsEndDate = (NSDate)new DateTime(2023, 12, 30, 0, 0, 0, DateTimeKind.Utc); ;
            var predicate = EventStore.PredicateForEvents(nsStartDate, nsEndDate, new EKCalendar[1] { EventStore.DefaultCalendarForNewEvents });
            var ekEvents = EventStore.EventsMatching(predicate).ToList();

            var result = new List<CalendarEvent>();
            foreach (var ekEv in ekEvents)
            {
                result.Add(new CalendarEvent
                {
                    Id = ekEv.EventIdentifier,
                    CalendarId = ekEv.Calendar.CalendarIdentifier,
                    Summary = ekEv.Title,
                    Location = ekEv.Location,
                    StartDate = (DateTime)ekEv.StartDate,
                    EndDate = (DateTime)ekEv.EndDate,
                    Timezone = ekEv.TimeZone?.Name,
                    IsAllDay = ekEv.AllDay
                }); ;
            }
            return result;
        }
    }
}


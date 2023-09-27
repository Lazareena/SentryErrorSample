using System;

namespace SentryErrorSampleApp.Models
{
	public class CalendarEvent
	{
        public string Id { get; set; }
        public string CalendarId { get; set; }
        public string Summary { get; set; }
        public string Location { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Timezone { get; set; }
        public bool IsAllDay { get; set; }
    }
}


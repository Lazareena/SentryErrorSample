using System;
using SentryErrorSampleApp.Models;

namespace SentryErrorSampleApp.Services
{
	public partial class CalendarService
	{
		public partial Task<List<CalendarEvent>> LoadEvents();
	}
}


using System.Collections.ObjectModel;
using SentryErrorSampleApp.Models;
using SentryErrorSampleApp.Services;

namespace SentryErrorSampleApp;

public partial class MainPage : ContentPage
{
	private CalendarService _calendarService = new CalendarService();
	public ObservableCollection<CalendarEvent> CalendarEvents = new ObservableCollection<CalendarEvent>();

	public MainPage()
	{
		InitializeComponent();
		events.ItemsSource = CalendarEvents;
	}

	public async void LoadEvents_Clicked(System.Object sender, System.EventArgs e)
	{
		var calendarEvents = await _calendarService.LoadEvents();
		CalendarEvents.Clear();
		foreach (var ev in calendarEvents)
			CalendarEvents.Add(ev);
	}
}



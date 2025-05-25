using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Calendar.v3;
using Google.Apis.Services;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Calendar
{
    public class GoogleCalendarAdapter : IGoogleCalendarAdapter
    {
        private readonly CalendarService _service;

        public GoogleCalendarAdapter()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "client_secret.json");
            var credential = GoogleCredential.FromFile(path)
                .CreateScoped(CalendarService.Scope.CalendarReadonly);

            _service = new CalendarService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = "TaskManager",
            });
        }

        public async Task<List<CalendarEvent>> GetEventsAsync(DateTime from, DateTime to)
        {
            EventsResource.ListRequest request = _service.Events.List("primary");
            request.TimeMin = from;
            request.TimeMax = to;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            Events events = await request.ExecuteAsync();

            List<CalendarEvent> result = new();
            if (events.Items != null)
            {
                foreach (var e in events.Items)
                {
                    result.Add(new CalendarEvent
                    {
                        Title = e.Summary,
                        Description = e.Description ?? "",
                        Date = e.Start.DateTime.HasValue ? e.Start.DateTime.Value : DateTime.Parse(e.Start.Date),
                        Type = "GoogleCalendar"
                    });
                }
            }

            return result;
        }
    }
}

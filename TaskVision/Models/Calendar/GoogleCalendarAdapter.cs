using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Google.Apis.Services;
using TaskVision.Models.Tasks;
using TaskVision.Enum;
using TaskVision.Services.Interfaces;

namespace TaskVision.Services.Implementation
{
    public class GoogleCalendarAdapter : IGoogleCalendarAdapter
    {
        private readonly CalendarService _service;

        public GoogleCalendarAdapter()
        {
            var path = Path.Combine(AppContext.BaseDirectory, "client_secret.json");

            var credential = GoogleCredential.FromFile(path)
                .CreateScoped(CalendarService.Scope.CalendarReadonly);

            _service = new CalendarService(new BaseClientService.Initializer
            {
                HttpClientInitializer = credential,
                ApplicationName = "TaskVision"
            });
        }

        public async Task<List<ITask>> GetAllEventsAsync()
        {
            List<ITask> tasks = new();

            EventsResource.ListRequest request = _service.Events.List("primary");
            request.TimeMin = DateTime.UtcNow;
            request.ShowDeleted = false;
            request.SingleEvents = true;
            request.OrderBy = EventsResource.ListRequest.OrderByEnum.StartTime;

            Events events = await request.ExecuteAsync();

            if (events.Items != null)
            {
                foreach (var e in events.Items)
                {
                    var start = e.Start.DateTime ?? DateTime.Parse(e.Start.Date);
                    var end = e.End.DateTime ?? DateTime.Parse(e.End.Date);

                    tasks.Add(new SimpleTask
                    {
                        Title = e.Summary ?? "Fără titlu",
                        Description = e.Description ?? "",
                        Start = start,
                        End = end,
                        Priority = TaskPriority.Medium,
                        Color = "#F9E79F"
                    });
                }
            }

            return tasks;
        }
    }
}

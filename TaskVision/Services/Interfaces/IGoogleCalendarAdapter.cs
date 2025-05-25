using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Models.Calendar;

namespace TaskVision.Services.Interfaces
{
    public interface IGoogleCalendarAdapter
    {
        Task<List<CalendarEvent>> GetEventsAsync(DateTime from, DateTime to);
    }
}

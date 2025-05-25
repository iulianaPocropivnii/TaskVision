using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskVision.Services.Interfaces
{
    public interface ICalendarService
    {
        Task AddEventAsync(string title, DateTime date);
    }

}

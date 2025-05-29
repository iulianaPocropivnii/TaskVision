using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Enum;

namespace TaskVision.Services.Interfaces
{
    public interface ITaskBuilder
    {
        ITaskBuilder WithTitle(string title);
        ITaskBuilder WithDescription(string desc);
        ITaskBuilder WithStart(DateTime start);
        ITaskBuilder WithEnd(DateTime end);
        ITaskBuilder WithDeadline(DateTime deadline);
        ITaskBuilder WithColor(string color);
        ITaskBuilder WithPriority(TaskPriority priority);
        ITask Build();
    }

}

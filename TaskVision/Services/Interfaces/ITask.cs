using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Enum;

namespace TaskVision.Services.Interfaces
{
    public interface ITask : IPrototype<ITask>
    {
        string Title { get; }
        string Description { get; }
        DateTime Deadline { get; }
        TaskPriority Priority { get; }
        void UpdateTask();
    }
}

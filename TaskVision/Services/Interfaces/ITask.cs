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
        public int Id { get; set; }
        string Title { get; set; }
        string Description { get; set; }
        DateTime Start { get; set; }
        DateTime End { get; set; }
        string Color { get; set; }
        DateTime Deadline { get; }
        public ITaskState State { get; set; }
        public TaskPriority Priority { get; set; }
        void UpdateTask();
    }
}

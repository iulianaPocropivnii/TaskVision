using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Enum;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Memento
{
    public class TaskMemento
    {
        public string Title { get; }
        public ITaskState State { get; }

        public TaskMemento(string title, ITaskState state)
        {
            Title = title;
            State = state;
        }
    }
}

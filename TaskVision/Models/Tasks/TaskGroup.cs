using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TaskVision.Enum;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Tasks
{
    public class TaskGroup : ITask
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskPriority Priority { get; set; }

        private List<ITask> _tasks = new();

        public void AddTask(ITask task)
        {
            _tasks.Add(task);
        }

        public void RemoveTask(ITask task)
        {
            _tasks.Remove(task);
        }

        public List<ITask> GetTasks()
        {
            return _tasks;
        }

        public void UpdateTask()
        {
            foreach (var task in _tasks)
            {
                task.UpdateTask();
            }
        }
    }
}

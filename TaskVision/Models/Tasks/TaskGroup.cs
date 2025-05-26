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
    namespace TaskVision.Models.Tasks
    {
        public class TaskGroup : ITask
        {
            private readonly List<ITask> _subTasks = new List<ITask>();

            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime Deadline { get; set; }
            public TaskPriority Priority { get; set; }

            public TaskGroup() { }

            public void AddTask(ITask task)
            {
                _subTasks.Add(task);
            }

            public void RemoveTask(ITask task)
            {
                _subTasks.Remove(task);
            }

            public IEnumerable<ITask> GetSubTasks() => _subTasks;

            public void UpdateTask()
            {
                foreach (var task in _subTasks)
                {
                    task.UpdateTask();
                }
            }

            public ITask Clone()
            {
                var clonedGroup = new TaskGroup
                {
                    Title = this.Title,
                    Description = this.Description,
                    Deadline = this.Deadline,
                    Priority = this.Priority
                };

                foreach (var task in _subTasks)
                {
                    clonedGroup.AddTask(task.Clone());
                }

                return clonedGroup;
            }
        }
    }
}

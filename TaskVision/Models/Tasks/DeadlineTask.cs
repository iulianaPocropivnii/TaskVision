using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using TaskVision.Enum;
using TaskVision.Models.Memento;
using TaskVision.Models.State;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Tasks
{
    public class DeadlineTask : ITask
    {
        private readonly IDatabaseService _databaseService;
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public TaskPriority Priority { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Color { get; set; }
        public string StateName { get; set; } = "ToDo";

        [Ignore]
        public ITaskState State
        {
            get => StateName switch
            {
                "ToDo" => new ToDoState(),
                "InProgress" => new InProgressState(),
                "Done" => new DoneState(),
                _ => new ToDoState()
            };
            set => StateName = value switch
            {
                ToDoState => "ToDo",
                InProgressState => "InProgress",
                DoneState => "Done",
                _ => "ToDo"
            };
        }

        public DeadlineTask() { }
        public void UpdateTask()
        {
            _databaseService.UpdateTask(this);

        }
        public DeadlineTask(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }
        public ITask Clone()
        {
            return new DeadlineTask(_databaseService)
            {
                Title = this.Title,
                Description = this.Description,
                Deadline = this.Deadline,
                Priority = this.Priority
            };
        }
        public TaskMemento SaveState()
        {
            return new TaskMemento(this);
        }

    }

}

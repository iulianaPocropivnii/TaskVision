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
    public class SimpleTask : ITask
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public DateTime Deadline { get; set; }
        public TaskPriority Priority { get; set; } = TaskPriority.Medium;
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public string Color { get; set; } = "#a29bfe";

        public string StateName { get; set; } = "ToDo"; // 🔁 Se salvează în SQLite

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

        public SimpleTask() { }

        public void UpdateTask() { }

        public ITask Clone()
        {
            return (ITask)this.MemberwiseClone();
        }

        public TaskMemento SaveState()
        {
            return new TaskMemento(this);
        }
    }


}


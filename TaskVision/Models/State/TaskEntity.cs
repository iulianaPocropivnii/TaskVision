using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Enum;
using TaskVision.Models.Memento;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.State
{
    public class TaskEntity: ITask
    {
        public DateTime Start { get; set; }
        public DateTime Deadline { get; }
        public DateTime End { get; set; }
        public string Description { get; set; }
        public TaskPriority Priority { get; set; }
        public string Color { get; set; }
        public int Id { get; set; }
        public ITaskState State
        {
            get => _currentState;
            set => _currentState = value;
        }
        public ITask Clone()
        {
            return (ITask)this.MemberwiseClone();
        }

        public void UpdateTask()
        {
            // implementare dacă e necesară
        }

        public string Title { get; set; }
        private ITaskState _currentState;

        public TaskEntity(string title)
        {
            Title = title;
            _currentState = new ToDoState(); 
        }

        public void SetState(ITaskState newState)
        {
            _currentState = newState;
        }

        public void StartTask()
        {
            _currentState.Start(this);
        }

        public void CompleteTask()
        {
            _currentState.Complete(this);
        }

        public string GetCurrentState()
        {
            return _currentState.GetStateName();
        }

        public TaskMemento SaveState()
        {
            return new TaskMemento(this);
        }

        public void RestoreState(TaskMemento memento)
        {
            Title = memento.Title;
            _currentState = memento.State;
        }
    }

}

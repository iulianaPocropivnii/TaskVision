using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Enum;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.State
{
    public class TaskEntity
    {
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
    }

}

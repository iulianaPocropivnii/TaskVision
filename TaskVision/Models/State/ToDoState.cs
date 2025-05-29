using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.State
{
    public class ToDoState : ITaskState
    {
        public void Next(ITask task)
        {
            task.State = new InProgressState();
        }

        public void Start(TaskEntity task)
        {
            Console.WriteLine("Task started. Moving from ToDo to InProgress.");
            task.SetState(new InProgressState());
        }

        public void Complete(TaskEntity task)
        {
            Console.WriteLine("Cannot complete task directly from ToDo. Start it first.");
        }

        public string GetStateName() => "ToDo";
    }
}

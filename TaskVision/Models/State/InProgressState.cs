using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.State
{
    public class InProgressState : ITaskState
    {
        public void Next(ITask task)
        {
            task.State = new DoneState();
        }
        public void Start(TaskEntity task)
        {
            Console.WriteLine("Task is already in progress.");
        }

        public void Complete(TaskEntity task)
        {
            Console.WriteLine("Task completed. Moving from InProgress to Done.");
            task.SetState(new DoneState());
        }

        public string GetStateName() => "InProgress";
    }

}

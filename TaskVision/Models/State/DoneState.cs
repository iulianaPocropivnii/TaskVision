using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.State
{
    public class DoneState : ITaskState
    {
        public void Start(TaskEntity task)
        {
            Console.WriteLine("Task is already done. Cannot start again.");
        }

        public void Complete(TaskEntity task)
        {
            Console.WriteLine("Task is already completed.");
        }

        public string GetStateName() => "Done";
    }

}

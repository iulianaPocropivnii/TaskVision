using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Enum;
using TaskVision.Models.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.ChainOfResponsability
{
    public class PriorityValidator : TaskHandler
    {
        public override bool Handle(ITask task)
        {
            if (task is DeadlineTask deadlineTask)
            {
                var validPriorities = new[] { TaskPriority.High, TaskPriority.Medium, TaskPriority.Low };

                if (!validPriorities.Contains((TaskPriority)deadlineTask.Priority))
                {
                    Console.WriteLine("Prioritatea nu este validă.");
                    return false;
                }
            }
            return base.Handle(task);
        }
    }
}

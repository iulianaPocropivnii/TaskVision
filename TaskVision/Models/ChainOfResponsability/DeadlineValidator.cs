using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.ChainOfResponsability
{
    public class DeadlineValidator : TaskHandler
    {
        public override bool Handle(ITask task)
        {
            if (task.Deadline < DateTime.Now)
            {
                Console.WriteLine("Deadline-ul trebuie să fie în viitor.");
                return false;
            }

            return base.Handle(task);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Models.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.ChainOfResponsability
{
    public class TimeRangeHandler : TaskHandler
    {
        protected override ValidationResult Handle(ITask task)
        {
            if (task is DeadlineTask dt && dt.Deadline <= DateTime.Now)
                return new ValidationResult { IsValid = false, ErrorMessage = "Deadline-ul trebuie să fie în viitor." };
            return new ValidationResult();
        }
    }
}

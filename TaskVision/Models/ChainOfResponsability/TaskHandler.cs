using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.ChainOfResponsability
{
    public abstract class TaskHandler
    {
        protected TaskHandler _next;
        public TaskHandler SetNext(TaskHandler next) { _next = next; return next; }

        public ValidationResult Validate(ITask task)
        {
            var result = Handle(task);
            return (!result.IsValid || _next == null)
                ? result
                : _next.Validate(task);
        }

        protected abstract ValidationResult Handle(ITask task);
    }
}

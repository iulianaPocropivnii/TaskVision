using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.ChainOfResponsability
{
    public abstract class TaskHandler
    {
        protected TaskHandler _next;

        public void SetNext(TaskHandler next)
        {
            _next = next;
        }

        public virtual bool Handle(ITask task)
        {
            if (_next != null)
            {
                return _next.Handle(task);
            }
            return true;
        }
    }
}

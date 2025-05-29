using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Models.State;

namespace TaskVision.Services.Interfaces
{
    public interface ITaskState
    {
        void Start(TaskEntity task);
        void Next(ITask task);
        void Complete(TaskEntity task);
        string GetStateName();
    }

}

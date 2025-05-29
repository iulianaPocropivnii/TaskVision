using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskVision.Services.Interfaces
{
    public interface IDatabaseService
    {
        List<ITask> GetAllTasks();
        void AddTask(ITask task);
        void RemoveTask(ITask task);
        void UpdateTask(ITask task);
    }

}

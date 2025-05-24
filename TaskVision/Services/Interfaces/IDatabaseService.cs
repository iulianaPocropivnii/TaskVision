using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskVision.Services.Interfaces
{
    public interface IDatabaseService
    {
        void AddDbTask(ITask task);
        void RemoveDbTask(ITask task);
        void UpdateDbTask(ITask updatedTask);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Models.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.FactoryMethod
{
    public abstract class Creator
    {
        public abstract ITask FactoryMethod();

        public void UpdateTask(ITask task)
        {
            task.UpdateTask();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Strategy
{
    public class SortByDeadline : ISortingStrategy
    {
        public IEnumerable<ITask> Sort(IEnumerable<ITask> tasks)
        {
            return tasks.OrderBy(t => t.Deadline);
        }
    }
}

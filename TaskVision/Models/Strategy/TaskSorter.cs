using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Strategy
{
    public class TaskSorter
    {
        private ISortingStrategy _strategy;

        public void SetStrategy(ISortingStrategy strategy)
        {
            _strategy = strategy;
        }

        public IEnumerable<ITask> ExecuteSort(IEnumerable<ITask> tasks)
        {
            if (_strategy == null)
                throw new InvalidOperationException("Strategy not set.");
            return _strategy.Sort(tasks);
        }
    }
}

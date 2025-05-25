using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskVision.Services.Interfaces
{
    public interface ISortingStrategy
    {
        IEnumerable<ITask> Sort(IEnumerable<ITask> tasks);
    }
}

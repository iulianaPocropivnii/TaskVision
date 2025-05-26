using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskVision.Models.Memento
{
    public class TaskHistory
    {
        private Stack<TaskMemento> _history = new();

        public void Save(TaskMemento memento)
        {
            _history.Push(memento);
        }

        public TaskMemento Undo()
        {
            if (_history.Count > 0)
                return _history.Pop();

            return null;
        }
    }

}

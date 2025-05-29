using TaskVision.Enum;
using TaskVision.Models.Tasks;
using TaskVision.Services.Interfaces;
using TaskVision.Models.State;

namespace TaskVision.Models.Memento
{
    public class TaskMemento
    {
        public string Title { get; }
        public string Description { get; }
        public DateTime Start { get; }
        public DateTime End { get; }
        public TaskPriority Priority { get; }
        public string Color { get; }
        public ITaskState State { get; }

        public TaskMemento(ITask task)
        {
            Title = task.Title;
            Description = task.Description;
            Start = task.Start;
            End = task.End;
            Priority = task.Priority;
            Color = task.Color;
            State = task.State;
        }

        public void Restore(ITask task)
        {
            task.Title = Title;
            task.Description = Description;
            task.Start = Start;
            task.End = End;
            task.Priority = Priority;
            task.Color = Color;
            task.State = State;
        }
    }
}

using TaskVision.Enum;
using TaskVision.Models.FactoryMethod.TaskCreator;
using TaskVision.Models.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Tasks
{
    public class Builder
    {
        private string _title;
        private string _description;
        private DateTime? _deadline;
        private DateTime? _start;
        private DateTime? _end;
        private IDatabaseService _db;

        /// <summary>
        /// Injectează serviciul de baze de date.
        /// </summary>
        public Builder(IDatabaseService db)
        {
            _db = db;
        }

        public Builder WithTitle(string title) { _title = title; return this; }
        public Builder WithDescription(string desc) { _description = desc; return this; }
        public Builder WithDeadline(DateTime? dl) { _deadline = dl; return this; }
        public Builder WithStart(DateTime start) { _start = start; return this; }
        public Builder WithEnd(DateTime end) { _end = end; return this; }
        private TaskPriority _priority = TaskPriority.Medium;
        private string _color = "#a29bfe";

        public Builder WithPriority(TaskPriority priority)
        {
            _priority = priority;
            return this;
        }

        public Builder WithColor(string color)
        {
            _color = color;
            return this;
        }

        /// <summary>
        /// Construiește ITask-ul final.
        /// Utilizează Factory Method pentru a crea instanța corectă.
        /// </summary>
        public ITask Build()
        {
            if (_deadline.HasValue)
            {
                var dt = new DeadlineTask(_db)
                {
                    Title = _title,
                    Description = _description,
                    Deadline = _deadline.Value,
                    Start = _deadline.Value,
                    End = _deadline.Value,
                    Priority = _priority,
                    Color = _color
                };
                return dt;
            }

            var task = new SimpleTask
            {
                Title = _title,
                Description = _description,
                Priority = _priority,
                Color = _color
            };

            if (_start.HasValue && _end.HasValue)
            {
                task.Start = _start.Value;
                task.End = _end.Value;
            }

            return task;
        }

    }
}
using TaskVision.Models.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Tasks.Builder
{
    public class TaskBuilder
    {
        private string _title;
        private string _description;
        private DateTime? _deadline;
        private IDatabaseService _dbService;

        public TaskBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        public TaskBuilder WithDescription(string description)
        {
            _description = description;
            return this;
        }

        public TaskBuilder WithDeadline(DateTime deadline)
        {
            _deadline = deadline;
            return this;
        }

        public TaskBuilder WithDatabaseService(IDatabaseService dbService)
        {
            _dbService = dbService;
            return this;
        }

        public ITask Build()
        {
            if (_deadline.HasValue)
                return new DeadlineTask(_dbService) { Title = _title, Description = _description, Deadline = _deadline.Value };
            else
                return new SimpleTask(_dbService) { Title = _title, Description = _description };
        }
    }
}
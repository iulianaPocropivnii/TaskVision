using TaskVision.Services.Interfaces;
using TaskVision.Models.Tasks;
using TaskVision.Enum;

namespace TaskVision.Models.FactoryMethod.TaskCreator
{
    public class DeadlineTaskCreator : Creator
    {
        private readonly IDatabaseService _databaseService;

        public DeadlineTaskCreator(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public override ITask FactoryMethod()
        {
            return new Builder(_databaseService)
                .WithTitle("Task cu deadline")
                .WithDescription("Are termen limită")
                .WithDeadline(DateTime.Today.AddDays(3))
                .WithColor("#ff7675")
                .WithPriority(TaskPriority.High)
                .Build();
        }
    }
}

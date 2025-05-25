using TaskVision.Services.Interfaces;
using TaskVision.Models.Tasks;

namespace TaskVision.Models.FactoryMethod.TaskCreator
{
    public class RecurringTaskCreator : Creator
    {
        private readonly IDatabaseService _databaseService;

        public RecurringTaskCreator(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public override ITask FactoryMethod()
        {
            return new RecurringTask(_databaseService);
        }
    }
}

using TaskVision.Services.Interfaces;
using TaskVision.Models.Tasks;

namespace TaskVision.Models.FactoryMethod.TaskCreator
{
    public class SimpleTaskCreator : Creator
    {
        private readonly IDatabaseService _databaseService;

        public SimpleTaskCreator(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public override ITask FactoryMethod()
        {
            return new SimpleTask(_databaseService);
        }
    }
}

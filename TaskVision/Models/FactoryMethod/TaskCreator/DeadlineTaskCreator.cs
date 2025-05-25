using TaskVision.Services.Interfaces;
using TaskVision.Models.Tasks;

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
            return new DeadlineTask(_databaseService);
        }
    }
}

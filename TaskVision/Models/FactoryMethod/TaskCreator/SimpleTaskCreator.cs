using TaskVision.Services.Interfaces;
using TaskVision.Models.Tasks;
using TaskVision.Models.Tasks.Builder;

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
            return new TaskBuilder()
                .WithTitle("Titlu Default")
                .WithDescription("Descriere simplă")
                .WithDatabaseService(_databaseService)
                .Build();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Command
{
    public class UpdateTaskCommand : ICommand
    {
        private readonly ITask _task;
        private readonly IDatabaseService _database;
        private readonly ITask _backup;

        public UpdateTaskCommand(ITask task, IDatabaseService database)
        {
            _task = task;
            _database = database;
            _backup = task.Clone(); 
        }

        public void Execute()
        {
            _task.UpdateTask();
        }

        public void Undo()
        {
            _database.UpdateDbTask(_backup);
        }
    }

}

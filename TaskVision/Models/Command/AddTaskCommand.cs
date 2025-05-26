using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskVision.Services.Interfaces;

namespace TaskVision.Models.Command
{
    public class AddTaskCommand : ICommand
    {
        private readonly ITask _task;
        private readonly IDatabaseService _database;

        public AddTaskCommand(ITask task, IDatabaseService database)
        {
            _task = task;
            _database = database;
        }

        public void Execute()
        {
            _database.AddDbTask(_task);
        }

        public void Undo()
        {
            _database.RemoveDbTask(_task);
        }
    }
}
